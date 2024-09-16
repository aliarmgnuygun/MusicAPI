using Entities.Models;

namespace Services.Contracts
{
    public interface ISanatciService
    {
        IEnumerable<Sanatci> GetAllSanatcilar(bool trackChanges);
        Sanatci GetSanatciById(int id, bool trackChanges);
        Sanatci CreateOneSanatci(Sanatci sanatci);
    }
}
