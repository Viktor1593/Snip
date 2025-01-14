﻿namespace Winter
{
    public partial class Snip
    {
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSnipVersion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemVlc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSetFormat;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSaveSeparateFiles;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSaveAlbumArtwork;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSmall;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMedium;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLarge;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSaveHistory;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDisplayTrackPopup;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEmptyFileIfNoTrackPlaying;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.Timer timerScanMediaPlayer;

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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }

            if (disposing && (this.keyboardHook != null))
            {
                this.keyboardHook.Dispose();
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
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemSnipVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemVlc = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemSetFormat = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemSaveSeparateFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSaveAlbumArtwork = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSmall = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemMedium = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemLarge = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSaveHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDisplayTrackPopup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEmptyFileIfNoTrackPlaying = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.timerScanMediaPlayer = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Text = LocalizedMessages.NoTrackPlaying;
            this.notifyIcon.Visible = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSnipVersion,
            this.toolStripSeparator,
            this.toolStripMenuItemVlc,
            this.toolStripSeparator1,
            this.toolStripMenuItemSetFormat,
            this.toolStripSeparator2,
            this.toolStripMenuItemSaveSeparateFiles,
            this.toolStripMenuItemSaveAlbumArtwork,
            this.toolStripMenuItemSaveHistory,
            this.toolStripMenuItemDisplayTrackPopup,
            this.toolStripMenuItemEmptyFileIfNoTrackPlaying,
            this.toolStripSeparator3,
            this.toolStripMenuItemExit});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(68, 220);
            // 
            // toolStripMenuItemSnipVersion
            // 
            this.toolStripMenuItemSnipVersion.Enabled = false;
            this.toolStripMenuItemSnipVersion.Name = "toolStripMenuItemSnipVersion";
            this.toolStripMenuItemSnipVersion.Size = new System.Drawing.Size(67, 22);
            this.toolStripMenuItemSnipVersion.Text = LocalizedMessages.SnipForm + AssemblyInformation.AssemblyShorterVersion;
            // 
            // toolStripMenuItemVlc
            // 
            this.toolStripMenuItemVlc.Name = "toolStripMenuItemVlc";
            this.toolStripMenuItemVlc.Size = new System.Drawing.Size(67, 22);
            this.toolStripMenuItemVlc.Text = LocalizedMessages.VLC;
            this.toolStripMenuItemVlc.Click += new System.EventHandler(this.PlayerSelectionCheck);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(64, 6);
            // 
            // toolStripMenuItemSetFormat
            // 
            this.toolStripMenuItemSetFormat.Name = "toolStripMenuItemSetFormat";
            this.toolStripMenuItemSetFormat.Size = new System.Drawing.Size(67, 22);
            this.toolStripMenuItemSetFormat.Text = LocalizedMessages.SetOutputFormat;
            this.toolStripMenuItemSetFormat.Click += new System.EventHandler(this.ToolStripMenuItemSetFormat_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(64, 6);
            // 
            // toolStripMenuItemSaveSeparateFiles
            // 
            this.toolStripMenuItemSaveSeparateFiles.Name = "toolStripMenuItemSaveSeparateFiles";
            this.toolStripMenuItemSaveSeparateFiles.Size = new System.Drawing.Size(67, 22);
            this.toolStripMenuItemSaveSeparateFiles.Text = LocalizedMessages.SaveInformationSeparately;
            this.toolStripMenuItemSaveSeparateFiles.Click += new System.EventHandler(this.ToolStripMenuItemSaveSeparateFiles_Click);
            // 
            // toolStripMenuItemSaveAlbumArtwork
            // 
            this.toolStripMenuItemSaveAlbumArtwork.Name = "toolStripMenuItemSaveAlbumArtwork";
            this.toolStripMenuItemSaveAlbumArtwork.Size = new System.Drawing.Size(67, 22);
            this.toolStripMenuItemSaveAlbumArtwork.Text = LocalizedMessages.SaveAlbumArtwork;
            this.toolStripMenuItemSaveAlbumArtwork.Click += new System.EventHandler(this.ToolStripMenuItemSaveAlbumArtwork_Click);
            // 
            // toolStripMenuItemSmall
            // 
            this.toolStripMenuItemSmall.Checked = true;
            this.toolStripMenuItemSmall.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemSmall.Name = "toolStripMenuItemSmall";
            this.toolStripMenuItemSmall.Size = new System.Drawing.Size(67, 22);
            this.toolStripMenuItemSmall.Text = LocalizedMessages.ImageResolutionSmall;
            this.toolStripMenuItemSmall.Click += new System.EventHandler(this.AlbumArtworkResolutionCheck);
            // 
            // toolStripMenuItemMedium
            // 
            this.toolStripMenuItemMedium.Name = "toolStripMenuItemMedium";
            this.toolStripMenuItemMedium.Size = new System.Drawing.Size(67, 22);
            this.toolStripMenuItemMedium.Text = LocalizedMessages.ImageResolutionMedium;
            this.toolStripMenuItemMedium.Click += new System.EventHandler(this.AlbumArtworkResolutionCheck);
            // 
            // toolStripMenuItemLarge
            // 
            this.toolStripMenuItemLarge.Name = "toolStripMenuItemLarge";
            this.toolStripMenuItemLarge.Size = new System.Drawing.Size(67, 22);
            this.toolStripMenuItemLarge.Text = LocalizedMessages.ImageResolutionLarge;
            this.toolStripMenuItemLarge.Click += new System.EventHandler(this.AlbumArtworkResolutionCheck);
            // 
            // toolStripMenuItemSaveHistory
            // 
            this.toolStripMenuItemSaveHistory.Name = "toolStripMenuItemSaveHistory";
            this.toolStripMenuItemSaveHistory.Size = new System.Drawing.Size(67, 22);
            this.toolStripMenuItemSaveHistory.Text = LocalizedMessages.SaveTrackHistory;
            this.toolStripMenuItemSaveHistory.Click += new System.EventHandler(this.ToolStripMenuItemSaveHistory_Click);
            // 
            // toolStripMenuItemDisplayTrackPopup
            // 
            this.toolStripMenuItemDisplayTrackPopup.Name = "toolStripMenuItemDisplayTrackPopup";
            this.toolStripMenuItemDisplayTrackPopup.Size = new System.Drawing.Size(67, 22);
            this.toolStripMenuItemDisplayTrackPopup.Text = LocalizedMessages.DisplayTrackPopup;
            this.toolStripMenuItemDisplayTrackPopup.Click += new System.EventHandler(this.ToolStripMenuItemDisplayTrackPopup_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(64, 6);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(67, 22);
            this.toolStripMenuItemExit.Text = LocalizedMessages.ExitApplication;
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.ToolStripMenuItemExit_Click);
            // 
            // toolStripMenuItemEmptyFileIfNoTrackPlaying
            // 
            this.toolStripMenuItemEmptyFileIfNoTrackPlaying.Checked = true;
            this.toolStripMenuItemEmptyFileIfNoTrackPlaying.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemEmptyFileIfNoTrackPlaying.Name = "toolStripMenuItemEmptyFileIfNoTrackPlaying";
            this.toolStripMenuItemEmptyFileIfNoTrackPlaying.Size = new System.Drawing.Size(67, 22);
            this.toolStripMenuItemEmptyFileIfNoTrackPlaying.Text = LocalizedMessages.EmptyFile;
            this.toolStripMenuItemEmptyFileIfNoTrackPlaying.Click += new System.EventHandler(this.ToolStripMenuItemEmptyFileIfNoTrackPlaying_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator.Name = "toolStripSeparator3";
            this.toolStripSeparator.Size = new System.Drawing.Size(64, 6);
            // 
            // timerScanTitle
            // 
            this.timerScanMediaPlayer.Enabled = false;
            this.timerScanMediaPlayer.Tick += new System.EventHandler(this.TimerScanMediaPlayer_Tick);
            // 
            // Snip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Icon = Properties.Resources.SnipIcon;
            this.Name = "Snip";
            this.Text = LocalizedMessages.SnipForm;
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}
