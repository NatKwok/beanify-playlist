using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanify_Playlist
{
    public class Songs
    {
        public Songs() { }

        public Songs(string songname, string artist, int plays, int lengthinsec, string albumname) 
        {
            SongName= songname;
            Artist= artist;
            Plays= plays;
            Lengthinsec= lengthinsec;
            AlbumName = albumname;
        }

        public int SongID { get; set; }

        [Required]
        [StringLength(50)]
        public string SongName { get; set;}

        [Required]
        [StringLength(50)]
        public string Artist { get; set;}

        [Required]
        public int Plays { get; set;}

        [Required]
        public int Lengthinsec { get; set;}

        [Required]
        [StringLength(50)]
        public string AlbumName { get; set;}
    }
}
