﻿using BBData.Model;
using Microsoft.EntityFrameworkCore;

namespace BBData.DB
{
    public class BookBorrowingDBContext : DbContext
    {
        public BookBorrowingDBContext(DbContextOptions<BookBorrowingDBContext> options) : base(options)
        {
        

        }
        public BookBorrowingDBContext() : base() { }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookBorrowing> BookBorrowings { get; set; }
        public DbSet<Country> Countries { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().ToTable("Country").HasKey(m => m.Id);

            modelBuilder.Entity<Book>().ToTable("Book").HasKey(m => m.Id);
            //how do we extend the data model?
            modelBuilder.Entity<Book>()
        .HasDiscriminator<string>("Edition")
        .HasValue<Book>("Book")
        .HasValue<NewInfoForBook>("NewInfoForBook");
        
         modelBuilder.Entity<BookBorrowing>().ToTable("BookBorrowing").HasKey(m => m.Id);


            modelBuilder.Seed();

        }
    }
}

