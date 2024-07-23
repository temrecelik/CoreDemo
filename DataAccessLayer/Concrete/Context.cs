﻿using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
	public class Context : DbContext
	{
		//bu methodun içinde bağlantı stringi tanımlanır
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=DESKTOP-EKSE2T7;database=CoreBlogDb;integrated security=true ;TrustServerCertificate=True");
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<Message2>()
				 .HasOne(X => X.SenderUser)
				 .WithMany(y => y.WriterSender)
				 .HasForeignKey(z => z.SenderID)
				 .OnDelete(DeleteBehavior.ClientSetNull);


            modelBuilder.Entity<Message2>()
                 .HasOne(X => X.ReceiverUser)
                 .WithMany(y => y.WriterReceiver)
                 .HasForeignKey(z => z.ReceiverID)
                 .OnDelete(DeleteBehavior.ClientSetNull);
        }


        //bağlantı stringinden sonra CoreBlogDb altında aşağıdaki tablolarımız oluşur ve tabloların adı
        //s takısı ile olur içerikleri yani sutunları entities'den gelir.
        public DbSet<About> Abouts { get; set; }
		public DbSet<Blog> Blogs { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Writer> Writers { get; set; }
		public DbSet<NewsLetter> NewsLetters { get; set; }
		public DbSet<Notification> Notifications { get; set; } 
		public DbSet<Message> Messages { get; set; }
        public DbSet<Message2> Message2s { get; set; }



    }

}