﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HolePunch.Accesses.Repositories
{
    public partial class HolePunchContext : DbContext
    {
        public HolePunchContext()
        {
        }

        public HolePunchContext(DbContextOptions<HolePunchContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CidrGroup> CidrGroup { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<ServiceAllowlist> ServiceAllowlist { get; set; }
        public virtual DbSet<ServiceForwardTarget> ServiceForwardTarget { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserGroup> UserGroup { get; set; }
        public virtual DbSet<UserGroupMember> UserGroupMember { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CidrGroup>(entity =>
            {
                entity.HasComment("網段組");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.CidrList).HasComment("網段集合");

                entity.Property(e => e.Name).HasComment("名稱");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasComment("服務");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Enabled).HasComment("是否啟用");

                entity.Property(e => e.LogoUrl).HasComment("服務Logo圖片網址");

                entity.Property(e => e.Name).HasComment("服務名稱");

                entity.Property(e => e.Port).HasComment("服務Listen埠號");

                entity.Property(e => e.Protocol).HasComment("通訊協議(TCP/UDP)");
            });

            modelBuilder.Entity<ServiceAllowlist>(entity =>
            {
                entity.HasComment("容許網段");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Cidr).HasComment("網段");

                entity.Property(e => e.CidrGroupId).HasComment("網段組");

                entity.Property(e => e.ServiceForwardTargetId).HasComment("服務轉發目標ID，若為空則表示整個服務");

                entity.Property(e => e.ServiceId).HasComment("服務ID");

                entity.Property(e => e.Type).HasComment("類型(CIDR_GROUP、CIDR、USER_GROUP、USER)");

                entity.Property(e => e.UserGroupId).HasComment("使用者群組");

                entity.Property(e => e.UserId).HasComment("使用者ID");
            });

            modelBuilder.Entity<ServiceForwardTarget>(entity =>
            {
                entity.HasComment("服務轉發目標");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Enabled).HasComment("是否啟用");

                entity.Property(e => e.IpAddress).HasComment("IP");

                entity.Property(e => e.Name).HasComment("轉發目標名稱");

                entity.Property(e => e.Port).HasComment("埠號");

                entity.Property(e => e.Priority).HasComment("優先權(0最大)");

                entity.Property(e => e.ServiceId).HasComment("服務ID");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasComment("用戶");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Account).HasComment("帳號");

                entity.Property(e => e.Enabled).HasComment("是否啟用");

                entity.Property(e => e.Name).HasComment("名稱");

                entity.Property(e => e.Password).HasComment("密碼(SHA1)");
            });

            modelBuilder.Entity<UserGroup>(entity =>
            {
                entity.HasComment("使用者群組");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.IsAdmin).HasComment("是否為管理者");

                entity.Property(e => e.Name).HasComment("名稱");
            });

            modelBuilder.Entity<UserGroupMember>(entity =>
            {
                entity.HasKey(e => new { e.UserGroupId, e.UserId })
                    .HasName("pk_user_group_member");

                entity.HasComment("使用者群組成員");

                entity.Property(e => e.UserGroupId).HasComment("使用者群組ID");

                entity.Property(e => e.UserId).HasComment("使用者ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}