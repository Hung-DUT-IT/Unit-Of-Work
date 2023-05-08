using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UnitOfWork.DAL.Entities
{
    public class Product
    {
        [Key]
        public int IdProduct { get; set; }
        [Required]
        [MaxLength(255)]
        public string NameProduct { get; set; }
        [Required]
        public int Price { get; set; }

        public int IdCateogory { get; set; }
        public Category Category { get; set; }
    }
}
