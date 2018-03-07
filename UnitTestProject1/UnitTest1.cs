using System;
using BDDao;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestebuscaporId()
        {
            PessoaDao dao = new PessoaDao();
            var Pessoa = dao.PesquisarPessoaPorId(1);

            Assert.AreEqual("Fulano", Pessoa.Nome);
            Assert.AreEqual(0, Pessoa.Idade);
        }

        [TestMethod]
        public void AdicionarPessoa()
        {
            PessoaDao dao = new PessoaDao();
            Pessoa p = new Pessoa("Davi", 22);
            dao.AdicionarPessoa(p);

        }

        /*[TestMethod]
        public void AlterarPessoa()
        {
            PessoaDao dao = new PessoaDao();
            dao.AlterarPessoa(3, "Davi Sampaio", 20);
        }*/

        [TestMethod]
        public void ExcluirPessoaPorId()
        {
            PessoaDao Dao = new PessoaDao();
            Dao.PesquisarPessoaPorId(3);        //Checar se existe a linha a ser deletada
            Dao.ExcluirPessoaPorId(3);          //Se sim, deletar linha
        }
    }
}
