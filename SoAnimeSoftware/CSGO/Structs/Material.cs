using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoAnimeSoftware.CSGO;

namespace SoAnimeSoftware.CSGO.Structs
{
    public unsafe struct Material
    {
        public string GetName() {
            fixed (Material* ptr = &this)
            {
                return SDK.Material.GetName(ptr)->ToString();
            }
        }
        public string GetTextureGroupName()
        {
            fixed (Material* ptr = &this)
            {
                return SDK.Material.GetTextureGroupName(ptr)->ToString();
            }
        }
        public void AlphaModulate(float alpha)
        {
            fixed (Material* ptr = &this)
            {
                SDK.Material.AlphaModulate(ptr, alpha);
            }
        }
        public void ColorModulate(SColor color)
        {
            fixed (Material* ptr = &this)
            {
                SDK.Material.ColorModulate(ptr, color);
            }
        }
        public bool IsPrecached()
        {
            fixed (Material* ptr = &this)
            {
                return SDK.Material.IsPrecached(ptr);
            }
        }
        
        
    }
}
