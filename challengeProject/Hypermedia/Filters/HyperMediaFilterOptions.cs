using challengeProject.Hypermedia.Abstract;
using System.Collections.Generic;

namespace challengeProject.Hypermedia.Filters
{
    public class HyperMediaFilterOptions
    {

        public List<IResponseEnricher> ContentResposeEnricherList { get; set; } = new List<IResponseEnricher>();

    }
}
