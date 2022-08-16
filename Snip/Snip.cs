#region File Information
/*
 * Copyright (C) 2012-2018 David Rudie
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02111, USA.
 */
#endregion

namespace Winter
{
    using System;
    using System.Globalization;
    using System.Reflection;
    using System.Resources;
    using System.Windows.Forms;
    using Microsoft.Win32;

    public partial class Snip : Form
    {
        #region Fields

        KeyboardHook keyboardHook = new KeyboardHook();

        #endregion

        #region Constructor

        public Snip()
        {
            Globals.ResourceManager = ResourceManager.CreateFileBasedResourceManager("Strings", Application.StartupPath + @"/Resources", null);

            // Immediately set all of the localization
            SetLocalizedMessages();

            Globals.DefaultTrackFormat = LocalizedMessages.TrackFormat;
            Globals.DefaultSeparatorFormat = " " + LocalizedMessages.SeparatorFormat + " ";
            Globals.DefaultArtistFormat = LocalizedMessages.ArtistFormat;
            Globals.DefaultAlbumFormat = LocalizedMessages.AlbumFormat;

            this.InitializeComponent();

            this.Load += new EventHandler(this.Snip_Load);
            this.FormClosing += new FormClosingEventHandler(this.Snip_FormClosing);

            // Set the icon of the system tray icon.
            this.notifyIcon.Icon = Properties.Resources.SnipIcon;
            Globals.SnipNotifyIcon = this.notifyIcon;

            // Minimize the main window.
            this.WindowState = FormWindowState.Minimized;

            // Create a blank media player so that the initial call to Unload() won't fuck shit up.
            Globals.CurrentPlayer = new MediaPlayer();

            this.LoadSettings();
            this.timerScanMediaPlayer.Enabled = true;

            // Register global hotkeys
            this.ToggleHotkeys();

            if (CheckVersion.IsNewVersionAvailable())
            {
                this.toolStripMenuItemSnipVersion.Text = LocalizedMessages.NewVersionAvailable;
                this.toolStripMenuItemSnipVersion.Enabled = true;
                this.toolStripMenuItemSnipVersion.Click += ToolStripMenuItemSnipVersion_Click;
            }
        }

        #endregion

        #region Methods

        private static void SetLocalizedMessages()
        {
            LocalizedMessages.SnipForm = "SnipForm";
            LocalizedMessages.NewVersionAvailable = "NewVersionAvailable";
            LocalizedMessages.VLC = "VLC";
            LocalizedMessages.WindowsMediaPlayer = "WindowsMediaPlayer";
            LocalizedMessages.SwitchedToPlayer = "SwitchedToPlayer";
            LocalizedMessages.PlayerIsNotRunning = "PlayerIsNotRunning";
            LocalizedMessages.NoTrackPlaying = "NoTrackPlaying";
            LocalizedMessages.SetOutputFormat = "SetOutputFormat";
            LocalizedMessages.SaveInformationSeparately = "SaveInformationSeparately";
            LocalizedMessages.SaveAlbumArtwork = "SaveAlbumArtwork";
            LocalizedMessages.ImageResolutionSmall = "ImageResolutionSmall";
            LocalizedMessages.ImageResolutionMedium = "ImageResolutionMedium";
            LocalizedMessages.ImageResolutionLarge = "ImageResolutionLarge";
            LocalizedMessages.SaveTrackHistory = "SaveTrackHistory";
            LocalizedMessages.DisplayTrackPopup = "DisplayTrackPopup";
            LocalizedMessages.EmptyFile = "EmptyFile";
            LocalizedMessages.EnableHotkeys = "EnableHotkeys";
            LocalizedMessages.ExitApplication = "ExitApplication";
            LocalizedMessages.SetOutputFormatForm = "SetOutputFormatForm";
            LocalizedMessages.SetTrackFormat = "SetTrackFormat";
            LocalizedMessages.SetSeparatorFormat = "SetSeparatorFormat";
            LocalizedMessages.SetArtistFormat = "SetArtistFormat";
            LocalizedMessages.SetAlbumFormat = "SetAlbumFormat";
            LocalizedMessages.ButtonDefaults = "ButtonDefaults";
            LocalizedMessages.ButtonSave = "ButtonSave";
            LocalizedMessages.TrackFormat = "TrackFormat";
            LocalizedMessages.SeparatorFormat = "SeparatorFormat";
            LocalizedMessages.ArtistFormat = "ArtistFormat";
            LocalizedMessages.AlbumFormat = "AlbumFormat";
        }

