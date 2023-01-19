using System;
using System.Windows;
using System.Windows.Controls;

namespace Beanify_Playlist
{
    /// <summary>
    /// Interaction logic for addWindow.xaml
    /// </summary>
    public partial class addWindow : Window
    {
        Playlist_DBContext db = new Playlist_DBContext();

        public addWindow()
        {
            InitializeComponent();
        }
        // (string cover, string title, int songcount, int totalplays)

        private void Tbx_playlisttitle_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Cb_Songs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void addPlaylist_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                Playlist newPlaylist = new Playlist("Test Cover", Tbx_playlisttitle.Text, 3, 10);
                db.MyPlaylists.Add(newPlaylist);
                db.SaveChanges();
                MessageBox.Show("Playlist Added");
                this.Close();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("DB error" + ex.Message);
            }
            catch (SystemException ex)
            {
                MessageBox.Show(this, "Error reading from database\n" + ex.Message, "Database error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(1);
            }
        }
    }
}
