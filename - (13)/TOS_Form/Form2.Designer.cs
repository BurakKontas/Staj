namespace TOS_Form
{
    partial class Form2
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
            this.DataForm_BackButton = new System.Windows.Forms.Button();
            this.DataForm_SaveButton = new System.Windows.Forms.Button();
            this.DataForm_ShowButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DataForm_BackButton
            // 
            this.DataForm_BackButton.Location = new System.Drawing.Point(12, 418);
            this.DataForm_BackButton.Name = "DataForm_BackButton";
            this.DataForm_BackButton.Size = new System.Drawing.Size(75, 20);
            this.DataForm_BackButton.TabIndex = 0;
            this.DataForm_BackButton.Text = "Back";
            this.DataForm_BackButton.UseVisualStyleBackColor = true;
            this.DataForm_BackButton.Click += new System.EventHandler(this.DataForm_BackButton_Click);
            // 
            // DataForm_SaveButton
            // 
            this.DataForm_SaveButton.Location = new System.Drawing.Point(368, 418);
            this.DataForm_SaveButton.Name = "DataForm_SaveButton";
            this.DataForm_SaveButton.Size = new System.Drawing.Size(75, 20);
            this.DataForm_SaveButton.TabIndex = 1;
            this.DataForm_SaveButton.Text = "Save";
            this.DataForm_SaveButton.UseVisualStyleBackColor = true;
            this.DataForm_SaveButton.Click += new System.EventHandler(this.DataForm_Save_Button_Click);
            // 
            // DataForm_ShowButton
            // 
            this.DataForm_ShowButton.Location = new System.Drawing.Point(713, 418);
            this.DataForm_ShowButton.Name = "DataForm_ShowButton";
            this.DataForm_ShowButton.Size = new System.Drawing.Size(75, 20);
            this.DataForm_ShowButton.TabIndex = 2;
            this.DataForm_ShowButton.Text = "Show File";
            this.DataForm_ShowButton.UseVisualStyleBackColor = true;
            this.DataForm_ShowButton.Click += new System.EventHandler(this.DataForm_ShowButton_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DataForm_ShowButton);
            this.Controls.Add(this.DataForm_SaveButton);
            this.Controls.Add(this.DataForm_BackButton);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DataForm_BackButton;
        private System.Windows.Forms.Button DataForm_SaveButton;
        private System.Windows.Forms.Button DataForm_ShowButton;
    }
}