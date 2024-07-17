using System.Data;
using TechRevolutionXApi.Interfaces;
using TechRevolutionXApi.Models;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechRevolutionXApi.Repository
{
    public class CadastroRepository : IContatoRepository
    {
        private readonly IDbConnection _connection;

        public CadastroRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IList<Contato>> GetAllAsync()
        {
            var query = "SELECT * FROM Contatos";
            var resultado = await _connection.QueryAsync<Contato>(query);
            return resultado.ToList();
        }

        public async Task CreateAsync(Contato contato)
        {
            var comandoSql = @"INSERT INTO Contatos (Nome, Telefone, Email, DDD)
                               VALUES (@Nome, @Telefone, @Email, @DDD)";
            await _connection.ExecuteAsync(comandoSql, contato);
        }


        public async Task UpdateAsync(Contato contato)
        {
            var comandoSql = @"UPDATE Contatos 
                       SET Nome = @Nome, 
                           Telefone = @Telefone, 
                           Email = @Email, 
                           DDD = @DDD 
                       WHERE Id = @Id"; // Supondo que Id seja a chave primária da tabela Contatos

            await _connection.ExecuteAsync(comandoSql, contato);
        }
        public async Task DeleteAsync(int ID)
        {
            var listaRegistros = await GetAllAsync();
            var contato = listaRegistros.FirstOrDefault(x => x.ID.Equals(ID));

            if (contato != null)
            {
                var comandoSql = @"DELETE FROM Contatos WHERE Id = @Id";
                await _connection.ExecuteAsync(comandoSql, new { Id = ID });
            }
            /*else
            {
                throw new Exception($"O contato com ID {id} não foi encontrado.");
                // ou tratamento de erro adequado, como retornar um resultado indicando que o contato não existe
            }
            */
        }


        /*public async Task UpdateAsync(Contato contato)
        {
            var listaContatos = await GetAllAsync();
            var cadastroExistente = listaContatos.FirstOrDefault(x => x.ID.Equals(contato.ID));

            if (cadastroExistente == null)
            {
                var comandoSql = @"UPDATE Contatos 
                       SET Nome = @Nome, 
                           Telefone = @Telefone, 
                           Email = @Email, 
                           DDD = @DDD 
                       WHERE Id = @Id"; // Supondo que Id seja a chave primária da tabela Contatos

                await _connection.ExecuteAsync(comandoSql, contato);
            }
  

        }*/
    }
}
