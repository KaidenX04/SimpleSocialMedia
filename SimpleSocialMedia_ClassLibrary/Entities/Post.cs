﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SimpleSocialMedia_ClassLibrary.Entities
{
    [Table("Post")]
    public partial class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
            LikesNavigation = new HashSet<Like>();
        }

        [Key]
        public int PostID { get; set; }
        public int AccountID { get; set; }
        [Required]
        [StringLength(300)]
        [Unicode(false)]
        public string Text { get; set; }
        public int Likes { get; set; }

        [ForeignKey("AccountID")]
        [InverseProperty("Posts")]
        public virtual Account Account { get; set; }
        [InverseProperty("Post")]
        public virtual ICollection<Comment> Comments { get; set; }
        [InverseProperty("Post")]
        public virtual ICollection<Like> LikesNavigation { get; set; }
    }
}