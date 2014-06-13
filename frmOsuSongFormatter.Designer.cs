namespace OsuSongFormatter
{
    partial class frmOsuSongFormatter
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
            this.lblSongFolder = new System.Windows.Forms.Label();
            this.txtSongFolder = new System.Windows.Forms.TextBox();
            this.btnSongFolder = new System.Windows.Forms.Button();
            this.lblListOfSongs = new System.Windows.Forms.Label();
            this.lbListOfSongs = new System.Windows.Forms.ListBox();
            this.txtDestinationFolder = new System.Windows.Forms.TextBox();
            this.btnDestinationFolder = new System.Windows.Forms.Button();
            this.lblDestinationFolder = new System.Windows.Forms.Label();
            this.btnTransferAndFormat = new System.Windows.Forms.Button();
            this.pgbTransfert = new System.Windows.Forms.ProgressBar();
            this.lbError = new System.Windows.Forms.ListBox();
            this.lblError = new System.Windows.Forms.Label();
            this.lblTransfert = new System.Windows.Forms.Label();
            this.btnAbout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSongFolder
            // 
            this.lblSongFolder.AutoSize = true;
            this.lblSongFolder.Location = new System.Drawing.Point(12, 9);
            this.lblSongFolder.Name = "lblSongFolder";
            this.lblSongFolder.Size = new System.Drawing.Size(84, 13);
            this.lblSongFolder.TabIndex = 0;
            this.lblSongFolder.Text = "Osu! song folder";
            // 
            // txtSongFolder
            // 
            this.txtSongFolder.Location = new System.Drawing.Point(12, 25);
            this.txtSongFolder.Name = "txtSongFolder";
            this.txtSongFolder.ReadOnly = true;
            this.txtSongFolder.Size = new System.Drawing.Size(512, 20);
            this.txtSongFolder.TabIndex = 1;
            this.txtSongFolder.Click += new System.EventHandler(this.SelectSongFolder);
            // 
            // btnSongFolder
            // 
            this.btnSongFolder.Location = new System.Drawing.Point(530, 25);
            this.btnSongFolder.Name = "btnSongFolder";
            this.btnSongFolder.Size = new System.Drawing.Size(31, 20);
            this.btnSongFolder.TabIndex = 2;
            this.btnSongFolder.Text = "...";
            this.btnSongFolder.UseVisualStyleBackColor = true;
            this.btnSongFolder.Click += new System.EventHandler(this.SelectSongFolder);
            // 
            // lblListOfSongs
            // 
            this.lblListOfSongs.AutoSize = true;
            this.lblListOfSongs.Location = new System.Drawing.Point(21, 120);
            this.lblListOfSongs.Name = "lblListOfSongs";
            this.lblListOfSongs.Size = new System.Drawing.Size(66, 13);
            this.lblListOfSongs.TabIndex = 3;
            this.lblListOfSongs.Text = "List of songs";
            // 
            // lbListOfSongs
            // 
            this.lbListOfSongs.FormattingEnabled = true;
            this.lbListOfSongs.Location = new System.Drawing.Point(24, 137);
            this.lbListOfSongs.Name = "lbListOfSongs";
            this.lbListOfSongs.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbListOfSongs.Size = new System.Drawing.Size(537, 225);
            this.lbListOfSongs.TabIndex = 4;
            // 
            // txtDestinationFolder
            // 
            this.txtDestinationFolder.Location = new System.Drawing.Point(12, 68);
            this.txtDestinationFolder.Name = "txtDestinationFolder";
            this.txtDestinationFolder.ReadOnly = true;
            this.txtDestinationFolder.Size = new System.Drawing.Size(512, 20);
            this.txtDestinationFolder.TabIndex = 5;
            this.txtDestinationFolder.Click += new System.EventHandler(this.SelectDestinationFolder);
            // 
            // btnDestinationFolder
            // 
            this.btnDestinationFolder.Location = new System.Drawing.Point(530, 68);
            this.btnDestinationFolder.Name = "btnDestinationFolder";
            this.btnDestinationFolder.Size = new System.Drawing.Size(31, 20);
            this.btnDestinationFolder.TabIndex = 6;
            this.btnDestinationFolder.Text = "...";
            this.btnDestinationFolder.UseVisualStyleBackColor = true;
            this.btnDestinationFolder.Click += new System.EventHandler(this.SelectDestinationFolder);
            // 
            // lblDestinationFolder
            // 
            this.lblDestinationFolder.AutoSize = true;
            this.lblDestinationFolder.Location = new System.Drawing.Point(12, 52);
            this.lblDestinationFolder.Name = "lblDestinationFolder";
            this.lblDestinationFolder.Size = new System.Drawing.Size(89, 13);
            this.lblDestinationFolder.TabIndex = 7;
            this.lblDestinationFolder.Text = "Destination folder";
            // 
            // btnTransferAndFormat
            // 
            this.btnTransferAndFormat.Location = new System.Drawing.Point(584, 137);
            this.btnTransferAndFormat.Name = "btnTransferAndFormat";
            this.btnTransferAndFormat.Size = new System.Drawing.Size(97, 53);
            this.btnTransferAndFormat.TabIndex = 8;
            this.btnTransferAndFormat.Text = "Transfer and format";
            this.btnTransferAndFormat.UseVisualStyleBackColor = true;
            this.btnTransferAndFormat.Click += new System.EventHandler(this.btnTransferAndFormat_Click);
            // 
            // pgbTransfert
            // 
            this.pgbTransfert.Location = new System.Drawing.Point(12, 589);
            this.pgbTransfert.Name = "pgbTransfert";
            this.pgbTransfert.Size = new System.Drawing.Size(861, 23);
            this.pgbTransfert.TabIndex = 9;
            // 
            // lbError
            // 
            this.lbError.FormattingEnabled = true;
            this.lbError.Location = new System.Drawing.Point(24, 401);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(537, 95);
            this.lbError.TabIndex = 10;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(21, 385);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(64, 13);
            this.lblError.TabIndex = 11;
            this.lblError.Text = "List of errors";
            // 
            // lblTransfert
            // 
            this.lblTransfert.AutoSize = true;
            this.lblTransfert.Location = new System.Drawing.Point(12, 573);
            this.lblTransfert.Name = "lblTransfert";
            this.lblTransfert.Size = new System.Drawing.Size(24, 13);
            this.lblTransfert.TabIndex = 12;
            this.lblTransfert.Text = "0/0";
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(715, 137);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(97, 53);
            this.btnAbout.TabIndex = 13;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // frmOsuSongFormatter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 624);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.lblTransfert);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lbError);
            this.Controls.Add(this.pgbTransfert);
            this.Controls.Add(this.btnTransferAndFormat);
            this.Controls.Add(this.lblDestinationFolder);
            this.Controls.Add(this.btnDestinationFolder);
            this.Controls.Add(this.txtDestinationFolder);
            this.Controls.Add(this.lbListOfSongs);
            this.Controls.Add(this.lblListOfSongs);
            this.Controls.Add(this.btnSongFolder);
            this.Controls.Add(this.txtSongFolder);
            this.Controls.Add(this.lblSongFolder);
            this.Name = "frmOsuSongFormatter";
            this.Text = "Osu! Song Formatter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSongFolder;
        private System.Windows.Forms.TextBox txtSongFolder;
        private System.Windows.Forms.Button btnSongFolder;
        private System.Windows.Forms.Label lblListOfSongs;
        private System.Windows.Forms.ListBox lbListOfSongs;
        private System.Windows.Forms.TextBox txtDestinationFolder;
        private System.Windows.Forms.Button btnDestinationFolder;
        private System.Windows.Forms.Label lblDestinationFolder;
        private System.Windows.Forms.Button btnTransferAndFormat;
        private System.Windows.Forms.ProgressBar pgbTransfert;
        private System.Windows.Forms.ListBox lbError;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblTransfert;
        private System.Windows.Forms.Button btnAbout;
    }
}

