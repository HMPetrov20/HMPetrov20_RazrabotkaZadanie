using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class Category
{
    public int CategoryID { get; set; }

    [StringLength(50)]
    public string Name { get; set; }

    // Navigation property

    public ICollection<Book> Books { get; set; }
}

public class Member
{
    public int MemberID { get; set; }

    [StringLength(100)]
    public string Name { get; set; }

    [StringLength(200)]
    public string Address { get; set; }

    [StringLength(20)]
    public string Phone { get; set; }

    [StringLength(100)]
    public string Email { get; set; }

    // Navigation properties

    public ICollection<Loan> Loans { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
}

public class Book
{
    public int BookID { get; set; }

    [StringLength(100)]
    public string Title { get; set; }

    [StringLength(100)]
    public string Author { get; set; }

    public int PublicationYear { get; set; }

    [StringLength(20)]
    public string ISBN { get; set; }

    public int Quantity { get; set; }
    public int AvailableQuantity { get; set; }

    // Foreign key

    public int CategoryID { get; set; }
    
    // Navigation property

    public Category Category { get; set; }
    public ICollection<Loan> Loans { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
}

public class Loan
{
    public int LoanID { get; set; }
    
    // Foreign keys

    public int BookID { get; set; }
    public int MemberID { get; set; }
    
    // Navigation properties

    public Book Book { get; set; }
    public Member Member { get; set; }
    
    public DateTime LoanDate { get; set; }
    public DateTime ReturnDate { get; set; }
}

public class Reservation
{
    public int ReservationID { get; set; }
    
    // Foreign keys

    public int BookID { get; set; }
    public int MemberID { get; set; }
    
    // Navigation properties

    public Book Book { get; set; }
    public Member Member { get; set; }
    
    public DateTime ReservationDate { get; set; }
}

public class LibraryContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Loan> Loans { get; set; }
    public DbSet<Reservation> Reservations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Trqbva da se sloji connection string tuk");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure primary keys

        modelBuilder.Entity<Category>().HasKey(c => c.CategoryID);
        modelBuilder.Entity<Member>().HasKey(m => m.MemberID);
        modelBuilder.Entity<Book>().HasKey(b => b.BookID);
        modelBuilder.Entity<Loan>().HasKey(l => l.LoanID);
        modelBuilder.Entity<Reservation>().HasKey(r => r.ReservationID);

        // Configure relationships

        modelBuilder.Entity<Book>()
            .HasOne(b => b.Category)
            .WithMany(c => c.Books)
            .HasForeignKey(b => b.CategoryID);

        modelBuilder.Entity<Loan>()
            .HasOne(l => l.Book)
            .WithMany(b => b.Loans)
            .HasForeignKey(l => l.BookID);

        modelBuilder.Entity<Loan>()
            .HasOne(l => l.Member)
            .WithMany(m => m.Loans)
            .HasForeignKey(l => l.MemberID);

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Book)
            .WithMany(b => b.Reservations)
            .HasForeignKey(r => r.BookID);

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Member)
            .WithMany(m => m.Reservations)
            .HasForeignKey(r => r.MemberID);
    }
}
