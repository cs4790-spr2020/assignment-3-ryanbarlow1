using BlabberApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlabberApp.DataStore
{
    public class BlabConfiguration : IEntityTypeConfiguration<Blab>
    {
        public void Configure(EntityTypeBuilder<Blab> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Message).HasMaxLength(160).IsRequired(); // max length for old times sake
            builder.Property(b => b.DateCreated).IsRequired();
            builder.Property(b => b.UserId).IsRequired();

            builder.HasOne(b => b.User)
                .WithMany(u => u.Blabs)
                .HasForeignKey(b => b.UserId)
                .IsRequired();
        }
    }
}