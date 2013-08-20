using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Classes
{
    public class Artist
    {
        public int ArtistId { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public DateTime DateOfBirth { get; set; }

        private ICollection<Song> songs;

        private ICollection<Album> albums;

        public Artist()
        {
            this.albums = new HashSet<Album>();
            this.songs = new HashSet<Song>();
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
