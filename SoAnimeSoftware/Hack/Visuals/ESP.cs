using SoAnimeSoftware.CSGO;
using SoAnimeSoftware.CSGO.Structs;
using SoAnimeSoftware.Hack.Misc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoAnimeSoftware.GUI;
using SoAnimeSoftware.Hack.Misc.MovementRecorder;
using SoAnimeSoftware.Objects;
using SoAnimeSoftware.Utils;

namespace SoAnimeSoftware.Hack.Visuals
{
    static unsafe class Esp
    {
        public static readonly Box[] PlayerBoxes = new Box[128];
        public static List<Box> WeaponBoxes = new List<Box>();

        public static void Draw()
        {
            if (!Settings.esp)
                return;

            for (int i = 1; i < SDK.EntityList.GetHighestEntityIndex(); ++i)
            {
                var e = CSGO.SDK.EntityList.GetEntityByIndex(i);

                if (e == null)
                    continue;

                var classId = (EClassId) e->GetClientClass()->m_ClassID;

                switch (classId)
                {
                    case EClassId.CCSPlayer:

                        if (e == SDK.g_LocalPlayer())
                            continue;

                        if (e->IsDormant() || !e->IsAlive())
                            continue;

                        PlayerEsp(i, e);
                        BacktrackBox(i, e);
                        break;
                    default:
                        if (e->IsWeapon())
                            if (e->m_hOwnerEntity == -1)
                                WeaponEsp(i, e);
                        break;
                }
            }
        }

        public static DrawList backtrackTrace = new DrawList();
        
        public static void BacktrackBox(int index, Entity* e)
        {
            if (!Settings.backtrack || !Settings.backTrackLT)
                return;

            if (e->IsDormant() || !e->IsAlive() || !SDK.g_LocalPlayer()->IsAlive())
                return;

            if (index < 0 || index >= TargetList.Targets.Length || TargetList.Targets[index] == null)
                return;

            var target = TargetList.Targets[index];
            if (!target.Valid)
                return;

            if (target.Ticks.First == null)
                return;
            
            var pos = ExtraMath.GetBonePosition(target.Ticks.First.Value.Matrix, 8);

            Vector dst = new Vector();
            
            if (ExtraMath.WorldToScreen(pos, ref dst))
            {
                var color = e->IsEnemy() ? Settings.enemyEsp : Settings.teamEsp;
                var oColor = Settings.outlineEsp;
                SDK.Surface.SetDrawColor(color);
                SDK.Surface.DrawOutlinedRect(dst.X - 4, dst.Y - 4, dst.X + 4, dst.Y + 4);
                SDK.Surface.SetDrawColor(oColor);
                SDK.Surface.DrawOutlinedRect(dst.X - 3, dst.Y - 3, dst.X + 3, dst.Y + 3);
                SDK.Surface.DrawOutlinedRect(dst.X - 5, dst.Y - 5, dst.X + 5, dst.Y + 5);
            }
        }

        public static void PlayerEsp(int i, Entity* e)
        {
            if (!Settings.boxes)
                return;

            PlayerBoxes[i].Calc(e);

            if (e->IsEnemy())
                PlayerBoxes[i].Draw(Settings.enemyEsp, Settings.outlineEsp);
            else if (Settings.teamEspEnabled)
                PlayerBoxes[i].Draw(Settings.teamEsp, Settings.outlineEsp);
            else
                return;

            var name = e->PlayerInfo().szName.ToString();
            var health = e->m_iHealth;
            var font = GUI.Render.smallESP;
            var size = SDK.Surface.GetTextSize(font, name);
            SDK.Surface.SetTextPosition(((int) PlayerBoxes[i].x0 + (int) PlayerBoxes[i].x1 - size[0]) / 2,
                (int) PlayerBoxes[i].y0 - size[1]);
            SDK.Surface.SetTextColor(Color.Orange.R, Color.Orange.G, Color.Orange.B, (int) PlayerBoxes[i].opacity);
            SDK.Surface.SetTextFont(font);
            SDK.Surface.PrintText(name);


            size = SDK.Surface.GetTextSize(font, health.ToString());
            SDK.Surface.SetTextPosition(((int) PlayerBoxes[i].x0 + (int) PlayerBoxes[i].x1 - size[0]) / 2,
                (int) PlayerBoxes[i].y1 + size[1] / 3);
            SDK.Surface.SetTextColor(Color.Green.R, Color.Green.G, Color.Green.B, (int) PlayerBoxes[i].opacity);
            SDK.Surface.SetTextFont(font);
            SDK.Surface.PrintText(health.ToString() + '%');

            /*
            if(e == null)
                return;
            var weapon = e->GetActiveWeapon();
            if(weapon == null)
                return;
            var weaponInfo = weapon->GetWeaponData();
            if(weaponInfo == null)
                return;
            size = SDK.Surface.GetTextSize(GVars.icons_glyph22o, health.ToString());
            SDK.Surface.SetTextPosition(((int) playerBoxes[i].x0 + (int) playerBoxes[i].x1 - size[0]) / 2 + 20,
                (int) playerBoxes[i].y1 + size[1] / 3);
            SDK.Surface.SetTextColor(Color.White.R, Color.White.G, Color.White.B, (int) playerBoxes[i].opacity);
            SDK.Surface.SetTextFont(GVars.icons22o);
            SDK.Surface.PrintText(weapon->GetIcon());
            */
        }

