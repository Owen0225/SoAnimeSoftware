using System.Collections.Generic;

namespace SoAnimeSoftware.GUI.Elements.Abstraction
{
    interface IControl
    {
        void Interact();
        LinkedList<IControl> Childrens { get; set; }
        IControl Parent { get; set; }
    }
}