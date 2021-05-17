using KFSolutionsModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSrepository_EF6
{
    public class KfsContext : DbContext
    {
        public DbSet<EmpAddress> EmpAddresss { get; set; }
        public DbSet<EmpAppAccount> EmpAppAccounts { get; set; }
        public DbSet<EmpContract> EmpContracts { get; set; }
        public DbSet<EmpContractStatuutType> EmpContractStatuutTypes { get; set; }
        public DbSet<EmpContractType> EmpContractTypes { get; set; }
        public DbSet<EmpDepartment> EmpDepartments { get; set; }
        public DbSet<Employee> Employees { get; set; }



        //============================================================================================
        public KfsContext(string aNameOrConnectionString) : base(aNameOrConnectionString)
        {
            //this.Configuration.LazyLoadingEnabled = false;

            //Database.SetInitializer(new CreateDatabaseIfNotExists<KfsContext>()); //deze als dbOk is, is ook de standaard
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<KfsContext>());
            Database.SetInitializer(new DropCreateDatabaseAlways<KfsContext>()); //bij het testen

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            //maakt een 1 op veel relatie
            modelBuilder.Entity<Employee>()
                .HasRequired<EmpDepartment>(b => b.EmpDepartment)
                .WithMany(a => a.Employees)
                .HasForeignKey<int>(b => b.Id_EmpDepartment);


            //dit is een 1 op 1 relatie
            modelBuilder.Entity<EmpAddress>()
                .HasOptional(x => x.Employee)
                .WithRequired(a => a.EmpAddress);



            //dit is een 1 op 1 relatie
            modelBuilder.Entity<EmpContract>()
                .HasOptional(x => x.Employee)
                .WithRequired(a => a.EmpContract);

            //maakt een 1 op veel relatie
            modelBuilder.Entity<EmpContract>()
                .HasRequired<EmpContractType>(b => b.EmpContractType)
                .WithMany(a => a.EmpContracts)
                .HasForeignKey<int>(b => b.Id_EmpContractType);

            //maakt een 1 op veel relatie
            modelBuilder.Entity<EmpContract>()
                .HasRequired<EmpContractStatuutType>(b => b.EmpContractStatuutType)
                .WithMany(a => a.EmpContracts)
                .HasForeignKey<int>(b => b.Id_EmpContractStatuutType);


            //dit is een 1 op 0 of 1 relatie
            modelBuilder.Entity<Employee>()
                .HasOptional(x => x.EmpAppAccount)
                .WithRequired(a => a.Employee);
















            ////maakt een 0 of 1 op veel relatie
            //modelBuilder.Entity<Employee>()
            //    .HasOptional<Address>(b => b.Address)
            //    .WithMany(a => a.Employees)
            //    .HasForeignKey<int?>(b => b.Id_Address);



            //---------------------------------------------------------------
            //een adres kan 1 of meer Personen hebben
            //een Persoon kan 0 of 1 Adress hebben
            // <Artist>  1 -------  0* <Album>

            //int Id_Artiest is NIET van het nullable type
            //verkeerd uitgelegd in de tut :-(
            //modelBuilder.Entity<Artist>().HasMany(art => art.Albums)
            //    .WithRequired(alb => alb.Artist)
            //    .HasForeignKey(alb => alb.Id_Artiest);

            //---------------------------------------------------------------



            ////---------------------------------------------------------------
            ////een User kan 0 of meer Playlists hebben
            ////een Playlist moet juist 1 User hebben
            //// <User>  1 -------  0* <Playlist>

            ////int Id_User is NIET van het nullable type
            ////verkeerd uitgelegd in de tut :-(
            //modelBuilder.Entity<User>().HasMany(u => u.PlayLists)
            //    .WithRequired(p => p.User)
            //    .HasForeignKey(p => p.Id_User);


            ////---------------------------------------------------------------
            ////een artiest kan 0 of meer Albums hebben
            ////een album moet juist 1 artiest hebben
            //// <Artist>  1 -------  0* <Album>

            ////int Id_Artiest is NIET van het nullable type
            ////verkeerd uitgelegd in de tut :-(
            //modelBuilder.Entity<Artist>().HasMany(art => art.Albums)
            //    .WithRequired(alb => alb.Artist)
            //    .HasForeignKey(alb => alb.Id_Artiest);

            ////---------------------------------------------------------------

            ////een Album kan 0 of meer Songs bevatten
            ////een song moet juist in Album hebben
            //// <Album>  1 -------  0* <Song>

            ////int Id_Album is NIET van het nullable type
            ////verkeerd uitgelegd in de tut :-(
            //modelBuilder.Entity<Album>().HasMany(a => a.Songs)
            //    .WithRequired(s => s.Album)
            //    .HasForeignKey(s => s.Id_Album);


            ////---------------------------------------------------------------
            ////https://entityframework.net/knowledge-base/7050404/create-code-first--many-to-many--with-additional-fields-in-association-table
            //// <Album>  0* -------  0* <Song>
            //modelBuilder.Entity<PlayList>()
            //    .HasMany(t => t.Songs)
            //    .WithMany(t => t.PlayLists)
            //.Map(m =>
            //{
            //    m.ToTable("PlayList_Songs");
            //    m.MapLeftKey("Id_PlayList");
            //    m.MapRightKey("Id_Song");
            //});

            ////---------------------------------------------------------------


            ////een User kan 0 of meer Interactions bevatten
            ////een interaction moet juist 1 User hebben
            //// <User>  1 -------  0* <Interaction>

            //modelBuilder.Entity<User>().HasMany(i => i.Interactions)
            //    .WithRequired(s => s.User)
            //    .HasForeignKey(s => s.Id_user);

            ////---------------------------------------------------------------


            ////een Song kan 0 of meer Interactions bevatten
            ////een interaction moet juist 1 Song hebben
            ////https://entityframework.net/knowledge-base/7050404/create-code-first--many-to-many--with-additional-fields-in-association-table
            //// <Song>  1 -------  0* <Interaction>

            //modelBuilder.Entity<Song>().HasMany(i => i.Interactions)
            //    .WithRequired(x => x.Song)
            //    .HasForeignKey(s => s.Id_song);






            base.OnModelCreating(modelBuilder);
        }



    }
}
