using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Hashing;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService userService;
        private ITokenHelper tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            this.userService = userService;
            this.tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = userService.GetClaims(user);
            var accessToken = tokenHelper.CreateToken(user, claims);

            return new SuccessDataResult<AccessToken>(accessToken);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = userService.GetByMail(userForLoginDto.Email);
            if(userToCheck is null)
            {
                return new ErrorDataResult<User>(Messages.UserNotVerified);
            }

            if (!HashingHelper.VerifyPassword(userForLoginDto.Password, userToCheck.PasswordHash))
                return new ErrorDataResult<User>(Messages.UserNotVerified);

            return new SuccessDataResult<User>(userToCheck, Messages.UserLoginSuccessful);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out var passwordHash, out var passwordSalt);

            var user = new Core.Entities.Concrete.User()
            {
                FirstName = userForRegisterDto.FirstName,
                Email = userForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            userService.Add(user);

            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IResult UserExists(string email)
        {
            if (userService.GetByMail(email) != null)
                return new ErrorResult(Messages.UserAlreadyExist);

            return new SuccessResult();
        }
    }
}
