using SoAnimeSoftware.CSGO;
using SoAnimeSoftware.CSGO.Structs;
using SoAnimeSoftware.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static SoAnimeSoftware.CSGO.ESequence;
using static SoAnimeSoftware.CSGO.EItemDefinitionIndex;
using System.Runtime.InteropServices;

namespace SoAnimeSoftware.Hack.Visuals
{
    unsafe class SkinChanger
    {
        public static Random random = new Random((int) DateTime.Now.Ticks);
        public static Dictionary<string, int> ModelIndexes;

        public static Dictionary<EItemDefinitionIndex, string> WeaponIcons =
            new Dictionary<EItemDefinitionIndex, string>()
            {
                [KNIFE] = "knife",
                [_T_] = "knife_t",
                [BAYONET] = "bayonet",
                [FLIP] = "knife_flip",
                [GUT] = "knife_gut",
                [KARAMBIT] = "knife_karambit",
                [M9_BAYONET] = "knife_m9_bayonet",
                [TACTICAL] = "knife_tactical",
                [FALCHION] = "knife_falchion",
                [SURVIVAL_BOWIE] = "knife_survival_bowie",
                [BUTTERFLY] = "knife_butterfly",
                [PUSH] = "knife_push",
                [URSUS] = "knife_ursus",
                [NAVAJA] = "knife_gypsy_jackknife",
                [STILETTO] = "knife_stiletto",
                [WIDOWMAKER] = "knife_widowmaker",
                [CLASSIC] = "knife_css",
                [SKELETON] = "knife_skeleton",
                [SURVIVAL] = "knife_canis",
                [NOMAD] = "knife_outdoor",
                [PARACORD] = "knife_cord",
            };

        public static void Init()
        {
            ModelIndexes = new Dictionary<string, int>()
            {
                ["KNIFE"] = SDK.ModelInfo.GetModelIndex("models/weapons/v_knife_default_ct.mdl"),
                ["_T_"] = SDK.ModelInfo.GetModelIndex("models/weapons/v_knife_default_t.mdl"),
                ["BAYONET"] = SDK.ModelInfo.GetModelIndex("models/weapons/v_knife_bayonet.mdl"),
                ["FLIP"] = SDK.ModelInfo.GetModelIndex("models/weapons/v_knife_flip.mdl"),
                ["GUT"] = SDK.ModelInfo.GetModelIndex("models/weapons/v_knife_gut.mdl"),
                ["KARAMBIT"] = SDK.ModelInfo.GetModelIndex("models/weapons/v_knife_karam.mdl"),
                ["M9_BAYONET"] = SDK.ModelInfo.GetModelIndex("models/weapons/v_knife_m9_bay.mdl"),
                ["TACTICAL"] = SDK.ModelInfo.GetModelIndex("models/weapons/v_knife_tactical.mdl"),
                ["FALCHION"] = SDK.ModelInfo.GetModelIndex("models/weapons/v_knife_falchion_advanced.mdl"),
                ["SURVIVAL_BOWIE"] = SDK.ModelInfo.GetModelIndex("models/weapons/v_knife_survival_bowie.mdl"),
                ["BUTTERFLY"] = SDK.ModelInfo.GetModelIndex("models/weapons/v_knife_butterfly.mdl"),
                ["PUSH"] = SDK.ModelInfo.GetModelIndex("models/weapons/v_knife_push.mdl"),
                ["URSUS"] = SDK.ModelInfo.GetModelIndex("models/weapons/v_knife_ursus.mdl"),
                ["NAVAJA"] = SDK.ModelInfo.GetModelIndex("models/weapons/v_knife_gypsy_jackknife.mdl"),
                ["STILETTO"] = SDK.ModelInfo.GetModelIndex("models/weapons/v_knife_stiletto.mdl"),
                ["WIDOWMAKER"] = SDK.ModelInfo.GetModelIndex("models/weapons/v_knife_widowmaker.mdl"),
                ["CLASSIC"] = SDK.ModelInfo.GetModelIndex("models/weapons/v_knife_css.mdl"),
                ["SKELETON"] = SDK.ModelInfo.GetModelIndex("models/weapons/v_knife_skeleton.mdl"),
                ["SURVIVAL"] = SDK.ModelInfo.GetModelIndex("models/weapons/v_knife_canis.mdl"),
                ["NOMAD"] = SDK.ModelInfo.GetModelIndex("models/weapons/v_knife_outdoor.mdl"),
                ["PARACORD"] = SDK.ModelInfo.GetModelIndex("models/weapons/v_knife_cord.mdl"),

                ["STUDDED_BLOODHOUND"] =
                    SDK.ModelInfo.GetModelIndex("models/weapons/w_models/arms/w_glove_bloodhound.mdl"),
                ["T_SIDE"] = SDK.ModelInfo.GetModelIndex("models/weapons/w_models/arms/w_glove_fingerless.mdl"),
                ["CT_SIDE"] = SDK.ModelInfo.GetModelIndex("models/weapons/w_models/arms/w_glove_hardknuckle.mdl"),
                ["SPORTY"] = SDK.ModelInfo.GetModelIndex("models/weapons/w_models/arms/w_glove_sporty.mdl"),
                ["SLICK"] = SDK.ModelInfo.GetModelIndex("models/weapons/w_models/arms/w_glove_slick.mdl"),
                ["LEATHER_WRAP"] =
                    SDK.ModelInfo.GetModelIndex("models/weapons/w_models/arms/w_glove_handwrap_leathery.mdl"),
                ["MOTORCYCLE"] = SDK.ModelInfo.GetModelIndex("models/weapons/w_models/arms/w_glove_motorcycle.mdl"),
                ["SPECIALIST"] = SDK.ModelInfo.GetModelIndex("models/weapons/w_models/arms/w_glove_specialist.mdl"),
                ["HYDRA"] = SDK.ModelInfo.GetModelIndex("models/weapons/w_models/arms/w_glove_bloodhound_hydra.mdl")
            };
        }

