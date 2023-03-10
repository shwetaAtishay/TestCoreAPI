using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Models
{
    //internal class NOCContext
    //{
    //}
    public partial class NOCContext : DbContext
    {
        public NOCContext()
        {
        }

        public NOCContext(DbContextOptions<NOCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SRVCMST> CategoryMaster { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
        #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=Zapures;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SRVCMST>(entity =>
            {
                entity.HasKey(e => e.iPK_CatId);

                entity.Property(e => e.sClsNm).HasMaxLength(100);

                entity.Property(e => e.sCrtdBy).HasMaxLength(10);

                entity.Property(e => e.dtCrtdDt).HasColumnType("datetime");

                entity.Property(e => e.sDcmntLst).HasMaxLength(50);

                entity.Property(e => e.sHrdwrLst).HasMaxLength(50);

                entity.Property(e => e.sName).HasMaxLength(500);

                entity.Property(e => e.sSrvcLst).HasMaxLength(50);

                entity.Property(e => e.sUpdtBy).HasMaxLength(10);

                entity.Property(e => e.dtUpdtOn).HasColumnType("datetime");

                entity.Property(e => e.sVrfctnLst).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
