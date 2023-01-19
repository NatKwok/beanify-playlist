using System;
using System.Data.Entity;
using System.Linq;

namespace Beanify_Playlist
{
    public class Playlist_DBContext : DbContext
    {
        // Your context has been configured to use a 'Playlist_DBContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Beanify_Playlist.Playlist_DBContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Playlist_DBContext' 
        // connection string in the application configuration file.
        public Playlist_DBContext()
            : base("name=Playlist_DBContext1")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<Playlist> MyPlaylists { get; set; }
      // public virtual DbSet<Songs> SongList { get; set; }
    }  

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}