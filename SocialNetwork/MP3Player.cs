using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxWMPLib;
using System.IO;

namespace SocialNetwork
{
    public partial class MP3Player : Form
    {
      private String[] arraySongs = { "System of a Down - Bounce", "System of a Down - Chop Suey!", "System of a Down - Toxicity", "Incubus - Drive", "Incubus - Love Hurts" };
      public MP3Player()
        {
            InitializeComponent();
            for (int i = 0; i < arraySongs.Length; i++)
            {
                songsBox.Rows.Add(arraySongs[i] + ".mp3");
            }
        }

        private void axWindowsMediaPlayer_Enter(object sender, EventArgs e)
        {
            axWindowsMediaPlayer.Ctlcontrols.play();
            axWindowsMediaPlayer.Ctlcontrols.pause();
            axWindowsMediaPlayer.Ctlcontrols.next();
            axWindowsMediaPlayer.Ctlcontrols.stop();
            axWindowsMediaPlayer.Ctlcontrols.previous();
            axWindowsMediaPlayer.Ctlcontrols.fastForward();
            axWindowsMediaPlayer.Ctlcontrols.fastReverse();
        }

        private void songsBox_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            axWindowsMediaPlayer.URL = Path.GetFullPath("..\\..\\utils\\mp3\\" + songsBox.CurrentCell.Value.ToString());
            axWindowsMediaPlayer.Ctlcontrols.play();
        }

       

    }
}
