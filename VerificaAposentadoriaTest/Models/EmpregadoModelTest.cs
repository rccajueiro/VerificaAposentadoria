using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VerificaAposentadoriaEngine.Models;

namespace VerificaAposentadoriaTest.Models
{
    [TestClass]
    public class EmpregadoModelTest
    {
        [TestMethod]
        public void TestValidInstance()
        {
            Equals(new EmpregadoModel("Ricardo Cajueiro", new DateTime(1986, 2, 5), DateTime.Now));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), EmpregadoModel.EXCEPTION_MENSAGEM_NOME_NULL)]
        public void TestNomeNull()
        {
            new EmpregadoModel(null, DateTime.Now.AddYears(-18), DateTime.Now);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), EmpregadoModel.EXCEPTION_MENSAGEM_NOME_VAZIO)]
        public void TestNomeVazio()
        {
            new EmpregadoModel("", DateTime.Now.AddYears(-18), DateTime.Now);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), EmpregadoModel.EXCEPTION_MENSAGEM_DATA_NASCIMENTO_MAIOR_DATA_ATUAL)]
        public void TestDataNascimentoMaiorAtual()
        {
            new EmpregadoModel("Empregado Com Data de Nascimento Maior", DateTime.Now.AddDays(1), DateTime.Now);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), EmpregadoModel.EXCEPTION_MENSAGEM_DATA_NASCIMENTO_MAIOR_IDADE)]
        public void TestDataNascimentoMenorIdade()
        {
            new EmpregadoModel("Empregado Menor de Idade", DateTime.Now.AddYears(-16), DateTime.Now);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), EmpregadoModel.EXCEPTION_MENSAGEM_DATA_INGRESSO_MAIOR_DATA_ATUAL)]
        public void TestDataIngressoMaiorAtual()
        {
            new EmpregadoModel("Data de Ingresso Maior", DateTime.Now.AddYears(-18), DateTime.Now.AddDays(1));
        }

        [TestMethod]
        public void TestGetIdade()
        {
            Assert.AreEqual(60, new EmpregadoModel("Empregado 30 anos", DateTime.Now.AddYears(-60), DateTime.Now.AddYears(-25)).GetIdade());
        }

        [TestMethod]
        public void TestGetTempoDeTrabalho()
        {
            Assert.AreEqual(25, new EmpregadoModel("Empregado 30 anos", DateTime.Now.AddYears(-60), DateTime.Now.AddYears(-25)).GetTempoDeTrabalho());
        }

        [TestMethod]
        public void TestAposentadoPorIdade()
        {
            Assert.AreEqual(true, new EmpregadoModel("Aposentado Por Idade", DateTime.Now.AddYears(-65), DateTime.Now.AddYears(-10)).IsAptoAposentadoria());
        }

        [TestMethod]
        public void TestAposentadoPorTempoDeTrabalho()
        {
            Assert.AreEqual(true, new EmpregadoModel("Aposentado Por Tempo de Trabalho", DateTime.Now.AddYears(-50), DateTime.Now.AddYears(-30)).IsAptoAposentadoria());
        }

        [TestMethod]
        public void TestAposentadoPorIdadeETempoDeTrabalho()
        {
           Assert.AreEqual(true, new EmpregadoModel("Aposentado Por Tempo de Trabalho", DateTime.Now.AddYears(-60), DateTime.Now.AddYears(-25)).IsAptoAposentadoria());
        }

        [TestMethod]
        public void TestInaptoParaAposentar()
        {
            Assert.AreEqual(false, new EmpregadoModel("Inapto Para Aposentar", DateTime.Now.AddYears(-30), DateTime.Now.AddYears(-10)).IsAptoAposentadoria());
        }
    }
}
