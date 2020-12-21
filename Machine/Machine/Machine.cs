using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Machine
{
    public partial class Machine : Form
    {

        private string m_WorkerNumber;
        private string m_ProjectName;
        private DataTable m_dataTable;
        private DataTable m_dataTable2;
        private OleDbConnection m_Connection;
        private OleDbConnection m_Connection2;
        private OleDbDataAdapter m_DataAdapter;
        public Machine(string WorkerNumber, string ProjectName)
        {
            InitializeComponent();
            //Setting up all default settings
            m_WorkerNumber = WorkerNumber;
            m_ProjectName = ProjectName;
            WorkerNumLabel.Text = WorkerNumber;
            ProjectNameLabel.Text = ProjectName;
            ItemsBox.Text = "-Select-";
            OpeningBox.Text = "-Select-";
            OpeningBox.Items.AddRange(new object[] { "מלאה", "חצי", "שליש" });

            try
            {
                m_Connection = new OleDbConnection();
                m_Connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Sagi\Documents\Db\MachineDB.accdb;Persist Security Info=False;";
                m_Connection.Open();
                m_DataAdapter = new OleDbDataAdapter("SELECT * FROM ItemsTable", m_Connection);
                m_dataTable = new DataTable();
                m_DataAdapter.Fill(m_dataTable);
                //Fill up the items box
                for (int i = 0; i < m_dataTable.Rows.Count; i++)
                {
                    ItemsBox.Items.Add(m_dataTable.Rows[i]["שם פריט"]);
                }
                m_Connection.Close();

                //Open up database

                m_Connection2 = new OleDbConnection();
                m_Connection2.ConnectionString =@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Sagi\Documents\Db\MachineDB.accdb;Persist Security Info=False;";
                m_Connection2.Open();
                //Query from database                
                m_DataAdapter = new OleDbDataAdapter("SELECT * FROM OrdersTable", m_Connection2);
                m_dataTable2 = new DataTable();
                m_DataAdapter.Fill(m_dataTable2);
                //close database
                m_Connection2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().ToString(), "Error In Connection");
            }
        }

        private void ItemsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Query to database about the item's makat
            m_Connection.Open();
            m_DataAdapter = new OleDbDataAdapter("SELECT * FROM ItemsTable where [שם פריט] ='" + ItemsBox.Text + "'", m_Connection);
            DataTable dataTable = new DataTable();
            m_DataAdapter.Fill(dataTable);
            MakatLabel.Text = dataTable.Rows[0]["מקט"].ToString();
            m_Connection.Close();
        }
        private void RefreshDT2()
        {
            //ממלא בטבלת של המערכת סי את טבלת המוצרים
            m_Connection2.Open();
            m_DataAdapter = new OleDbDataAdapter("SELECT * FROM OrdersTable", m_Connection2);
            m_dataTable2 = new DataTable();
            m_DataAdapter.Fill(m_dataTable2);
            m_Connection2.Close();
        }

        private void AmountBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //User can only input numbers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Check if the user entered all the information
            if (ItemsBox.Text == "-Select-" || OpeningBox.Text == "-Select-" || AmountBox.Text == "")
            {
                MessageBox.Show("אנא למלא את כל המידע המבוקש!");
            }
            else
            {
                try
                {
                    //Check if he is eligible to order and didnt go over the max items can be bought
                    var rows = m_dataTable.Select().Where(p => (p["מקט"]).ToString() == MakatLabel.Text);
                    DataTable temp = rows.CopyToDataTable();
                    int MaxPerItem = Int32.Parse(temp.Rows[0]["כמות להזמנה"].ToString());//gets the max for the items

                    DataTable tempTable = null;
                    int OrderedAlready = 0;
                    var rows2 = m_dataTable2.Select().Where(p => (p["מקט"]).ToString() == MakatLabel.Text.ToString() && (p["מספר כרטיס"]).ToString() == m_WorkerNumber.ToString());
                    if (rows2.Any())
                    {
                        tempTable = rows2.CopyToDataTable();
                    }
                    if (tempTable != null)
                        for (int j = 0; j < tempTable.Rows.Count; j++)
                        {
                            int tempAmount = Int32.Parse(tempTable.Rows[j]["כמות"].ToString());
                            OrderedAlready += tempAmount;
                        }
                    int OrderingCurrently = Int32.Parse(AmountBox.Text);
                    if (MaxPerItem >= (OrderedAlready + OrderingCurrently))
                    { //Order is starting
                        //Build command to enter a new row to database
                        string sql = "insert into OrdersTable([מספר כרטיס], [כמות], [מקט] ,[פרוייקט], [סוג פתיחה]) values (?, ?, ?, ?, ?)";
                        using (OleDbCommand command = new OleDbCommand(sql, m_Connection2))
                        {
                            m_Connection2.Open();
                            command.Parameters.AddWithValue("מספר כרטיס", WorkerNumLabel.Text);
                            command.Parameters.AddWithValue("כמות", AmountBox.Text);
                            command.Parameters.AddWithValue("מקט", MakatLabel.Text);
                            command.Parameters.AddWithValue("פרוייקט", ProjectNameLabel.Text);
                            command.Parameters.AddWithValue("סוג פתיחה", OpeningBox.Text);
                            //Execute the command to database
                            command.ExecuteNonQuery();
                        }

                        m_Connection2.Close();
                        MessageBox.Show("ההזמנה בוצעה בהצלחה!");
                        RefreshDT2();
                    }
                    else
                    {//worker ordered too much of this item
                        MessageBox.Show("שים לב לחריגה במוצר:(" + OrderedAlready +"/" +MaxPerItem +")" );
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.GetBaseException().ToString(), "Error In Connection");
                }

            }
        }
    }
}
