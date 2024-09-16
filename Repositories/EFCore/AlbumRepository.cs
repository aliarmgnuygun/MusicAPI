using Entities.Models;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class AlbumRepository : RepositoryBase<Album>, IAlbumRepository
    {
        public AlbumRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public void AddAlbums(Album album) => Create(album);
    }
}
