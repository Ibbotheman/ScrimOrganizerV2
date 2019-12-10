using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ScrimOrganizerV2.Models;

namespace ScrimOrganizerV2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ScrimOrganizerV2.Models.Team> Team { get; set; }
        public DbSet<ScrimOrganizerV2.Models.Summoner> Summoner { get; set; }
        public DbSet<ScrimOrganizerV2.Models.VersusTeam> VersusTeam { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Team>()
                .HasMany(a => a.Summoners)
                .WithOne(b => b.Team)
                .OnDelete(DeleteBehavior.Cascade);            
        }
    }
}
