using API_57Blocks.Entities;
using API_57Blocks.Helpers;
using API_57Blocks.Models.Songs;
using AutoMapper;

namespace API_57Blocks.Services
{
    public interface ISongService
    {
        IEnumerable<Song> GetPrivate(int userId, SongsParameters parameters);
        IEnumerable<Song> GetPublic(SongsParameters parameters);
        Song Create(int userId, SongRequest model);
        Song Update(int userId, int id, SongRequest model);
    }

    public class SongService : ISongService
    {
        private APIContext _context;
        private readonly IMapper _mapper;

        public SongService(
            APIContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Song> GetPrivate(int userId, SongsParameters parameters)
        {
            var songs = _context.Songs.Where(x => x.UserId == userId);
            return songs
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToList();
        }

        public IEnumerable<Song> GetPublic(SongsParameters parameters)
        {
            var songs = _context.Songs.Where(x => x.scope.Equals("public"));
            return songs
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToList();
        }

        public Song Create(int userId, SongRequest model)
        {
            // map model to new song object
            var song = _mapper.Map<Song>(model);
            song.scope = "private";
            song.UserId = userId;

            // save song
            _context.Songs.Add(song);
            _context.SaveChanges();

            return song;
        }

        public Song Update(int userId, int id, SongRequest model)
        {
            var existingSong = _context.Songs.SingleOrDefault(x => x.Id == id && x.UserId == userId);

            if (existingSong == null)
                throw new AppException("Song not found, or not owner");

            // map model to new song object
            var song = _mapper.Map<Song>(model);
            existingSong.Name = song.Name;
            existingSong.Artist = song.Artist;
            existingSong.Album = song.Album;
            existingSong.Year = song.Year;
            existingSong.Genre = song.Genre;

            // save song
            _context.SaveChanges();

            return existingSong;
        }

    }
}
