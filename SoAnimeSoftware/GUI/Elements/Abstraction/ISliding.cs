namespace SoAnimeSoftware.GUI.Elements.Abstraction
{
    interface ISliding : IMoving
    {
        int FinalX { get; set; }
        int FinalY { get; set; }
        float SlideTime { get; set; }
        float Factor { get; set; }
    }
}