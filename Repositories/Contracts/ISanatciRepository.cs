using Entities.Models;

namespace Repositories.Contracts
{
    public interface ISanatciRepository
    {
        void Add(Sanatci sanatci);
        void Update(Sanatci sanatci);
        void Delete(Sanatci sanatci);

        IQueryable<Sanatci> GetAllSanatcilar(bool trackChanges);
        Sanatci GetSanatciById(int sanatciId, bool trackChanges);
    }
}
