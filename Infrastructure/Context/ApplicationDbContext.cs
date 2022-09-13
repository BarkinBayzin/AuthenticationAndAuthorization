using AuthenticationAndAuthorization.Models.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationAndAuthorization.Infrastructure.Context
{
    //IdentityDbContext için "Microsoft.AspNetCore.Identity.EntityFrameworkCore" paketini yüklüyoruz.
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
