using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using Utilities.Utilities;

namespace Services
{
    public class SarkiManager : ISarkiService
    {
        private readonly IRepositoryManager _repositoryManager;

        public SarkiManager(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public Sarki CreateSarki(Sarki sarki)
        {
            sarki.Ad = RandomGenerator.GenerateRandomString(15);
            _repositoryManager.Sarki.AddOneSarki(sarki);
            _repositoryManager.Save();

            return sarki;

        }
    }
}
