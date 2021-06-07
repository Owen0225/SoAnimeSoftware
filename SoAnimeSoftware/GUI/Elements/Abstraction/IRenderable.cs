namespace SoAnimeSoftware.GUI.Elements.Abstraction
{
    public interface IRenderable
    {
        void Draw();

        bool IsValid { get; set; }
    }
}