using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerificaAposentadoriaEngine.Models;

namespace VerificaAposentadoriaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Random Rand = new Random();

            string Nome = "Ricardo Cajueiro";
            DateTime DataNascimento = DateTime.Now.AddYears(- Rand.Next(18, 65)); // Idade aleatória de 18 a 65 anos
            DateTime DataIngresso = DateTime.Now.AddYears(- Rand.Next(30)); // Data de ingresso aleatória, até 30 anos

            EmpregadoModel e = new EmpregadoModel(Nome, DataNascimento, DataIngresso);

            Console.Write("Nome: ");
            Console.WriteLine(e.Nome);

            Console.Write("Idade: ");
            Console.WriteLine(e.GetIdade());

            Console.Write("Tempo de trabalho: ");
            Console.WriteLine(e.GetTempoDeTrabalho());

            if (e.IsAptoAposentadoria())
                Console.WriteLine("Apto para aposentadoria");
            else
                Console.WriteLine("Inapto para aposentadoria");
            
            Console.ReadKey();
        }
    }
}
