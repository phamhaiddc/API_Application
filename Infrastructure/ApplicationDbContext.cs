using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<User>> GetUsers(CancellationToken cancellationToken)
        {
            var users = await Users.ToListAsync(cancellationToken);

            // Transform users to UserDto as needed
            var userDtos = users.Select(user => new User
            {
                Id = user.Id,
                Users = user.Users,
                // Map other properties
            }).ToList();

            return userDtos;
        }

    }
}
