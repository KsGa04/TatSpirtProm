﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace TatSprirtProm
{

    public partial class TatSpirtPromEntities : DbContext
    {
        public TatSpirtPromEntities()
            : base("name=TatSpirtPromEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Delivery> Delivery { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Storage> Storage { get; set; }
        public virtual DbSet<Storage_product> Storage_product { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}