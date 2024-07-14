using System;
using System.Collections.Generic;

namespace musicalbums
{
	public class AlbumController
	{
		public AlbumController(InMemoryAlbumRepository inMemoryAlbumRepository)
		{
		}

        internal void AddAlbum(string title, string artist, int releaseYear, List<string> tracks)
        {
            throw new NotImplementedException();
        }

        internal void DeleteAlbum(int id)
        {
            throw new NotImplementedException();
        }

        internal void EditAlbum(int id, string title, string artist, int releaseYear, List<string> tracks)
        {
            throw new NotImplementedException();
        }

        internal object GetAllAlbums()
        {
            throw new NotImplementedException();
        }
    }
}

