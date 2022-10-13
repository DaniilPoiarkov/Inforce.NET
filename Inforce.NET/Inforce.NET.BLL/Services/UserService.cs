using AutoMapper;
using Inforce.NET.Common.AuxiliaryModels;
using Inforce.NET.Common.AuxiliaryModels.Exceptions;
using Inforce.NET.Common.DTOs;
using Inforce.NET.Common.Entities;
using Inforce.NET.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inforce.NET.BLL.Services
{
    public class UserService
    {
        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(DatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var user = _mapper.Map<UserDto>(
                await _dbContext.Users
                    .Where(u => u.Id == id)
                    .Include(u => u.OwnedUrls)
                    .FirstOrDefaultAsync());

            if(user == null)
                throw new NotFoundException(nameof(User));

            return user;
        }

        public async Task<List<ShortedUrlDto>> GetUrlsByUserId(int userId)
        {
            return _mapper.Map<List<ShortedUrlDto>>(await _dbContext.ShortedUrls.Where(su => su.CreatedById == userId).ToListAsync());
        }

        public async Task<ShortedUrlDto> CreateShortedUrl(NewUrl model)
        {
            var validModel = await ValidateModel(model);

            var entity = _mapper.Map<ShortedUrl>(validModel);

            entity.CreatedDate = DateTime.UtcNow;
            entity.ShortUrl = ShortenUrl(validModel.URL?? string.Empty);

            await _dbContext.ShortedUrls.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<ShortedUrlDto>(entity);
        }

        public async Task<ShortedUrlDto> GetLinkByTinyUrl(string tinyUrl)
        {
            var url = _mapper.Map<ShortedUrlDto>(await _dbContext.ShortedUrls.FirstOrDefaultAsync(su => su.ShortUrl == "http://localhost:4200/tiny/" + tinyUrl));

            if (url == null)
                throw new NotFoundException("Url");

            return url;
        }

        public async Task<ShortedUrlDto> GetUrlById(int id)
        {
            var url = _mapper.Map<ShortedUrlDto>(await _dbContext.ShortedUrls.FirstOrDefaultAsync(su => su.Id == id));
            return url;
        }

        private static string ShortenUrl(string url)
        {
            //TODO: replace localhost with real domain
            var shortedUrl = "http://localhost:4200/tiny/" + UrlShortenerService.GenerateShortUrl(UrlShortenerService.GenerateKey(url));
            return shortedUrl;
        }

        private async Task<NewUrl> ValidateModel(NewUrl model)
        {
            if(string.IsNullOrEmpty(model.URL))
                throw new InvalidValuesException("Invalid Url");

            var isExist = await _dbContext.Users.AnyAsync(u => u.Id == model.CreatedById);
            var userHas = await _dbContext.ShortedUrls.AnyAsync(u => u.URL == model.URL && u.CreatedById == model.CreatedById);

            if (!isExist)
                throw new InvalidValuesException("User with given Id not found");

            if(userHas)
                throw new InvalidValuesException("This link is already exist");

            return model;
        }
    }
}
