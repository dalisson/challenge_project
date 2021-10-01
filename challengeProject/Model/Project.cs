using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using challengeProject.Model.Base;

namespace challengeProject.Model
{
    [Table("projetos")]
    public class Project : BaseEntity
    {
        [Key]
        [Column("id_projeto")]
        public new int Id { get; set; }
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
