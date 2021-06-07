using SoAnimeSoftware.CSGO.Structs;

namespace SoAnimeSoftware.GUI.Elements.Abstraction
{
    public interface IGameSliding : IMoving
    {
        float SlideTime { get; set; }
        Vector FinalPosition { get; set; }
        float Factor { get; set; }
    }
}