        public static void WeaponEsp(int i, Entity* e)
        {
            if (!Settings.boxes)
                return;

            var box = new Box();
            box.Calc(e);
            var sc = SDK.Surface.GetScreenSize();
            if (new Vector((sc[0] - box.x0 - box.x1) / 2, (sc[1] - box.y0 - box.y1) / 2).Length2D /
                (sc[0] / Settings.visualFov) < 2)
                box.opacity = 255;
            else
                box.opacity = 50;
            if (!box.Draw(Settings.weaponEsp, Settings.weaponOutlineEsp))
                return;

            var data = e->GetWeaponData();
            var name = SDK.Localize.FindAsUTF8(data->szHudName)->ToString();
            var size = SDK.Surface.GetTextSize(GUI.Render.smallESP, name);
            SDK.Surface.SetTextPosition(((int) box.x0 + (int) box.x1 - size[0]) / 2, (int) box.y0 - size[1]);
            SDK.Surface.SetTextColor(Color.Orange.R, Color.Orange.G, Color.Orange.B, (int) box.opacity);
            SDK.Surface.SetTextFont(GUI.Render.smallESP);
            SDK.Surface.PrintText(name);
        }

        public unsafe struct Box
        {
            public float x0, y0;
            public float x1, y1;
            public Vector[] vertices;
            public bool valid;
            public Matrix3x4 lastMatrix;
            public bool exists;

            public float opacity;
            public bool vanishing;

            public void Calc(Entity* e)
            {
                var size = CSGO.SDK.Surface.GetScreenSize();

                Vector* mins = e->m_vecMins;
                Vector* maxs = e->m_vecMaxs;

                x0 = size[0] * 2;
                y0 = size[1] * 2;
                x1 = -x0;
                y1 = -y0;
                vertices = new Vector[8];

                for (int i = 0; i < 8; i++)
                {
                    Vector point = new Vector()
                    {
                        X = (i & 1) != 0 ? maxs->X : mins->X,
                        Y = (i & 2) != 0 ? maxs->Y : mins->Y,
                        Z = (i & 4) != 0 ? maxs->Z : mins->Z
                    };

                    if (!e->IsDormant())
                    {
                        if (!ExtraMath.WorldToScreen(point.Transform(e->m_rgflCoordinateFrame), ref vertices[i]))
                        {
                            valid = false;
                            return;
                        }

                        lastMatrix = *e->m_rgflCoordinateFrame;
                        exists = true;
                        vanishing = false;
                    }
                    else if (exists && valid)
                    {
                        if (!ExtraMath.WorldToScreen(point.Transform(lastMatrix), ref vertices[i]))
                        {
                            valid = false;
                            return;
                        }

                        vanishing = true;
                    }

                    if (vertices[i].X < x0)
                        x0 = vertices[i].X;
                    if (vertices[i].Y < y0)
                        y0 = vertices[i].Y;
                    if (vertices[i].X > x1)
                        x1 = vertices[i].X;
                    if (vertices[i].Y > y1)
                        y1 = vertices[i].Y;
                }

                valid = true;
            }

            public bool Draw(ByteColor color, ByteColor outline)
            {
                if (!valid)
                    return false;

                if (vanishing && opacity > 0)
                {
                    opacity -= 5;
                    if (opacity == 0)
                        exists = false;
                }
                else if (!vanishing && opacity < 255)
                    opacity += 5;

                CSGO.SDK.Surface.SetDrawColor(color.R, color.G, color.B, opacity);
                CSGO.SDK.Surface.DrawOutlinedRect((int) x0, (int) y0, (int) x1, (int) y1);
                CSGO.SDK.Surface.SetDrawColor(outline.R, outline.G, outline.B, opacity);
                CSGO.SDK.Surface.DrawOutlinedRect((int) x0 + 1, (int) y0 + 1, (int) x1 - 1, (int) y1 - 1);
                CSGO.SDK.Surface.DrawOutlinedRect((int) x0 - 1, (int) y0 - 1, (int) x1 + 1, (int) y1 + 1);


                return true;
            }
        }
    }
}