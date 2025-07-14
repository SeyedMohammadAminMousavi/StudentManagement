namespace StudentManagement.WinFormsClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewStudents = new DataGridView();
            txtFullName = new TextBox();
            txtNationalCode = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnLoadStudents = new Button();
            btnSave = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            dtpBirthDate = new DateTimePicker();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewStudents
            // 
            dataGridViewStudents.AccessibleName = "dataGridViewStudents";
            dataGridViewStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStudents.GridColor = SystemColors.Desktop;
            dataGridViewStudents.Location = new Point(253, 226);
            dataGridViewStudents.Name = "dataGridViewStudents";
            dataGridViewStudents.Size = new Size(535, 212);
            dataGridViewStudents.TabIndex = 0;
            dataGridViewStudents.CellClick += dataGridViewStudents_CellClick;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(426, 65);
            txtFullName.Multiline = true;
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(100, 29);
            txtFullName.TabIndex = 1;
            // 
            // txtNationalCode
            // 
            txtNationalCode.Location = new Point(677, 65);
            txtNationalCode.Multiline = true;
            txtNationalCode.Name = "txtNationalCode";
            txtNationalCode.Size = new Size(100, 29);
            txtNationalCode.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(320, 69);
            label1.Name = "label1";
            label1.Size = new Size(84, 21);
            label1.TabIndex = 4;
            label1.Text = "Full Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(559, 69);
            label2.Name = "label2";
            label2.Size = new Size(112, 21);
            label2.TabIndex = 5;
            label2.Text = "National Code:";
            // 
            // btnLoadStudents
            // 
            btnLoadStudents.Location = new Point(22, 48);
            btnLoadStudents.Name = "btnLoadStudents";
            btnLoadStudents.Size = new Size(207, 61);
            btnLoadStudents.TabIndex = 6;
            btnLoadStudents.Text = "load all students";
            btnLoadStudents.UseVisualStyleBackColor = true;
            btnLoadStudents.Click += btnLoadStudents_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(22, 139);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(207, 61);
            btnSave.TabIndex = 7;
            btnSave.Text = "add new or update existing student";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(22, 226);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(207, 61);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "delete selected student";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(22, 314);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(207, 61);
            btnClear.TabIndex = 9;
            btnClear.Text = "clear input fields";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Location = new Point(426, 141);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(301, 29);
            dtpBirthDate.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(336, 145);
            label3.Name = "label3";
            label3.Size = new Size(82, 21);
            label3.TabIndex = 11;
            label3.Text = "Birth Date:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(dtpBirthDate);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnSave);
            Controls.Add(btnLoadStudents);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtNationalCode);
            Controls.Add(txtFullName);
            Controls.Add(dataGridViewStudents);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewStudents;
        private TextBox txtFullName;
        private TextBox txtNationalCode;
        private Label label1;
        private Label label2;
        private Button btnLoadStudents;
        private Button btnSave;
        private Button btnDelete;
        private Button btnClear;
        private DateTimePicker dtpBirthDate;
        private Label label3;
    }
}
