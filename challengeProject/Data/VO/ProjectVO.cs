using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using challengeProject.Model.Base;
using System.Text.Json.Serialization;
using challengeProject.Hypermedia.Abstract;
using challengeProject.Hypermedia;

namespace challengeProject.Data.VO
{
    
    public class ProjectVO : ISupportsHyperMedia
    {
        [JsonPropertyName("id_projeto")]
        public int Id { get; set; }
        
        public string nome { get; set; }

        public DateTime data_criacao { get; set; }

        public DateTime data_termino { get; set; }

        public int gerente { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
