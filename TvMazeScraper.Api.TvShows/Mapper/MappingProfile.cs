using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using TvMazeScraper.Api.TvShows.Domain;
using TvMazeScraper.Api.TvShows.Domain.Entity;
using TvMazeScraper.Api.TvShows.Model;

namespace TvMazeScraper.Api.TvShows.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            AllowNullDestinationValues = true;
            CreateMap<string[], string>().ConvertUsing(new StringTypeConverter());

            CreateMap<ScraperTvShowsDto, TvShow>()
                .ForMember(dest => dest.NetworkOfficialSite,
                    opt => opt.MapFrom(x => x.Network.OfficialSite))
                .ForMember(dest => dest.NextEpisodeHref, opt => opt.MapFrom(x => x.Links.NextEpisode))
                .ForMember(dest => dest.PreviousEpisodeHref, opt => opt.MapFrom(x => x.Links.PreviousEpisode))
                .ForMember(dest => dest.Href, opt => opt.MapFrom(x => x.Links.Self.Href))
                .ForMember(dest => dest.WebChannelName,opt => opt.MapFrom(x => x.WebChannel.Name))
                .ForMember(dest => dest.Casts,opt => opt.MapFrom(x => x.Casts))
                .ReverseMap();

            CreateMap<CastDto, Cast>()
                .ForMember(dest=>dest.Id, source=>source.MapFrom(x=>x.Person.Id))
                .ForMember(dest=>dest.TvShowId, source=>source.MapFrom(x=>x.ShowId))
                .ReverseMap();

            CreateMap<TvShow, TvShowDto>().ReverseMap();



        }

    }
}
