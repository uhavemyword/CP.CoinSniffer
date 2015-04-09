namespace CP.CoinSniffer.WinForm
{
    partial class TestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestForm));
            this.label1 = new System.Windows.Forms.Label();
            this.PrivateKeyTextBox = new System.Windows.Forms.TextBox();
            this.CompressedPublicKeyTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CheckButton = new System.Windows.Forms.Button();
            this.InsertButton = new System.Windows.Forms.Button();
            this.FirstSeenTextBox = new System.Windows.Forms.TextBox();
            this.BalanceTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RandomButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.UncompressedPublicKeyTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CompressedPrivateKeyTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.UncompressedPrivateKeyTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input a private Key in any format";
            // 
            // PrivateKeyTextBox
            // 
            this.PrivateKeyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PrivateKeyTextBox.Location = new System.Drawing.Point(12, 45);
            this.PrivateKeyTextBox.Name = "PrivateKeyTextBox";
            this.PrivateKeyTextBox.Size = new System.Drawing.Size(495, 22);
            this.PrivateKeyTextBox.TabIndex = 1;
            this.PrivateKeyTextBox.Text = "5K6jfyvCuoXUBa6ufBd8KN3d8upTsYsaiWYvCorBodQK4Bh4PsL";
            // 
            // CompressedPublicKeyTextBox
            // 
            this.CompressedPublicKeyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CompressedPublicKeyTextBox.Location = new System.Drawing.Point(119, 218);
            this.CompressedPublicKeyTextBox.Name = "CompressedPublicKeyTextBox";
            this.CompressedPublicKeyTextBox.ReadOnly = true;
            this.CompressedPublicKeyTextBox.Size = new System.Drawing.Size(506, 22);
            this.CompressedPublicKeyTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Private Key";
            // 
            // CheckButton
            // 
            this.CheckButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckButton.Location = new System.Drawing.Point(513, 42);
            this.CheckButton.Name = "CheckButton";
            this.CheckButton.Size = new System.Drawing.Size(112, 28);
            this.CheckButton.TabIndex = 4;
            this.CheckButton.Text = "Check";
            this.CheckButton.UseVisualStyleBackColor = true;
            this.CheckButton.Click += new System.EventHandler(this.CheckButton_Click);
            // 
            // InsertButton
            // 
            this.InsertButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InsertButton.Location = new System.Drawing.Point(437, 291);
            this.InsertButton.Name = "InsertButton";
            this.InsertButton.Size = new System.Drawing.Size(188, 28);
            this.InsertButton.TabIndex = 9;
            this.InsertButton.Text = "Insert into list";
            this.InsertButton.UseVisualStyleBackColor = true;
            this.InsertButton.Click += new System.EventHandler(this.InsertButton_Click);
            // 
            // FirstSeenTextBox
            // 
            this.FirstSeenTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FirstSeenTextBox.Location = new System.Drawing.Point(119, 294);
            this.FirstSeenTextBox.Name = "FirstSeenTextBox";
            this.FirstSeenTextBox.ReadOnly = true;
            this.FirstSeenTextBox.Size = new System.Drawing.Size(208, 22);
            this.FirstSeenTextBox.TabIndex = 8;
            // 
            // BalanceTextBox
            // 
            this.BalanceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BalanceTextBox.Location = new System.Drawing.Point(119, 260);
            this.BalanceTextBox.Name = "BalanceTextBox";
            this.BalanceTextBox.ReadOnly = true;
            this.BalanceTextBox.Size = new System.Drawing.Size(208, 22);
            this.BalanceTextBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "First Seen";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Balance";
            // 
            // RandomButton
            // 
            this.RandomButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RandomButton.Location = new System.Drawing.Point(437, 257);
            this.RandomButton.Name = "RandomButton";
            this.RandomButton.Size = new System.Drawing.Size(188, 28);
            this.RandomButton.TabIndex = 10;
            this.RandomButton.Text = "Random";
            this.RandomButton.UseVisualStyleBackColor = true;
            this.RandomButton.Click += new System.EventHandler(this.RandomButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 34);
            this.label4.TabIndex = 11;
            this.label4.Text = "Public Key\r\n(Compressed)";
            // 
            // UncompressedPublicKeyTextBox
            // 
            this.UncompressedPublicKeyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UncompressedPublicKeyTextBox.Location = new System.Drawing.Point(119, 175);
            this.UncompressedPublicKeyTextBox.Name = "UncompressedPublicKeyTextBox";
            this.UncompressedPublicKeyTextBox.ReadOnly = true;
            this.UncompressedPublicKeyTextBox.Size = new System.Drawing.Size(506, 22);
            this.UncompressedPublicKeyTextBox.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Public Key";
            // 
            // CompressedPrivateKeyTextBox
            // 
            this.CompressedPrivateKeyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CompressedPrivateKeyTextBox.Location = new System.Drawing.Point(119, 133);
            this.CompressedPrivateKeyTextBox.Name = "CompressedPrivateKeyTextBox";
            this.CompressedPrivateKeyTextBox.ReadOnly = true;
            this.CompressedPrivateKeyTextBox.Size = new System.Drawing.Size(506, 22);
            this.CompressedPrivateKeyTextBox.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 34);
            this.label7.TabIndex = 15;
            this.label7.Text = "Private Key\r\n(Compressed)";
            // 
            // UncompressedPrivateKeyTextBox
            // 
            this.UncompressedPrivateKeyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UncompressedPrivateKeyTextBox.Location = new System.Drawing.Point(119, 90);
            this.UncompressedPrivateKeyTextBox.Name = "UncompressedPrivateKeyTextBox";
            this.UncompressedPrivateKeyTextBox.ReadOnly = true;
            this.UncompressedPrivateKeyTextBox.Size = new System.Drawing.Size(506, 22);
            this.UncompressedPrivateKeyTextBox.TabIndex = 16;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 333);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.UncompressedPrivateKeyTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CompressedPrivateKeyTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.UncompressedPublicKeyTextBox);
            this.Controls.Add(this.RandomButton);
            this.Controls.Add(this.InsertButton);
            this.Controls.Add(this.FirstSeenTextBox);
            this.Controls.Add(this.CheckButton);
            this.Controls.Add(this.BalanceTextBox);
            this.Controls.Add(this.PrivateKeyTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CompressedPublicKeyTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Single Address";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PrivateKeyTextBox;
        private System.Windows.Forms.TextBox CompressedPublicKeyTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CheckButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox FirstSeenTextBox;
        private System.Windows.Forms.TextBox BalanceTextBox;
        private System.Windows.Forms.Button InsertButton;
        private System.Windows.Forms.Button RandomButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox UncompressedPublicKeyTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox CompressedPrivateKeyTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox UncompressedPrivateKeyTextBox;
    }
}