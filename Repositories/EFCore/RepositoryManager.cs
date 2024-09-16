using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly ISanatciRepository _sanatciRepository;
        private readonly IAlbumRepository _albumRepository;
        private readonly ISarkiRepository _sarkiRepository;

        public RepositoryManager(RepositoryContext context, ISanatciRepository sanatciRepository, IAlbumRepository albumRepository, ISarkiRepository sarkiRepository)
        {
            _context = context;
            _sanatciRepository = sanatciRepository;
            _albumRepository = albumRepository;
            _sarkiRepository = sarkiRepository;
        }
        public ISanatciRepository Sanatci => _sanatciRepository;

        public IAlbumRepository Album => _albumRepository;

        public ISarkiRepository Sarki => _sarkiRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
