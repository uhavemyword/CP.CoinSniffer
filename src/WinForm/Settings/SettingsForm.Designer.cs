namespace CP.CoinSniffer.WinForm.Settings
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.TabControl = new System.Windows.Forms.TabControl();
            this.MainTabPage = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.KeyTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.IntervalNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ThreadCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.StartOnLaunchCheckBox = new System.Windows.Forms.CheckBox();
            this.LaunchOnLoginCheckBox = new System.Windows.Forms.CheckBox();
            this.DisplayTabPage = new System.Windows.Forms.TabPage();
            this.CapacityForNonExistNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.OnlyShowExistingCheckBox = new System.Windows.Forms.CheckBox();
            this.WindowTabPage = new System.Windows.Forms.TabPage();
            this.MinimizeOnCloseCheckBox = new System.Windows.Forms.CheckBox();
            this.MinimizeToTrayCheckBox = new System.Windows.Forms.CheckBox();
            this.NotificationTabPage = new System.Windows.Forms.TabPage();
            this.MailEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.MailGroupBox = new System.Windows.Forms.GroupBox();
            this.MailTestButton = new System.Windows.Forms.Button();
            this.MailBodyTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.MailToTextBox = new System.Windows.Forms.TextBox();
            this.MailSubjectTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.MailUsernameTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.MailPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.MailServerTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.MailPortTextBox = new System.Windows.Forms.TextBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.TabControl.SuspendLayout();
            this.MainTabPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IntervalNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThreadCountNumericUpDown)).BeginInit();
            this.DisplayTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CapacityForNonExistNumericUpDown)).BeginInit();
            this.WindowTabPage.SuspendLayout();
            this.NotificationTabPage.SuspendLayout();
            this.MailGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl.Controls.Add(this.MainTabPage);
            this.TabControl.Controls.Add(this.DisplayTabPage);
            this.TabControl.Controls.Add(this.WindowTabPage);
            this.TabControl.Controls.Add(this.NotificationTabPage);
            this.TabControl.Location = new System.Drawing.Point(12, 12);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(588, 312);
            this.TabControl.TabIndex = 0;
            // 
            // MainTabPage
            // 
            this.MainTabPage.Controls.Add(this.groupBox1);
            this.MainTabPage.Controls.Add(this.StartOnLaunchCheckBox);
            this.MainTabPage.Controls.Add(this.LaunchOnLoginCheckBox);
            this.MainTabPage.Location = new System.Drawing.Point(4, 25);
            this.MainTabPage.Name = "MainTabPage";
            this.MainTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.MainTabPage.Size = new System.Drawing.Size(580, 283);
            this.MainTabPage.TabIndex = 0;
            this.MainTabPage.Text = "Main";
            this.MainTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.KeyTypeComboBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.IntervalNumericUpDown);
            this.groupBox1.Controls.Add(this.ThreadCountNumericUpDown);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(6, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(568, 126);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Following settings will take effect on next start";
            // 
            // KeyTypeComboBox
            // 
            this.KeyTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KeyTypeComboBox.FormattingEnabled = true;
            this.KeyTypeComboBox.Location = new System.Drawing.Point(115, 86);
            this.KeyTypeComboBox.Name = "KeyTypeComboBox";
            this.KeyTypeComboBox.Size = new System.Drawing.Size(186, 23);
            this.KeyTypeComboBox.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label5.Location = new System.Drawing.Point(6, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Key Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(214, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "(millisecond)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Thread Count";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(6, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Interval";
            // 
            // IntervalNumericUpDown
            // 
            this.IntervalNumericUpDown.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.IntervalNumericUpDown.Location = new System.Drawing.Point(115, 55);
            this.IntervalNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.IntervalNumericUpDown.Name = "IntervalNumericUpDown";
            this.IntervalNumericUpDown.Size = new System.Drawing.Size(93, 25);
            this.IntervalNumericUpDown.TabIndex = 4;
            // 
            // ThreadCountNumericUpDown
            // 
            this.ThreadCountNumericUpDown.Location = new System.Drawing.Point(115, 25);
            this.ThreadCountNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ThreadCountNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ThreadCountNumericUpDown.Name = "ThreadCountNumericUpDown";
            this.ThreadCountNumericUpDown.Size = new System.Drawing.Size(93, 25);
            this.ThreadCountNumericUpDown.TabIndex = 5;
            this.ThreadCountNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // StartOnLaunchCheckBox
            // 
            this.StartOnLaunchCheckBox.AutoSize = true;
            this.StartOnLaunchCheckBox.Location = new System.Drawing.Point(15, 45);
            this.StartOnLaunchCheckBox.Name = "StartOnLaunchCheckBox";
            this.StartOnLaunchCheckBox.Size = new System.Drawing.Size(317, 19);
            this.StartOnLaunchCheckBox.TabIndex = 11;
            this.StartOnLaunchCheckBox.Text = "Start sniffing on launch CoinSniffer";
            this.StartOnLaunchCheckBox.UseVisualStyleBackColor = true;
            // 
            // LaunchOnLoginCheckBox
            // 
            this.LaunchOnLoginCheckBox.AutoSize = true;
            this.LaunchOnLoginCheckBox.Location = new System.Drawing.Point(15, 15);
            this.LaunchOnLoginCheckBox.Name = "LaunchOnLoginCheckBox";
            this.LaunchOnLoginCheckBox.Size = new System.Drawing.Size(301, 19);
            this.LaunchOnLoginCheckBox.TabIndex = 8;
            this.LaunchOnLoginCheckBox.Text = "Launch CoinSniffer on system login";
            this.LaunchOnLoginCheckBox.UseVisualStyleBackColor = true;
            // 
            // DisplayTabPage
            // 
            this.DisplayTabPage.Controls.Add(this.CapacityForNonExistNumericUpDown);
            this.DisplayTabPage.Controls.Add(this.label3);
            this.DisplayTabPage.Controls.Add(this.OnlyShowExistingCheckBox);
            this.DisplayTabPage.Location = new System.Drawing.Point(4, 25);
            this.DisplayTabPage.Name = "DisplayTabPage";
            this.DisplayTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.DisplayTabPage.Size = new System.Drawing.Size(580, 283);
            this.DisplayTabPage.TabIndex = 1;
            this.DisplayTabPage.Text = "Display";
            this.DisplayTabPage.UseVisualStyleBackColor = true;
            // 
            // CapacityForNonExistNumericUpDown
            // 
            this.CapacityForNonExistNumericUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.CapacityForNonExistNumericUpDown.Location = new System.Drawing.Point(356, 40);
            this.CapacityForNonExistNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.CapacityForNonExistNumericUpDown.Name = "CapacityForNonExistNumericUpDown";
            this.CapacityForNonExistNumericUpDown.Size = new System.Drawing.Size(123, 25);
            this.CapacityForNonExistNumericUpDown.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(335, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Listview capacity for non exist addresses";
            // 
            // OnlyShowExistingCheckBox
            // 
            this.OnlyShowExistingCheckBox.AutoSize = true;
            this.OnlyShowExistingCheckBox.Location = new System.Drawing.Point(15, 15);
            this.OnlyShowExistingCheckBox.Name = "OnlyShowExistingCheckBox";
            this.OnlyShowExistingCheckBox.Size = new System.Drawing.Size(253, 19);
            this.OnlyShowExistingCheckBox.TabIndex = 1;
            this.OnlyShowExistingCheckBox.Text = "Only show existing addresses";
            this.OnlyShowExistingCheckBox.UseVisualStyleBackColor = true;
            this.OnlyShowExistingCheckBox.CheckedChanged += new System.EventHandler(this.OnlyShowExistingCheckBox_CheckedChanged);
            // 
            // WindowTabPage
            // 
            this.WindowTabPage.Controls.Add(this.MinimizeOnCloseCheckBox);
            this.WindowTabPage.Controls.Add(this.MinimizeToTrayCheckBox);
            this.WindowTabPage.Location = new System.Drawing.Point(4, 25);
            this.WindowTabPage.Name = "WindowTabPage";
            this.WindowTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.WindowTabPage.Size = new System.Drawing.Size(580, 283);
            this.WindowTabPage.TabIndex = 2;
            this.WindowTabPage.Text = "Window";
            this.WindowTabPage.UseVisualStyleBackColor = true;
            // 
            // MinimizeOnCloseCheckBox
            // 
            this.MinimizeOnCloseCheckBox.AutoSize = true;
            this.MinimizeOnCloseCheckBox.Location = new System.Drawing.Point(15, 45);
            this.MinimizeOnCloseCheckBox.Name = "MinimizeOnCloseCheckBox";
            this.MinimizeOnCloseCheckBox.Size = new System.Drawing.Size(165, 19);
            this.MinimizeOnCloseCheckBox.TabIndex = 1;
            this.MinimizeOnCloseCheckBox.Text = "Minimize on close";
            this.MinimizeOnCloseCheckBox.UseVisualStyleBackColor = true;
            // 
            // MinimizeToTrayCheckBox
            // 
            this.MinimizeToTrayCheckBox.AutoSize = true;
            this.MinimizeToTrayCheckBox.Location = new System.Drawing.Point(15, 15);
            this.MinimizeToTrayCheckBox.Name = "MinimizeToTrayCheckBox";
            this.MinimizeToTrayCheckBox.Size = new System.Drawing.Size(373, 19);
            this.MinimizeToTrayCheckBox.TabIndex = 0;
            this.MinimizeToTrayCheckBox.Text = "Minimize to the tray instead of the taskbar";
            this.MinimizeToTrayCheckBox.UseVisualStyleBackColor = true;
            // 
            // NotificationTabPage
            // 
            this.NotificationTabPage.Controls.Add(this.MailEnabledCheckBox);
            this.NotificationTabPage.Controls.Add(this.MailGroupBox);
            this.NotificationTabPage.Location = new System.Drawing.Point(4, 25);
            this.NotificationTabPage.Name = "NotificationTabPage";
            this.NotificationTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.NotificationTabPage.Size = new System.Drawing.Size(580, 283);
            this.NotificationTabPage.TabIndex = 3;
            this.NotificationTabPage.Text = "Notification";
            this.NotificationTabPage.UseVisualStyleBackColor = true;
            // 
            // MailEnabledCheckBox
            // 
            this.MailEnabledCheckBox.AutoSize = true;
            this.MailEnabledCheckBox.Location = new System.Drawing.Point(15, 15);
            this.MailEnabledCheckBox.Name = "MailEnabledCheckBox";
            this.MailEnabledCheckBox.Size = new System.Drawing.Size(245, 19);
            this.MailEnabledCheckBox.TabIndex = 1;
            this.MailEnabledCheckBox.Text = "E-Mail to me when find coin";
            this.MailEnabledCheckBox.UseVisualStyleBackColor = true;
            this.MailEnabledCheckBox.CheckedChanged += new System.EventHandler(this.MailEnabledCheckBox_CheckedChanged);
            // 
            // MailGroupBox
            // 
            this.MailGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MailGroupBox.Controls.Add(this.MailTestButton);
            this.MailGroupBox.Controls.Add(this.MailBodyTextBox);
            this.MailGroupBox.Controls.Add(this.label12);
            this.MailGroupBox.Controls.Add(this.label10);
            this.MailGroupBox.Controls.Add(this.MailToTextBox);
            this.MailGroupBox.Controls.Add(this.MailSubjectTextBox);
            this.MailGroupBox.Controls.Add(this.label11);
            this.MailGroupBox.Controls.Add(this.label8);
            this.MailGroupBox.Controls.Add(this.MailUsernameTextBox);
            this.MailGroupBox.Controls.Add(this.label9);
            this.MailGroupBox.Controls.Add(this.MailPasswordTextBox);
            this.MailGroupBox.Controls.Add(this.label6);
            this.MailGroupBox.Controls.Add(this.MailServerTextBox);
            this.MailGroupBox.Controls.Add(this.label7);
            this.MailGroupBox.Controls.Add(this.MailPortTextBox);
            this.MailGroupBox.Location = new System.Drawing.Point(15, 15);
            this.MailGroupBox.Name = "MailGroupBox";
            this.MailGroupBox.Size = new System.Drawing.Size(551, 205);
            this.MailGroupBox.TabIndex = 0;
            this.MailGroupBox.TabStop = false;
            // 
            // MailTestButton
            // 
            this.MailTestButton.Location = new System.Drawing.Point(395, 135);
            this.MailTestButton.Name = "MailTestButton";
            this.MailTestButton.Size = new System.Drawing.Size(134, 56);
            this.MailTestButton.TabIndex = 18;
            this.MailTestButton.Text = "Test Mail";
            this.MailTestButton.UseVisualStyleBackColor = true;
            this.MailTestButton.Click += new System.EventHandler(this.MailTestButton_Click);
            // 
            // MailBodyTextBox
            // 
            this.MailBodyTextBox.Location = new System.Drawing.Point(21, 135);
            this.MailBodyTextBox.Multiline = true;
            this.MailBodyTextBox.Name = "MailBodyTextBox";
            this.MailBodyTextBox.Size = new System.Drawing.Size(357, 56);
            this.MailBodyTextBox.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 117);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 15);
            this.label12.TabIndex = 16;
            this.label12.Text = "Body";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 15);
            this.label10.TabIndex = 12;
            this.label10.Text = "To";
            // 
            // MailToTextBox
            // 
            this.MailToTextBox.Location = new System.Drawing.Point(21, 89);
            this.MailToTextBox.Name = "MailToTextBox";
            this.MailToTextBox.Size = new System.Drawing.Size(206, 25);
            this.MailToTextBox.TabIndex = 13;
            // 
            // MailSubjectTextBox
            // 
            this.MailSubjectTextBox.Location = new System.Drawing.Point(244, 89);
            this.MailSubjectTextBox.Name = "MailSubjectTextBox";
            this.MailSubjectTextBox.Size = new System.Drawing.Size(285, 25);
            this.MailSubjectTextBox.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(241, 71);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 15);
            this.label11.TabIndex = 14;
            this.label11.Text = "Subject";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(241, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "Username";
            // 
            // MailUsernameTextBox
            // 
            this.MailUsernameTextBox.Location = new System.Drawing.Point(244, 43);
            this.MailUsernameTextBox.Name = "MailUsernameTextBox";
            this.MailUsernameTextBox.Size = new System.Drawing.Size(134, 25);
            this.MailUsernameTextBox.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(392, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 15);
            this.label9.TabIndex = 10;
            this.label9.Text = "Password";
            // 
            // MailPasswordTextBox
            // 
            this.MailPasswordTextBox.Location = new System.Drawing.Point(395, 43);
            this.MailPasswordTextBox.Name = "MailPasswordTextBox";
            this.MailPasswordTextBox.PasswordChar = '*';
            this.MailPasswordTextBox.Size = new System.Drawing.Size(134, 25);
            this.MailPasswordTextBox.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "Server";
            // 
            // MailServerTextBox
            // 
            this.MailServerTextBox.Location = new System.Drawing.Point(21, 43);
            this.MailServerTextBox.Name = "MailServerTextBox";
            this.MailServerTextBox.Size = new System.Drawing.Size(134, 25);
            this.MailServerTextBox.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(169, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Port";
            // 
            // MailPortTextBox
            // 
            this.MailPortTextBox.Location = new System.Drawing.Point(172, 43);
            this.MailPortTextBox.Name = "MailPortTextBox";
            this.MailPortTextBox.Size = new System.Drawing.Size(55, 25);
            this.MailPortTextBox.TabIndex = 7;
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.Location = new System.Drawing.Point(303, 338);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(95, 32);
            this.OkButton.TabIndex = 1;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(404, 338);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(95, 32);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ApplyButton
            // 
            this.ApplyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ApplyButton.Location = new System.Drawing.Point(505, 338);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(95, 32);
            this.ApplyButton.TabIndex = 3;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 384);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.TabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.TabControl.ResumeLayout(false);
            this.MainTabPage.ResumeLayout(false);
            this.MainTabPage.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IntervalNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThreadCountNumericUpDown)).EndInit();
            this.DisplayTabPage.ResumeLayout(false);
            this.DisplayTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CapacityForNonExistNumericUpDown)).EndInit();
            this.WindowTabPage.ResumeLayout(false);
            this.WindowTabPage.PerformLayout();
            this.NotificationTabPage.ResumeLayout(false);
            this.NotificationTabPage.PerformLayout();
            this.MailGroupBox.ResumeLayout(false);
            this.MailGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage MainTabPage;
        private System.Windows.Forms.TabPage DisplayTabPage;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown ThreadCountNumericUpDown;
        private System.Windows.Forms.NumericUpDown IntervalNumericUpDown;
        private System.Windows.Forms.TabPage WindowTabPage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox LaunchOnLoginCheckBox;
        private System.Windows.Forms.CheckBox MinimizeOnCloseCheckBox;
        private System.Windows.Forms.CheckBox MinimizeToTrayCheckBox;
        private System.Windows.Forms.CheckBox OnlyShowExistingCheckBox;
        private System.Windows.Forms.NumericUpDown CapacityForNonExistNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage NotificationTabPage;
        private System.Windows.Forms.GroupBox MailGroupBox;
        private System.Windows.Forms.CheckBox MailEnabledCheckBox;
        private System.Windows.Forms.Button MailTestButton;
        private System.Windows.Forms.TextBox MailBodyTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox MailToTextBox;
        private System.Windows.Forms.TextBox MailSubjectTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox MailUsernameTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox MailPasswordTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox MailServerTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox MailPortTextBox;
        private System.Windows.Forms.CheckBox StartOnLaunchCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox KeyTypeComboBox;
        private System.Windows.Forms.Label label5;
    }
}