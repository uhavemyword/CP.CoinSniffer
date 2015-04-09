namespace CP.CoinSniffer.WinForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.ErrorStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.MessageStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.PerformanceStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CurrentElapsedDayLabel = new System.Windows.Forms.Label();
            this.TotalScannedLabel = new System.Windows.Forms.Label();
            this.TotalElapsedDayLabel = new System.Windows.Forms.Label();
            this.CurrentScannedLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TotalElapsedTimeLabel = new System.Windows.Forms.Label();
            this.CurrentElapsedTimeLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TotalFoundLabel = new System.Windows.Forms.Label();
            this.CurrentFoundLabel = new System.Windows.Forms.Label();
            this.ListViewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CopyRowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.AddressInfoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BalanceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FirstSeenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ClearAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyIconContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ExitToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.StopwatchTimer = new System.Windows.Forms.Timer(this.components);
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.StartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ErrorTextBox = new System.Windows.Forms.TextBox();
            this.BlinkTimer = new System.Windows.Forms.Timer(this.components);
            this.listView1 = new System.Windows.Forms.MyListView();
            this.PublicKeyColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FirstSeenColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BalanceColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PrivateKeyColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ScannedAtColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatusStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.ListViewContextMenuStrip.SuspendLayout();
            this.NotifyIconContextMenuStrip.SuspendLayout();
            this.MainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ErrorStatusLabel,
            this.ProgressBar,
            this.MessageStatusLabel,
            this.toolStripStatusLabel2,
            this.PerformanceStatusLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 402);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(782, 25);
            this.StatusStrip.TabIndex = 11;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // ErrorStatusLabel
            // 
            this.ErrorStatusLabel.IsLink = true;
            this.ErrorStatusLabel.Name = "ErrorStatusLabel";
            this.ErrorStatusLabel.Size = new System.Drawing.Size(129, 20);
            this.ErrorStatusLabel.Text = "ErrorStatusLabel";
            this.ErrorStatusLabel.Click += new System.EventHandler(this.ErrorStatusLabel_Click);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(150, 19);
            // 
            // MessageStatusLabel
            // 
            this.MessageStatusLabel.Name = "MessageStatusLabel";
            this.MessageStatusLabel.Size = new System.Drawing.Size(158, 20);
            this.MessageStatusLabel.Text = "MessageStatusLabel";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(142, 20);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // PerformanceStatusLabel
            // 
            this.PerformanceStatusLabel.Name = "PerformanceStatusLabel";
            this.PerformanceStatusLabel.Size = new System.Drawing.Size(186, 20);
            this.PerformanceStatusLabel.Text = "PerformanceStatusLabel";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CurrentElapsedDayLabel);
            this.panel1.Controls.Add(this.TotalScannedLabel);
            this.panel1.Controls.Add(this.TotalElapsedDayLabel);
            this.panel1.Controls.Add(this.CurrentScannedLabel);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.TotalElapsedTimeLabel);
            this.panel1.Controls.Add(this.CurrentElapsedTimeLabel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TotalFoundLabel);
            this.panel1.Controls.Add(this.CurrentFoundLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 143);
            this.panel1.TabIndex = 18;
            // 
            // CurrentElapsedDayLabel
            // 
            this.CurrentElapsedDayLabel.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CurrentElapsedDayLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.CurrentElapsedDayLabel.Location = new System.Drawing.Point(531, 45);
            this.CurrentElapsedDayLabel.Margin = new System.Windows.Forms.Padding(0);
            this.CurrentElapsedDayLabel.Name = "CurrentElapsedDayLabel";
            this.CurrentElapsedDayLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CurrentElapsedDayLabel.Size = new System.Drawing.Size(95, 32);
            this.CurrentElapsedDayLabel.TabIndex = 19;
            this.CurrentElapsedDayLabel.Text = "0";
            // 
            // TotalScannedLabel
            // 
            this.TotalScannedLabel.AutoSize = true;
            this.TotalScannedLabel.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TotalScannedLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.TotalScannedLabel.Location = new System.Drawing.Point(346, 88);
            this.TotalScannedLabel.Name = "TotalScannedLabel";
            this.TotalScannedLabel.Size = new System.Drawing.Size(31, 36);
            this.TotalScannedLabel.TabIndex = 17;
            this.TotalScannedLabel.Text = "0";
            // 
            // TotalElapsedDayLabel
            // 
            this.TotalElapsedDayLabel.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TotalElapsedDayLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.TotalElapsedDayLabel.Location = new System.Drawing.Point(531, 88);
            this.TotalElapsedDayLabel.Margin = new System.Windows.Forms.Padding(0);
            this.TotalElapsedDayLabel.Name = "TotalElapsedDayLabel";
            this.TotalElapsedDayLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TotalElapsedDayLabel.Size = new System.Drawing.Size(95, 32);
            this.TotalElapsedDayLabel.TabIndex = 18;
            this.TotalElapsedDayLabel.Text = "0";
            // 
            // CurrentScannedLabel
            // 
            this.CurrentScannedLabel.AutoSize = true;
            this.CurrentScannedLabel.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CurrentScannedLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.CurrentScannedLabel.Location = new System.Drawing.Point(346, 45);
            this.CurrentScannedLabel.Name = "CurrentScannedLabel";
            this.CurrentScannedLabel.Size = new System.Drawing.Size(31, 36);
            this.CurrentScannedLabel.TabIndex = 16;
            this.CurrentScannedLabel.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label5.Location = new System.Drawing.Point(628, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Elapsed";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label4.Location = new System.Drawing.Point(346, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Scanned";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label3.Location = new System.Drawing.Point(112, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Found";
            // 
            // TotalElapsedTimeLabel
            // 
            this.TotalElapsedTimeLabel.AutoSize = true;
            this.TotalElapsedTimeLabel.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TotalElapsedTimeLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.TotalElapsedTimeLabel.Location = new System.Drawing.Point(628, 88);
            this.TotalElapsedTimeLabel.Name = "TotalElapsedTimeLabel";
            this.TotalElapsedTimeLabel.Size = new System.Drawing.Size(125, 36);
            this.TotalElapsedTimeLabel.TabIndex = 12;
            this.TotalElapsedTimeLabel.Text = "00:00:00";
            // 
            // CurrentElapsedTimeLabel
            // 
            this.CurrentElapsedTimeLabel.AutoSize = true;
            this.CurrentElapsedTimeLabel.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CurrentElapsedTimeLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.CurrentElapsedTimeLabel.Location = new System.Drawing.Point(628, 45);
            this.CurrentElapsedTimeLabel.Name = "CurrentElapsedTimeLabel";
            this.CurrentElapsedTimeLabel.Size = new System.Drawing.Size(125, 36);
            this.CurrentElapsedTimeLabel.TabIndex = 11;
            this.CurrentElapsedTimeLabel.Text = "00:00:00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(23, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Total";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(23, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Current";
            // 
            // TotalFoundLabel
            // 
            this.TotalFoundLabel.AutoSize = true;
            this.TotalFoundLabel.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TotalFoundLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.TotalFoundLabel.Location = new System.Drawing.Point(112, 88);
            this.TotalFoundLabel.Name = "TotalFoundLabel";
            this.TotalFoundLabel.Size = new System.Drawing.Size(31, 36);
            this.TotalFoundLabel.TabIndex = 8;
            this.TotalFoundLabel.Text = "0";
            // 
            // CurrentFoundLabel
            // 
            this.CurrentFoundLabel.AutoSize = true;
            this.CurrentFoundLabel.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CurrentFoundLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.CurrentFoundLabel.Location = new System.Drawing.Point(112, 45);
            this.CurrentFoundLabel.Name = "CurrentFoundLabel";
            this.CurrentFoundLabel.Size = new System.Drawing.Size(31, 36);
            this.CurrentFoundLabel.TabIndex = 7;
            this.CurrentFoundLabel.Text = "0";
            // 
            // ListViewContextMenuStrip
            // 
            this.ListViewContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyRowMenuItem,
            this.DeleteMenuItem,
            this.toolStripSeparator1,
            this.AddressInfoMenuItem,
            this.BalanceMenuItem,
            this.FirstSeenMenuItem,
            this.toolStripSeparator2,
            this.ClearAllMenuItem});
            this.ListViewContextMenuStrip.Name = "contextMenuStrip1";
            this.ListViewContextMenuStrip.Size = new System.Drawing.Size(171, 160);
            // 
            // CopyRowMenuItem
            // 
            this.CopyRowMenuItem.Name = "CopyRowMenuItem";
            this.CopyRowMenuItem.Size = new System.Drawing.Size(170, 24);
            this.CopyRowMenuItem.Text = "Copy";
            this.CopyRowMenuItem.Click += new System.EventHandler(this.CopyRowMenuItem_Click);
            // 
            // DeleteMenuItem
            // 
            this.DeleteMenuItem.Name = "DeleteMenuItem";
            this.DeleteMenuItem.Size = new System.Drawing.Size(170, 24);
            this.DeleteMenuItem.Text = "Delete";
            this.DeleteMenuItem.Click += new System.EventHandler(this.DeleteMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
            // 
            // AddressInfoMenuItem
            // 
            this.AddressInfoMenuItem.Name = "AddressInfoMenuItem";
            this.AddressInfoMenuItem.Size = new System.Drawing.Size(170, 24);
            this.AddressInfoMenuItem.Text = "Address Info";
            this.AddressInfoMenuItem.Click += new System.EventHandler(this.AddressMenuItem_Click);
            // 
            // BalanceMenuItem
            // 
            this.BalanceMenuItem.Name = "BalanceMenuItem";
            this.BalanceMenuItem.Size = new System.Drawing.Size(170, 24);
            this.BalanceMenuItem.Text = "Balance";
            this.BalanceMenuItem.Click += new System.EventHandler(this.AddressMenuItem_Click);
            // 
            // FirstSeenMenuItem
            // 
            this.FirstSeenMenuItem.Name = "FirstSeenMenuItem";
            this.FirstSeenMenuItem.Size = new System.Drawing.Size(170, 24);
            this.FirstSeenMenuItem.Text = "First Seen";
            this.FirstSeenMenuItem.Click += new System.EventHandler(this.AddressMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(167, 6);
            // 
            // ClearAllMenuItem
            // 
            this.ClearAllMenuItem.Name = "ClearAllMenuItem";
            this.ClearAllMenuItem.Size = new System.Drawing.Size(170, 24);
            this.ClearAllMenuItem.Text = "Clear All";
            this.ClearAllMenuItem.Click += new System.EventHandler(this.ClearAllMenuItem_Click);
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.ContextMenuStrip = this.NotifyIconContextMenuStrip;
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Text = "Coin Sniffer";
            this.NotifyIcon.Visible = true;
            this.NotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseClick);
            // 
            // NotifyIconContextMenuStrip
            // 
            this.NotifyIconContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitToolStripMenuItem2});
            this.NotifyIconContextMenuStrip.Name = "NotifyIconContextMenuStrip";
            this.NotifyIconContextMenuStrip.Size = new System.Drawing.Size(105, 28);
            // 
            // ExitToolStripMenuItem2
            // 
            this.ExitToolStripMenuItem2.Name = "ExitToolStripMenuItem2";
            this.ExitToolStripMenuItem2.Size = new System.Drawing.Size(104, 24);
            this.ExitToolStripMenuItem2.Text = "Exit";
            this.ExitToolStripMenuItem2.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // StopwatchTimer
            // 
            this.StopwatchTimer.Enabled = true;
            this.StopwatchTimer.Interval = 1000;
            this.StopwatchTimer.Tick += new System.EventHandler(this.StopwatchTimer_Tick);
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.MainMenuStrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainMenuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartToolStripMenuItem,
            this.StopToolStripMenuItem,
            this.TestToolStripMenuItem,
            this.SettingsToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(782, 33);
            this.MainMenuStrip.TabIndex = 20;
            this.MainMenuStrip.Text = "menuStrip1";
            // 
            // StartToolStripMenuItem
            // 
            this.StartToolStripMenuItem.Name = "StartToolStripMenuItem";
            this.StartToolStripMenuItem.Size = new System.Drawing.Size(70, 29);
            this.StartToolStripMenuItem.Text = " Start";
            this.StartToolStripMenuItem.Click += new System.EventHandler(this.StartToolStripMenuItem_Click);
            // 
            // StopToolStripMenuItem
            // 
            this.StopToolStripMenuItem.Name = "StopToolStripMenuItem";
            this.StopToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.StopToolStripMenuItem.Text = "Stop";
            this.StopToolStripMenuItem.Click += new System.EventHandler(this.StopToolStripMenuItem_Click);
            // 
            // TestToolStripMenuItem
            // 
            this.TestToolStripMenuItem.Name = "TestToolStripMenuItem";
            this.TestToolStripMenuItem.Size = new System.Drawing.Size(63, 29);
            this.TestToolStripMenuItem.Text = "Test";
            this.TestToolStripMenuItem.Click += new System.EventHandler(this.TestToolStripMenuItem_Click);
            // 
            // SettingsToolStripMenuItem
            // 
            this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            this.SettingsToolStripMenuItem.Size = new System.Drawing.Size(95, 29);
            this.SettingsToolStripMenuItem.Text = "Settings";
            this.SettingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(56, 29);
            this.ExitToolStripMenuItem.Text = "Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // ErrorTextBox
            // 
            this.ErrorTextBox.Location = new System.Drawing.Point(439, 271);
            this.ErrorTextBox.Multiline = true;
            this.ErrorTextBox.Name = "ErrorTextBox";
            this.ErrorTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ErrorTextBox.Size = new System.Drawing.Size(100, 21);
            this.ErrorTextBox.TabIndex = 21;
            // 
            // BlinkTimer
            // 
            this.BlinkTimer.Interval = 380;
            this.BlinkTimer.Tick += new System.EventHandler(this.BlinkTimer_Tick);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PublicKeyColumn,
            this.FirstSeenColumn,
            this.BalanceColumn,
            this.PrivateKeyColumn,
            this.ScannedAtColumn});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(0, 176);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(782, 251);
            this.listView1.TabIndex = 17;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListView1_MouseDoubleClick);
            this.listView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ListView1_MouseUp);
            // 
            // PublicKeyColumn
            // 
            this.PublicKeyColumn.Text = "Address (Public Key)";
            this.PublicKeyColumn.Width = 320;
            // 
            // FirstSeenColumn
            // 
            this.FirstSeenColumn.Text = "First Seen";
            this.FirstSeenColumn.Width = 180;
            // 
            // BalanceColumn
            // 
            this.BalanceColumn.Text = "Balance";
            this.BalanceColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BalanceColumn.Width = 100;
            // 
            // PrivateKeyColumn
            // 
            this.PrivateKeyColumn.Text = "Private Key";
            this.PrivateKeyColumn.Width = 450;
            // 
            // ScannedAtColumn
            // 
            this.ScannedAtColumn.Text = "Scanned At";
            this.ScannedAtColumn.Width = 180;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 427);
            this.Controls.Add(this.ErrorTextBox);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MainMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 237);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Coin Sniffer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ListViewContextMenuStrip.ResumeLayout(false);
            this.NotifyIconContextMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel MessageStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel PerformanceStatusLabel;
        private System.Windows.Forms.MyListView listView1;
        private System.Windows.Forms.ColumnHeader PublicKeyColumn;
        private System.Windows.Forms.ColumnHeader FirstSeenColumn;
        private System.Windows.Forms.ColumnHeader BalanceColumn;
        private System.Windows.Forms.ColumnHeader PrivateKeyColumn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip ListViewContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem CopyRowMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddressInfoMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem BalanceMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FirstSeenMenuItem;
        private System.Windows.Forms.ColumnHeader ScannedAtColumn;
        private System.Windows.Forms.NotifyIcon NotifyIcon;
        private System.Windows.Forms.ContextMenuStrip NotifyIconContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem2;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.Label CurrentFoundLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TotalFoundLabel;
        private System.Windows.Forms.Label TotalElapsedTimeLabel;
        private System.Windows.Forms.Label CurrentElapsedTimeLabel;
        private System.Windows.Forms.Label TotalScannedLabel;
        private System.Windows.Forms.Label CurrentScannedLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer StopwatchTimer;
        private System.Windows.Forms.Label TotalElapsedDayLabel;
        private System.Windows.Forms.Label CurrentElapsedDayLabel;
        private System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem StartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ClearAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TestToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel ErrorStatusLabel;
        private System.Windows.Forms.TextBox ErrorTextBox;
        private System.Windows.Forms.Timer BlinkTimer;
    }
}

