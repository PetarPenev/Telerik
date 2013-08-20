using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Classes
{
    public class Song
    {
        public int SongId { get; set; }

        public int Year { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        private ICollection<Artist> artists;

        private ICollection<Album> albums;

        public Song()
        {
            this.albums = new HashSet<Album>();
            this.artists = new HashSet<Artist>();
        }

        public virtual ICollection<Album> Albums
        {
            get
            {
                return this.albums;
            }

            set
            {
                this.albums = value;
            }
        }

        public virtual ICollection<Artist> Artists
        {
            get
            {
                return this.artists;
            }

            set
            {
                this.artists = value;
            }
        }
    }
}
