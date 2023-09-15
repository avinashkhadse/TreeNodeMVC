using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TreeNodeMVC.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        [Display(Name = "Category Description")]
        public string Description { get; set; }

        [ForeignKey("Parent")]
        public int? ParentID { get; set; }

        public virtual Category Parent { get; set; }

        public virtual ICollection<Category> Childs { get; set; }
    }
}
