//using DragonOgg.MediaPlayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TagLib;

namespace OsuSongFormatter
{
    public partial class frmOsuSongFormatter : Form
    {
        private int _intNbSong = 0;
        private int _intCurSong = 0;

        private delegate void DeleguePgbTransfert();

        private delegate void DelegueLblTransfert();

        public frmOsuSongFormatter()
        {
            InitializeComponent();
        }

        private void SelectSongFolder(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdOsuSongsFolder = new FolderBrowserDialog();
            DialogResult dgResult = fbdOsuSongsFolder.ShowDialog();

            if (dgResult == DialogResult.OK)
            {
                txtSongFolder.Text = fbdOsuSongsFolder.SelectedPath;

                String[] strSongsFolders = Directory.GetDirectories(fbdOsuSongsFolder.SelectedPath);

                Array.Sort(strSongsFolders, StringComparer.CurrentCultureIgnoreCase);

                String[] strSongsNameList = GetSongsName(strSongsFolders);

                lbListOfSongs.Items.Clear();
                lbListOfSongs.Items.AddRange(strSongsNameList);
                lblTransfert.Text = "0/" + strSongsNameList.Length;
                pgbTransfert.Maximum = strSongsNameList.Length;
                pgbTransfert.Step = 1;
            }
        }

        private void SelectDestinationFolder(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdDestination = new FolderBrowserDialog();
            DialogResult dgResult = fbdDestination.ShowDialog();

            if (dgResult == DialogResult.OK)
            {
                txtDestinationFolder.Text = fbdDestination.SelectedPath;
            }
        }

        private String[] GetSongsName(String[] strSongsFolders)
        {
            String[] strSongsNameList = new String[strSongsFolders.Length];

            for (int i = 0; i < strSongsFolders.Length; i++)
            {
                strSongsNameList[i] = GetSongName(new DirectoryInfo(strSongsFolders[i]));
            }

            return strSongsNameList;
        }

        private void btnTransferAndFormat_Click(object sender, EventArgs e)
        {
            if (txtSongFolder.Text != "")
            {
                if (txtDestinationFolder.Text != "")
                {
                    Thread thTransfertAndFormat = new Thread(TransfertAndFormat);
                    thTransfertAndFormat.Start();
                }
                else
                {
                    MessageBox.Show("Please select the destination folder");
                    btnDestinationFolder.Focus();
                }
            }
            else
            {
                MessageBox.Show("Please select the osu song folder!");
                btnSongFolder.Focus();
            }


        }

        private string GetSongName(DirectoryInfo diSongFolder)
        {
            string strSongName = "";
            if (Char.IsNumber(diSongFolder.Name[0]))
            {
                int intSpacePos = diSongFolder.Name.IndexOf(' ');
                if (intSpacePos != -1)
                {
                    strSongName = diSongFolder.Name.Substring(intSpacePos + 1);
                }
                else
                {
                    strSongName = diSongFolder.Name;
                }
            }
            else
            {
                strSongName = diSongFolder.Name;
            }
            return strSongName;
        }

