using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UnitOfWork.DAL.Entities
{
    public class Category
    {
        [Key]
        public int IdCateogory { get; set; }
        [Required]
        [MaxLength(255)]
        public string NameCategory { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
