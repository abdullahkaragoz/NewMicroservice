using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NewMicroservice.Catalog.Api.Features.Categories;
using MongoDB.EntityFrameworkCore.Extensions;

namespace NewMicroservice.Catalog.Api.Repositories;

public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToCollection("categories");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Ignore(x => x.Courses);
    }
}
