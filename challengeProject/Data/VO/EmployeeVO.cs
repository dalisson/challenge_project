using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using challengeProject.Model.Base;
using System.Text.Json.Serialization;
using challengeProject.Hypermedia.Abstract;
using challengeProject.Hypermedia;

namespace challengeProject.Data.VO
{
    
    public class EmployeeVO : ISupportsHyperMedia
    {
        [JsonPropertyName("id_empregado")]
        public int Id{ get; set; }

        public string primeiro_nome { get; set; }

        public string ultimo_nome { get; set; }

        public long telefone { get; set; }

        public string endereco { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
