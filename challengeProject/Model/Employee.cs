using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challengeProject.Model
{
    public class Employee
    {
        //id do empregado
        public int id_empregado { get; set; }

        //primero nome do empregado
        public string primeiro_nome { get; set; }

        //ultimo nome do empregado
        public string ultimo_nome { get; set; }

        //telefone do empregado, guardado como numero
        public long telefone { get; set; }

        //endreco do empregado.
        public string endereco { get; set; }
    }
}
