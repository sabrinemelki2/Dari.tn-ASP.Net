//using Dari.Data.Configurations;
//using Dari.Data.Conventions;
using Dari.Data.configurations;
using Dari.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;

namespace Dari.Data
{
    public class Context : IdentityDbContext<Client, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {

        public Context() : base("name=MaChaine")
        {

        }
        static Context()
        {
            Database.SetInitializer<Context>(null);
        }

        public static Context Create()
        {
            return new Context();
        }
        public virtual DbSet<Annonce> Annonces { get; set; }
        public virtual DbSet<Rate> Rates { get; set; }
        public virtual DbSet<Meuble> Meuble { get; set; }
        public DbSet<CategorieMeub> CategorieMeubs { get; set; }
        public virtual DbSet<RDV> RDV { get; set; }
       





        protected override void OnModelCreating(DbModelBuilder modelBuilder)
         {

            base.OnModelCreating(modelBuilder);
            // RDV Entity 
           
            modelBuilder.Entity<RDV>()
                .HasRequired<Client>(a => a.visiteur)
                .WithMany(d => d.RDVS)
                .HasForeignKey(d => d.visiteurID).WillCascadeOnDelete(false);
            ////
            modelBuilder.Configurations.Add(new Meubleconfiguration());

        }

        public class ContexInit : DropCreateDatabaseIfModelChanges<Context>
        {
            protected override void Seed(Context context)
            {

            }
        }


    }


}
