using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
using System.Windows.Shapes;

namespace Beanify_Playlist
{
    /// <summary>
    /// Interaction logic for editWindow.xaml
    /// </summary>
    public partial class editWindow : Window
    {
        Playlist_DBContext db = new Playlist_DBContext();

        public editWindow()
        {
            InitializeComponent();
            try
            {
               LvEditPlaylist.ItemsSource = db.MyPlaylists.ToList();
            }

            catch (SystemException ex)
            {
                MessageBox.Show(this, "Error reading from database\n" + ex.Message, "Fatal error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
                Environment.Exit(1);
            }
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Playlist selectedPlaylist = LvEditPlaylist.SelectedItem as Playlist;

                if (selectedPlaylist == null) return;

                selectedPlaylist.Title = TbxTitle.Text;
                db.SaveChanges();
                MessageBox.Show("Playlist Updated");
                this.Close();
                

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("DB error" + ex.Message);
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var errors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in errors.ValidationErrors)
                    {
                        string errorMessage = validationError.ErrorMessage;
                        MessageBox.Show(errorMessage);
                    }
                }
            }
        }

        private void TbxTitle_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void LvEditPlaylist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
