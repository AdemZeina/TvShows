using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace TvMazeScraper.Api.TvShows.Mapper
{

    public class StringTypeConverter : ITypeConverter<string[], string>
    {
        public string Convert(string[] source, string destination, ResolutionContext context)
        {
            var stringList = string.Join(", ",source);
            return stringList;
        }
    }
}
