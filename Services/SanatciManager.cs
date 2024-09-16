using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System.Text;
using Utilities.Utilities;

namespace Services
{
    public class SanatciManager : ISanatciService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IAlbumService _albumManager;

        public SanatciManager(IRepositoryManager manager, IAlbumService albumManager)
        {
            _repoManager = manager;
            _albumManager = albumManager;
        }

        public Sanatci CreateOneSanatci(Sanatci sanatci)
        {
            sanatci.Ad = RandomGenerator.GenerateRandomString(5);
            sanatci.KurulusTarihi = RandomGenerator.GenerateRandomDate(new DateTime(1950,01,01));
            sanatci.Albumler = new List<Album>();

            int albumSayisi = sanatci.AlbumSayisi;

            for (int i = 0; i < albumSayisi; i++)
            {
                Album yeniAlbum = _albumManager.CreateOneAlbum(new Album 
                { 
                    SanatciId = sanatci.Id,
                    Sanatci = sanatci,
                    Sarkilar = new List<Sarki>()
                });
                sanatci.Albumler.Add(yeniAlbum);
            }
            _repoManager.Sanatci.Add(sanatci);
            _repoManager.Save();
            return sanatci;
        }
        

        public IEnumerable<Sanatci> GetAllSanatcilar(bool trackChanges)
        {
           return _repoManager.Sanatci.GetAllSanatcilar(trackChanges);
            
        }

        public Sanatci GetSanatciById(int id, bool trackChanges)
        {
            var sanatci = _repoManager.Sanatci.GetSanatciById(id, trackChanges);
            if (sanatci is null)
            {
                throw new Exception("Sanatci bulunamadi");
            }
            return sanatci;
        }
    }
}
