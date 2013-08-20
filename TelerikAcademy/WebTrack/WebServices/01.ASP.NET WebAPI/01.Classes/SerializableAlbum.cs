using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace _01.Classes
{
    [DataContract(Name="Album")]
    public class SerializableAlbum
    {
        public int AlbumId { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Producer { get; set; }

        [DataMember]
        public int Year { get; set; }

        [DataMember(Name = "artists")]
        public ICollection<EmbeddedArtist> Artists { get; set; }

        [DataMember(Name = "songs")]
        public ICollection<EmbeddedSong> Songs { get; set; }

        public SerializableAlbum()
        {
            this.Artists = new HashSet<EmbeddedArtist>();
            this.Songs = new HashSet<EmbeddedSong>();
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

        public void AddSongs(List<string> songs)
        {
            List<EmbeddedSong> newSongs = new List<EmbeddedSong>();
            foreach (var song in songs)
            {
                newSongs.Add(new EmbeddedSong() { Name = song });
            }

            this.Songs = newSongs;
        }
    }

    [DataContract(Name = "artist")]
    public class EmbeddedArtist
    {
        [DataMember(Name="name")]
        public string Name { get; set; }
    }
}
