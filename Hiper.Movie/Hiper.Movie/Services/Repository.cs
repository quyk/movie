using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Hiper.Movie.Model;
using Newtonsoft.Json;

namespace Hiper.Movie.Services
{
    public class Repository
    {
        public async Task<MovieSerialize> GetMovie(string title)
        {
            var api = $"http://www.omdbapi.com/?apikey=63763883&s={title}";
            MovieSerialize moveisList;
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(api);
                moveisList = JsonConvert.DeserializeObject<MovieSerialize>(json);
            }
            return moveisList;
        }
    }
}