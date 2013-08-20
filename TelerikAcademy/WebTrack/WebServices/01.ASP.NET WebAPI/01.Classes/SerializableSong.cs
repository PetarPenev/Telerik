using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace _01.Classes
{
    [DataContract(Name="Song")]
    public class SerializableSong
    {
        public int SongId { get; set; }

        [DataMember]
        public int Year { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Genre { get; set; }

        [DataMember(Name="songs")]
        public IEnumerable<EmbeddedArtist> Artists { get; set; }

        [DataMember(Name="albums")]
        public IEnumerable<EmbeddedAlbum> Albums { get; set; }

        public SerializableSong()
        {
            this.Artists = new List<EmbeddedArtist>();
            this.Albums = new List<EmbeddedAlbum>();
        }

        public void AddArtists(List<string> artists)
        {
            List<EmbeddedArtist> newArtists = new List<EmbeddedArtist>();
            foreach (var artist in artists)
            {
                newArtists.Add(new EmbeddedArtist() { Name = artist });
            }

            this.Artists = newArtists;
        }

        public void AddAlbums(List<string> albums)
        {
            List<EmbeddedAlbum> newAlbums = new List<EmbeddedAlbum>();
            foreach (var album in albums)
            {
                newAlbums.Add(new EmbeddedAlbum() { Name = album });
            }

            this.Albums = newAlbums;
        }
    }
}
