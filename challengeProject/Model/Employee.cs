using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace challengeProject.Model
{
    [Table("empregados")]
    
    public class Employee
    {
        //id do empregado
        [Column("id_empregado")]
        [Key]  
        public int Id { get; set; }

        //primero nome do empregado
        [Column("primeiro_nome")]
        public string primeiro_nome { get; set; }

        //ultimo nome do empregado
        [Column("ultimo_nome")]
        public string ultimo_nome { get; set; }

        //telefone do empregado, guardado como numero
        [Column("telefone")]
        public long telefone { get; set; }

        //endreco do empregado.
        [Column("endereco")]
        public string endereco { get; set; }
    }
}
