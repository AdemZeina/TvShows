using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TvMazeScraper.Api.TvShows.Model;

namespace TvMazeScraper.Api.TvShows.Client
{
    public class TvMazeClient : ITvMazeClient
    {
        private readonly HttpClient _httpClient;
        public TvMazeClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IList<ScraperTvShowsDto>> GetTvShows()
        {
            var response = await _httpClient.GetFromJsonAsync<IList<ScraperTvShowsDto>>("shows");

            foreach (ScraperTvShowsDto item in response)
            {
                try
                {
                    var cast = await GetTvShowCasts(item.Id);
                    foreach (CastDto castItem in cast)
                    {
                        castItem.ShowId = item.Id;
                    }
                    item.Casts.AddRange(cast);
                }
                catch
                {
                    continue;
                }

            }
            return response;
        }

        public async Task<IList<CastDto>> GetTvShowCasts(int showId)
        {
            return await _httpClient.GetFromJsonAsync<List<CastDto>>("shows/" + showId + "/cast");
        }
    }
}
