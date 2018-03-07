using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interefaces
{
    public interface IPessoaDao
    {
        //CRUD
        void AdicionarPessoa(Pessoa p);

        Pessoa PesquisarPessoaPorId(int id);

        void AlterarPessoa(int id, string nome, int idade);

        void ExcluirPessoaPorId(int id);

        List<Pessoa> PesquisarPorSubstring(String substring);
    }
}
