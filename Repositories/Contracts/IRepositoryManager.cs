namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        ISanatciRepository Sanatci { get; }
        IAlbumRepository Album { get; }
        ISarkiRepository Sarki { get; }
        void Save();

    }
}
