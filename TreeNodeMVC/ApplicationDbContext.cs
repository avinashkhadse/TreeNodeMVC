using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TreeNodeMVC.Models;

namespace TreeNodeMVC
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            //Your connection string in Web.Config File
            : base("Server=AVINASH_PATIL\\SQLEXPRESS01;Database=TreeNode;Integrated Security=True;MultipleActiveResultSets=True;Encrypt=False;connect timeout=1000;")
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}