using E_commerceWebsite.Domain.Entities;
using E_commerceWebsite.Infrastructure.Persistence;
using Serilog;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs;

namespace E_commerceWebsite.Infrastructure.Repositories
{
    public class CreateKeyAppRepositories
    {
        private readonly E_commerceWebsiteDbContext _context;
        private readonly ILogger _logger;
        private static string Methods = "CreateKeyAppRepositories";

        public CreateKeyAppRepositories(E_commerceWebsiteDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<KeyApp?> CreateAsync(KeyAppDto model)
        {
            if (string.IsNullOrEmpty(model.ServiceKeyId) ||
                string.IsNullOrEmpty(model.NameKey) ||
                string.IsNullOrEmpty(model.Value))
            {
                return null;
            }

            var entity = new KeyApp
            {
                Id = Guid.NewGuid(),
                ServiceKeyId = model.ServiceKeyId,
                NameKey = model.NameKey,
                Value = model.Value,
                Description = model.Description,
                CreatedDate = DateTime.UtcNow
            };

            _context.KeyApps.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IList<KeyConfigDto>> GetByServiceKeyId(string value)
        {
            try
            {
                var keyApp = await _context.KeyApps
                    .FirstOrDefaultAsync(k => k.Value == value);

                if (keyApp == null)
                {
                    return null;
                }

                return new List<KeyConfigDto>
                {
                    new KeyConfigDto
                    {
                        NameKey = keyApp.NameKey,
                        Value = keyApp.Value,
                        Description = keyApp.Description
                    }
                };
            }
            catch (Exception ex)
            {
                _logger.Error($"Exception in {nameof(GetByServiceKeyId)}: {ex.Message}");
                return null;
            }
        }
    }
}
