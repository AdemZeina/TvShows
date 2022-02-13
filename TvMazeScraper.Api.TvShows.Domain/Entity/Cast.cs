namespace TvMazeScraper.Api.TvShows.Domain.Entity
{
    public class Cast : BaseEntity
    {
        public int TvShowId { get; set; }
        public string PersonUrl { get; set; }
        public string PersonName { get; set; }
        public string PersonCountryName { get; set; }
        public string PersonBirthday { get; set; }
        public string PersonDeathDay { get; set; }
        public string PersonGender { get; set; }
        public string PersonImageMedium { get; set; }
        public string PersonImageOrginal { get; set; }
        public int PersonUpdated { get; set; }
        public string PersonHref { get; set; }
        public string PersonPreviousEpisodeHref { get; set; }
        public string PersonNextEpisodeHref { get; set; }
        public string CharacterUrl { get; set; }
        public string CharacterName { get; set; }
        public string CharacterImageMedium { get; set; }
        public string CharacterImageOrginal { get; set; }
        public string CharacterHref { get; set; }
        public string CharacterPreviousEpisodeHref { get; set; }
        public string CharacterNextEpisodeHref { get; set; }
        public bool Self { get; set; }
        public bool Voice { get; set; }
    }
}
