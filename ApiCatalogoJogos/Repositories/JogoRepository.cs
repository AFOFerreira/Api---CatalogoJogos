using ApiCatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositories
{
    public class JogoRepository : IJogoRepository
    {

        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>() {

            { Guid.Parse("cdd7731f-a2f6-4e60-af80-b89bfa6f0098"), new Jogo{ Id =  Guid.Parse("cdd7731f-a2f6-4e60-af80-b89bfa6f0098"), Nome = "The last of us", Produtora = "Naughty Dog",Preco = 150 } },
            { Guid.Parse("aa7ff3fc-7718-4b46-862a-ac63fa44f1cc"), new Jogo{ Id =  Guid.Parse("aa7ff3fc-7718-4b46-862a-ac63fa44f1cc"), Nome = "The last of us - PART 2", Produtora = "Naughty Dog",Preco = 250 } },
            { Guid.Parse("2ae8622a-056f-4942-87a2-fa779a3fa18b"), new Jogo{ Id =  Guid.Parse("2ae8622a-056f-4942-87a2-fa779a3fa18b"), Nome = "Street fighter", Produtora = "EA",Preco = 80 } },
        };

        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> Obter(Guid id)
        {
            if (!jogos.ContainsKey(id))
                return null;

            return Task.FromResult(jogos[id]);
        }

        public Task<List<Jogo>> Obter(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());
        }
        public Task Atualizar(Jogo jogo)
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            
        }

        public Task Inserir(Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
        }

        public Task Remover(Guid id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;

        }
    }
}
