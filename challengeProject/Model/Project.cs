using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace challengeProject.Model
{
    [Table("projetos")]
    public class Project
    {
        [Key]
        [Column("id_projeto")]
        public int Id { get; set; }
        [Column("nome")]
        public string nome { get; set; }

        [Column("data_criacao")]
        public DateTime data_criacao { get; set; }

        [Column("data_termino")]
        public DateTime data_termino { get; set; }

        [Column("gerente")]
        public int gerente { get; set; }
    }
}
