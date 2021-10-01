using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using challengeProject.Model.Base;

namespace challengeProject.Data.VO
{
    
    public class EmployeeVO
    {
        
        public int id_empregado { get; set; }

        public string primeiro_nome { get; set; }

        public string ultimo_nome { get; set; }

        public long telefone { get; set; }

        public string endereco { get; set; }
    }
}