        private void TransfertAndFormat()
        {
            DirectoryInfo diOsuSongFolder = new DirectoryInfo(txtSongFolder.Text);
            DirectoryInfo diDestinationFolder = new DirectoryInfo(txtDestinationFolder.Text);
            DirectoryInfo[] diSongsFolderList = diOsuSongFolder.GetDirectories();
            DeleguePgbTransfert dgPgbTransfertUpdate = delegate { this.pgbTransfert.PerformStep(); this.pgbTransfert.Refresh(); };
            DelegueLblTransfert dgLblTransfertUpdate = delegate { this.lblTransfert.Text = _intCurSong + "/" + _intNbSong; ; this.lblTransfert.Refresh(); };
            DeleguePgbTransfert dgPgbTransfertReset = delegate { this.pgbTransfert.Value = 0; this.pgbTransfert.Refresh(); };
            DelegueLblTransfert dgLblTransfertReset = delegate { _intCurSong = 0; this.lblTransfert.Text = "0/" + _intNbSong; ; this.lblTransfert.Refresh(); };
            _intNbSong = diSongsFolderList.Length;

            this.Invoke(dgPgbTransfertReset);
            this.Invoke(dgLblTransfertReset);

            foreach (DirectoryInfo diSongFolder in diSongsFolderList)
            {
                bool blnImgFound = false;
                IPicture ipImg = new Picture();
                if (diSongFolder.Name != "tutorial")
                {
                    foreach (FileInfo fiFileInFolder in diSongFolder.GetFiles())
                    {
                        if (fiFileInFolder.Extension == ".jpg")
                        {
                            blnImgFound = true;
                            ipImg = new Picture(fiFileInFolder.FullName);
                        }

                        if (fiFileInFolder.Extension == ".mp3" || fiFileInFolder.Extension == ".ogg")
                        {
                            if (!new FileInfo(diDestinationFolder.FullName + "\\" + GetSongName(diSongFolder) + fiFileInFolder.Extension).Exists)
                            {
                                String strSongName = GetSongName(diSongFolder);
                                String strPath = diDestinationFolder.FullName + "\\" + strSongName + fiFileInFolder.Extension;
                                System.IO.File.Copy(fiFileInFolder.FullName, strPath, false);

                                String[] strArtistAndTitle = strSongName.Split(new string[1] { " - " }, StringSplitOptions.None);
                                String strAlbum = "Osu!";
                                String[] strPerformers = new String[1] { strArtistAndTitle[0] };

                                if (fiFileInFolder.Extension == ".mp3")
                                {
                                    TagLib.File fMpegSong = TagLib.Mpeg.File.Create(strPath);
                                    TagEditor(fMpegSong, strAlbum, strPerformers, strArtistAndTitle, blnImgFound, ipImg);

                                }
                                else
                                {
                                    if (fiFileInFolder.Extension == ".ogg")
                                    {
                                        TagLib.File fOggSong = TagLib.Ogg.File.Create(strPath);
                                        TagEditor(fOggSong, strAlbum, strPerformers, strArtistAndTitle, blnImgFound, ipImg);
                                    }
                                }
                            }
                        }
                    }
                }
                _intCurSong++;
                this.Invoke(dgLblTransfertUpdate);
                this.Invoke(dgPgbTransfertUpdate);
            }
            MessageBox.Show("Operation terminated successfully!");
        }

        private void TagEditor(TagLib.File fSong, String strAlbum, String[] strPerformers, String[] strArtistAndTitle, bool blnImgFound, IPicture ipImg)
        {
            try
            {
                fSong.Tag.Album = strAlbum;
                fSong.Tag.Performers = strPerformers;
                if (strArtistAndTitle.Length == 2)
                {
                    fSong.Tag.Title = strArtistAndTitle[1];
                }
                else
                {
                    fSong.Tag.Title = strArtistAndTitle[0];
                }
                if (blnImgFound)
                {
                    fSong.Tag.Pictures = new IPicture[] { ipImg };
                }
                fSong.Save();
            }
            catch (Exception ex)
            {
                lbError.Items.Add(ex.ToString());
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This application format and copy songs from your Osu! repository for you to add to your library and have good title and tags.\n" +
                            "Original Osu .mp3 and .ogg files don't have the good title and they don't have any tags.\n" +
                            "This application function as follow :\n" +
                            "1-You select the Osu! song folder.\n" +
                            "2-You select the destination where you want to copy your songs.\n" +
                            "3-The title of all the song will appear is the listbox.\n" +
                            "   (The titles are now formatted, this format is:\n" +
                            "   3.1-If there is a number in the first letter of the name of the folder of the song, all the caracter before the first space is deleted.\n" +
                            "       (If there's no Osu! track number and the name of the artist begin with a number, it'll delete the first word of the artist name).\n" +
                            "   3.2-Then the artist name is all the caracters before the ' - '.\n" +
                            "   3.3-The song title is all the caracters after the ' - '.\n" +
                            "       (If there's only one of the artist and the title, both will be the same.))\n" +
                            "4-You click on the button Transfer and format.\n" +
                            "5-The files (except the tutorial song that is put aside because it contains many .mp3 files and it is not a very good song to put in your library) will be copied to your destination folder with the name of the file like this :\n" +
                            "   Artist - Title\n" +
                            "   (Already existing files with the same name will not be replaced.)\n" +
                            "6-The artist and song title tag will be added to the new files, the album title will be Osu!.\n" +
                            "7-If there is a .jpg picture in the folder of the song, it'll be added to the tag of the new song file.\n" +
                            "8-A progress bar will indicate the progression of the transfer.\n" +
                            "9-If there are errors, they'll be in the error listbox.\n" +
                            "10-I suggest you take a look at the files generated before adding them to your library and correct some flaws that happen because all Osu! songs don't have the same naming format."
                             , "About Osu Song Formatter", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
