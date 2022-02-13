namespace TvMazeScraper.Api.TvShows.Model
{


    public class Rootobject
    {
        public CastDto[] CastListDto { get; set; }
    }

    public class CastDto
    {
        public string Id { get; set; }
        public int ShowId { get; set; } = 0;
        public Person Person { get; set; }
        public Character Character { get; set; }
        public bool Self { get; set; }
        public bool Voice { get; set; }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public string Birthday { get; set; }
        public object DeathDay { get; set; }
        public string Gender { get; set; }
        public Image Image { get; set; }
        public int Updated { get; set; }
        public Links Links { get; set; }
    }


    public class Character
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public Image Image { get; set; }
        public Links Links { get; set; }
    }



}
