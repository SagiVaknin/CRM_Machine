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
using Excel = Microsoft.Office.Interop.Excel;

namespace AdminMachine
{
    public partial class AMachine : Form
    {

        //active
        private OleDbConnection m_Connection;
        private OleDbDataAdapter m_DataAdapter;
        private DataTable m_ProjectsDTable = null;
        private DataTable m_OrdersDTable = null;
        private DataTable m_ItemsDTable = null;
        private DataTable m_WorkersDTable = null;
        private Bitmap m_Image;
        public AMachine()
        {
            InitializeComponent();
            //Setup default
            //add to comboboxes all the subjects
            ItemsBox.Items.AddRange(new object[] { "מק''טים" });
            DohComboBox.Items.AddRange(new object[] { "דוח עלויות לפי פרוייקט" ,"דוח פריטים","צריכת עובדים","המוצר הנצרך ביותר","עלות לפי עובד","עלות לפי מוצר"});
            m_Connection = new OleDbConnection();
            m_Image = new Bitmap(@"C:\Users\Sagi\Documents\Db\delete.png");
            DataGridShower.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            DataGridShower.EnableHeadersVisualStyles = false;
            m_Connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Sagi\Documents\Db\MachineDB.accdb;Persist Security Info=False;";

        }


        private void ItemsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //מופיע בשורה האדומה 
            string CurrentChoise = ItemsBox.Text;
            CurrentData.Text = CurrentChoise;
            //Label stays the same
            this.BeginInvoke((MethodInvoker)delegate { this.ItemsBox.Text = "מוצרים"; });
        }

