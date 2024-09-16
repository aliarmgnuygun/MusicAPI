using Entities.Models;

namespace Repositories.Contracts
{
    public interface IAlbumRepository
    {
        void AddAlbums(Album album);
    }
}
