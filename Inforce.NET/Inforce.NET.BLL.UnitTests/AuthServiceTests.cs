using AutoMapper;
using Inforce.NET.BLL.MappingProfiles;
using Inforce.NET.BLL.Services;
using Inforce.NET.Common.Entities;
using Inforce.NET.Common.Enums;
using Inforce.NET.DAL;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Inforce.NET.BLL.UnitTests
{
    public class AuthServiceTests
    {
        private readonly AuthService _service;
        private readonly DatabaseContext _dbContext;

        public AuthServiceTests()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase("TestDb" + Guid.NewGuid()).Options;

            _dbContext = new DatabaseContext(options);

            var mapper = new MapperConfiguration(opt =>
            {
                opt.AddProfile<ShortedUrlProfile>();
                opt.AddProfile<UserProfile>();
            }).CreateMapper();

            _service = new(_dbContext, mapper);
        }

        [Fact]
        public async Task Login_WhenValidCredentials_ThenReturnCorrectUser()
        {
            var model = new User()
            {
                Id = 1,
                Login = "Login",
                Password = "Password",
                FullName = "Name",
                Role = UserRole.Admin,
            };

            _dbContext.Users.Add(model);
            _dbContext.SaveChanges();

            var user = await _service.Login(new()
            {
                Login = model.Login,
                Password = model.Password,
            });

            Assert.NotNull(user);
            Assert.Equal(model.FullName, user.FullName);
            Assert.Equal(model.Role, user.Role);
        }
    }
}
