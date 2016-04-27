using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Reguler_Serre
{
    class Program
    {
        static void Main(string[] args)
        {
            int reponse;
            ConnectionSQL CSQL = new ConnectionSQL();
            while (true)
            {           
                reponse = CSQL.Reponse();

                if (reponse == 1)
                {








                    
                }
                System.Threading.Thread.Sleep(60000);
            }
        }
    }
}
