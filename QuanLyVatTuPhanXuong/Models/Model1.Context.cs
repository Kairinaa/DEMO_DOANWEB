﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyVatTuPhanXuong.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QuanLyVatTuPhanXuongXeEntities : DbContext
    {
        public QuanLyVatTuPhanXuongXeEntities()
            : base("name=QuanLyVatTuPhanXuongXeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tNuocSX> tNuocSXes { get; set; }
        public virtual DbSet<tPhuKien> tPhuKiens { get; set; }
        public virtual DbSet<tThanhPhan> tThanhPhans { get; set; }
        public virtual DbSet<tTho> tThoes { get; set; }
        public virtual DbSet<tXe> tXes { get; set; }
    }
}