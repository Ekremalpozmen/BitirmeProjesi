﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BitirmeProjesi.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BitirmeProjesiEntities : DbContext
    {
        public BitirmeProjesiEntities()
            : base("name=BitirmeProjesiEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Animals> Animals { get; set; }
        public virtual DbSet<AnimalsVaccinations> AnimalsVaccinations { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<VetUsers> VetUsers { get; set; }
    }
}
