using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Beanify_Playlist
{
    public class Playlist
    {
        public Playlist() { }

        public Playlist(string cover, string title, int songcount, int totalplays)
        {
            Cover = cover;
            Title = title;
            Songcount = songcount;
            Totalplays = totalplays;
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Cover { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        public int Songcount { get; set; }

        [Required]
        public int Totalplays { get; set; }


    }
}
