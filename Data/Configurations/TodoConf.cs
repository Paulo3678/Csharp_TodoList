using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Models;

namespace TodoList.Data.Configurations;

public class TodoConf : IEntityTypeConfiguration<Todo>
{
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
           .ValueGeneratedOnAdd()
           .UseIdentityColumn();

        builder.Property(x => x.Title)
            .HasColumnType("VARCHAR")
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(x => x.Description)
            .HasColumnType("TEXT")
            .IsRequired();

        builder.Property(x => x.Done)
            .HasColumnType("BIT")
            .HasDefaultValue(false)
            .IsRequired();

    }
}
