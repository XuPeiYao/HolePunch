﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HolePunch.Accesses.Repositories
{
    /// <summary>
    /// 網段組
    /// </summary>
    [Table("cidr_group", Schema = "holepunch")]
    public partial class CidrGroup
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        /// <summary>
        /// 名稱
        /// </summary>
        [Required]
        [Column("name")]
        [StringLength(100)]
        public string Name { get; set; }
        /// <summary>
        /// 網段集合
        /// </summary>
        [Column("cidr_list")]
        public string[] CidrList { get; set; }
    }
}