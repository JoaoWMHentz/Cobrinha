using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobrinha
{
    class ParteCobrinha
    {
        public ParteCobrinha(){}
        public int Colun { get; set; }
        public int Row { get; set; }
        
        public ParteCobrinha(int Colun, int Row)
        {
            this.Row = Row;
            this.Colun = Colun;
        }
        
    }
}
