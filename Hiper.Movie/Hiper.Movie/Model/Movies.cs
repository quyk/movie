using System;
using Java.Lang;
using Newtonsoft.Json;

namespace Hiper.Movie.Model
{
    public class Movies
    {
        [JsonProperty(PropertyName = "Title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "Year")]
        public string Year { get; set; }

        [JsonProperty(PropertyName = "Poster")]
        public string Poster { get; set; }
    }
}