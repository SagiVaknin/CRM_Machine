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

namespace AdminMachine
{
    public partial class AddMakat : Form
    {
        private OleDbConnection m_Connection;
        public AddMakat()
        {
            InitializeComponent();
            m_Connection = new OleDbConnection();
            m_Connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Sagi\Documents\Db\MachineDB.accdb;Persist Security Info=False;";

        }

        private void AmountBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void MakatBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if(MakatBox.Text !="" && AmountBox.Text != "" && ItemNameBox.Text !="" && SapakBox.Text!="" && PriceBox.Text != "")
            {
                try
                {
                    string sql = "insert into ItemsTable([מקט], [שם פריט] ,[כמות להזמנה], [ספק],[מחיר]) values (?, ?, ?, ?,?)";                
                    using (OleDbCommand command = new OleDbCommand(sql, m_Connection))
                    {
                        m_Connection.Open();
                        command.Parameters.AddWithValue("מקט", MakatBox.Text);
                        command.Parameters.AddWithValue("שם פריט", ItemNameBox.Text);
                        command.Parameters.AddWithValue("כמות להזמנה", AmountBox.Text);
                        command.Parameters.AddWithValue("ספק", SapakBox.Text);
                        command.Parameters.AddWithValue("מחיר", AmountBox.Text);
                        command.ExecuteNonQuery();
                    }

                    m_Connection.Close();
                    this.Hide();
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.GetBaseException().ToString(), "Error In Connection");
                }

            }
        }

        private void PriceBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }
    }
}
