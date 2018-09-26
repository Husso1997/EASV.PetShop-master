﻿using Easv.PetShop.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easv.PetShop.Infrastructure.Data
{
    public class PetAppContext : DbContext
    {
        public PetAppContext(DbContextOptions<PetAppContext> opt) : base(opt)
        {

        }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pet>().HasOne<Owner>(o => o.PetOwner).
                 WithMany(o => o.Pets).OnDelete(DeleteBehavior.SetNull);
        }


    }
}
