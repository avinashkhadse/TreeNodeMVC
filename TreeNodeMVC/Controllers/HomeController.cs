using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TreeNodeMVC.Models;

namespace TreeNodeMVC.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TreeView()
        {
            return View();
        }

        public ActionResult GetTreeNodes()
        {
            var nodes = db.Categories.ToList();

            var treeNodes = nodes.Where(n => n.ParentID == null)
                .Select(n => new Child
                {
                    id = n.ID.ToString(),
                    text = n.Name,
                    children = GetChildren(nodes, n.ID)
                }).ToList();

            var fruitNode = new Child
            {
                id = "fruit",
                text = "Fruit",
                children = new List<Child>
        {
            new Child { id = "apple", text = "Apple" },
            new Child { id = "mango", text = "Mango" }
        }
            };

            // Add Vegetable node
            var vegetableNode = new Child
            {
                id = "vegetable",
                text = "Vegetable",
                children = new List<Child>
        {
            new Child { id = "salad", text = "Salad" },
            new Child { id = "potato", text = "Potato" },
            new Child { id = "mushroom", text = "Mushroom" }
        }
            };

            treeNodes.Add(fruitNode);
            treeNodes.Add(vegetableNode);


            return Json(treeNodes, JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<Child> GetChildren(List<Category> nodes, int parentId)
        {
            return nodes
                .Where(n => n.ParentID == parentId)
                .Select(n => new Child
                {
                    id = n.ID.ToString(),
                    text = n.Name,
                    children = GetChildren(nodes, n.ID)
                });
        }
    }
}
