using System.Collections.Generic;
using TvMazeScraper.Api.TvShows.Domain;
using TvMazeScraper.Api.TvShows.Domain.Entity;

namespace TvMazeScraper.Api.TvShows.Model
{
    public class TvShowDto
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Language { get; set; }
        public string Genres { get; set; }
        public string Status { get; set; }
        public int? Runtime { get; set; }
        public int AverageRuntime { get; set; }
        public string Premiered { get; set; }
        public string Ended { get; set; }
        public string OfficialSite { get; set; }
        public string ScheduleTime { get; set; }
        public string ScheduleDays { get; set; }
        public float? RatingAverage { get; set; }
        public int Weight { get; set; }
        public string NetworkName { get; set; }
        public string NetworkCountryName { get; set; }
        public string NetworkCountryCode { get; set; }
        public string NetworkOfficialSite { get; set; }
        public string WebChannelName { get; set; }
        public string WebChannelCountryName { get; set; }
        public string WebChannelCountryCode { get; set; }
        public string DvdCountry { get; set; }
        public int TvRage { get; set; }
        public int? TheTvDb { get; set; }
        public string Imdb { get; set; }

        public string ImageMedium { get; set; }
        public string ImageOriginal { get; set; }
        public string Summary { get; set; }
        public int Updated { get; set; }
        public string Href { get; set; }
        public string PreviousEpisodeHref { get; set; }
        public string NextEpisodeHref { get; set; }

        public List<Cast> Casts { get; set; }
    }
}
