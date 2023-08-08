using AutoMoreira.Core.Domains.Identity;
using Microsoft.EntityFrameworkCore;

namespace AutoMoreira.Persistence.Mapping
{
    public class UserRoleMap : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> entity)
        {
            entity.ToTable("user_role");

            entity.HasKey(user => new { user.UserId, user.RoleId });

            entity.HasOne(userRole => userRole.Role)
                    .WithMany(role => role.UserRoles)
                    .HasForeignKey(userRole => userRole.RoleId)
                    .IsRequired(true);

            entity.HasOne(userRole => userRole.User)
                    .WithMany(role => role.UserRoles)
                    .HasForeignKey(userRole => userRole.UserId)
                    .IsRequired(true);


        }

    }
}
