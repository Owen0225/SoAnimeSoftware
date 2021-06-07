using SoAnimeSoftware.CSGO;
using SoAnimeSoftware.CSGO.Structs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SoAnimeSoftware.Objects;
using SoAnimeSoftware.Utils;

namespace SoAnimeSoftware.Hack.Visuals
{
    unsafe class Chams
    {
        public static CMaterial* Normal;
        public static CMaterial* Flat;
        public static CMaterial* Crystal;
        public static CMaterial* Glass;
        public static CMaterial* PlasticGlass;
        public static CMaterial* DarkChrome;
        public static CMaterial* Reflective;
        public static CMaterial* Glow;
        public static CMaterial* Animated;
        public static CMaterial* Metallic;

        public static Random rnd = new Random();

        public static CMaterial*[] materials;

        public static void Init()
        {
            Normal = CSGO.SDK.MaterialSystem.CreateCustomMaterial("VertexLitGeneric",
                "\"VertexLitGeneric\" {\"$basetexture\" \"vgui/white_additive\" \"$envmap\" \"\" \"$normalmapalphaenvmapmask\" \"1\" \"$envmapcontrast\"  \"1\" \"$nofog\" \"1\" \"$model\" \"1\" \"$nocull\" \"0\" \"$selfillum\" \"1\" \"$halflambert\" \"1\" \"$znearer\" \"0\" \"$flat\" \"1\" \"$ignorez\" \"0\" }");
            Flat = CSGO.SDK.MaterialSystem.CreateCustomMaterial("UnlitGeneric",
                "\"UnlitGeneric\" { \"$basetexture\" \"vgui/white_additive\" \"$envmap\" \"\" \"$normalmapalphaenvmapmask\" \"1\" \"$envmapcontrast\"  \"1\" \"$nofog\" \"1\" \"$model\" \"1\" \"$nocull\" \"0\" \"$selfillum\" \"1\" \"$halflambert\" \"1\" \"$znearer\" \"0\" \"$flat\" \"1\" \"$ignorez\" \"0\" }");
            Crystal = SDK.MaterialSystem.FindMaterial("models/inventory_items/trophy_majors/gloss");
            Glass = SDK.MaterialSystem.FindMaterial(
                "models/inventory_items/cologne_prediction/cologne_prediction_glass");
            PlasticGlass = SDK.MaterialSystem.FindMaterial("models/inventory_items/trophy_majors/gloss");
            DarkChrome = SDK.MaterialSystem.FindMaterial("models/gibs/glass/glas");

            Reflective = CSGO.SDK.MaterialSystem.CreateCustomMaterial("VertexLitGeneric",
                "\"VertexLitGeneric\" {  \"$basetexture\" \"vgui/white_additive\"  \"$envmap\" \"env_cubemap\"  \"$envmaptint\" \"[.10 .10 .10]\"  \"$phong\" \"1\"  \"$phongexponent\" \"200\"  \"$phongboost\" \"1.0\"  \"$rimlight\" \"1\"  \"$nofog\" \"1\"  \"$model\" \"1\"  \"$nocull\" \"0\"  \"$lightwarptexture\" \"metalic\"  \"$selfillum\" \"1\"  \"$halflambert\" \"1\"  \"$ignorez\" \"0\" }");
            Glow = CSGO.SDK.MaterialSystem.CreateCustomMaterial("VertexLitGeneric",
                "\"VertexLitGeneric\" {  \"$additive\" \"1\"  \"$envmap\" \"models/effects/cube_white\"  \"$envmapfresnel\" \"1\"  \"$envmapfresnelminmaxexp\" \"[0 1 2]\"  \"$alpha\" \"0.8\"  \"$ignorez\" \"0\" }");
            Glow->SetTintColor(new FloatColor(Color.MediumPurple));
            //Glow = CSGO.SDK.MaterialSystem.CreateCustomMaterial("VertexLitGeneric",
            //    "\"VertexLitGeneric\" {  \"$additive\" \"1\"  \"$envmap\" \"models/effects/cube_white\"  \"$envmaptint\" \"[1 1 1]\"  \"$envmapfresnel\" \"1\"  \"$envmapfresnelminmaxexp\" \"[0 1 2]\"  \"$alpha\" \"0.8\"  \"$ignorez\" \"0\" }");
            Animated = CSGO.SDK.MaterialSystem.CreateCustomMaterial("VertexLitGeneric",
                "\"VertexLitGeneric\" {$envmap editor/cube_vertigo $envmapcontrast 1 $basetexture dev/zone_warning proxies { texturescroll { texturescrollvar $basetexturetransform texturescrollrate 0.6 texturescrollangle 90 } }}");
            Metallic = SDK.MaterialSystem.CreateCustomMaterial("VertexLitGeneric",
                "\"VertexLitGeneric\" { \"$basetexture\" \"vgui/white_additive\" \"$ignorez\" \"0\" \"$envmap\" \"env_cubemap\" \"$normalmapalphaenvmapmask\" \"1\" \"$envmapcontrast\"  \"1\"  \"$nofog\" \"1\" \"$model\" \"1\" \"$nocull\" \"0\" \"$selfillum\" \"1\" \"$halflambert\" \"1\"  \"$znearer\" \"0\"  \"$flat\" \"1\" }  ");

            materials = new CMaterial*[]
                {Normal, Flat, Crystal, Glass, PlasticGlass, DarkChrome, Metallic, Animated, Reflective, Glow};
        }


