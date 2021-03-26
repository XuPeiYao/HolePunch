﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HolePunch.Accesses.Repositories
{
    /// <summary>
    /// 使用者群組
    /// </summary>
    [Table("user_group", Schema = "holepunch")]
    public partial class UserGroup
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        /// <summary>
        /// 名稱
        /// </summary>
        [Required]
        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }
        /// <summary>
        /// 是否為管理者
        /// </summary>
        [Column("is_admin")]
        public bool IsAdmin { get; set; }
    }
}