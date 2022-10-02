namespace TOS_Form
{
    partial class Form3
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
            this.Form3_TreeView = new System.Windows.Forms.TreeView();
            this.Form3_SelectButton = new System.Windows.Forms.Button();
            this.Form3_BankName = new System.Windows.Forms.Label();
            this.Form3_BackButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Form3_TreeView
            // 
            this.Form3_TreeView.Location = new System.Drawing.Point(12, 27);
            this.Form3_TreeView.Name = "Form3_TreeView";
            this.Form3_TreeView.Size = new System.Drawing.Size(776, 379);
            this.Form3_TreeView.TabIndex = 1;
            this.Form3_TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Form3_TreeView_AfterSelect);
            // 
            // Form3_SelectButton
            // 
            this.Form3_SelectButton.Location = new System.Drawing.Point(363, 415);
            this.Form3_SelectButton.Name = "Form3_SelectButton";
            this.Form3_SelectButton.Size = new System.Drawing.Size(75, 23);
            this.Form3_SelectButton.TabIndex = 2;
            this.Form3_SelectButton.Text = "Select";
            this.Form3_SelectButton.UseVisualStyleBackColor = true;
            this.Form3_SelectButton.Click += new System.EventHandler(this.Form3_SelectButton_Click);
            // 
            // Form3_BankName
            // 
            this.Form3_BankName.AutoSize = true;
            this.Form3_BankName.Location = new System.Drawing.Point(396, 9);
            this.Form3_BankName.Name = "Form3_BankName";
            this.Form3_BankName.Size = new System.Drawing.Size(0, 13);
            this.Form3_BankName.TabIndex = 3;
            // 
            // Form3_BackButton
            // 
            this.Form3_BackButton.Location = new System.Drawing.Point(12, 418);
            this.Form3_BackButton.Name = "Form3_BackButton";
            this.Form3_BackButton.Size = new System.Drawing.Size(75, 20);
            this.Form3_BackButton.TabIndex = 4;
            this.Form3_BackButton.Text = "Back";
            this.Form3_BackButton.UseVisualStyleBackColor = true;
            this.Form3_BackButton.Click += new System.EventHandler(this.Form3_BackButton_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Form3_BackButton);
            this.Controls.Add(this.Form3_BankName);
            this.Controls.Add(this.Form3_SelectButton);
            this.Controls.Add(this.Form3_TreeView);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TreeView Form3_TreeView;
        private System.Windows.Forms.Button Form3_SelectButton;
        private System.Windows.Forms.Label Form3_BankName;
        private System.Windows.Forms.Button Form3_BackButton;
    }
}