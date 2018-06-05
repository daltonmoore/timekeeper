namespace WindowsFormsApplication1
{
    partial class MainForm
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
            this.createUserButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.clockInButton = new System.Windows.Forms.Button();
            this.clockOutButton = new System.Windows.Forms.Button();
            this.calculateHoursButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // createUserButton
            // 
            this.createUserButton.Location = new System.Drawing.Point(243, 12);
            this.createUserButton.Name = "createUserButton";
            this.createUserButton.Size = new System.Drawing.Size(104, 23);
            this.createUserButton.TabIndex = 2;
            this.createUserButton.Text = "Create User";
            this.createUserButton.UseVisualStyleBackColor = true;
            this.createUserButton.Click += new System.EventHandler(this.createUserButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "User Name";
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.userNameTextBox.Location = new System.Drawing.Point(78, 10);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(159, 20);
            this.userNameTextBox.TabIndex = 3;
            // 
            // clockInButton
            // 
            this.clockInButton.Location = new System.Drawing.Point(243, 41);
            this.clockInButton.Name = "clockInButton";
            this.clockInButton.Size = new System.Drawing.Size(104, 23);
            this.clockInButton.TabIndex = 5;
            this.clockInButton.Text = "Clock In";
            this.clockInButton.UseVisualStyleBackColor = true;
            this.clockInButton.Click += new System.EventHandler(this.clockInButton_Click);
            // 
            // clockOutButton
            // 
            this.clockOutButton.Location = new System.Drawing.Point(243, 70);
            this.clockOutButton.Name = "clockOutButton";
            this.clockOutButton.Size = new System.Drawing.Size(104, 23);
            this.clockOutButton.TabIndex = 6;
            this.clockOutButton.Text = "Clock Out";
            this.clockOutButton.UseVisualStyleBackColor = true;
            this.clockOutButton.Click += new System.EventHandler(this.clockOutButton_Click);
            // 
            // calculateHoursButton
            // 
            this.calculateHoursButton.Location = new System.Drawing.Point(243, 99);
            this.calculateHoursButton.Name = "calculateHoursButton";
            this.calculateHoursButton.Size = new System.Drawing.Size(104, 23);
            this.calculateHoursButton.TabIndex = 7;
            this.calculateHoursButton.Text = "Calculate Hours";
            this.calculateHoursButton.UseVisualStyleBackColor = true;
            this.calculateHoursButton.Click += new System.EventHandler(this.calculateHoursButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(723, 587);
            this.Controls.Add(this.calculateHoursButton);
            this.Controls.Add(this.clockOutButton);
            this.Controls.Add(this.clockInButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.userNameTextBox);
            this.Controls.Add(this.createUserButton);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createUserButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.Button clockInButton;
        private System.Windows.Forms.Button clockOutButton;
        private System.Windows.Forms.Button calculateHoursButton;
    }
}

