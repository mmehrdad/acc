using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Acc.Infrastructure.Helper;
using Acc.Infrastructure.Configurations;
using Acc.Core.Entities.Interfaces;
using Acc.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Acc.Core.Entities.Identity;
using Acc.Core.Entities;

namespace Acc.Infrastructure.DBContexts
{
    public class AccDbContext :  IdentityDbContext<User, Role, string, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        private readonly IUserInformationProvider userInformationProvider;

        public AccDbContext(IUserInformationProvider userInformationProvider)
        {
            this.userInformationProvider = userInformationProvider;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            options.UseSqlServer(
                AppConfig.GetConnectionString("WebRazorDatabase"),
                providerOptions =>
                {
                    providerOptions.CommandTimeout(180);
                });

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IDbModelConfiguration).Assembly);

            modelBuilder.ApplySoftDeleteQueryFilter();
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<BaseModel>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedTime = DateTime.UtcNow;
                    entry.Entity.Version = 1;
                  //  entry.Entity.Id = IdGenerator.GenerateCustomId();
                    entry.Entity.IsActive = true;
                    entry.Entity.IsDeleted = false;
                    //entry.Entity.CreatorId=userInformationProvider.CurrentUserId;
                    entry.Entity.CreatorIp = HttpRequestExtensions.GetIp(userInformationProvider.HttpContext());
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.ModifiedTime = DateTime.UtcNow;
                    entry.Entity.Version++;
                    //entry.Entity.ModifierId = userInformationProvider.CurrentUserId;
                    entry.Entity.ModifierIp = HttpRequestExtensions.GetIp(userInformationProvider.HttpContext());

                }
                else if (entry.State == EntityState.Deleted)
                {
                    // Soft-delete only if IsDeleted is null (first delete)
                    if (entry.Entity.IsDeleted == null || entry.Entity.IsDeleted == false)
                    {
                        entry.State = EntityState.Modified;
                        entry.Entity.IsDeleted = true;
                    }
                    else
                    {
                        // Physically remove if already soft-deleted (IsDeleted != null)
                        entry.State = EntityState.Deleted;
                    }
                }

            }

           // ApplySoftDelete(ChangeTracker);

            return base.SaveChanges();
        }
        private void ApplySoftDelete(ChangeTracker changeTracker)
        {
            var deletedEntries = changeTracker.Entries().Where(x => x.State == EntityState.Deleted);

            foreach (EntityEntry deletedEntry in deletedEntries)
            {
                if (deletedEntry.Entity is ISoftEntity entity)
                {
                    entity.IsDeleted = true;
                    deletedEntry.State = EntityState.Modified;
                }
            }
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseModel>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedTime = DateTime.UtcNow;
                    entry.Entity.Version = 1;
                   // entry.Entity.Id = IdGenerator.GenerateCustomId();
                    entry.Entity.IsActive = true;
                    entry.Entity.IsDeleted = false;
                    //entry.Entity.CreatorId = userInformationProvider.CurrentUserId;
                    entry.Entity.CreatorIp = HttpRequestExtensions.GetIp(userInformationProvider.HttpContext());

                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.ModifiedTime = DateTime.UtcNow;
                    entry.Entity.Version++;
                    //entry.Entity.ModifierId = userInformationProvider.CurrentUserId;
                    entry.Entity.ModifierIp = HttpRequestExtensions.GetIp(userInformationProvider.HttpContext());

                }
                else if (entry.State == EntityState.Deleted)
                {
                    // Soft-delete only if IsDeleted is null (first delete)
                    if (entry.Entity.IsDeleted == null || entry.Entity.IsDeleted == false)
                    {
                        entry.State = EntityState.Modified;
                        entry.Entity.IsDeleted = true;
                    }
                    else
                    {
                        // Physically remove if already soft-deleted (IsDeleted != null)
                        entry.State = EntityState.Deleted;
                    }
                }

            }
          //  ApplySoftDelete(ChangeTracker);
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