        public static int GetModelIndex(string name)
        {
            if (ModelIndexes == null)
                Init();
            return ModelIndexes[name];
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate Entity* CreateEntityDlg(int entry, int serial);

        public static Entity* CreateGlove(int entry, int serial)
        {
            var createFnPtr = IntPtr.Zero;
            for (var clientClass = SDK.Client.GetAllClasses(); clientClass != null; clientClass = clientClass->m_pNext)
                if (clientClass->m_ClassID == (int) EClassId.CEconWearable)
                {
                    createFnPtr = clientClass->m_pCreateFn;
                    break;
                }

            if (createFnPtr == IntPtr.Zero)
                return null;

            Marshal.GetDelegateForFunctionPointer<CreateEntityDlg>(createFnPtr)(entry, serial);
            return SDK.EntityList.GetEntityByIndex(entry);
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate int EquipWearableDlg(IntPtr thisptr, IntPtr player);

        private static int _gloveHandle;

        public static void SetupGlove()
        {
            var lp = SDK.EntityList.GetEntityByIndex(SDK.Engine.GetLocalPlayer());

            var wearables = lp->m_hMyWearables;

            var glove = SDK.EntityList.GetEntityFromHandle(wearables);

            if (glove == null)
            {
                var our_glove = SDK.EntityList.GetEntityFromHandle(_gloveHandle);
                if (our_glove != null)
                {
                    lp->m_hMyWearables = _gloveHandle;
                    glove = our_glove;
                }
            }

            if (glove == null)
            {
                var entry = SDK.EntityList.GetHighestEntityIndex() + 1;
                for (int i = 65; i <= SDK.EntityList.GetHighestEntityIndex(); i++)
                {
                    var e = SDK.EntityList.GetEntityByIndex(i);
                    if (e == null)
                        continue;
                    if (e->GetClientClass()->m_ClassID == 70)
                    {
                        entry = i;
                        break;
                    }
                }


                var serial = random.Next(0, int.MaxValue) % 0x1000;

                glove = CreateGlove(entry, serial);

                if (glove == null)
                {
                    return;
                }

                if (glove != null)
                {
                    Log.Debug(11);
                    glove->m_bInitialized = true;
                    lp->m_hMyWearables = entry | serial << 16;
                    _gloveHandle = lp->m_hMyWearables;
                }
            }

            if (glove != null)
            {
                Marshal.GetDelegateForFunctionPointer<EquipWearableDlg>(Offsets.EquipWearablePointer)((IntPtr) glove,
                    (IntPtr) lp);

                lp->m_nBody = 1;

                var model = "SPORTY";

                var model_index = GetModelIndex(model);

                if (glove->m_nModelIndex != model_index)
                    glove->m_nModelIndex = model_index;

                if (glove->m_iItemDefinitionIndex != (int) Enum.Parse(typeof(EItemDefinitionIndex), model))
                    glove->m_iItemDefinitionIndex = (int) Enum.Parse(typeof(EItemDefinitionIndex), model);

                glove->m_nFallbackPaintKit = 10008;
                glove->m_flFallbackWear = 0.0001f;
                glove->m_iAccountID = lp->PlayerInfo().xuidLow;
                glove->m_iItemIDHigh = -1;
                glove->SetModelIndex(model_index);
                glove->PreDataUpdate();
            }
        }

        public static void Run()
        {
            if (!Settings.skinChanger)
                return;

            var lp = SDK.EntityList.GetEntityByIndex(SDK.Engine.GetLocalPlayer());

            if (lp == null)
                return;

            if (!lp->IsAlive())
                return;

            if (Settings.needRebuildSkin == Status.ENABLED)
            {
                Settings.needRebuildSkin = Status.ENABLED_DONE;
                SDK.ClientState->m_nDeltaTick = -1;
                return;
            }
            else if (Settings.needRebuildSkin == Status.ENABLED_DONE)
            {
                Settings.needRebuildSkin = Status.DISABLED;
                SDK.ClientState->m_nDeltaTick = -1;
                return;
            }

            var weapons = lp->m_hMyWeapons;

            for (var i = 0; weapons[i] != (IntPtr) (-1); i++)
            {
                var hWeapon = SDK.EntityList.GetEntityFromHandle((int) weapons[i]);

                if (hWeapon == null) break;

                if (hWeapon->m_iItemDefinitionIndex == 59 || hWeapon->m_iItemDefinitionIndex == 42 ||
                    (hWeapon->m_iItemDefinitionIndex > 400 && hWeapon->m_iItemDefinitionIndex < 600))
                {
                    if (string.IsNullOrEmpty(Settings.knife))
                        continue;

                    var modelIndex = GetModelIndex(Settings.knife);

                    if (hWeapon->m_nModelIndex != modelIndex)
                        hWeapon->m_nModelIndex = modelIndex;


                    if (hWeapon->m_iItemDefinitionIndex !=
                        (int) Enum.Parse(typeof(EItemDefinitionIndex), Settings.knife))
                        hWeapon->m_iItemDefinitionIndex =
                            (int) Enum.Parse(typeof(EItemDefinitionIndex), Settings.knife);

                    hWeapon->m_nFallbackPaintKit = Settings.skinId;
                    hWeapon->m_flFallbackWear = 0.0001f;
                    hWeapon->m_iAccountID = hWeapon->m_OriginalOwnerXuidLow;
                    //hWeapon->m_nFallbackStatTrak = 9999;
                    hWeapon->m_iItemIDHigh = -1;


                    var paintKit = (CPaintKit*) hWeapon->GetPaintKitDefinition();
                    paintKit->color1 = Settings.color1;
                    paintKit->color2 = Settings.color2;
                    paintKit->color3 = Settings.color3;
                    paintKit->color4 = Settings.color4;
                    paintKit->pearlescent = Settings.pearlescent < 0 ? paintKit->pearlescent : Settings.pearlescent;


                    var viewMdl = SDK.EntityList.GetEntityFromHandle(lp->m_hViewModel);
                    if (viewMdl == null) continue;


                    var currentWeapon = SDK.EntityList.GetEntityFromHandle(viewMdl->m_hWeapon);
                    if (currentWeapon == null) continue;

                    if (currentWeapon == hWeapon && viewMdl->m_nModelIndex != modelIndex)
                        viewMdl->m_nModelIndex = modelIndex;
                }
                else
                {
                    hWeapon->m_flFallbackWear = 0.001f;
                    hWeapon->m_iAccountID = hWeapon->m_OriginalOwnerXuidLow;
                    //hWeapon->m_nFallbackStatTrak = 228;
                    hWeapon->m_iItemIDHigh = -1;

                    hWeapon->m_nFallbackPaintKit = Settings.skinId;
                    var paintKit = (CPaintKit*) hWeapon->GetPaintKitDefinition();

                    paintKit->color1 = Settings.color1;
                    paintKit->color2 = Settings.color2;
                    paintKit->color3 = Settings.color3;
                    paintKit->color4 = Settings.color4;
                    paintKit->pearlescent = Settings.pearlescent < 0 ? paintKit->pearlescent : Settings.pearlescent;
                }
            }

            if (Settings.needRebuildSkin == Status.ENABLED_DONE)
            {
                Settings.needRebuildSkin = Status.DISABLED;
                SDK.ClientState->m_nDeltaTick = -1;
            }
            else if (Settings.needRebuildSkin == Status.DISABLED)
            {
                ForceFullupdate();
                Settings.needRebuildSkin = Status.DISABLED_DONE;
            }
            else if (Settings.needRebuildSkin == Status.DISABLED_DONE)
            {
                hudUpdateRequired = true;
                Settings.needRebuildSkin = Status.UNDEFINED;
            }
        }


        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate int SetStickerAttributeIntDlg(IntPtr thisptr, int slot, int attributeType);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate float SetStickerAttributeFloatDlg(IntPtr thisptr, int slot, int attributeType);

        public static SetStickerAttributeIntDlg o_SetStickerAttributeInt;
        public static SetStickerAttributeFloatDlg o_SetStickerAttributeFloat;
        public static SetStickerAttributeIntDlg hk_SetStickerAttributeInt;
        public static SetStickerAttributeFloatDlg hk_SetStickerAttributeFloat;

        public static int ItemVTableOffset = 0;
        public static IntPtr ItemVtablePtr;

        public static bool hooked = false;

        public static void StickerApply(Entity* item)
        {
            if (ItemVTableOffset == 0)
                ItemVTableOffset = Offsets.DT_EconEntity.m_Item + 0xC;

            if (!hooked)
            {
                ItemVtablePtr = (IntPtr) (ItemVTableOffset + (int) item);

                hk_SetStickerAttributeInt = SetStickerAttributeInt;
                hk_SetStickerAttributeFloat = SetStickerAttributeFloat;
                o_SetStickerAttributeInt =
                    Marshal.GetDelegateForFunctionPointer<SetStickerAttributeIntDlg>(
                        Memory.SetVTableFunction(ItemVtablePtr, 5, hk_SetStickerAttributeInt));
                o_SetStickerAttributeFloat =
                    Marshal.GetDelegateForFunctionPointer<SetStickerAttributeFloatDlg>(
                        Memory.SetVTableFunction(ItemVtablePtr, 4, hk_SetStickerAttributeFloat));

                hooked = true;
            }
        }

        public static void StickerUnhook()
        {
            if (hooked)
            {
                if (ItemVtablePtr == null)
                    return;

                Memory.SetVTableFunction(ItemVtablePtr, 4, o_SetStickerAttributeFloat);
                Memory.SetVTableFunction(ItemVtablePtr, 5, o_SetStickerAttributeInt);

                hooked = false;
            }
        }

        public static int SetStickerAttributeInt(IntPtr thisptr, int slot, int attributeType)
        {
            if ((EStickerAttribute) attributeType == EStickerAttribute.Index)
                return 377;

            return o_SetStickerAttributeInt(thisptr, slot, attributeType);
        }

        public static float SetStickerAttributeFloat(IntPtr thisptr, int slot, int attributeType)
        {
            switch ((EStickerAttribute) attributeType)
            {
                case EStickerAttribute.Wear:
                {
                    if (slot == 0)
                        return 0.5f;
                    else
                        return 0.25f;
                }
                case EStickerAttribute.Rotation:
                    return 0f;
                case EStickerAttribute.Scale:
                    return 1f;
            }

            return o_SetStickerAttributeFloat(thisptr, slot, attributeType);
        }


        public static void SequenceFix(CRecvProxyData* pData, IntPtr pStruct)
        {
            if (!Settings.skinChanger)
                return;

            if (SDK.g_LocalPlayer() == null || !SDK.g_LocalPlayer()->IsAlive() || SDK.g_LocalPlayer()->IsDormant())
                return;

            //Log.Debug("SequenceFix null check passed", SDK.g_LocalPlayer() == null, !SDK.g_LocalPlayer()->isAlive(), SDK.g_LocalPlayer()->isDormant());

            var weapon = SDK.g_LocalPlayer()->GetActiveWeapon();
            if (weapon == null)
            {
                return;
            }

            var itemIndex = weapon->m_iItemDefinitionIndex;
            //Log.Debug("Item index", itemIndex);
            if (itemIndex == 59 || itemIndex == 42 || (itemIndex > 400 && itemIndex < 600))
            {
                var modelname = ((EItemDefinitionIndex) itemIndex).ToString("G");

                var name = SDK.ModelInfo.GetModel(GetModelIndex(modelname))->szName.ToString();
                pData->m_Value.m_Int = GetAnimation(name, pData->m_Value.m_Int);
            }
        }

        public static void FixHudIcon(GameEvent* e)
        {
            if (!Settings.skinChanger)
                return;

            if (e->GetName()->ToString() != "player_death")
                return;

            if (e->GetInt("attacker") != CSGO.SDK.g_LocalPlayer()->UserID())
                return;

            var iconName = e->GetString("weapon");

            if (WeaponIcons.Values.Contains(iconName))
                e->SetString("weapon",
                    WeaponIcons[(EItemDefinitionIndex) Enum.Parse(typeof(EItemDefinitionIndex), Settings.knife)]);
        }


        public static int GetAnimation(string model, int sequence)
        {
            switch (model)
            {
                case "models/weapons/v_knife_butterfly.mdl":
                {
                    switch ((ESequence) sequence)
                    {
                        case SEQUENCE_DEFAULT_DRAW:
                            return (int) RandomSequence(SEQUENCE_BUTTERFLY_DRAW, SEQUENCE_BUTTERFLY_DRAW2);
                        case SEQUENCE_DEFAULT_LOOKAT01:
                            return (int) RandomSequence(SEQUENCE_BUTTERFLY_LOOKAT01, SEQUENCE_BUTTERFLY_LOOKAT03);
                        default:
                            return sequence + 1;
                    }
                }
                case "models/weapons/v_knife_falchion_advanced.mdl":
                {
                    switch ((ESequence) sequence)
                    {
                        case SEQUENCE_DEFAULT_IDLE2:
                            return (int) SEQUENCE_FALCHION_IDLE1;
                        case SEQUENCE_DEFAULT_HEAVY_MISS1:
                            return (int) RandomSequence(SEQUENCE_FALCHION_HEAVY_MISS1,
                                SEQUENCE_FALCHION_HEAVY_MISS1_NOFLIP);
                        case SEQUENCE_DEFAULT_LOOKAT01:
                            return (int) RandomSequence(SEQUENCE_FALCHION_LOOKAT01, SEQUENCE_FALCHION_LOOKAT02);
                        case SEQUENCE_DEFAULT_DRAW:
                        case SEQUENCE_DEFAULT_IDLE1:
                            return sequence;
                        default:
                            return sequence - 1;
                    }
                }
                case "models/weapons/v_knife_push.mdl":
                {
                    switch ((ESequence) sequence)
                    {
                        case SEQUENCE_DEFAULT_IDLE2:
                            return (int) SEQUENCE_DAGGERS_IDLE1;
                        case SEQUENCE_DEFAULT_LIGHT_MISS1:
                        case SEQUENCE_DEFAULT_LIGHT_MISS2:
                            return (int) RandomSequence(SEQUENCE_DAGGERS_LIGHT_MISS1, SEQUENCE_DAGGERS_LIGHT_MISS5);
                        case SEQUENCE_DEFAULT_HEAVY_MISS1:
                            return (int) RandomSequence(SEQUENCE_DAGGERS_HEAVY_MISS2, SEQUENCE_DAGGERS_HEAVY_MISS1);
                        case SEQUENCE_DEFAULT_HEAVY_HIT1:
                        case SEQUENCE_DEFAULT_HEAVY_BACKSTAB:
                        case SEQUENCE_DEFAULT_LOOKAT01:
                            return sequence + 3;
                        case SEQUENCE_DEFAULT_DRAW:
                        case SEQUENCE_DEFAULT_IDLE1:
                            return sequence;
                        default:
                            return sequence + 2;
                    }
                }
                case "models/weapons/v_knife_survival_bowie.mdl":
                {
                    switch ((ESequence) sequence)
                    {
                        case SEQUENCE_DEFAULT_DRAW:
                        case SEQUENCE_DEFAULT_IDLE1:
                            return sequence;
                        case SEQUENCE_DEFAULT_IDLE2:
                            return (int) SEQUENCE_BOWIE_IDLE1;
                        default:
                            return sequence - 1;
                    }
                }
                case "models/weapons/v_knife_ursus.mdl":
                case "models/weapons/v_knife_skeleton.mdl":
                {
                    switch ((ESequence) sequence)
                    {
                        case SEQUENCE_DEFAULT_DRAW:
                            return (int) RandomSequence(SEQUENCE_BUTTERFLY_DRAW, SEQUENCE_BUTTERFLY_DRAW2);
                        case SEQUENCE_DEFAULT_LOOKAT01:
                            return (int) RandomSequence(SEQUENCE_BUTTERFLY_LOOKAT01, 14);
                        default:
                            return sequence + 1;
                    }
                }
                case "models/weapons/v_knife_outdoor.mdl":
                {
                    switch (sequence)
                    {
                        case 0:
                            return (int) RandomSequence(0, 1);
                        case 12:
                            return (int) RandomSequence(13, 14);
                        default:
                            return sequence + 1;
                    }
                }
                case "models/weapons/v_knife_cord.mdl":
                case "models/weapons/v_knife_canis.mdl":
                {
                    switch ((ESequence) sequence)
                    {
                        case SEQUENCE_DEFAULT_DRAW:
                            return (int) RandomSequence(SEQUENCE_BUTTERFLY_DRAW, SEQUENCE_BUTTERFLY_DRAW2);
                        case SEQUENCE_DEFAULT_LOOKAT01:
                            return (int) RandomSequence(SEQUENCE_BUTTERFLY_LOOKAT01, 14);
                        default:
                            return sequence + 1;
                    }
                }
                case "models/weapons/v_knife_stiletto.mdl":
                {
                    switch ((ESequence) sequence)
                    {
                        case SEQUENCE_DEFAULT_LOOKAT01:
                            return (int) RandomSequence(12, 13);
                        default:
                            return sequence;
                    }
                }
                case "models/weapons/v_knife_widowmaker.mdl":
                {
                    switch ((ESequence) sequence)
                    {
                        case SEQUENCE_DEFAULT_LOOKAT01:
                            return (int) RandomSequence(14, 15);
                        default:
                            return sequence;
                    }
                }
                default:
                    return sequence;
            }
        }

        public static ESequence RandomSequence(ESequence s1, ESequence s2)
        {
            return (ESequence) (random.Next((int) s1, (int) s1 + 1));
        }

        public static ESequence RandomSequence(ESequence s1, int s2)
        {
            return (ESequence) (random.Next((int) s1, (int) s1 + 1));
        }

        public static ESequence RandomSequence(int s1, ESequence s2)
        {
            return (ESequence) (random.Next((int) s1, (int) s1 + 1));
        }

        public static ESequence RandomSequence(int s1, int s2)
        {
            return (ESequence) (random.Next((int) s1, (int) s1 + 1));
        }


        public static bool hudUpdateRequired = false;


        public static void ForceFullupdate()
        {
            if (SDK.g_LocalPlayer() == null || !SDK.g_LocalPlayer()->IsAlive())
                return;

            if (SDK.g_LocalPlayer()->IsDormant())
                return;

            //SDK.CVar.FindVar("cl_fullupdate")->ChangeCallback();
            SDK.ClientState->m_nDeltaTick = -1;

            hudUpdateRequired = true;
        }

        public static void UpdateHud()
        {
            if (!hudUpdateRequired) return;

            for (int i = 0; i < *((int*) SDK.HudWeapon + 0x20); i++)
                i = SDK.HudWeapon->ClearHudWeapon(i);

            hudUpdateRequired = false;
        }
    }
}