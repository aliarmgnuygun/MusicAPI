using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<ISanatciRepository> _sanatciRepository;
        private readonly Lazy<IAlbumRepository> _albumRepository;
        private readonly Lazy<ISarkiRepository> _sarkiRepository;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _sanatciRepository = new Lazy<ISanatciRepository>(() => new SanatciRepository(_context));
            _albumRepository = new Lazy<IAlbumRepository>(() => new AlbumRepository(_context));
            _sarkiRepository = new Lazy<ISarkiRepository>(() => new SarkiRepository(_context));
        }
        public ISanatciRepository Sanatci => _sanatciRepository.Value;

        public IAlbumRepository Album => _albumRepository.Value;

        public ISarkiRepository Sarki => _sarkiRepository.Value;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
