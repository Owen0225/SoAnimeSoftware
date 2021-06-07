using System.Drawing;
using SoAnimeSoftware.CSGO.Structs;

namespace SoAnimeSoftware.GUI.Elements.Abstraction
{
    interface IFading : IAnimated
    {
        int FinalOpacity { get; set; }
        float FadeTime { get; set; }
        int OpacityOffset { get; set; }

        void Fade();
    }
}