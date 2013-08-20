using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Classes
{
    public class Album
    {
        public int AlbumId { get; set; }

        public string Title { get; set; }

        public string Producer { get; set; }

        public int Year { get; set; }

        private ICollection<Artist> artists;

        private ICollection<Song> songs;

        public Album()
        {
            this.artists = new HashSet<Artist>();
            this.songs = new HashSet<Song>();
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

        public virtual ICollection<Song> Songs
        {
            get
            {
                return this.songs;
            }

            set
            {
                this.songs = value;
            }
        }
    }
}
