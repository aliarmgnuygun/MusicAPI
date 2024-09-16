using Entities.Models;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class SanatciRepository : RepositoryBase<Sanatci>, ISanatciRepository
    {
        public SanatciRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void Add(Sanatci sanatci) => Create(sanatci);

        public IQueryable<Sanatci> GetAllSanatcilar(bool trackChanges) => FindAll(trackChanges).OrderBy(s => s.Id);

        public Sanatci GetSanatciById(int sanatciId, bool trackChanges) =>
            FindByCondition(s => s.Id.Equals(sanatciId), trackChanges).SingleOrDefault();
    }
}
