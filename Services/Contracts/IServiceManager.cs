namespace Services.Contracts
{
    public interface IServiceManager
    {
        ISanatciService SanatciService { get; }
        IAlbumService AlbumService { get; }
        ISarkiService SarkiService { get; }
    }
}