        public static Matrix3x4[] s1 = new Matrix3x4[256];
        public static Matrix3x4[] s2 = new Matrix3x4[256];
        public static Matrix3x4[] s3 = new Matrix3x4[256];
        public static Matrix3x4[] s4 = new Matrix3x4[256];

        public static void Render(IntPtr ptr, IntPtr ctx, IntPtr state, ModelRenderInfo* info,
            ref Matrix3x4 customBoneToWorld)
        {
            if (!Settings.chams || CSGO.SDK.ModelRender.IsForcedMaterialOverride())
            {
                CSGO.SDK.ModelRender.DrawModelExecute(ptr, ctx, state, info, ref customBoneToWorld);
                return;
            }


            string modelName = info->model->szName.ToString();
            // Log.Debug(modelName, SDK.ModelInfo.GetStudioHdr(info->model)->numbones
            // );

            if (modelName.StartsWith("models/player"))
            {
                if (info->entityIndex > 0 && info->entityIndex < 65)
                {
                    FloatColor visible;
                    FloatColor occluded;

                    var e = CSGO.SDK.EntityList.GetEntityByIndex(info->entityIndex);

                    if (e == SDK.g_LocalPlayer())
                    {
                        ApplyChams(Normal, new FloatColor(Color.LightSkyBlue), 1f,
                            (EMaterialVarFlag.MATERIAL_VAR_WIREFRAME, false),
                            (EMaterialVarFlag.MATERIAL_VAR_IGNOREZ, false));
                        CSGO.SDK.ModelRender.DrawModelExecute(ptr, ctx, state, info, ref customBoneToWorld);

                        ApplyChams(Glow, new FloatColor(Color.DodgerBlue), 1f,
                            (EMaterialVarFlag.MATERIAL_VAR_WIREFRAME, false),
                            (EMaterialVarFlag.MATERIAL_VAR_IGNOREZ, false));
                        CSGO.SDK.ModelRender.DrawModelExecute(ptr, ctx, state, info, ref customBoneToWorld);

                        CSGO.SDK.StudioRender.ForcedMaterialOverride((CMaterial*) IntPtr.Zero);

                        return;
                    }

                    if (e->isEnemy())
                    {
                        if (!Settings.enemyChams)
                        {
                            CSGO.SDK.ModelRender.DrawModelExecute(ptr, ctx, state, info, ref customBoneToWorld);
                            return;
                        }

                        visible = Settings.enemyChamsVisible;
                        occluded = Settings.enemyChamsOccluded;
                    }
                    else
                    {
                        if (!Settings.teamChams)
                        {
                            CSGO.SDK.ModelRender.DrawModelExecute(ptr, ctx, state, info, ref customBoneToWorld);
                            return;
                        }

                        visible = Settings.teamChamsVisible;
                        occluded = Settings.teamChamsOccluded;
                    }

                    var mat = Normal;

                    if (Settings.matType >= 0 && Settings.matType < materials.Length)
                    {
                        mat = materials[Settings.matType];
                    }


                    Glow->SetTintColor(new FloatColor(Color.Plum));
                    ApplyChams(Flat, new FloatColor(Color.RoyalBlue), 1f,
                        (EMaterialVarFlag.MATERIAL_VAR_WIREFRAME, false),
                        (EMaterialVarFlag.MATERIAL_VAR_IGNOREZ, false));
                    CSGO.SDK.ModelRender.DrawModelExecute(ptr, ctx, state, info, ref customBoneToWorld);

                    ApplyChams(Glow, new FloatColor(Color.Black), 1f, (EMaterialVarFlag.MATERIAL_VAR_WIREFRAME, false),
                        (EMaterialVarFlag.MATERIAL_VAR_IGNOREZ, false));
                    CSGO.SDK.ModelRender.DrawModelExecute(ptr, ctx, state, info, ref customBoneToWorld);
                    
                    CSGO.SDK.StudioRender.ForcedMaterialOverride((CMaterial*) IntPtr.Zero);
                    
                    return;
                }
            }
            else if (modelName.StartsWith("models/weapons/v_"))
            {
                if (modelName.Contains("arms"))
                {
                    Glow->SetTintColor(new FloatColor(Color.RoyalBlue));
                    ApplyChams(Glow, new FloatColor(Color.RoyalBlue), 0.5f,
                        (EMaterialVarFlag.MATERIAL_VAR_WIREFRAME, false),
                        (EMaterialVarFlag.MATERIAL_VAR_IGNOREZ, false));

                    CSGO.SDK.ModelRender.DrawModelExecute(ptr, ctx, state, info, ref customBoneToWorld);
                    CSGO.SDK.StudioRender.ForcedMaterialOverride((CMaterial*) IntPtr.Zero);


                    return;
                }
                else if (modelName.Contains("sleeve"))
                {
                    ApplyChams(Metallic, new FloatColor(Color.Purple), 0.7f,
                        (EMaterialVarFlag.MATERIAL_VAR_WIREFRAME, false),
                        (EMaterialVarFlag.MATERIAL_VAR_IGNOREZ, true));
                    CSGO.SDK.ModelRender.DrawModelExecute(ptr, ctx, state, info, ref customBoneToWorld);
                    CSGO.SDK.StudioRender.ForcedMaterialOverride((CMaterial*) IntPtr.Zero);
                    return;
                }
                else if (!modelName.Contains("tablet") && !modelName.Contains("parachute") &&
                         !modelName.Contains("fists"))
                {
                    ApplyChams(Metallic, new FloatColor(Color.MediumPurple), 1f,
                        (EMaterialVarFlag.MATERIAL_VAR_WIREFRAME, false),
                        (EMaterialVarFlag.MATERIAL_VAR_IGNOREZ, false));
                    CSGO.SDK.ModelRender.DrawModelExecute(ptr, ctx, state, info, ref customBoneToWorld);

                    ApplyChams(Normal, new FloatColor(Color.DodgerBlue), 1f,
                        (EMaterialVarFlag.MATERIAL_VAR_WIREFRAME, true),
                        (EMaterialVarFlag.MATERIAL_VAR_IGNOREZ, false));
                    CSGO.SDK.ModelRender.DrawModelExecute(ptr, ctx, state, info, ref customBoneToWorld);


                    CSGO.SDK.StudioRender.ForcedMaterialOverride((CMaterial*) IntPtr.Zero);
                    return;
                }
            }

            CSGO.SDK.ModelRender.DrawModelExecute(ptr, ctx, state, info, ref customBoneToWorld);
        }
        

        public static void ApplyChams(CMaterial* mat, FloatColor color, float alpha,
            params (EMaterialVarFlag, bool)[] flags)
        {
            for (int i = 0; i < flags.Length; i++)
            {
                mat->SetMaterialVarFlag(flags[i].Item1, flags[i].Item2);
            }

            mat->ColorModulate(color);
            mat->AlphaModulate(alpha);
            CSGO.SDK.StudioRender.ForcedMaterialOverride(mat);
        }
    }
}