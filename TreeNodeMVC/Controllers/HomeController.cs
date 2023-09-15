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

        // Action to fetch all nodes
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
