using AutoMapper;
using Inforce.NET.BLL.MappingProfiles;
using Inforce.NET.BLL.Services;
using Inforce.NET.Common.AuxiliaryModels;
using Inforce.NET.Common.AuxiliaryModels.Exceptions;
using Inforce.NET.Common.Entities;
using Inforce.NET.Common.Enums;
using Inforce.NET.DAL;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Inforce.NET.BLL.UnitTests
{
    public class UserServiceTests
    {
        private readonly UserService _service;
        private readonly DatabaseContext _dbContext;

        public UserServiceTests()
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
        public async Task ValidateNewUrlModel_WhenModelValid_ThenReturnThisModel()
        {
            var model = new NewUrl()
            {
                CreatedById = 1,
                URL = "https://www.google.com/search?q=images&oq=images&aqs=chrome.0.69i59l2j0i512l4j69i60l2.1468j0j7&sourceid=chrome&ie=UTF-8#imgrc=GTOsfXGJyz8O-M",
            };

            var user = new User()
            {
                Id = 1,
                Login = "",
                Password = "",
                FullName = "",
                Role = UserRole.Admin,
            };

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            Assert.Same(model, await _service.ValidateModel(model));

            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }

        [Fact]
        public async Task ValidateNewUrlModel_WhenUserNotExist_ThenExceptionThrows()
        {
            var model = new NewUrl()
            {
                CreatedById = 1,
                URL = "https://www.google.com/search?q=images&oq=images&aqs=chrome.0.69i59l2j0i512l4j69i60l2.1468j0j7&sourceid=chrome&ie=UTF-8#imgrc=GTOsfXGJyz8O-M",
            };

            await Assert.ThrowsAsync<InvalidValuesException>(async () => await _service.ValidateModel(model));
        }

        [Fact]
        public async Task CreateShortedUrl_WhenDataValid_ThenReturnDtoObjectWithSettedProperties()
        {
            var model = new NewUrl()
            {
                CreatedById = 1,
                URL = "https://www.google.com/search?q=images&oq=images&aqs=chrome.0.69i59l2j0i512l4j69i60l2.1468j0j7&sourceid=chrome&ie=UTF-8#imgrc=GTOsfXGJyz8O-M",
            };

            var user = new User()
            {
                Id = 1,
                Login = "",
                Password = "",
                FullName = "",
                Role = UserRole.Admin,
            };

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            var result = await _service.CreateShortedUrl(model);

            Assert.NotNull(result);
            Assert.Equal(model.CreatedById, result.CreatedById);
            Assert.NotSame(model.URL, result.ShortUrl);
            Assert.Same(model.URL, result.URL);
            Assert.True(result.Id != default);
        }
    }
}
