using AuthProjectJWT.Core.Entities.Concrete;
using AuthProjectJWT.Core.Utilities.Results;
using AuthProjectJWT.Core.Utilities.Security.Jwt;
using AuthProjectJWT.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthProjectJWT.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserRegister userForRegisterDto, string password);
        IDataResult<User> Login(UserLogin userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
