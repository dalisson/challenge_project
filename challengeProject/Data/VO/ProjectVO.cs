using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using challengeProject.Model.Base;

namespace challengeProject.Data.VO
{
    
    public class ProjectVO
    {
        public int Id { get; set; }
        
        public string nome { get; set; }

        public DateTime data_criacao { get; set; }

        public DateTime data_termino { get; set; }

        public int gerente { get; set; }
    }
}