        private void RefreshWorkersDT()
        {
            //ממלא בטבלת של המערכת סי את טבלת העובדים
            m_Connection.Open();
            m_DataAdapter = new OleDbDataAdapter("SELECT * FROM EmployeesTable", m_Connection);
            m_WorkersDTable = new DataTable();
            m_DataAdapter.Fill(m_WorkersDTable);
            m_Connection.Close();
        }
        private void RefreshProjectDT()
        {
            //ממלא בטבלת של המערכת סי את טבלת הפרוייקטים
            m_Connection.Open();
            m_DataAdapter = new OleDbDataAdapter("SELECT * FROM ProjectTable", m_Connection);
            m_ProjectsDTable = new DataTable();
            m_DataAdapter.Fill(m_ProjectsDTable);
            m_Connection.Close();
        }
        private void RefreshOrdersDT()
        {
            //ממלא בטבלת של המערכת סי את טבלת ההזמנות
            m_Connection.Open();
            m_DataAdapter = new OleDbDataAdapter("SELECT * FROM OrdersTable", m_Connection);
            m_OrdersDTable = new DataTable();
            m_DataAdapter.Fill(m_OrdersDTable);
            m_Connection.Close();
        }
        private void RefreshItemsDT()
        {
            //ממלא בטבלת של המערכת סי את טבלת המוצרים
            m_Connection.Open();
            m_DataAdapter = new OleDbDataAdapter("SELECT * FROM ItemsTable", m_Connection);
            m_ItemsDTable = new DataTable();
            m_DataAdapter.Fill(m_ItemsDTable);
            m_Connection.Close();
        }
        private void ShowMakatList()
        {

            try
            {
                //מנקה את הטבלה המציגה
                DataGridShower.Columns.Clear();
                //אם הטבלה לא קיימת תיצור
                if (m_ItemsDTable == null) RefreshItemsDT();
                //קישור הטבלה המציגה לטבלת הנתונים
                DataGridShower.DataSource = m_ItemsDTable;
                //ליצור עמודה בעלת תמונה למחיקה
                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                {
                    imageColumn.Name = "colImages";
                    imageColumn.HeaderText = "X";
                    imageColumn.Width = 20;
                    imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                    imageColumn.CellTemplate = new DataGridViewImageCell(false);
                    imageColumn.DefaultCellStyle.NullValue = null;
                }

                DataGridShower.Columns.Insert(5, imageColumn) ; //הכנס את עמודת המחיקה לעמודה מספר 5

                for (int i = 0; i < DataGridShower.RowCount; i++)
                {
                    DataGridShower[5,i].Value = m_Image; //הכנס עבור כל תא של עמודת המחיקה את התמונה
                                                          
                }
                StyleDataGrid();
                DataGridShower.Refresh();//רענן את הטבלה המציגה
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().ToString(), "Error In Connection");
            }
        }


        private void ItemsBox_DropDownClosed(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() => { ItemsBox.Select(0, 0); }));
        }

        private void CurrentData_TextChanged(object sender, EventArgs e)
        {
            AddMakat.Visible = false;
            if(CurrentData.Text == "מק''טים")
            {
                AddMakat.Visible = true;
                ShowMakatList();
            }
            if(CurrentData.Text == "דוח עלויות לפי פרוייקט")
            {
                ShowReport1();
            }
            if (CurrentData.Text == "דוח פריטים")
            {
                ShowReport2();
            }
            if (CurrentData.Text == "צריכת עובדים")
            {
                ShowReport3();
            }
            if (CurrentData.Text == "המוצר הנצרך ביותר")
            {
                ShowReport4();
            }
            if (CurrentData.Text == "עלות לפי עובד")
            {
                ShowReport5();
            }
            if (CurrentData.Text == "עלות לפי מוצר")
            {
                ShowReport6();
            }
        }

        private void ShowReport6()
        {
            DataGridShower.Columns.Clear();
            if (m_ProjectsDTable == null) RefreshProjectDT();
            if (m_OrdersDTable == null) RefreshOrdersDT();
            if (m_ItemsDTable == null) RefreshItemsDT();
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("שם פריט");
            dt.Columns.Add("מק''ט");
            for (int j = 0; j < m_ProjectsDTable.Rows.Count; j++)
            {
                dt.Columns.Add(m_ProjectsDTable.Rows[j]["רשימת פרוייקטים"].ToString());
            }
            dt.Columns.Add("סה''כ");
            for (int i = 0; i < m_ItemsDTable.Rows.Count; i++)
            { 
                int sum = 0;
                               
                var itemName = m_ItemsDTable.Rows[i]["שם פריט"];
                var makat = m_ItemsDTable.Rows[i]["מקט"];
                int price = Int32.Parse(m_ItemsDTable.Rows[i]["מחיר"].ToString());
                DataRow dr = dt.NewRow();
                dr["שם פריט"] = itemName.ToString();
                dr["מק''ט"] = makat.ToString();

                for (int j = 0; j < m_ProjectsDTable.Rows.Count; j++)
                    {
                        DataTable tempTable = null;
                        int ProjectSum = 0;
                        var projectName = m_ProjectsDTable.Rows[j]["רשימת פרוייקטים"];
                        var rows = m_OrdersDTable.Select().Where(p => (p["מקט"]).ToString() == makat.ToString() && (p["פרוייקט"]).ToString() == projectName.ToString());
                        if (rows.Any())
                        {
                            tempTable = rows.CopyToDataTable();
                        }
                        if (tempTable != null) 
                            for (int k =0;k< tempTable.Rows.Count;k++)
                            {
                                int tempAmount = 0;
                                try
                                {
                                    tempAmount = Int32.Parse(tempTable.Rows[k]["כמות"].ToString());
                                }
                                catch (Exception e)
                                {
                                    continue;
                                }
                                ProjectSum += tempAmount * price;
                            }
                        dr[projectName.ToString()] = ProjectSum;
                        sum += ProjectSum;
                    }
                dr["סה''כ"] = sum;
                dt.Rows.Add(dr); 

            }
            DataGridShower.DataSource = dt;
            StyleDataGrid();
            DataGridShower.Refresh();
        }

        private void ShowReport5()
        {
            DataGridShower.Columns.Clear();
            if (m_ProjectsDTable == null) RefreshProjectDT();
            if (m_OrdersDTable == null) RefreshOrdersDT();
            if (m_WorkersDTable == null) RefreshWorkersDT();
            if (m_ItemsDTable == null) RefreshItemsDT();
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("מספר כרטיס");
            dt.Columns.Add("שם פרטי");
            dt.Columns.Add("שם משפחה");
            for (int j = 0; j < m_ProjectsDTable.Rows.Count; j++)
            {
                dt.Columns.Add(m_ProjectsDTable.Rows[j]["רשימת פרוייקטים"].ToString());
            }
            dt.Columns.Add("סה''כ");
            for (int i = 0; i < m_WorkersDTable.Rows.Count; i++)
            {
                int sum = 0;

                var CardNumber = m_WorkersDTable.Rows[i]["מספר כרטיס"];
                var WorkerPName = m_WorkersDTable.Rows[i]["שם פרטי"];
                var WorkerLName = m_WorkersDTable.Rows[i]["שם משפחה"];
                DataRow dr = dt.NewRow();
                dr["מספר כרטיס"] = CardNumber.ToString();
                dr["שם פרטי"] = WorkerPName.ToString();
                dr["שם משפחה"] = WorkerLName.ToString();

                for (int j = 0; j < m_ProjectsDTable.Rows.Count; j++)
                {
                    DataTable tempTable = null;
                    int ProjectSum = 0;
                    var projectName = m_ProjectsDTable.Rows[j]["רשימת פרוייקטים"];
                    var rows = m_OrdersDTable.Select().Where(p => (p["פרוייקט"]).ToString() == projectName.ToString() && (p["מספר כרטיס"]).ToString() == CardNumber.ToString());
                    if (rows.Any())
                    {
                        tempTable = rows.CopyToDataTable();
                    }
                    if (tempTable != null)
                        for (int k = 0; k < tempTable.Rows.Count; k++)
                        {
                            var ItemRow = m_ItemsDTable.Select().Where(p => (p["מקט"]).ToString() == tempTable.Rows[k]["מקט"].ToString());
                            if (ItemRow.Any())
                            {
                                DataTable tempPriceTable = ItemRow.CopyToDataTable();
                                int price = 0;
                                int tempAmount = 0;
                                try
                                {
                                    tempAmount = Int32.Parse(tempTable.Rows[k]["כמות"].ToString());
                                    price = Int32.Parse(tempPriceTable.Rows[0]["מחיר"].ToString());
                                }
                                catch (Exception e)
                                {
                                    continue;
                                }
                                ProjectSum += tempAmount * price;
                            }
                        }
                    dr[projectName.ToString()] = ProjectSum;
                    sum += ProjectSum;
                }
                dr["סה''כ"] = sum;
                dt.Rows.Add(dr);

            }
            DataGridShower.DataSource = dt;
            StyleDataGrid();
            DataGridShower.Refresh();
            
        }

        private void ShowReport4()
        {
            DataGridShower.Columns.Clear();
       //     if (m_MakatDTable == null) RefreshProjectDT();
            if (m_OrdersDTable == null) RefreshOrdersDT();
            if (m_ItemsDTable == null) RefreshItemsDT();
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("שם מוצר");
            dt.Columns.Add("כמות");
            dt.Columns.Add("עלות");
            for (int i = 0; i < m_ItemsDTable.Rows.Count; i++)
            {
                try
                {
                    int sum = 0;
                    int amount = 0;
                    DataTable tempTable = null;

                    var itemName = m_ItemsDTable.Rows[i]["שם פריט"];
                    var makat = m_ItemsDTable.Rows[i]["מקט"];
                    var c = m_ItemsDTable.Rows[i]["מחיר"].ToString();
                    int price = Int32.Parse(m_ItemsDTable.Rows[i]["מחיר"].ToString());

                    var rows = m_OrdersDTable.Select().Where(p => (p["מקט"]).ToString() == makat.ToString());
                    if (rows.Any())
                    {
                        tempTable = rows.CopyToDataTable();
                    }
                    if (tempTable != null)
                        for (int j = 0; j < tempTable.Rows.Count; j++)
                        {
                            int tempAmount = Int32.Parse(tempTable.Rows[j]["כמות"].ToString());
                            amount += tempAmount;
                        }
                    sum = amount * price;
                    DataRow dr = dt.NewRow();
                    dr["שם מוצר"] = itemName.ToString();
                    dr["כמות"] = amount.ToString();
                    dr["עלות"] = sum.ToString();
                    dt.Rows.Add(dr);
                }
                catch (Exception e)
                {
                    continue;
                }
            }
            dt.DefaultView.Sort = "[כמות] DESC";
            dt = dt.DefaultView.ToTable();
            DataGridShower.DataSource = dt;
            StyleDataGrid();
            DataGridShower.Refresh();
        }
        private void ShowReport3()
        {
            DataGridShower.Columns.Clear();
            if (m_OrdersDTable == null) RefreshOrdersDT();
            if (m_ItemsDTable == null) RefreshItemsDT(); 
            if (m_WorkersDTable == null) RefreshWorkersDT();
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("מספר כרטיס");
            dt.Columns.Add("שם פרטי");
            dt.Columns.Add("שם משפחה");
            for (int j = 0; j < m_ItemsDTable.Rows.Count; j++)
            {
                dt.Columns.Add(m_ItemsDTable.Rows[j]["שם פריט"].ToString());
            }
            for (int i = 0; i < m_WorkersDTable.Rows.Count; i++)
            {
                

                
                var CardNumber = m_WorkersDTable.Rows[i]["מספר כרטיס"];
                var WorkerPName = m_WorkersDTable.Rows[i]["שם פרטי"];
                var WorkerLName = m_WorkersDTable.Rows[i]["שם משפחה"];
                DataRow dr = dt.NewRow();
                dr["מספר כרטיס"] = CardNumber.ToString();
                dr["שם פרטי"] = WorkerPName.ToString();
                dr["שם משפחה"] = WorkerLName.ToString();

                for (int j = 0; j < m_ItemsDTable.Rows.Count; j++)
                {
                    int amount = 0;
                    DataTable tempTable = null;
                    var itemName = m_ItemsDTable.Rows[j]["שם פריט"];
                    string c = itemName.ToString();
                    if (itemName.ToString() == "") continue;
                    var makat = m_ItemsDTable.Rows[j]["מקט"];
                    var rows = m_OrdersDTable.Select().Where(p => (p["מקט"]).ToString() == makat.ToString() && (p["מספר כרטיס"]).ToString() == CardNumber.ToString());
                    if (rows.Any())
                    {
                        tempTable = rows.CopyToDataTable();
                    }
                    if (tempTable != null)
                        for (int k = 0; k < tempTable.Rows.Count; k++)
                        {
                            int tempAmount = 0;
                            try
                            {
                                tempAmount = Int32.Parse(tempTable.Rows[k]["כמות"].ToString());
                            }
                            catch (Exception e)
                            {
                                amount += tempAmount;
                                continue;
                            }
                            amount += tempAmount;

                        }
                    dr[itemName.ToString()] = amount;
                 }
                dt.Rows.Add(dr);
            }               
            DataGridShower.DataSource = dt;
            StyleDataGrid();
            DataGridShower.Refresh();
        }
        private void ShowReport2()
        {
            DataGridShower.Columns.Clear();
            if (m_OrdersDTable == null) RefreshOrdersDT();
            if (m_ItemsDTable == null) RefreshItemsDT();
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("מק''ט");
            dt.Columns.Add("שם מוצר");
            dt.Columns.Add("מחיר");
            dt.Columns.Add("כמות");
            dt.Columns.Add("סה''כ");
            for (int i = 0; i < m_ItemsDTable.Rows.Count; i++)
            {
                try
                {
                    int sum = 0;
                    int amount = 0;
                    DataTable tempTable = null;
                
                    var itemName = m_ItemsDTable.Rows[i]["שם פריט"];
                    var makat = m_ItemsDTable.Rows[i]["מקט"];
                    var c = m_ItemsDTable.Rows[i]["מחיר"].ToString();
                    int price = Int32.Parse(m_ItemsDTable.Rows[i]["מחיר"].ToString());
                
                    var rows = m_OrdersDTable.Select().Where(p => (p["מקט"]).ToString() == makat.ToString());
                    if (rows.Any())
                    {
                        tempTable = rows.CopyToDataTable();
                    }
                    if(tempTable!=null)
                        for (int j = 0; j < tempTable.Rows.Count; j++)
                        {
                            int tempAmount = Int32.Parse(tempTable.Rows[j]["כמות"].ToString());
                            amount += tempAmount;
                        }
                    sum = amount * price;
                    DataRow dr = dt.NewRow();
                    dr["מק''ט"] = makat.ToString();
                    dr["שם מוצר"] = itemName.ToString();
                    dr["מחיר"] = price.ToString();
                    dr["כמות"] = amount.ToString();
                    dr["סה''כ"] = sum.ToString();
                    dt.Rows.Add(dr);
                }
                catch (Exception e)
                {
                    continue;
                }
            }
            DataGridShower.DataSource = dt;
            StyleDataGrid();
            DataGridShower.Refresh();
        }
        private void ShowReport1()
        {
            DataGridShower.Columns.Clear();
            if (m_ProjectsDTable == null) RefreshProjectDT();
            if (m_OrdersDTable == null) RefreshOrdersDT();
            if (m_ItemsDTable == null) RefreshItemsDT();
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("שם פרוייקט");
            dt.Columns.Add("סה''כ");
            for (int i = 0; i < m_ProjectsDTable.Rows.Count; i++)
            {
                int sum = 0;
                DataTable tempTable = null;
                var c = m_ProjectsDTable.Rows[i]["רשימת פרוייקטים"];
                var rows = m_OrdersDTable.Select().Where(p => (p["פרוייקט"]).ToString() == c.ToString());
                if (rows.Any())
                {
                    tempTable = rows.CopyToDataTable();
                }
                if (tempTable != null)
                    for (int j = 0; j < tempTable.Rows.Count; j++)
                    {
                        var makat = tempTable.Rows[j]["מקט"];
                        var row = m_ItemsDTable.Select().Where(p => (p["מקט"]).ToString() == makat.ToString());
                        int amount = Int32.Parse(tempTable.Rows[j]["כמות"].ToString());
                        int price = 0;
                        if (row.Any())
                        {
                            DataTable temp2Table = row.CopyToDataTable();
                            price = Int32.Parse(temp2Table.Rows[0]["מחיר"].ToString());
                            sum += price * amount;
                        }
                    }
                DataRow dr = dt.NewRow();
                dr["שם פרוייקט"] = c.ToString();
                dr["סה''כ"] = sum;
                dt.Rows.Add(dr);
            }
            DataGridShower.DataSource = dt;
            StyleDataGrid();
            DataGridShower.Refresh();
        }
        private void DataGridShower_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(CurrentData.Text == "מק''טים" && e.ColumnIndex == 5)
            {
                             // e.RowIndex

                          //    string cmd = "UPDATE FROM [Sheet1$] where [מקט] ='" + DataGridShower.Rows[e.RowIndex].Cells[0].Value.ToString() +"'" ;
                          //    string cmd = "UPDATE [Sheet1$] SET [מקט] = '" + DBNull.Value + "' WHERE [מקט] ='" + DataGridShower.Rows[e.RowIndex].Cells[0].Value.ToString() +"'" ;
                              try
                              {
                                  m_Connection.Open();
                                  OleDbDataAdapter deleteDataAdapter = new OleDbDataAdapter(" ", m_Connection);
                                  OleDbCommand d = new OleDbCommand(" DELETE FROM ItemsTable WHERE [מקט] = '" + DataGridShower.Rows[e.RowIndex].Cells[0].Value.ToString() +"'", m_Connection);
                                  m_DataAdapter.DeleteCommand = d;
                                  m_DataAdapter.DeleteCommand.ExecuteNonQuery();
                                  m_Connection.Close();
                                  RefreshItemsDT();
                                  ShowMakatList();
                              }
                              catch (Exception ex)
                              {
                                  MessageBox.Show(ex.GetBaseException().ToString(), "Error In Connection");
                              }

            }
        }



        private void AddMakat_Click(object sender, EventArgs e)
        {
            var form = new AddMakat();
            form.FormClosed += Form_FormClosed;
            if (Application.OpenForms[form.Name] == null)
            {
                form.Show();
            }
            else {
                Application.OpenForms[form.Name].Focus();
            }
        }
        /// <summary>
        /// User ended interaction with makat adder so refersh the data table and refersh the data grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefreshItemsDT();
            ShowMakatList();
        }

        private void DohComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string CurrentChoise = DohComboBox.Text;
            CurrentData.Text = CurrentChoise;
            this.BeginInvoke((MethodInvoker)delegate { this.DohComboBox.Text = "דוחות"; });
        }
        private void StyleDataGrid()
        {
            try
            {

                for (int i = 0; i < DataGridShower.Rows.Count; i++)
                {

                    if (IsOdd(i))
                    {

                            DataGridShower.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
        public static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }

    }
}
