using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerificaAposentadoriaEngine.Helpers;

namespace VerificaAposentadoriaEngine.Models
{
    public class EmpregadoModel
    {
        public const string EXCEPTION_MENSAGEM_NOME_NULL = "Nome não pode ser nulo";
        public const string EXCEPTION_MENSAGEM_NOME_VAZIO = "O nome não pode ser vazio";
        public const string EXCEPTION_MENSAGEM_DATA_NASCIMENTO_INVALIDA = "Data de nascimento inválida";
        public const string EXCEPTION_MENSAGEM_DATA_NASCIMENTO_MAIOR_DATA_ATUAL = "Data de nascimento não pode maior que a data atual";
        public const string EXCEPTION_MENSAGEM_DATA_NASCIMENTO_MAIOR_IDADE = "Empregado deve ser maior de idade";
        public const string EXCEPTION_MENSAGEM_DATA_INGRESSO_MAIOR_DATA_ATUAL = "Data de ingresso não pode ser maior que a data atual.";

        private string nome;
        private DateTime dataNascimento;
        private DateTime dataIngresso;

        public string Nome
        {
            get { return nome; }
        }
        public DateTime DataNascimento
        {
            get { return dataNascimento; }
        }
        public DateTime DataIngresso
        {
            get { return dataIngresso; }
        }

        public EmpregadoModel(string Nome, DateTime DataNascimento, DateTime DataIngresso)
        {
            if (Nome == null) throw new ArgumentNullException(EXCEPTION_MENSAGEM_NOME_NULL);
            if (Nome.Trim() == "") throw new ArgumentException(EXCEPTION_MENSAGEM_NOME_VAZIO);
            if (new DateTime(DataNascimento.Year, DataNascimento.Month, DataNascimento.Day) > new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)) throw new ArgumentException(EXCEPTION_MENSAGEM_DATA_NASCIMENTO_MAIOR_DATA_ATUAL);
            try
            {
                if (DataHoraHelper.DiferencaEmAnos(DataNascimento) < 18) throw new ArgumentException(EXCEPTION_MENSAGEM_DATA_NASCIMENTO_MAIOR_IDADE);
            }
            catch (ArgumentOutOfRangeException Ex)
            {
                throw new ArgumentException(EXCEPTION_MENSAGEM_DATA_NASCIMENTO_INVALIDA);
            }
            if (new DateTime(DataIngresso.Year, DataIngresso.Month, DataIngresso.Day) > new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)) throw new ArgumentException(EXCEPTION_MENSAGEM_DATA_INGRESSO_MAIOR_DATA_ATUAL);

            nome = Nome;
            dataNascimento = DataNascimento;
            dataIngresso = DataIngresso;
        }

        public int GetIdade()
        {
            try
            { 
                return DataHoraHelper.DiferencaEmAnos(dataNascimento);
            }
            catch (ArgumentOutOfRangeException Ex)
            {
                return 0;
            }
        }

        public int GetTempoDeTrabalho()
        {
            try
            { 
                return DataHoraHelper.DiferencaEmAnos(dataIngresso);
            }
            catch (ArgumentOutOfRangeException Ex)
            {
                return 0;
            }
        }

        public bool IsAptoAposentadoria()
        {
            return GetIdade() >= 65 || GetTempoDeTrabalho() >= 30 || (GetIdade() >= 60 && GetTempoDeTrabalho() >= 25);
        }
    }
}
