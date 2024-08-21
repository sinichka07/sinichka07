using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Avalonia.Interactivity;

namespace LatestVersionOfMusicAlbums
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public int Year { get; set; }
        public List<string> Tracks { get; set; }

        public Album()
        {
            Tracks = new List<string>();
        }
    }

    public class AlbumModel
    {
        private List<Album> albums = new List<Album>();
        public List<Album> GetAlbums()
        {
            return albums;
        }
        public void AddAlbum(Album album)
        {
            albums.Add(album);
        }
        public void RemoveAlbum(int id)
        {
            albums.RemoveAll(albums => albums.Id == id);
        }

        public void EditAlbum(int id, Album updatedAlbum)
        {
            var existingAlbum = model.GetAlbums().FirstOrDefault(a => a.Id == id);
            if (existingAlbum != null)
            {
                existingAlbum.Title = updatedAlbum.Title;
                existingAlbum.Artist = updatedAlbum.Artist;
                existingAlbum.Year = updatedAlbum.Year;

                LoadAlbums();
            }
            else
            {
                Console.WriteLine("Album was not found");
            }
        }
    }
    
}
