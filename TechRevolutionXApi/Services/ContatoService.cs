using TechRevolutionXApi.Interfaces;
using TechRevolutionXApi.Models;

namespace TechRevolutionXApi.Services
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoService(IContatoRepository contatoRepository) {

            _contatoRepository = contatoRepository;
        }
        public async Task CreateAsync(Contato contato)
        {
            await _contatoRepository.CreateAsync(contato);
        }

        public async Task DeleteAsync(int ID)
        {
            await _contatoRepository.DeleteAsync(ID);
        }

        public async Task<IList<Contato>> GetAllAsync()
        {
            return await _contatoRepository.GetAllAsync();
        }

        public async Task UpdateAsync(Contato produto)
        {
            await _contatoRepository.UpdateAsync(produto);

        }
    }
}
