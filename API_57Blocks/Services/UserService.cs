using API_57Blocks.Authorization;
using API_57Blocks.Entities;
using API_57Blocks.Helpers;
using API_57Blocks.Models.Users;
using AutoMapper;
using BCryptNet = BCrypt.Net.BCrypt;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace API_57Blocks.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        User GetById(int id);
        void Register(RegisterRequest model);
    }

    public class UserService : IUserService
    {
        private APIContext _context;
        private IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;

        public UserService(
            APIContext context,
            IJwtUtils jwtUtils,
            IMapper mapper)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            // validate email
            if (!new EmailAddressAttribute().IsValid(model.Email))
                throw new AppException("Email '" + model.Email + "' is invalid");

            // validate password
            if (!ValidPassword(model.Password))
                throw new AppException("Password '" + model.Password + "' is invalid (must contains at least 10 characters, one lowercase letter, one uppercase letter and one of the following characters: !, @, #, ? or ] )");

            // validate email exists
            if (!_context.Users.Any(x => x.Email == model.Email))
                throw new AppException("Email '" + model.Email + "' does not exists");

            var user = _context.Users.SingleOrDefault(x => x.Email == model.Email);

            // validate
            if (user == null || !BCryptNet.Verify(model.Password, user.PasswordHash))
                throw new AppException("Email or password is incorrect");

            // authentication successful
            var response = _mapper.Map<AuthenticateResponse>(user);
            response.Token = _jwtUtils.GenerateToken(user);
            return response;
        }

        public User GetById(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }

        public void Register(RegisterRequest model)
        {
            // validate email
            if (!new EmailAddressAttribute().IsValid(model.Email))
                throw new AppException("Email '" + model.Email + "' is invalid");

            // validate
            if (_context.Users.Any(x => x.Email == model.Email))
                throw new AppException("Email '" + model.Email + "' is already taken");

            // validate password
            if (!ValidPassword(model.Password))
                throw new AppException("Password '" + model.Password + "' is invalid (must contains at least 10 characters, one lowercase letter, one uppercase letter and one of the following characters: !, @, #, ? or ] )");

            // map model to new user object
            var user = _mapper.Map<User>(model);

            // hash password
            user.PasswordHash = BCryptNet.HashPassword(model.Password);

            // save user
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        private bool ValidPassword(string password)
        {
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasMinimum10Chars = new Regex(@".{10,}");
            char[] SpecialChars = "!@#?]".ToCharArray();
            bool hasSpecial = password.IndexOfAny(SpecialChars) == -1 ? false : true;

            return hasUpperChar.IsMatch(password) && hasLowerChar.IsMatch(password) && hasMinimum10Chars.IsMatch(password) && hasSpecial;
        }

    }
}
