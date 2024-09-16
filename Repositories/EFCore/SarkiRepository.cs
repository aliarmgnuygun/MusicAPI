using Entities.Models;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class SarkiRepository : RepositoryBase<Sarki>, ISarkiRepository
    {
        public SarkiRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void AddOneSarki(Sarki sarki) => Create(sarki);
    }
}
