using API_57Blocks.Entities;
using API_57Blocks.Models.Songs;
using API_57Blocks.Models.Users;
using AutoMapper;

namespace API_57Blocks.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // User -> AuthenticateResponse
            CreateMap<User, AuthenticateResponse>();

            // RegisterRequest -> User
            CreateMap<RegisterRequest, User>();

            // SongRequest -> Song
            CreateMap<SongRequest, Song>();

            // Song -> SongsResponse
            CreateMap<Song, SongsResponse>();
        }
    }
}
