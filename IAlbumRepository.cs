using System.Collections.Generic;

public interface IAlbumRepository
{
    void AddAlbum(Album album);
    void EditAlbum(Album album);
    void DeleteAlbum(int albumId);
    Album GetAlbumById(int albumId);
    List<Album> GetAllAlbums();
}
