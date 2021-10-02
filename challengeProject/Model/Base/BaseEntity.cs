using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace challengeProject.Model.Base
{
    public class BaseEntity
    {
       [Column("id")]
        public int Id { get; set; }
    }
}
