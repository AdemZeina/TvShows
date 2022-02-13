using System.Collections.Generic;
using System.Threading.Tasks;
using TvMazeScraper.Api.TvShows.Model;

namespace TvMazeScraper.Api.TvShows.Client
{
    public interface ITvMazeClient
    {
        Task<IList<ScraperTvShowsDto>> GetTvShows();

        Task<IList<CastDto>> GetTvShowCasts(int showId);
    }
}
