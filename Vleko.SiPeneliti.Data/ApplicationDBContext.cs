using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Vleko.Bayarind.Data.Model;


namespace Vleko.Bayarind.Data
{
    public partial class ApplicationDBContext : DbContext
    {
        public virtual DbSet<TTransaction> t_transaction { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TTransaction>(entity =>
            {
                entity.ToTable("t_transaction");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.AuthCode)
                    .HasMaxLength(350)
                    .IsUnicode(false)
                    .HasColumnName("AUTH_CODE");

                entity.Property(e => e.CallbackUrl)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("CALLBACK_URL");

                entity.Property(e => e.ChannelId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("CHANNEL_ID")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Currency)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CURRENCY");

                entity.Property(e => e.CustomerAccount)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_ACCOUNT");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_NAME");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.FlagType)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FLAG_TYPE");

                entity.Property(e => e.ProcessFds).HasColumnName("PROCESS_FDS");

                entity.Property(e => e.ServiceCode).HasColumnName("SERVICE_CODE");

                entity.Property(e => e.TransactionAmmoun).HasColumnName("TRANSACTION_AMMOUN");

                entity.Property(e => e.TransactionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("TRANSACTION_DATE");

                entity.Property(e => e.TransactionExpire)
                    .HasColumnType("datetime")
                    .HasColumnName("TRANSACTION_EXPIRE");

                entity.Property(e => e.TransactionMessage)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TRANSACTION_MESSAGE");

                entity.Property(e => e.TransactionNo).HasColumnName("TRANSACTION_NO");

                entity.Property(e => e.TransactionStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TRANSACTION_STATUS");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
