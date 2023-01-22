using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Beanify_Playlist
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Playlist_DBContext db = new Playlist_DBContext();

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                LvPlaylist.ItemsSource = db.MyPlaylists.ToList();
               // LvSonglist.ItemsSource = db.SongList.ToList();
            }

            catch (SystemException ex)
            {
                MessageBox.Show(this, "Error reading from database\n" + ex.Message, "Fatal error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
                Environment.Exit(1);
            }
        }

        private void LvPlaylist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddPlaylist_Click(object sender, RoutedEventArgs e)
        {
            addWindow addWindow = new addWindow();
            addWindow.Show();
        }
        private void DeletePlaylist_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Playlist selectedPlaylist = LvPlaylist.SelectedItem as Playlist;
                db.MyPlaylists.Remove(selectedPlaylist);
                db.SaveChanges();
                LvPlaylist.ItemsSource = db.MyPlaylists.ToList();
                LvPlaylist.Items.Refresh();
                LvPlaylist.SelectedIndex = -1;
                MessageBox.Show("Playlist Deleted");
            }
            catch (SystemException ex)
            {
                MessageBox.Show(this, "Error reading from database\n" + ex.Message, "Database error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(1);
            }
        }

        private void LvSonglist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddSong_Click(object sender, RoutedEventArgs e)
        {

        }
        private void DeleteSong_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Play Test Success");
            myMediaElement.Play();
        }
        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            myMediaElement.Pause();

        }
        private void Skip_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void sliProgress_ValueChanged(object sender, RoutedEventArgs e)
        {

        }

        private void sliProgress_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int SliderValue = (int)sliProgress.Value;

            TimeSpan ts = new TimeSpan(0, 0, 0, 0, SliderValue);
            myMediaElement.Position = ts;
        }

        private void Element_MediaOpened(object sender, EventArgs e)
        {
            sliProgress.Maximum = myMediaElement.NaturalDuration.TimeSpan.TotalMilliseconds;
        }

        // When the media playback is finished. Stop() the media to seek to media start.
        private void Element_MediaEnded(object sender, EventArgs e)
        {
            myMediaElement.Stop();
        }
    }
}
