using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challengeProject.Model
{
    public class Project
    {
        public int id_projeto { get; set; }

        public string nome { get; set; }

        public DateTime data_criacao { get; set; }

        public DateTime data_termino { get; set; }

        public int gerente { get; set; }
    }
}
