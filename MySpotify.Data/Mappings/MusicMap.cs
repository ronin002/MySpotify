using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySpotify.Models;

namespace Og1_PM_API.Data.Mappings
{
    public class MusicMap : IEntityTypeConfiguration<Music>
    {
        public void Configure(EntityTypeBuilder<Music> builder)
        {
            builder.ToTable("Music");

            //Chave primária
            builder.HasKey(x => x.Id);

            //Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseMySqlIdentityColumn();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name");

            builder.Property(x => x.Duration)
                .HasColumnName("Duration")
                .HasDefaultValue("");

            builder.Property(x => x.Album)
                .HasColumnName("Album")
                .HasDefaultValue("");

            builder.Property(x => x.Title)
                .HasColumnName("Title")
                .HasDefaultValue("");

            builder.Property(x => x.MusicURL)
                .HasColumnName("MusicURL")
                .HasDefaultValue("");


            builder.Property(x => x.Author)
                .HasColumnName("Author")
                .HasDefaultValue("");

            builder.Property(x => x.Artist)
                .HasColumnName("Artist")
                .HasDefaultValue("");

            builder.Property(x => x.Rhythm)
               .HasColumnName("Rhythm")
               .HasDefaultValue("");

            /*
            builder.HasOne(x => x.Singer)
                .WithMany(m => m.Musics)
                .HasForeignKey(x => x.Id);

            builder.HasOne(x => x.Rhythm)
               .WithMany(x => x.Musics)
               .HasForeignKey(x => x.Id);
            */



            builder
               .HasMany(x => x.Playlists)
               .WithMany(x => x.Musics)
               .UsingEntity<Dictionary<string, object>>(
                   "CompanyRole",
                   role => role
                       .HasOne<Playlist>()
                       .WithMany()
                       .HasForeignKey("Playlist_Id")
                       .HasConstraintName("FK_MusicT_PlaylistId")
                       .OnDelete(DeleteBehavior.NoAction),
                   company => company
                       .HasOne<Music>()
                       .WithMany()
                       .HasForeignKey("Music_Id")
                       .HasConstraintName("FK_PlaylistT_MusicId")
                       .OnDelete(DeleteBehavior.NoAction));
        }
    }
}
