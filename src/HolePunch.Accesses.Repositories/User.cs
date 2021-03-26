﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HolePunch.Accesses.Repositories
{
    /// <summary>
    /// 用戶
    /// </summary>
    [Table("user", Schema = "holepunch")]
    public partial class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        /// <summary>
        /// 帳號
        /// </summary>
        [Required]
        [Column("account")]
        [StringLength(255)]
        public string Account { get; set; }
        /// <summary>
        /// 密碼(SHA1)
        /// </summary>
        [Required]
        [Column("password")]
        [StringLength(255)]
        public string Password { get; set; }
        /// <summary>
        /// 名稱
        /// </summary>
        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }
        /// <summary>
        /// 是否啟用
        /// </summary>
        [Column("enabled")]
        public bool Enabled { get; set; }
    }
}