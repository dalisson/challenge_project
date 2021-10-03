using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace challengeProject.Model
{
    [Table("usuarios")]
    public class User
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("user_name")]
        public string user_name { get; set; }

        [Column("password")]
        public string password { get; set; }

        [Column("refresh_token")]
        public string refresh_token { get; set; }
        [Column("refresh_token_expiry_time")]
        public DateTime refresh_token_expiry_time {get; set;}
    }
}
