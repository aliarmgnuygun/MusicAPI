using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using Utilities.Utilities;


namespace Services
{
    public class AlbumManager : IAlbumService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly ISarkiService _sarkiManager;


        public AlbumManager(IRepositoryManager repoManager, ISarkiService sarkiManager)
        {
            _repoManager = repoManager;
            _sarkiManager = sarkiManager;

        }

        public Album CreateOneAlbum(Album album)
        {
            album.Ad = RandomGenerator.GenerateRandomString(10);
            album.CikisTarihi = RandomGenerator.GenerateRandomDate(new DateTime(1950, 01, 01));
            album.Sarkilar = new List<Sarki>();
            int sarkiSayisi = RandomGenerator.GenerateSarkiNumber(6, 15);

            _repoManager.Album.AddAlbums(album);
            _repoManager.Save();  
            for (int i = 0; i < sarkiSayisi; i++)
            {
                Sarki yeniSarki = _sarkiManager.CreateSarki(new Sarki 
                { 
                    AlbumId = album.Id,
                    SanatciId = album.SanatciId, 
                    Sanatci = album.Sanatci, 
                    Album = album 
                });
                album.Sarkilar.Add(yeniSarki);
            }
            _repoManager.Save();
            return album;
        }
    }
}
