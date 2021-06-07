using System.Collections.Generic;
using SoAnimeSoftware.GUI.Elements.Abstraction;

namespace SoAnimeSoftware.GUI
{
    public class DrawList : LinkedList<IRenderable>
    {
        public DrawList() : base()
        {
        }

        public void Draw()
        {
            var node = First;

            while (node != null)
            {
                var item = node.Value;
                var next = node.Next;

                if (item.IsValid)
                {
                    item.Draw();
                }
                else
                {
                    Remove(node);
                }

                node = next;
            }
        }
    }
}