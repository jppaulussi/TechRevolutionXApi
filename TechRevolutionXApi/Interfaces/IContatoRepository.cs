using TechRevolutionXApi.Models;

namespace TechRevolutionXApi.Interfaces
{
    public interface IContatoRepository
    {
        public Task<IList<Contato>> GetAllAsync();

        public Task CreateAsync(Contato contato);

        public Task UpdateAsync(Contato contato);

        public Task DeleteAsync(int ID);

    }
}
