using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _01.Classes
{
    [DataContract(Name="Artist")]
    public class SerializableArtist
    {
        public int ArtistId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public DateTime DateOfBirth { get; set; }

        [DataMember(Name="songs")]
        public IEnumerable<EmbeddedSong> Songs { get; set; }

        [DataMember(Name="albums")]
        public IEnumerable<EmbeddedAlbum> Albums { get; set; }

        public SerializableArtist()
        {
            this.Songs = new List<EmbeddedSong>();
            this.Albums = new List<EmbeddedAlbum>();
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

    [DataContract(Name = "song")]
    public class EmbeddedSong
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }

    [DataContract(Name = "album")]
    public class EmbeddedAlbum
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
