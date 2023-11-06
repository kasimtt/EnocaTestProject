using EnocaTestProject.Domain.Entities;
using EnocaTestProject.Persistence.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C = EnocaTestProject.Persistence.EntityConfigurations;
using CC = EnocaTestProject.Domain.Entities;

namespace EnocaTestProject.Persistence.Context
{
    public class EnocaTestProjectDB: DbContext
    {
        public EnocaTestProjectDB(DbContextOptions<EnocaTestProjectDB> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //    relationship.DeleteBehavior = DeleteBehavior.Restrict;  //introducing hatası için yazıldı
            //}

            modelBuilder.ApplyConfiguration(new C.CarrierConfiguration());
            modelBuilder.ApplyConfiguration(new CarrierConfigurationConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());

        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker : Entityler üzerinden yapılan değişiklerin ya da yeni eklenen verinin yakalanmasını sağlayan propertydir. Update operasyonlarında Track edilen verileri yakalayıp elde etmemizi sağlar.

            var datas = ChangeTracker
                  .Entries<BaseEntity>();

            foreach (var data in datas)
            {

                switch (data.State)
                {
                    case EntityState.Modified:
                        data.Entity.UpdatedDate = DateTime.UtcNow;
                        //data.Entity.DataState = Domain.Enums.DataState.Active;
                        if (data.Entity.DataState != Domain.Enums.DataState.Deleted)
                        {
                            data.Entity.DataState = Domain.Enums.DataState.Active;
                        }

                        break;
                    case EntityState.Added:
                        data.Entity.CreatedDate = DateTime.UtcNow;
                        data.Entity.DataState = Domain.Enums.DataState.Active;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);

        }

        public DbSet<CC.CarrierConfiguration> CarrierConfigurations { get; set; }
        public DbSet<Carrier> Carriers { get; set; }    
        public DbSet<Order> Orders { get; set; }


    }
}
