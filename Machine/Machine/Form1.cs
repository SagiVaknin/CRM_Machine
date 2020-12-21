using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Machine
{
    public partial class LoginWindow : Form
    {
        private OleDbConnection m_conn2;
        public LoginWindow()
        {
            InitializeComponent();

            try
                {
                    //connect to database
                    OleDbConnection conn = new OleDbConnection();
                    m_conn2 = new OleDbConnection();
                    conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Sagi\Documents\Db\MachineDB.accdb;Persist Security Info=False;";
                    conn.Open();
                    DataTable ds = new DataTable();
                    OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM ProjectTable", conn);
                    da.Fill(ds);
                    for (int i = 0; i < ds.Rows.Count; i++)
                    {
                        CompanyBox.Items.Add(ds.Rows[i]["רשימת פרוייקטים"]);
                    }
                    conn.Close();

                    //m_conn2.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Sagi\\Documents\\Db\\נתונים- שם עובד מספר ותפקיד.xlsx; Extended Properties=Excel 12.0 XML;";
                    m_conn2.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Sagi\Documents\Db\MachineDB.accdb;Persist Security Info=False;";

                    
                    m_conn2.Open();
                    //gets all data from the database                   
                    OleDbDataAdapter da2 = new OleDbDataAdapter("SELECT * FROM EmployeesTable", m_conn2);
                    DataTable ds2 = new DataTable();                  
                    da2.Fill(ds2);
                    //default settings
                    CompanyBox.Text = "-Select-";
                    WorkerBox.Text = "-Select-";
                    //Put all rows from the database into the selecting options                    
                    for (int i = 0; i < ds2.Rows.Count; i++)
                    {
                        WorkerBox.Items.Add(ds2.Rows[i]["מספר כרטיס"]);
                    }
                    //close connection to the database
                    m_conn2.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.GetBaseException().ToString(), "Error In Connection");
                }
            }

        private void button1_Click(object sender, EventArgs e)
        {
            //User needs to fill all fields
            if (CompanyBox.Text == "-Select-" || CompanyBox.Text == "-Select-" || PasswordBox.Text == "")
                MessageBox.Show("Please fill out all the information needed!");
            else
            {
                //Get user row from database
                m_conn2.Open();
                OleDbDataAdapter DataAdapter = new OleDbDataAdapter("SELECT * FROM EmployeesTable where [מספר כרטיס] =" + WorkerBox.Text  , m_conn2);
                DataTable dataTable = new DataTable();
                DataAdapter.Fill(dataTable);
                //in case of right password
                if (PasswordBox.Text == dataTable.Rows[0]["סיסמא"].ToString())
                {
                    this.Hide();
                    Machine newWindow = new Machine(WorkerBox.Text, CompanyBox.Text);
                    newWindow.Closed += (s, args) => this.Close();
                    newWindow.Show();
                }
                else
                {
                    MessageBox.Show("Wrong Password!");
                }
                //close connection to database
                m_conn2.Close();   
            }
        }

        private void PasswordBox_KeyPressEvent(object sender, KeyPressEventArgs e)
        {//User can only enter numbers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }
    }
}
