﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store_microservice.Models
{
    public class Subcategory
    {
        
        public int SubcategoryId { get; set; }
        [MaxLength(50)]
        public string SubcategoryName { get; set; }

        [ForeignKey("Category")]
        public int FK_CategoryId { get; set; }
        public Category? Category { get; set; }

        public List<Item>? Items { get; set; }
    }
}
