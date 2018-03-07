using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pessoa
    {
        private int id;
        private string nome;
        private int idade;

        public Pessoa(){ }

            public Pessoa(string nome, int idade)
        {
            this.nome = nome;
            this.idade = idade;
        }

        public Pessoa(int id, string nome, int idade)
        {
            this.id = id;
            this.nome = nome;
            this.idade = idade;
        }

        public int Idade { get => idade; set => idade = value; }
        public string Nome { get => nome; set => nome = value; }
        public int Id { get => id; set => id = value; }
    }
}
