﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Empire.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [DisplayName("Display Order")]
        [Range(0, 100, ErrorMessage = "must be 0-100")]
        public int DisplayOrder { get; set; }
    }
}
