using SoAnimeSoftware.CSGO;
using SoAnimeSoftware.CSGO.Structs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.Hack.Visuals
{
    class Glow
    {
        public unsafe static void Run()
        {
            int lp_team = CSGO.SDK.g_LocalPlayer()->m_iTeamNum;

            for (int i = 0; i < CSGO.SDK.GlowObjManager.GlowObjectCount(); i++)
            {
                GlowObjectDefinition* obj = CSGO.SDK.GlowObjManager.GetGlowObject(i);
                if (obj->IsUnused())
                    continue;
                Entity* e = obj->entity;
                if (e == null || e->IsDormant())
                    continue;


                switch ((EClassId) e->GetClientClass()->m_ClassID)
                {
                    case EClassId.CCSPlayer:
                        if (!Settings.glow)
                            continue;

                        FloatColor color;

                        if (e->m_iTeamNum == lp_team)
                        {
                            if (!Settings.teamGlow)
                                continue;
                            color = Settings.teamGlowColor;
                        }
                        else
                            color = Settings.enemyGlowColor;

                        if (!e->IsAlive())
                            continue;

                        obj->glowColor = color;
                        obj->glowAlpha = Settings.alphaGlow;
                        obj->glowStyle = Settings.styleGlow;
                        obj->_renderWhenOccluded = 1;
                        obj->_renderWhenUnoccluded = 0;
                        break;

                    case EClassId.CPlantedC4:
                        obj->glowColor = new FloatColor(Color.Purple);
                        obj->glowAlpha = 0.8f;
                        obj->glowStyle = 0;
                        obj->_renderWhenOccluded = 1;
                        obj->_renderWhenUnoccluded = 0;
                        break;
                }
            }
        }
    }
}