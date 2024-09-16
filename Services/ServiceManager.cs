using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly ISanatciService sanatciService;
        private readonly IAlbumService albumService;
        private readonly ISarkiService sarkiService;

        public ServiceManager(ISanatciService sanatciService, IAlbumService albumService, ISarkiService sarkiService)
        {
            this.sanatciService = sanatciService;
            this.albumService = albumService;
            this.sarkiService = sarkiService;
        }


        public ISanatciService SanatciService => sanatciService;
        public IAlbumService AlbumService => albumService;
        public ISarkiService SarkiService => sarkiService;
    }
}
