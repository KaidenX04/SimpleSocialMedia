﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SimpleSocialMedia_ClassLibrary.Entities
{
    [Table("Account")]
    public partial class Account
    {
        public Account()
        {
            ChatAccount1s = new HashSet<Chat>();
            ChatAccount2s = new HashSet<Chat>();
            Comments = new HashSet<Comment>();
            Likes = new HashSet<Like>();
            Messages = new HashSet<Message>();
            Posts = new HashSet<Post>();
        }

        [Key]
        public int AccountID { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string AuthToken { get; set; }
        [Required]
        [StringLength(30)]
        [Unicode(false)]
        public string Username { get; set; }
        [Required]
        [StringLength(30)]
        [Unicode(false)]
        public string Password { get; set; }

        [InverseProperty("Account1")]
        public virtual ICollection<Chat> ChatAccount1s { get; set; }
        [InverseProperty("Account2")]
        public virtual ICollection<Chat> ChatAccount2s { get; set; }
        [InverseProperty("Account")]
        public virtual ICollection<Comment> Comments { get; set; }
        [InverseProperty("Account")]
        public virtual ICollection<Like> Likes { get; set; }
        [InverseProperty("Account")]
        public virtual ICollection<Message> Messages { get; set; }
        [InverseProperty("Account")]
        public virtual ICollection<Post> Posts { get; set; }
    }
}