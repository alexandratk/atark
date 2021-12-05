using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;
using PersonalityIdentification.Itrefaces;
using Microsoft.IdentityModel.Tokens;
using PersonalityIdentification.Helpers;

namespace PersonalityIdentification.Services
{
    public class AuthService : IAuthService
    {
        private readonly MyDataContext database;

        public AuthService(MyDataContext database)
        {
            this.database = database;
        }


        public async Task<User> findRequest(int id, string role)
        {
            var user = await GetUserById(database.Pupil, id);
            if (role == "Teacher")
                user = await GetUserById(database.Teacher, id);
            if (role == "Administrator" | role == "SuperAdministrator")
                user = await GetUserById(database.Administrator, id);
            if (role == "Parent")
                user = await GetUserById(database.Parent, id);
            if (user == null)
                throw new Exception("User not found");
            return new User()
            {
                Id = user.Id,
                Role = user.Role,
                Name = user.Name,
                Dateofbirth = user.Dateofbirth
            };
        }


        public async Task<User> GetUserById(IQueryable<User> placeToSerach, int id)
        {
            return await placeToSerach.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<AuthResponseModel> AuthUser(AuthRequestModel authRequestModel)
        {
            var user = await GetUserByPassAndMail(database.Pupil, authRequestModel);
            if (user == null)
                user = await GetUserByPassAndMail(database.Teacher, authRequestModel);
            if (user == null)
                user = await GetUserByPassAndMail(database.Administrator, authRequestModel);
            if (user == null)
                user = await GetUserByPassAndMail(database.Parent, authRequestModel);
            if (user == null)
                throw new Exception("User not found");
            Console.WriteLine("2222");
            var token = generateJWTToken(user);
            return new AuthResponseModel()
            {
                Id = user.Id,
                Role = user.Role,
                jwtToken = token
            };
        }


        public async Task<User> GetUserByPassAndMail(IQueryable<User> placeToSerach, AuthRequestModel authRequestModel)
        {
            return await placeToSerach.FirstOrDefaultAsync(p => p.Login == authRequestModel.Login && p.Password == HashHelper.ComputeSha256Hash(authRequestModel.Password));
        }

        string generateJWTToken(User person)
        {

            var now = DateTime.UtcNow;

            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role)
                };
            ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            var jwt = new JwtSecurityToken(
                 issuer: AuthOptions.ISSUER,
                 audience: AuthOptions.AUDIENCE,
                 notBefore: now,
                 claims: claimsIdentity.Claims,
                 expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                 signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }

    }
}