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

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresss { get; set; }


        public KfsContext(string aNameOrConnectionString) : base(aNameOrConnectionString)
        {
            //this.Configuration.LazyLoadingEnabled = false;

            //Database.SetInitializer(new CreateDatabaseIfNotExists<KfsContext>()); //deze als dbOk is, is ook de standaard
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<KfsContext>());
            Database.SetInitializer(new DropCreateDatabaseAlways<KfsContext>()); //bij het testen

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
