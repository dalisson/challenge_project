using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace challengeProject.Model
{   

    [Table("membros")]
    [Keyless]
    public class Membership
    {
        [Column("id_empregado")]
        public int id_empregado { get; set; }

        [Column("id_projeto")]
        public int id_projeto { get; set; }
    }
}
