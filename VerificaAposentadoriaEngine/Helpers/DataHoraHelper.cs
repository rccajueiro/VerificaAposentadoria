using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerificaAposentadoriaEngine.Helpers
{
    public class DataHoraHelper
    {
        public static int DiferencaEmAnos(DateTime data)
        {
            DateTime CurrentDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);

            int Diferenca = CurrentDateTime.Year - data.Year;

            if (data.Month > CurrentDateTime.Month)
                Diferenca--;
            else if(data.Month == CurrentDateTime.Month && data.Day > CurrentDateTime.Day)
                Diferenca--;
            
            return Diferenca;
        }
    }
}
