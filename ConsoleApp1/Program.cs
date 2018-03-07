using BDDao;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool loop = true;
            do
            {
                Console.WriteLine("1-Cadastrar Pessoa.");
                Console.WriteLine("2-Buscar Pessoa por id.");
                Console.WriteLine("3-Alterar Pessoa.");
                Console.WriteLine("4-Excluir Pessoa.");

                Console.Write("Informe o numero da ação: ");

                int caso = Convert.ToInt32(Console.ReadLine());

                Pessoa p = new Pessoa();
                PessoaDao dao = new PessoaDao();
                String nome;
                int idade;
                switch (caso)
                {
                    case 1:
                        loop = false;

                        Console.WriteLine("Informe o nome da pessoa: ");
                        nome = Console.ReadLine().ToString();
                        Console.WriteLine("Informe a idade da pessoa: ");
                        idade = Convert.ToInt32(Console.ReadLine());


                        p = new Pessoa(nome, idade);
                        dao.AdicionarPessoa(p);
                        Console.WriteLine("Cadastro efetuado com sucesso.");
                        break;
                    case 2:
                        loop = false;

                        Console.WriteLine("Informe o id a ser buscado: ");
                        int id = Convert.ToInt32(Console.ReadLine());

                        var pessoa = dao.PesquisarPessoaPorId(id);
                        Console.WriteLine("Idade: "+pessoa.Idade+"| Nome: "+pessoa.Nome);
                        break;
                    case 3:
                        loop = false;

                        Console.WriteLine("Informe o id a ser alterado: ");
                        id = Convert.ToInt32(Console.ReadLine());

                        pessoa = dao.PesquisarPessoaPorId(id);

                        Console.WriteLine("Alterar nome de "+pessoa.Nome+" para: ");
                        nome = Console.ReadLine().ToString();

                        Console.WriteLine("Alterar idade de "+pessoa.Nome+"("+pessoa.Idade+") para: ");
                        idade = Convert.ToInt32(Console.ReadLine());

                        dao.AlterarPessoa(id,nome,idade);

                        Console.WriteLine("Alteração feita com sucesso");

                        break;
                    case 4:
                        loop = false;

                        Console.WriteLine("Informe o id a ser excluido: ");
                        id = Convert.ToInt32(Console.ReadLine());

                        dao.ExcluirPessoaPorId(id);
                        Console.WriteLine("Exclusão efetuada com sucesso");

                        break;
                    default:
                        Console.WriteLine("Numero Inválido, efetue uma opção válida");
                        Console.WriteLine("----------------------------------------------------------");
                        break;
                }

            } while (loop);
        }
    }
}
