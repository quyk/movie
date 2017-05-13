using System.Collections.Generic;
using Hiper.Movie.Model;
using Newtonsoft.Json;

namespace Hiper.Movie.Services
{
    public class MovieSerialize
    {
        [JsonProperty(PropertyName = "Search")]
        public IList<Movies> Search { get; set; }

        [JsonProperty(PropertyName = "totalResults")]
        public string TotalResults { get; set; }

        [JsonProperty(PropertyName = "Response")]
        public bool Response { get; set; }
    }
}