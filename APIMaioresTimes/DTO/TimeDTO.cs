using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIMaioresTimes.DAO
{
    public class TimeDTO
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string LocalFundacao { get; set; }
        public string Estadio { get; set; }
        public int Titulos { get; set; }
        public DateTime Fundacao { get; set; }
    }
}
