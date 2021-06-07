using System;
using SoAnimeSoftware.CSGO.Structs;

namespace SoAnimeSoftware.GUI.Elements.Abstraction
{
    public abstract class RenderableBase : IRenderable
    {
        protected DateTime MaxLifeTime;
        protected DateTime CreatedTime;
        protected DateTime CurrentTime;
        protected float TimeLeft;


        protected RenderableBase(DateTime maxLifeTime)
        {
            this.MaxLifeTime = maxLifeTime;
            this.CreatedTime = CurrentTime = DateTime.Now;
            this.IsValid = maxLifeTime > CreatedTime;
        }

        public bool IsValid { get; set; }

        public void TimeUpdate()
        {
            CurrentTime = Render.GlobalTime;
            TimeLeft = (float) (MaxLifeTime - CurrentTime).TotalSeconds;
            IsValid = TimeLeft > 0;
        }

        public abstract bool Calculate();

        public abstract void Draw();
    }
}