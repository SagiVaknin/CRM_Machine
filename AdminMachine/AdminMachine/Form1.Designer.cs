namespace AdminMachine
{
    partial class AMachine
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DataGridShower = new System.Windows.Forms.DataGridView();
            this.ItemsBox = new System.Windows.Forms.ComboBox();
            this.CurrentData = new System.Windows.Forms.Label();
            this.AddMakat = new System.Windows.Forms.Button();
            this.DohComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridShower)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGridShower
            // 
            this.DataGridShower.AllowUserToAddRows = false;
            this.DataGridShower.AllowUserToDeleteRows = false;
            this.DataGridShower.AllowUserToResizeRows = false;
            this.DataGridShower.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DataGridShower.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridShower.GridColor = System.Drawing.SystemColors.ControlLight;
            this.DataGridShower.Location = new System.Drawing.Point(47, 105);
            this.DataGridShower.Name = "DataGridShower";
            this.DataGridShower.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DataGridShower.Size = new System.Drawing.Size(799, 464);
            this.DataGridShower.TabIndex = 0;
            this.DataGridShower.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridShower_CellClick);
            // 
            // ItemsBox
            // 
            this.ItemsBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ItemsBox.FormattingEnabled = true;
            this.ItemsBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ItemsBox.Location = new System.Drawing.Point(725, 38);
            this.ItemsBox.Name = "ItemsBox";
            this.ItemsBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ItemsBox.Size = new System.Drawing.Size(121, 21);
            this.ItemsBox.Sorted = true;
            this.ItemsBox.TabIndex = 1;
            this.ItemsBox.Text = "מוצרים";
            this.ItemsBox.SelectedIndexChanged += new System.EventHandler(this.ItemsBox_SelectedIndexChanged);
            this.ItemsBox.DropDownClosed += new System.EventHandler(this.ItemsBox_DropDownClosed);
            // 
            // CurrentData
            // 
            this.CurrentData.AutoSize = true;
            this.CurrentData.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentData.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CurrentData.Location = new System.Drawing.Point(600, 8);
            this.CurrentData.Name = "CurrentData";
            this.CurrentData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CurrentData.Size = new System.Drawing.Size(0, 25);
            this.CurrentData.TabIndex = 2;
            this.CurrentData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CurrentData.TextChanged += new System.EventHandler(this.CurrentData_TextChanged);
            // 
            // AddMakat
            // 
            this.AddMakat.BackColor = System.Drawing.SystemColors.GrayText;
            this.AddMakat.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.AddMakat.Location = new System.Drawing.Point(47, 589);
            this.AddMakat.Name = "AddMakat";
            this.AddMakat.Size = new System.Drawing.Size(129, 31);
            this.AddMakat.TabIndex = 3;
            this.AddMakat.Text = "הוסף מק\'\'ט";
            this.AddMakat.UseVisualStyleBackColor = false;
            this.AddMakat.Visible = false;
            this.AddMakat.Click += new System.EventHandler(this.AddMakat_Click);
            // 
            // DohComboBox
            // 
            this.DohComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DohComboBox.FormattingEnabled = true;
            this.DohComboBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DohComboBox.Location = new System.Drawing.Point(581, 38);
            this.DohComboBox.Name = "DohComboBox";
            this.DohComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DohComboBox.Size = new System.Drawing.Size(121, 21);
            this.DohComboBox.Sorted = true;
            this.DohComboBox.TabIndex = 4;
            this.DohComboBox.Text = "דוחות";
            this.DohComboBox.SelectedIndexChanged += new System.EventHandler(this.DohComboBox_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Red;
            this.groupBox1.Controls.Add(this.CurrentData);
            this.groupBox1.Location = new System.Drawing.Point(47, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(799, 36);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // AMachine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(891, 648);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DohComboBox);
            this.Controls.Add(this.AddMakat);
            this.Controls.Add(this.ItemsBox);
            this.Controls.Add(this.DataGridShower);
            this.Name = "AMachine";
            this.Text = "AMachine";
          //  this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AMachine_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridShower)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridShower;
        private System.Windows.Forms.ComboBox ItemsBox;
        private System.Windows.Forms.Label CurrentData;
        private System.Windows.Forms.Button AddMakat;
        private System.Windows.Forms.ComboBox DohComboBox;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

