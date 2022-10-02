using System.Windows.Forms;

namespace TOS_FORM_2
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.SaveButton = new System.Windows.Forms.Button();
            this.EditModeButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.NewBankDesignButton = new System.Windows.Forms.Button();
            this.HomePageButton = new System.Windows.Forms.Button();
            this.NewBankCodeButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.EditOnOffLabel = new System.Windows.Forms.Label();
            this.NewBankDetailButton = new System.Windows.Forms.Button();
            this.NewRowButton = new System.Windows.Forms.Button();
            this.NewFileButton = new System.Windows.Forms.Button();
            this.TransferBankFileButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(713, 386);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "Kaydet";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // EditModeButton
            // 
            this.EditModeButton.Location = new System.Drawing.Point(713, 357);
            this.EditModeButton.Name = "EditModeButton";
            this.EditModeButton.Size = new System.Drawing.Size(75, 23);
            this.EditModeButton.TabIndex = 2;
            this.EditModeButton.Text = "Düzenleme";
            this.EditModeButton.UseVisualStyleBackColor = false;
            this.EditModeButton.Click += new System.EventHandler(this.EditModeButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(347, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(107, 21);
            this.comboBox1.Sorted = true;
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(363, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Test";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Size = new System.Drawing.Size(695, 357);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView1_Validating);
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRows);
            // 
            // NewBankDesignButton
            // 
            this.NewBankDesignButton.Location = new System.Drawing.Point(713, 81);
            this.NewBankDesignButton.Name = "NewBankDesignButton";
            this.NewBankDesignButton.Size = new System.Drawing.Size(75, 35);
            this.NewBankDesignButton.TabIndex = 6;
            this.NewBankDesignButton.Text = "Yeni Banka Deseni";
            this.NewBankDesignButton.UseVisualStyleBackColor = false;
            this.NewBankDesignButton.Click += new System.EventHandler(this.NewBankDesignButton_Click);
            // 
            // HomePageButton
            // 
            this.HomePageButton.Location = new System.Drawing.Point(713, 52);
            this.HomePageButton.Name = "HomePageButton";
            this.HomePageButton.Size = new System.Drawing.Size(75, 23);
            this.HomePageButton.TabIndex = 7;
            this.HomePageButton.Text = "Anasayfa";
            this.HomePageButton.UseVisualStyleBackColor = false;
            this.HomePageButton.Click += new System.EventHandler(this.HomePageButton_Click);
            // 
            // NewBankCodeButton
            // 
            this.NewBankCodeButton.Location = new System.Drawing.Point(713, 122);
            this.NewBankCodeButton.Name = "NewBankCodeButton";
            this.NewBankCodeButton.Size = new System.Drawing.Size(75, 37);
            this.NewBankCodeButton.TabIndex = 8;
            this.NewBankCodeButton.Text = "Yeni Banka Kodu";
            this.NewBankCodeButton.UseVisualStyleBackColor = false;
            this.NewBankCodeButton.Click += new System.EventHandler(this.NewBankCodeButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(683, 425);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Düzenleme ";
            // 
            // EditOnOffLabel
            // 
            this.EditOnOffLabel.AutoSize = true;
            this.EditOnOffLabel.Location = new System.Drawing.Point(740, 425);
            this.EditOnOffLabel.Name = "EditOnOffLabel";
            this.EditOnOffLabel.Size = new System.Drawing.Size(36, 13);
            this.EditOnOffLabel.TabIndex = 10;
            this.EditOnOffLabel.Text = "Kapalı";
            // 
            // NewBankDetailButton
            // 
            this.NewBankDetailButton.Location = new System.Drawing.Point(713, 165);
            this.NewBankDetailButton.Name = "NewBankDetailButton";
            this.NewBankDetailButton.Size = new System.Drawing.Size(75, 37);
            this.NewBankDetailButton.TabIndex = 11;
            this.NewBankDetailButton.Text = "Yeni Banka Detayı";
            this.NewBankDetailButton.UseVisualStyleBackColor = false;
            this.NewBankDetailButton.Click += new System.EventHandler(this.NewBankDetailButton_Click);
            // 
            // NewRowButton
            // 
            this.NewRowButton.Location = new System.Drawing.Point(713, 327);
            this.NewRowButton.Name = "NewRowButton";
            this.NewRowButton.Size = new System.Drawing.Size(75, 24);
            this.NewRowButton.TabIndex = 13;
            this.NewRowButton.Text = "Yeni Satır";
            this.NewRowButton.UseVisualStyleBackColor = false;
            this.NewRowButton.Click += new System.EventHandler(this.NewRowButton_Click);
            // 
            // NewFileButton
            // 
            this.NewFileButton.Location = new System.Drawing.Point(713, 208);
            this.NewFileButton.Name = "NewFileButton";
            this.NewFileButton.Size = new System.Drawing.Size(75, 37);
            this.NewFileButton.TabIndex = 14;
            this.NewFileButton.Text = "Yeni Dosya Oluştur";
            this.NewFileButton.UseVisualStyleBackColor = false;
            this.NewFileButton.Click += new System.EventHandler(this.NewFileButton_Click);
            // 
            // TransferBankFileButton
            // 
            this.TransferBankFileButton.Location = new System.Drawing.Point(713, 262);
            this.TransferBankFileButton.Name = "TransferBankFileButton";
            this.TransferBankFileButton.Size = new System.Drawing.Size(75, 48);
            this.TransferBankFileButton.TabIndex = 15;
            this.TransferBankFileButton.Text = "Banka Dosyası Aktar";
            this.TransferBankFileButton.UseVisualStyleBackColor = false;
            this.TransferBankFileButton.Click += new System.EventHandler(this.TransferBankFileButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TransferBankFileButton);
            this.Controls.Add(this.NewFileButton);
            this.Controls.Add(this.NewRowButton);
            this.Controls.Add(this.NewBankDetailButton);
            this.Controls.Add(this.EditOnOffLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NewBankCodeButton);
            this.Controls.Add(this.HomePageButton);
            this.Controls.Add(this.NewBankDesignButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.EditModeButton);
            this.Controls.Add(this.SaveButton);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button EditModeButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Button NewBankDesignButton;
        private Button HomePageButton;
        private Button NewBankCodeButton;
        private Label label2;
        private Label EditOnOffLabel;
        private Button NewBankDetailButton;
        private Button NewRowButton;
        private Button NewFileButton;
        private Button TransferBankFileButton;
    }
}