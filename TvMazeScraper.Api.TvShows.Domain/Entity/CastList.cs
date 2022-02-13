using System.Collections.Generic;
using TvMazeScraper.Api.TvShows.Domain.Entity;

namespace TvMazeScraper.Api.TvShows.Domain
{
    public class CastList
    {
        public IList<Cast> Casts { get; set; }
    }
}