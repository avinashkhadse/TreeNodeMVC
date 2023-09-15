using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jsTree3.Models
{
    public class jsTree
    {
        public string id;
        public string text;
        public string icon;
        public State state;
        public List<jsTree> children;

        public static jsTree NewNode(string id)
        {
            return new jsTree()
            {
                id = id,
                text = string.Format("Node {0}", id),
                children = new List<jsTree>()
            };
        }
    }
    public class State
    {
        public bool opened = false;
        public bool disabled = false;
        public bool selected = false;

        public State(bool Opened, bool Disabled, bool Selected)
        {
            opened = Opened;
            disabled = Disabled;
            selected = Selected;
        }
    }
   
}