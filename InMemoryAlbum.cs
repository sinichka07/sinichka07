using System.Collections.Generic;
using System.Linq;

public class InMemoryAlbumRepository : IAlbumRepository
{
    private readonly List<Album> _albums = new List<Album>();
    private int _nextId = 1;

    public void AddAlbum(Album album)
    {
        album.Id = _nextId++;
        _albums.Add(album);
    }

    public void EditAlbum(Album album)
    {
        var existingAlbum = GetAlbumById(album.Id);
        if (existingAlbum != null)
        {
            existingAlbum.Title = album.Title;
            existingAlbum.Artist = album.Artist;
            existingAlbum.ReleaseYear = album.ReleaseYear;
            existingAlbum.Tracks = album.Tracks;
        }
    }

    public void DeleteAlbum(int albumId)
    {
        var album = GetAlbumById(albumId);
        if (album != null)
        {
            _albums.Remove(album);
        }
    }

    public Album GetAlbumById(int albumId)
    {
        return _albums.FirstOrDefault(a => a.Id == albumId);
    }

    public List<Album> GetAllAlbums()
    {
        return _albums;
    }
}
