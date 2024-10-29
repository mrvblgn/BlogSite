using BlogSite.Models.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSite.DataAccess.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("CategoryId");
        builder.Property(x => x.CreatedDate).HasColumnName("CreatedTime");
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedTime");
        builder.Property(x => x.Name).HasColumnName("CategoryName");

        builder
            .HasMany(x => x.Posts)
            .WithOne(c => c.Category)
            .HasForeignKey(c => c.CategoryId)
            .OnDelete(DeleteBehavior.NoAction); // bir kategori silindiğinde ilişkili postların silinmeyeceği anlamına gelir
         
        builder.HasData(new Category
        {
            Id = 1,
            Name = "Yazılım",
            CreatedDate = DateTime.Now,
        });
        
        
    }
}