        private void KeyboardHook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            switch (e.Key)
            {
                case Keys.OemOpenBrackets:
                    Globals.CurrentPlayer.ChangeToPreviousTrack();
                    break;

                case Keys.OemCloseBrackets:
                    Globals.CurrentPlayer.ChangeToNextTrack();
                    break;

                case Keys.OemMinus:
                    Globals.CurrentPlayer.DecreasePlayerVolume();
                    break;

                case Keys.Oemplus:
                    Globals.CurrentPlayer.IncreasePlayerVolume();
                    break;

                case Keys.M:
                    Globals.CurrentPlayer.MutePlayerAudio();
                    break;

                case Keys.Enter:
                    Globals.CurrentPlayer.PlayOrPauseTrack();
                    break;

                case Keys.P:
                    Globals.CurrentPlayer.PauseTrack();
                    break;

                case Keys.Back:
                    Globals.CurrentPlayer.StopTrack();
                    break;
            }
        }

        private void Snip_Load(object sender, EventArgs e)
        {
            // Hide the window from ever showing.
            this.Hide();
        }

        private void Snip_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Empty file, clear artwork and save settings automatically when the form is being closed.
            TextHandler.UpdateTextAndEmptyFilesMaybe(LocalizedMessages.NoTrackPlaying);
            Globals.CurrentPlayer.SaveBlankImage();
            Settings.Save();
        }

        private void LoadSettings()
        {
            Settings.Load();

            this.TogglePlayer(Globals.PlayerSelection);

            this.toolStripMenuItemSaveSeparateFiles.Checked = Globals.SaveSeparateFiles;
            this.toolStripMenuItemSaveAlbumArtwork.Checked = Globals.SaveAlbumArtwork;

            this.ToggleArtwork(Globals.ArtworkResolution);

            this.toolStripMenuItemSaveHistory.Checked = Globals.SaveHistory;
            this.toolStripMenuItemDisplayTrackPopup.Checked = Globals.DisplayTrackPopup;
            this.toolStripMenuItemEmptyFileIfNoTrackPlaying.Checked = Globals.EmptyFileIfNoTrackPlaying;
        }

        private void ToggleHotkeys()
        {
            if (this.keyboardHook != null)
            {
                this.keyboardHook.Dispose();
                this.keyboardHook = null;
            }
        }

        private void PlayerSelectionCheck(object sender, EventArgs e)
        {
            if (sender == this.toolStripMenuItemVlc)
            {
                this.TogglePlayer(Globals.MediaPlayerSelection.VLC);
            }
        }

        private void TogglePlayer(Globals.MediaPlayerSelection player)
        {
            this.toolStripMenuItemVlc.Checked        = player == Globals.MediaPlayerSelection.VLC;

            Globals.CurrentPlayer.Unload();
            string playerName = string.Empty;

            switch (player)
            {
                case Globals.MediaPlayerSelection.VLC:
                    Globals.CurrentPlayer = new VLC();
                    playerName = LocalizedMessages.VLC;
                    break;
                default:
                    return;
            }

            Globals.CurrentPlayer.Load();

            Globals.PlayerSelection = player;
            TextHandler.UpdateTextAndEmptyFilesMaybe(
                string.Format(
                    CultureInfo.InvariantCulture,
                    LocalizedMessages.SwitchedToPlayer,
                    playerName));
        }

        private void ToolStripMenuItemSaveSeparateFiles_Click(object sender, EventArgs e)
        {
            this.toolStripMenuItemSaveSeparateFiles.Checked = !this.toolStripMenuItemSaveSeparateFiles.Checked;
            Globals.SaveSeparateFiles = this.toolStripMenuItemSaveSeparateFiles.Checked;
        }

        private void ToolStripMenuItemSaveAlbumArtwork_Click(object sender, EventArgs e)
        {
            this.toolStripMenuItemSaveAlbumArtwork.Checked = !this.toolStripMenuItemSaveAlbumArtwork.Checked;
            Globals.SaveAlbumArtwork = this.toolStripMenuItemSaveAlbumArtwork.Checked;
        }

        private void ToolStripMenuItemSaveHistory_Click(object sender, EventArgs e)
        {
            this.toolStripMenuItemSaveHistory.Checked = !this.toolStripMenuItemSaveHistory.Checked;
            Globals.SaveHistory = this.toolStripMenuItemSaveHistory.Checked;
        }

        private void ToolStripMenuItemDisplayTrackPopup_Click(object sender, EventArgs e)
        {
            this.toolStripMenuItemDisplayTrackPopup.Checked = !this.toolStripMenuItemDisplayTrackPopup.Checked;
            Globals.DisplayTrackPopup = this.toolStripMenuItemDisplayTrackPopup.Checked;
        }

        private void ToolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TimerScanMediaPlayer_Tick(object sender, EventArgs e)
        {
            // Make sure this is set before starting the timer.
            //if (Globals.DebuggingIsEnabled)
            //{
                //Debug.MeasureMethod(Globals.CurrentPlayer.Update); // Writes a LOT of data
            //}
            //else
            //{
                Globals.CurrentPlayer.Update();
            //}
        }

        private void ToolStripMenuItemSetFormat_Click(object sender, EventArgs e)
        {
            OutputFormat outputFormat = null;

            try
            {
                outputFormat = new OutputFormat();
                outputFormat.ShowDialog();
            }
            finally
            {
                if (outputFormat != null)
                {
                    outputFormat.Dispose();
                }
            }

            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(
                string.Format(
                    CultureInfo.InvariantCulture,
                    "SOFTWARE\\{0}\\{1}",
                    AssemblyInformation.AssemblyTitle,
                    Assembly.GetExecutingAssembly().GetName().Version.Major));

            if (registryKey != null)
            {
                Globals.TrackFormat = Convert.ToString(registryKey.GetValue("Track Format", Globals.DefaultTrackFormat), CultureInfo.CurrentCulture);

                Globals.SeparatorFormat = Convert.ToString(registryKey.GetValue("Separator Format", Globals.DefaultSeparatorFormat), CultureInfo.CurrentCulture);

                Globals.ArtistFormat = Convert.ToString(registryKey.GetValue("Artist Format", Globals.DefaultArtistFormat), CultureInfo.CurrentCulture);

                Globals.AlbumFormat = Convert.ToString(registryKey.GetValue("Album Format", Globals.DefaultAlbumFormat), CultureInfo.CurrentCulture);

                registryKey.Close();
            }
        }
        
        private void AlbumArtworkResolutionCheck(object sender, EventArgs e)
        {
            if (sender == this.toolStripMenuItemSmall)
            {
                this.ToggleArtwork(Globals.AlbumArtworkResolution.Small);
            }
            else if (sender == this.toolStripMenuItemMedium)
            {
                this.ToggleArtwork(Globals.AlbumArtworkResolution.Medium);
            }
            else if (sender == this.toolStripMenuItemLarge)
            {
                this.ToggleArtwork(Globals.AlbumArtworkResolution.Large);
            }
        }

        private void ToggleArtwork(Globals.AlbumArtworkResolution artworkResolution)
        {
            this.toolStripMenuItemSmall.Checked  = artworkResolution == Globals.AlbumArtworkResolution.Small;
            this.toolStripMenuItemMedium.Checked = artworkResolution == Globals.AlbumArtworkResolution.Medium;
            this.toolStripMenuItemLarge.Checked  = artworkResolution == Globals.AlbumArtworkResolution.Large;
            Globals.ArtworkResolution = artworkResolution;
        }

        private void ToolStripMenuItemEmptyFileIfNoTrackPlaying_Click(object sender, EventArgs e)
        {
            this.toolStripMenuItemEmptyFileIfNoTrackPlaying.Checked = !this.toolStripMenuItemEmptyFileIfNoTrackPlaying.Checked;
            Globals.EmptyFileIfNoTrackPlaying = this.toolStripMenuItemEmptyFileIfNoTrackPlaying.Checked;
        }

        private void ToolStripMenuItemSnipVersion_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/dlrudie/Snip/releases/latest");
        }

        #endregion
    }
}
