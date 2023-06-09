﻿using DomainLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.DbContextLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<User> users { get; set; }
        public DbSet<Dentist> dentists { get; set; }
        public DbSet<Instrument> instruments { get; set; }
        public DbSet<Machine> machines { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<Consumber> Consumbers { get; set; }
        public DbSet<RelatedDisease> RelatedDiseases { get; set; }
    }
}
