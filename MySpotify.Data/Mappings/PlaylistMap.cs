using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySpotify.Models;

namespace Og1_PM_API.Data.Mappings
{
    public class PlaylistMap : IEntityTypeConfiguration<Playlist>
    {
        public void Configure(EntityTypeBuilder<Playlist> builder)
        {
            builder.ToTable("Playlist");

            //Chave primária
            builder.HasKey(x => x.Id);

            //Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseMySqlIdentityColumn();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name");
            
            builder.Property(x => x.OwnerId)
                .IsRequired()
                .HasColumnName("OwnerId");

            builder.Property(x => x.ImageURL)
                .HasColumnName("ImageURL")
                .HasDefaultValue("");

            builder
               .HasMany(x => x.Musics)
               .WithMany(x => x.Playlists)
               .UsingEntity<Dictionary<string, object>>(
                   "CompanyRole",
                   role => role
                       .HasOne<Music>()
                       .WithMany()
                       .HasForeignKey("Music_Id")
                       .HasConstraintName("FK_Playlist_MusicId")
                       .OnDelete(DeleteBehavior.NoAction),
                   company => company
                       .HasOne<Playlist>()
                       .WithMany()
                       .HasForeignKey("Playlist_Id")
                       .HasConstraintName("FK_Music_PlaylistId")
                       .OnDelete(DeleteBehavior.NoAction));
        }
    }
}
