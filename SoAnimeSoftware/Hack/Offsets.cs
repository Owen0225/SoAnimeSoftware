using System;
using SoAnimeSoftware.Utils;

namespace SoAnimeSoftware.Hack
{
    unsafe class Offsets
    {
        public static IntPtr LocalPlayer =
            Memory.ReadPointer(Memory.FindPattern("client.dll", "8B 0D ? ? ? ? 83 FF FF 74 07") + 2);

        public static IntPtr KeyValueInit = Memory.FindPattern("client.dll", "55 8B EC 51 33 C0 C7 45");

        public static IntPtr KeyValueLoad =
            Memory.FindPattern("client.dll", "55 8B EC 83 E4 F8 83 EC 34 53 8B 5D 0C 89 4C 24 04");

        public static IntPtr ClearHudWeaponFnPointer =
            Memory.FindPattern("client.dll", "55 8B EC 51 53 56 8B 75 08 8B D9 57 6B FE 2C");

        public static IntPtr FindHudElementFnPointer =
            Memory.FindPattern("client.dll", "55 8B EC 53 8B 5D 08 56 57 8B F9 33 F6 39 77 28");

        public static IntPtr GetSequenceActivityFnPointer =
            Memory.FindPattern("client.dll", "55 8B EC 53 8B 5D 08 56 8B F1 83");

        public static IntPtr VoiceRecordStartPointer =
            Memory.FindPattern("engine.dll", "55 8B EC 83 EC 0C 83 3D ?? ?? ?? ?? ?? 56 57");

        public static IntPtr SetAbsOriginPointer =
            Memory.FindPattern("client.dll", "55 8B EC 83 E4 F8 51 53 56 57 8B F1 E8");

        public static IntPtr SetAbsAnglesPointer =
            Memory.FindPattern("client.dll", "55 8B EC 83 E4 F8 83 EC 64 53 56 57 8B F1 E8");

        public static IntPtr InvalidateBoneCachePointer = Memory.FindPattern("client.dll", "A1 ? ? ? ? 48 C7 81") + 1;

        public static IntPtr EquipWearablePointer =
            Memory.FindPattern("client.dll", "55 8B EC 83 EC 10 53 8B 5D 08 57 8B F9");

        public static IntPtr SetCollisionBoundPointer = Memory.Dereference(Memory.FindPattern("client.dll", "E8 ? ? ? ? 0F BF 87 ? ? ? ?"), 1);

        public static IntPtr BoneAccessorPointer = Memory.FindPattern("client.dll", "8D 81 ? ? ? ? 50 8D 84 24") + 2;

        public static IntPtr InReload =
            Memory.ReadPointer(Memory.FindPattern("client.dll", "C6 87 ? ? ? ? ? 8B 06 8B CE FF 90") + 2);

        public static byte* DisablePostprocessing =
            *(byte**) (Memory.FindPattern("client.dll", "83 EC 4C 80 3D") + 5);

        public static IntPtr DxPresentPointer =
            Memory.FindPattern("gameoverlayrenderer.dll", "FF 15 ? ? ? ? 8B F8 85 DB") + 2;

        public static IntPtr DxResetPointer =
            Memory.FindPattern("gameoverlayrenderer.dll", "C7 45 ? ? ? ? ? FF 15 ? ? ? ? 8B F8") + 9;

        public static IntPtr D39DevicePointer =
            Memory.ReadPointer(
                Memory.ReadPointer(Memory.FindPattern("shaderapidx9.dll", "A1 ? ? ? ? 50 8B 08 FF 51 0C") + 1));
        
        public static IntPtr SetAnglePointer = Memory.FindPattern("client.dll", "55 8B EC 83 E4 F8 83 EC 64 53 56 57 8B F1");

        public static IntPtr GetEconItemViewPointer =
            Memory.FindPattern("client.dll", "8B 81 ? ? ? ? 81 C1 ? ? ? ? FF 50 04 83 C0 40 C3");
        
        public static IntPtr GetPaintKitDefinitionPointer = Memory.Dereference(Memory.FindPattern("client.dll", "E8 ? ? ? ? 8B F0 8B 4E 7C"), 1);

        public static IntPtr GetItemSchemaPointer = Memory.FindPattern("client.dll", "A1 ? ? ? ? 85 C0 75 53");

        public static IntPtr ClearCustomMaterialsPointer = Memory.Dereference( Memory.FindPattern("client.dll", "E8 ? ? ? ? 51 6A 26"),1);
        
        public static class DT_TestTraceline
        {
            public static int m_clrRender = NetVarManager.GetOffset("DT_TestTraceline", "m_clrRender");
            public static int m_vecOrigin = NetVarManager.GetOffset("DT_TestTraceline", "m_vecOrigin");
            public static int m_angRotation_0 = NetVarManager.GetOffset("DT_TestTraceline", "m_angRotation[0]");
            public static int m_angRotation_1 = NetVarManager.GetOffset("DT_TestTraceline", "m_angRotation[1]");
            public static int m_angRotation_2 = NetVarManager.GetOffset("DT_TestTraceline", "m_angRotation[2]");
            public static int moveparent = NetVarManager.GetOffset("DT_TestTraceline", "moveparent");
        }

        public static class DT_TEWorldDecal
        {
            public static int m_vecOrigin = NetVarManager.GetOffset("DT_TEWorldDecal", "m_vecOrigin");
            public static int m_nIndex = NetVarManager.GetOffset("DT_TEWorldDecal", "m_nIndex");
        }

        public static class DT_TESpriteSpray
        {
            public static int m_vecOrigin = NetVarManager.GetOffset("DT_TESpriteSpray", "m_vecOrigin");
            public static int m_vecDirection = NetVarManager.GetOffset("DT_TESpriteSpray", "m_vecDirection");
            public static int m_nModelIndex = NetVarManager.GetOffset("DT_TESpriteSpray", "m_nModelIndex");
            public static int m_fNoise = NetVarManager.GetOffset("DT_TESpriteSpray", "m_fNoise");
            public static int m_nCount = NetVarManager.GetOffset("DT_TESpriteSpray", "m_nCount");
            public static int m_nSpeed = NetVarManager.GetOffset("DT_TESpriteSpray", "m_nSpeed");
        }

        public static class DT_TESprite
        {
            public static int m_vecOrigin = NetVarManager.GetOffset("DT_TESprite", "m_vecOrigin");
            public static int m_nModelIndex = NetVarManager.GetOffset("DT_TESprite", "m_nModelIndex");
            public static int m_fScale = NetVarManager.GetOffset("DT_TESprite", "m_fScale");
            public static int m_nBrightness = NetVarManager.GetOffset("DT_TESprite", "m_nBrightness");
        }

        public static class DT_TESparks
        {
            public static int m_nMagnitude = NetVarManager.GetOffset("DT_TESparks", "m_nMagnitude");
            public static int m_nTrailLength = NetVarManager.GetOffset("DT_TESparks", "m_nTrailLength");
            public static int m_vecDir = NetVarManager.GetOffset("DT_TESparks", "m_vecDir");
        }

        public static class DT_TESmoke
        {
            public static int m_vecOrigin = NetVarManager.GetOffset("DT_TESmoke", "m_vecOrigin");
            public static int m_nModelIndex = NetVarManager.GetOffset("DT_TESmoke", "m_nModelIndex");
            public static int m_fScale = NetVarManager.GetOffset("DT_TESmoke", "m_fScale");
            public static int m_nFrameRate = NetVarManager.GetOffset("DT_TESmoke", "m_nFrameRate");
        }

        public static class DT_TEShowLine
        {
            public static int m_vecEnd = NetVarManager.GetOffset("DT_TEShowLine", "m_vecEnd");
        }

        public static class DT_TEProjectedDecal
        {
            public static int m_vecOrigin = NetVarManager.GetOffset("DT_TEProjectedDecal", "m_vecOrigin");
            public static int m_angRotation = NetVarManager.GetOffset("DT_TEProjectedDecal", "m_angRotation");
            public static int m_flDistance = NetVarManager.GetOffset("DT_TEProjectedDecal", "m_flDistance");
            public static int m_nIndex = NetVarManager.GetOffset("DT_TEProjectedDecal", "m_nIndex");
        }

        public static class DT_FEPlayerDecal
        {
            public static int m_nUniqueID = NetVarManager.GetOffset("DT_FEPlayerDecal", "m_nUniqueID");
            public static int m_unAccountID = NetVarManager.GetOffset("DT_FEPlayerDecal", "m_unAccountID");
            public static int m_unTraceID = NetVarManager.GetOffset("DT_FEPlayerDecal", "m_unTraceID");
            public static int m_rtGcTime = NetVarManager.GetOffset("DT_FEPlayerDecal", "m_rtGcTime");
            public static int m_vecEndPos = NetVarManager.GetOffset("DT_FEPlayerDecal", "m_vecEndPos");
            public static int m_vecStart = NetVarManager.GetOffset("DT_FEPlayerDecal", "m_vecStart");
            public static int m_vecRight = NetVarManager.GetOffset("DT_FEPlayerDecal", "m_vecRight");
            public static int m_vecNormal = NetVarManager.GetOffset("DT_FEPlayerDecal", "m_vecNormal");
            public static int m_nEntity = NetVarManager.GetOffset("DT_FEPlayerDecal", "m_nEntity");
            public static int m_nPlayer = NetVarManager.GetOffset("DT_FEPlayerDecal", "m_nPlayer");
            public static int m_nHitbox = NetVarManager.GetOffset("DT_FEPlayerDecal", "m_nHitbox");
            public static int m_nTintID = NetVarManager.GetOffset("DT_FEPlayerDecal", "m_nTintID");
            public static int m_flCreationTime = NetVarManager.GetOffset("DT_FEPlayerDecal", "m_flCreationTime");
            public static int m_nVersion = NetVarManager.GetOffset("DT_FEPlayerDecal", "m_nVersion");
            public static int m_ubSignature = NetVarManager.GetOffset("DT_FEPlayerDecal", "m_ubSignature");
        }

        public static class DT_TEPlayerDecal
        {
            public static int m_vecOrigin = NetVarManager.GetOffset("DT_TEPlayerDecal", "m_vecOrigin");
            public static int m_vecStart = NetVarManager.GetOffset("DT_TEPlayerDecal", "m_vecStart");
            public static int m_vecRight = NetVarManager.GetOffset("DT_TEPlayerDecal", "m_vecRight");
            public static int m_nEntity = NetVarManager.GetOffset("DT_TEPlayerDecal", "m_nEntity");
            public static int m_nPlayer = NetVarManager.GetOffset("DT_TEPlayerDecal", "m_nPlayer");
            public static int m_nHitbox = NetVarManager.GetOffset("DT_TEPlayerDecal", "m_nHitbox");
        }

        public static class DT_TEPhysicsProp
        {
            public static int m_vecOrigin = NetVarManager.GetOffset("DT_TEPhysicsProp", "m_vecOrigin");
            public static int m_angRotation_0 = NetVarManager.GetOffset("DT_TEPhysicsProp", "m_angRotation[0]");
            public static int m_angRotation_1 = NetVarManager.GetOffset("DT_TEPhysicsProp", "m_angRotation[1]");
            public static int m_angRotation_2 = NetVarManager.GetOffset("DT_TEPhysicsProp", "m_angRotation[2]");
            public static int m_vecVelocity = NetVarManager.GetOffset("DT_TEPhysicsProp", "m_vecVelocity");
            public static int m_nModelIndex = NetVarManager.GetOffset("DT_TEPhysicsProp", "m_nModelIndex");
            public static int m_nFlags = NetVarManager.GetOffset("DT_TEPhysicsProp", "m_nFlags");
            public static int m_nSkin = NetVarManager.GetOffset("DT_TEPhysicsProp", "m_nSkin");
            public static int m_nEffects = NetVarManager.GetOffset("DT_TEPhysicsProp", "m_nEffects");
            public static int m_clrRender = NetVarManager.GetOffset("DT_TEPhysicsProp", "m_clrRender");
        }

        public static class DT_TEParticleSystem
        {
            public static int m_vecOrigin_0 = NetVarManager.GetOffset("DT_TEParticleSystem", "m_vecOrigin[0]");
            public static int m_vecOrigin_1 = NetVarManager.GetOffset("DT_TEParticleSystem", "m_vecOrigin[1]");
            public static int m_vecOrigin_2 = NetVarManager.GetOffset("DT_TEParticleSystem", "m_vecOrigin[2]");
        }

        public static class DT_TEMuzzleFlash
        {
            public static int m_vecOrigin = NetVarManager.GetOffset("DT_TEMuzzleFlash", "m_vecOrigin");
            public static int m_vecAngles = NetVarManager.GetOffset("DT_TEMuzzleFlash", "m_vecAngles");
            public static int m_flScale = NetVarManager.GetOffset("DT_TEMuzzleFlash", "m_flScale");
            public static int m_nType = NetVarManager.GetOffset("DT_TEMuzzleFlash", "m_nType");
        }

        public static class DT_TELargeFunnel
        {
            public static int m_nModelIndex = NetVarManager.GetOffset("DT_TELargeFunnel", "m_nModelIndex");
            public static int m_nReversed = NetVarManager.GetOffset("DT_TELargeFunnel", "m_nReversed");
        }

        public static class DT_TEKillPlayerAttachments
        {
            public static int m_nPlayer = NetVarManager.GetOffset("DT_TEKillPlayerAttachments", "m_nPlayer");
        }

        public static class DT_TEImpact
        {
            public static int m_vecOrigin = NetVarManager.GetOffset("DT_TEImpact", "m_vecOrigin");
            public static int m_vecNormal = NetVarManager.GetOffset("DT_TEImpact", "m_vecNormal");
            public static int m_iType = NetVarManager.GetOffset("DT_TEImpact", "m_iType");
            public static int m_ucFlags = NetVarManager.GetOffset("DT_TEImpact", "m_ucFlags");
        }

        public static class DT_TEGlowSprite
        {
            public static int m_vecOrigin = NetVarManager.GetOffset("DT_TEGlowSprite", "m_vecOrigin");
            public static int m_nModelIndex = NetVarManager.GetOffset("DT_TEGlowSprite", "m_nModelIndex");
            public static int m_fScale = NetVarManager.GetOffset("DT_TEGlowSprite", "m_fScale");
            public static int m_fLife = NetVarManager.GetOffset("DT_TEGlowSprite", "m_fLife");
            public static int m_nBrightness = NetVarManager.GetOffset("DT_TEGlowSprite", "m_nBrightness");
        }

        public static class DT_TEShatterSurface
        {
            public static int m_vecOrigin = NetVarManager.GetOffset("DT_TEShatterSurface", "m_vecOrigin");
            public static int m_vecAngles = NetVarManager.GetOffset("DT_TEShatterSurface", "m_vecAngles");
            public static int m_vecForce = NetVarManager.GetOffset("DT_TEShatterSurface", "m_vecForce");
            public static int m_vecForcePos = NetVarManager.GetOffset("DT_TEShatterSurface", "m_vecForcePos");
            public static int m_flWidth = NetVarManager.GetOffset("DT_TEShatterSurface", "m_flWidth");
            public static int m_flHeight = NetVarManager.GetOffset("DT_TEShatterSurface", "m_flHeight");
            public static int m_flShardSize = NetVarManager.GetOffset("DT_TEShatterSurface", "m_flShardSize");
            public static int m_nSurfaceType = NetVarManager.GetOffset("DT_TEShatterSurface", "m_nSurfaceType");
            public static int m_uchFrontColor_0 = NetVarManager.GetOffset("DT_TEShatterSurface", "m_uchFrontColor[0]");
            public static int m_uchFrontColor_1 = NetVarManager.GetOffset("DT_TEShatterSurface", "m_uchFrontColor[1]");
            public static int m_uchFrontColor_2 = NetVarManager.GetOffset("DT_TEShatterSurface", "m_uchFrontColor[2]");
            public static int m_uchBackColor_0 = NetVarManager.GetOffset("DT_TEShatterSurface", "m_uchBackColor[0]");
            public static int m_uchBackColor_1 = NetVarManager.GetOffset("DT_TEShatterSurface", "m_uchBackColor[1]");
            public static int m_uchBackColor_2 = NetVarManager.GetOffset("DT_TEShatterSurface", "m_uchBackColor[2]");
        }

        public static class DT_TEFootprintDecal
        {
            public static int m_vecOrigin = NetVarManager.GetOffset("DT_TEFootprintDecal", "m_vecOrigin");
            public static int m_vecDirection = NetVarManager.GetOffset("DT_TEFootprintDecal", "m_vecDirection");
            public static int m_nEntity = NetVarManager.GetOffset("DT_TEFootprintDecal", "m_nEntity");
            public static int m_nIndex = NetVarManager.GetOffset("DT_TEFootprintDecal", "m_nIndex");
            public static int m_chMaterialType = NetVarManager.GetOffset("DT_TEFootprintDecal", "m_chMaterialType");
        }

        public static class DT_TEFizz
        {
            public static int m_nEntity = NetVarManager.GetOffset("DT_TEFizz", "m_nEntity");
            public static int m_nModelIndex = NetVarManager.GetOffset("DT_TEFizz", "m_nModelIndex");
            public static int m_nDensity = NetVarManager.GetOffset("DT_TEFizz", "m_nDensity");
            public static int m_nCurrent = NetVarManager.GetOffset("DT_TEFizz", "m_nCurrent");
        }

        public static class DT_TEExplosion
        {
            public static int m_nModelIndex = NetVarManager.GetOffset("DT_TEExplosion", "m_nModelIndex");
            public static int m_fScale = NetVarManager.GetOffset("DT_TEExplosion", "m_fScale");
            public static int m_nFrameRate = NetVarManager.GetOffset("DT_TEExplosion", "m_nFrameRate");
            public static int m_nFlags = NetVarManager.GetOffset("DT_TEExplosion", "m_nFlags");
            public static int m_vecNormal = NetVarManager.GetOffset("DT_TEExplosion", "m_vecNormal");
            public static int m_chMaterialType = NetVarManager.GetOffset("DT_TEExplosion", "m_chMaterialType");
            public static int m_nRadius = NetVarManager.GetOffset("DT_TEExplosion", "m_nRadius");
            public static int m_nMagnitude = NetVarManager.GetOffset("DT_TEExplosion", "m_nMagnitude");
        }

        public static class DT_TEEnergySplash
        {
            public static int m_vecPos = NetVarManager.GetOffset("DT_TEEnergySplash", "m_vecPos");
            public static int m_vecDir = NetVarManager.GetOffset("DT_TEEnergySplash", "m_vecDir");
            public static int m_bExplosive = NetVarManager.GetOffset("DT_TEEnergySplash", "m_bExplosive");
        }

        public static class DT_TEEffectDispatch
        {
            public static int m_EffectData = NetVarManager.GetOffset("DT_TEEffectDispatch", "m_EffectData");
            public static int m_vOrigin_x = NetVarManager.GetOffset("DT_TEEffectDispatch", "m_vOrigin.x");
            public static int m_vOrigin_y = NetVarManager.GetOffset("DT_TEEffectDispatch", "m_vOrigin.y");
            public static int m_vOrigin_z = NetVarManager.GetOffset("DT_TEEffectDispatch", "m_vOrigin.z");
            public static int m_vStart_x = NetVarManager.GetOffset("DT_TEEffectDispatch", "m_vStart.x");
            public static int m_vStart_y = NetVarManager.GetOffset("DT_TEEffectDispatch", "m_vStart.y");
            public static int m_vStart_z = NetVarManager.GetOffset("DT_TEEffectDispatch", "m_vStart.z");
            public static int m_vAngles = NetVarManager.GetOffset("DT_TEEffectDispatch", "m_vAngles");
            public static int m_vNormal = NetVarManager.GetOffset("DT_TEEffectDispatch", "m_vNormal");
            public static int m_fFlags = NetVarManager.GetOffset("DT_TEEffectDispatch", "m_fFlags");
            public static int m_flMagnitude = NetVarManager.GetOffset("DT_TEEffectDispatch", "m_flMagnitude");
            public static int m_flScale = NetVarManager.GetOffset("DT_TEEffectDispatch", "m_flScale");
            public static int m_nAttachmentIndex = NetVarManager.GetOffset("DT_TEEffectDispatch", "m_nAttachmentIndex");
            public static int m_nSurfaceProp = NetVarManager.GetOffset("DT_TEEffectDispatch", "m_nSurfaceProp");
            public static int m_iEffectName = NetVarManager.GetOffset("DT_TEEffectDispatch", "m_iEffectName");
            public static int m_nMaterial = NetVarManager.GetOffset("DT_TEEffectDispatch", "m_nMaterial");
            public static int m_nDamageType = NetVarManager.GetOffset("DT_TEEffectDispatch", "m_nDamageType");
            public static int m_nHitBox = NetVarManager.GetOffset("DT_TEEffectDispatch", "m_nHitBox");
            public static int entindex = NetVarManager.GetOffset("DT_TEEffectDispatch", "entindex");
            public static int m_nOtherEntIndex = NetVarManager.GetOffset("DT_TEEffectDispatch", "m_nOtherEntIndex");
            public static int m_nColor = NetVarManager.GetOffset("DT_TEEffectDispatch", "m_nColor");
            public static int m_flRadius = NetVarManager.GetOffset("DT_TEEffectDispatch", "m_flRadius");

            public static int m_bPositionsAreRelativeToEntity =
                NetVarManager.GetOffset("DT_TEEffectDispatch", "m_bPositionsAreRelativeToEntity");
        }

        public static class DT_TEDynamicLight
        {
            public static int m_vecOrigin = NetVarManager.GetOffset("DT_TEDynamicLight", "m_vecOrigin");
            public static int r = NetVarManager.GetOffset("DT_TEDynamicLight", "r");
            public static int g = NetVarManager.GetOffset("DT_TEDynamicLight", "g");
            public static int b = NetVarManager.GetOffset("DT_TEDynamicLight", "b");
            public static int exponent = NetVarManager.GetOffset("DT_TEDynamicLight", "exponent");
            public static int m_fRadius = NetVarManager.GetOffset("DT_TEDynamicLight", "m_fRadius");
            public static int m_fTime = NetVarManager.GetOffset("DT_TEDynamicLight", "m_fTime");
            public static int m_fDecay = NetVarManager.GetOffset("DT_TEDynamicLight", "m_fDecay");
        }

        public static class DT_TEDecal
        {
            public static int m_vecOrigin = NetVarManager.GetOffset("DT_TEDecal", "m_vecOrigin");
            public static int m_vecStart = NetVarManager.GetOffset("DT_TEDecal", "m_vecStart");
            public static int m_nEntity = NetVarManager.GetOffset("DT_TEDecal", "m_nEntity");
            public static int m_nHitbox = NetVarManager.GetOffset("DT_TEDecal", "m_nHitbox");
            public static int m_nIndex = NetVarManager.GetOffset("DT_TEDecal", "m_nIndex");
        }

        public static class DT_TEClientProjectile
        {
            public static int m_vecOrigin = NetVarManager.GetOffset("DT_TEClientProjectile", "m_vecOrigin");
            public static int m_vecVelocity = NetVarManager.GetOffset("DT_TEClientProjectile", "m_vecVelocity");
            public static int m_nModelIndex = NetVarManager.GetOffset("DT_TEClientProjectile", "m_nModelIndex");
            public static int m_nLifeTime = NetVarManager.GetOffset("DT_TEClientProjectile", "m_nLifeTime");
            public static int m_hOwner = NetVarManager.GetOffset("DT_TEClientProjectile", "m_hOwner");
        }

        public static class DT_TEBubbleTrail
        {
            public static int m_vecMins = NetVarManager.GetOffset("DT_TEBubbleTrail", "m_vecMins");
            public static int m_vecMaxs = NetVarManager.GetOffset("DT_TEBubbleTrail", "m_vecMaxs");
            public static int m_nModelIndex = NetVarManager.GetOffset("DT_TEBubbleTrail", "m_nModelIndex");
            public static int m_flWaterZ = NetVarManager.GetOffset("DT_TEBubbleTrail", "m_flWaterZ");
            public static int m_nCount = NetVarManager.GetOffset("DT_TEBubbleTrail", "m_nCount");
            public static int m_fSpeed = NetVarManager.GetOffset("DT_TEBubbleTrail", "m_fSpeed");
        }

        public static class DT_TEBubbles
        {
            public static int m_vecMins = NetVarManager.GetOffset("DT_TEBubbles", "m_vecMins");
            public static int m_vecMaxs = NetVarManager.GetOffset("DT_TEBubbles", "m_vecMaxs");
            public static int m_nModelIndex = NetVarManager.GetOffset("DT_TEBubbles", "m_nModelIndex");
            public static int m_fHeight = NetVarManager.GetOffset("DT_TEBubbles", "m_fHeight");
            public static int m_nCount = NetVarManager.GetOffset("DT_TEBubbles", "m_nCount");
            public static int m_fSpeed = NetVarManager.GetOffset("DT_TEBubbles", "m_fSpeed");
        }

        public static class DT_TEBSPDecal
        {
            public static int m_vecOrigin = NetVarManager.GetOffset("DT_TEBSPDecal", "m_vecOrigin");
            public static int m_nEntity = NetVarManager.GetOffset("DT_TEBSPDecal", "m_nEntity");
            public static int m_nIndex = NetVarManager.GetOffset("DT_TEBSPDecal", "m_nIndex");
        }

        public static class DT_TEBreakModel
        {
            public static int m_vecOrigin = NetVarManager.GetOffset("DT_TEBreakModel", "m_vecOrigin");
            public static int m_angRotation_0 = NetVarManager.GetOffset("DT_TEBreakModel", "m_angRotation[0]");
            public static int m_angRotation_1 = NetVarManager.GetOffset("DT_TEBreakModel", "m_angRotation[1]");
            public static int m_angRotation_2 = NetVarManager.GetOffset("DT_TEBreakModel", "m_angRotation[2]");
            public static int m_vecSize = NetVarManager.GetOffset("DT_TEBreakModel", "m_vecSize");
            public static int m_vecVelocity = NetVarManager.GetOffset("DT_TEBreakModel", "m_vecVelocity");
            public static int m_nModelIndex = NetVarManager.GetOffset("DT_TEBreakModel", "m_nModelIndex");
            public static int m_nRandomization = NetVarManager.GetOffset("DT_TEBreakModel", "m_nRandomization");
            public static int m_nCount = NetVarManager.GetOffset("DT_TEBreakModel", "m_nCount");
            public static int m_fTime = NetVarManager.GetOffset("DT_TEBreakModel", "m_fTime");
            public static int m_nFlags = NetVarManager.GetOffset("DT_TEBreakModel", "m_nFlags");
        }

        public static class DT_TEBloodStream
        {
            public static int m_vecDirection = NetVarManager.GetOffset("DT_TEBloodStream", "m_vecDirection");
            public static int r = NetVarManager.GetOffset("DT_TEBloodStream", "r");
            public static int g = NetVarManager.GetOffset("DT_TEBloodStream", "g");
            public static int b = NetVarManager.GetOffset("DT_TEBloodStream", "b");
            public static int a = NetVarManager.GetOffset("DT_TEBloodStream", "a");
            public static int m_nAmount = NetVarManager.GetOffset("DT_TEBloodStream", "m_nAmount");
        }

        public static class DT_TEBloodSprite
        {
            public static int m_vecOrigin = NetVarManager.GetOffset("DT_TEBloodSprite", "m_vecOrigin");
            public static int m_vecDirection = NetVarManager.GetOffset("DT_TEBloodSprite", "m_vecDirection");
            public static int r = NetVarManager.GetOffset("DT_TEBloodSprite", "r");
            public static int g = NetVarManager.GetOffset("DT_TEBloodSprite", "g");
            public static int b = NetVarManager.GetOffset("DT_TEBloodSprite", "b");
            public static int a = NetVarManager.GetOffset("DT_TEBloodSprite", "a");
            public static int m_nSprayModel = NetVarManager.GetOffset("DT_TEBloodSprite", "m_nSprayModel");
            public static int m_nDropModel = NetVarManager.GetOffset("DT_TEBloodSprite", "m_nDropModel");
            public static int m_nSize = NetVarManager.GetOffset("DT_TEBloodSprite", "m_nSize");
        }

        public static class DT_TEBeamSpline
        {
            public static int m_nPoints = NetVarManager.GetOffset("DT_TEBeamSpline", "m_nPoints");
            public static int m_vecPoints_0 = NetVarManager.GetOffset("DT_TEBeamSpline", "m_vecPoints[0]");
            public static int m_vecPoints = NetVarManager.GetOffset("DT_TEBeamSpline", "m_vecPoints");
        }

        public static class DT_TEBeamRingPoint
        {
            public static int m_vecCenter = NetVarManager.GetOffset("DT_TEBeamRingPoint", "m_vecCenter");
            public static int m_flStartRadius = NetVarManager.GetOffset("DT_TEBeamRingPoint", "m_flStartRadius");
            public static int m_flEndRadius = NetVarManager.GetOffset("DT_TEBeamRingPoint", "m_flEndRadius");
        }

        public static class DT_TEBeamRing
        {
            public static int m_nStartEntity = NetVarManager.GetOffset("DT_TEBeamRing", "m_nStartEntity");
            public static int m_nEndEntity = NetVarManager.GetOffset("DT_TEBeamRing", "m_nEndEntity");
        }

        public static class DT_TEBeamPoints
        {
            public static int m_vecStartPoint = NetVarManager.GetOffset("DT_TEBeamPoints", "m_vecStartPoint");
            public static int m_vecEndPoint = NetVarManager.GetOffset("DT_TEBeamPoints", "m_vecEndPoint");
        }

        public static class DT_TEBeamLaser
        {
            public static int m_nStartEntity = NetVarManager.GetOffset("DT_TEBeamLaser", "m_nStartEntity");
            public static int m_nEndEntity = NetVarManager.GetOffset("DT_TEBeamLaser", "m_nEndEntity");
        }

        public static class DT_TEBeamFollow
        {
            public static int m_iEntIndex = NetVarManager.GetOffset("DT_TEBeamFollow", "m_iEntIndex");
        }

        public static class DT_TEBeamEnts
        {
            public static int m_nStartEntity = NetVarManager.GetOffset("DT_TEBeamEnts", "m_nStartEntity");
            public static int m_nEndEntity = NetVarManager.GetOffset("DT_TEBeamEnts", "m_nEndEntity");
        }

        public static class DT_TEBeamEntPoint
        {
            public static int m_nStartEntity = NetVarManager.GetOffset("DT_TEBeamEntPoint", "m_nStartEntity");
            public static int m_nEndEntity = NetVarManager.GetOffset("DT_TEBeamEntPoint", "m_nEndEntity");
            public static int m_vecStartPoint = NetVarManager.GetOffset("DT_TEBeamEntPoint", "m_vecStartPoint");
            public static int m_vecEndPoint = NetVarManager.GetOffset("DT_TEBeamEntPoint", "m_vecEndPoint");
        }

        public static class DT_BaseBeam
        {
            public static int m_nModelIndex = NetVarManager.GetOffset("DT_BaseBeam", "m_nModelIndex");
            public static int m_nHaloIndex = NetVarManager.GetOffset("DT_BaseBeam", "m_nHaloIndex");
            public static int m_nStartFrame = NetVarManager.GetOffset("DT_BaseBeam", "m_nStartFrame");
            public static int m_nFrameRate = NetVarManager.GetOffset("DT_BaseBeam", "m_nFrameRate");
            public static int m_fLife = NetVarManager.GetOffset("DT_BaseBeam", "m_fLife");
            public static int m_fWidth = NetVarManager.GetOffset("DT_BaseBeam", "m_fWidth");
            public static int m_fEndWidth = NetVarManager.GetOffset("DT_BaseBeam", "m_fEndWidth");
            public static int m_nFadeLength = NetVarManager.GetOffset("DT_BaseBeam", "m_nFadeLength");
            public static int m_fAmplitude = NetVarManager.GetOffset("DT_BaseBeam", "m_fAmplitude");
            public static int m_nSpeed = NetVarManager.GetOffset("DT_BaseBeam", "m_nSpeed");
            public static int r = NetVarManager.GetOffset("DT_BaseBeam", "r");
            public static int g = NetVarManager.GetOffset("DT_BaseBeam", "g");
            public static int b = NetVarManager.GetOffset("DT_BaseBeam", "b");
            public static int a = NetVarManager.GetOffset("DT_BaseBeam", "a");
            public static int m_nFlags = NetVarManager.GetOffset("DT_BaseBeam", "m_nFlags");
        }

        public static class DT_TEMetalSparks
        {
            public static int m_vecPos = NetVarManager.GetOffset("DT_TEMetalSparks", "m_vecPos");
            public static int m_vecDir = NetVarManager.GetOffset("DT_TEMetalSparks", "m_vecDir");
        }

        public static class DT_SteamJet
        {
            public static int m_SpreadSpeed = NetVarManager.GetOffset("DT_SteamJet", "m_SpreadSpeed");
            public static int m_Speed = NetVarManager.GetOffset("DT_SteamJet", "m_Speed");
            public static int m_StartSize = NetVarManager.GetOffset("DT_SteamJet", "m_StartSize");
            public static int m_EndSize = NetVarManager.GetOffset("DT_SteamJet", "m_EndSize");
            public static int m_Rate = NetVarManager.GetOffset("DT_SteamJet", "m_Rate");
            public static int m_JetLength = NetVarManager.GetOffset("DT_SteamJet", "m_JetLength");
            public static int m_bEmit = NetVarManager.GetOffset("DT_SteamJet", "m_bEmit");
            public static int m_bFaceLeft = NetVarManager.GetOffset("DT_SteamJet", "m_bFaceLeft");
            public static int m_nType = NetVarManager.GetOffset("DT_SteamJet", "m_nType");
            public static int m_spawnflags = NetVarManager.GetOffset("DT_SteamJet", "m_spawnflags");
            public static int m_flRollSpeed = NetVarManager.GetOffset("DT_SteamJet", "m_flRollSpeed");
        }

        public static class DT_SmokeStack
        {
            public static int m_SpreadSpeed = NetVarManager.GetOffset("DT_SmokeStack", "m_SpreadSpeed");
            public static int m_Speed = NetVarManager.GetOffset("DT_SmokeStack", "m_Speed");
            public static int m_StartSize = NetVarManager.GetOffset("DT_SmokeStack", "m_StartSize");
            public static int m_EndSize = NetVarManager.GetOffset("DT_SmokeStack", "m_EndSize");
            public static int m_Rate = NetVarManager.GetOffset("DT_SmokeStack", "m_Rate");
            public static int m_JetLength = NetVarManager.GetOffset("DT_SmokeStack", "m_JetLength");
            public static int m_bEmit = NetVarManager.GetOffset("DT_SmokeStack", "m_bEmit");
            public static int m_flBaseSpread = NetVarManager.GetOffset("DT_SmokeStack", "m_flBaseSpread");
            public static int m_flTwist = NetVarManager.GetOffset("DT_SmokeStack", "m_flTwist");
            public static int m_flRollSpeed = NetVarManager.GetOffset("DT_SmokeStack", "m_flRollSpeed");
            public static int m_iMaterialModel = NetVarManager.GetOffset("DT_SmokeStack", "m_iMaterialModel");
            public static int m_AmbientLight_m_vPos = NetVarManager.GetOffset("DT_SmokeStack", "m_AmbientLight.m_vPos");

            public static int m_AmbientLight_m_vColor =
                NetVarManager.GetOffset("DT_SmokeStack", "m_AmbientLight.m_vColor");

            public static int m_AmbientLight_m_flIntensity =
                NetVarManager.GetOffset("DT_SmokeStack", "m_AmbientLight.m_flIntensity");

            public static int m_DirLight_m_vPos = NetVarManager.GetOffset("DT_SmokeStack", "m_DirLight.m_vPos");
            public static int m_DirLight_m_vColor = NetVarManager.GetOffset("DT_SmokeStack", "m_DirLight.m_vColor");

            public static int m_DirLight_m_flIntensity =
                NetVarManager.GetOffset("DT_SmokeStack", "m_DirLight.m_flIntensity");

            public static int m_vWind = NetVarManager.GetOffset("DT_SmokeStack", "m_vWind");
        }

        public static class DT_DustTrail
        {
            public static int m_SpawnRate = NetVarManager.GetOffset("DT_DustTrail", "m_SpawnRate");
            public static int m_Color = NetVarManager.GetOffset("DT_DustTrail", "m_Color");
            public static int m_ParticleLifetime = NetVarManager.GetOffset("DT_DustTrail", "m_ParticleLifetime");
            public static int m_StopEmitTime = NetVarManager.GetOffset("DT_DustTrail", "m_StopEmitTime");
            public static int m_MinSpeed = NetVarManager.GetOffset("DT_DustTrail", "m_MinSpeed");
            public static int m_MaxSpeed = NetVarManager.GetOffset("DT_DustTrail", "m_MaxSpeed");
            public static int m_MinDirectedSpeed = NetVarManager.GetOffset("DT_DustTrail", "m_MinDirectedSpeed");
            public static int m_MaxDirectedSpeed = NetVarManager.GetOffset("DT_DustTrail", "m_MaxDirectedSpeed");
            public static int m_StartSize = NetVarManager.GetOffset("DT_DustTrail", "m_StartSize");
            public static int m_EndSize = NetVarManager.GetOffset("DT_DustTrail", "m_EndSize");
            public static int m_SpawnRadius = NetVarManager.GetOffset("DT_DustTrail", "m_SpawnRadius");
            public static int m_bEmit = NetVarManager.GetOffset("DT_DustTrail", "m_bEmit");
            public static int m_Opacity = NetVarManager.GetOffset("DT_DustTrail", "m_Opacity");
        }

        public static class DT_FireTrail
        {
            public static int m_nAttachment = NetVarManager.GetOffset("DT_FireTrail", "m_nAttachment");
            public static int m_flLifetime = NetVarManager.GetOffset("DT_FireTrail", "m_flLifetime");
        }

        public static class DT_SporeTrail
        {
            public static int m_flSpawnRate = NetVarManager.GetOffset("DT_SporeTrail", "m_flSpawnRate");
            public static int m_vecEndColor = NetVarManager.GetOffset("DT_SporeTrail", "m_vecEndColor");
            public static int m_flParticleLifetime = NetVarManager.GetOffset("DT_SporeTrail", "m_flParticleLifetime");
            public static int m_flStartSize = NetVarManager.GetOffset("DT_SporeTrail", "m_flStartSize");
            public static int m_flEndSize = NetVarManager.GetOffset("DT_SporeTrail", "m_flEndSize");
            public static int m_flSpawnRadius = NetVarManager.GetOffset("DT_SporeTrail", "m_flSpawnRadius");
            public static int m_bEmit = NetVarManager.GetOffset("DT_SporeTrail", "m_bEmit");
        }

        public static class DT_SporeExplosion
        {
            public static int m_flSpawnRate = NetVarManager.GetOffset("DT_SporeExplosion", "m_flSpawnRate");

            public static int m_flParticleLifetime =
                NetVarManager.GetOffset("DT_SporeExplosion", "m_flParticleLifetime");

            public static int m_flStartSize = NetVarManager.GetOffset("DT_SporeExplosion", "m_flStartSize");
            public static int m_flEndSize = NetVarManager.GetOffset("DT_SporeExplosion", "m_flEndSize");
            public static int m_flSpawnRadius = NetVarManager.GetOffset("DT_SporeExplosion", "m_flSpawnRadius");
            public static int m_bEmit = NetVarManager.GetOffset("DT_SporeExplosion", "m_bEmit");
            public static int m_bDontRemove = NetVarManager.GetOffset("DT_SporeExplosion", "m_bDontRemove");
        }

        public static class DT_RocketTrail
        {
            public static int m_SpawnRate = NetVarManager.GetOffset("DT_RocketTrail", "m_SpawnRate");
            public static int m_StartColor = NetVarManager.GetOffset("DT_RocketTrail", "m_StartColor");
            public static int m_EndColor = NetVarManager.GetOffset("DT_RocketTrail", "m_EndColor");
            public static int m_ParticleLifetime = NetVarManager.GetOffset("DT_RocketTrail", "m_ParticleLifetime");
            public static int m_StopEmitTime = NetVarManager.GetOffset("DT_RocketTrail", "m_StopEmitTime");
            public static int m_MinSpeed = NetVarManager.GetOffset("DT_RocketTrail", "m_MinSpeed");
            public static int m_MaxSpeed = NetVarManager.GetOffset("DT_RocketTrail", "m_MaxSpeed");
            public static int m_StartSize = NetVarManager.GetOffset("DT_RocketTrail", "m_StartSize");
            public static int m_EndSize = NetVarManager.GetOffset("DT_RocketTrail", "m_EndSize");
            public static int m_SpawnRadius = NetVarManager.GetOffset("DT_RocketTrail", "m_SpawnRadius");
            public static int m_bEmit = NetVarManager.GetOffset("DT_RocketTrail", "m_bEmit");
            public static int m_nAttachment = NetVarManager.GetOffset("DT_RocketTrail", "m_nAttachment");
            public static int m_Opacity = NetVarManager.GetOffset("DT_RocketTrail", "m_Opacity");
            public static int m_bDamaged = NetVarManager.GetOffset("DT_RocketTrail", "m_bDamaged");
            public static int m_flFlareScale = NetVarManager.GetOffset("DT_RocketTrail", "m_flFlareScale");
        }

        public static class DT_SmokeTrail
        {
            public static int m_SpawnRate = NetVarManager.GetOffset("DT_SmokeTrail", "m_SpawnRate");
            public static int m_StartColor = NetVarManager.GetOffset("DT_SmokeTrail", "m_StartColor");
            public static int m_EndColor = NetVarManager.GetOffset("DT_SmokeTrail", "m_EndColor");
            public static int m_ParticleLifetime = NetVarManager.GetOffset("DT_SmokeTrail", "m_ParticleLifetime");
            public static int m_StopEmitTime = NetVarManager.GetOffset("DT_SmokeTrail", "m_StopEmitTime");
            public static int m_MinSpeed = NetVarManager.GetOffset("DT_SmokeTrail", "m_MinSpeed");
            public static int m_MaxSpeed = NetVarManager.GetOffset("DT_SmokeTrail", "m_MaxSpeed");
            public static int m_MinDirectedSpeed = NetVarManager.GetOffset("DT_SmokeTrail", "m_MinDirectedSpeed");
            public static int m_MaxDirectedSpeed = NetVarManager.GetOffset("DT_SmokeTrail", "m_MaxDirectedSpeed");
            public static int m_StartSize = NetVarManager.GetOffset("DT_SmokeTrail", "m_StartSize");
            public static int m_EndSize = NetVarManager.GetOffset("DT_SmokeTrail", "m_EndSize");
            public static int m_SpawnRadius = NetVarManager.GetOffset("DT_SmokeTrail", "m_SpawnRadius");
            public static int m_bEmit = NetVarManager.GetOffset("DT_SmokeTrail", "m_bEmit");
            public static int m_nAttachment = NetVarManager.GetOffset("DT_SmokeTrail", "m_nAttachment");
            public static int m_Opacity = NetVarManager.GetOffset("DT_SmokeTrail", "m_Opacity");
        }

        public static class DT_PropVehicleDriveable
        {
            public static int m_hPlayer = NetVarManager.GetOffset("DT_PropVehicleDriveable", "m_hPlayer");
            public static int m_nSpeed = NetVarManager.GetOffset("DT_PropVehicleDriveable", "m_nSpeed");
            public static int m_nRPM = NetVarManager.GetOffset("DT_PropVehicleDriveable", "m_nRPM");
            public static int m_flThrottle = NetVarManager.GetOffset("DT_PropVehicleDriveable", "m_flThrottle");
            public static int m_nBoostTimeLeft = NetVarManager.GetOffset("DT_PropVehicleDriveable", "m_nBoostTimeLeft");
            public static int m_nHasBoost = NetVarManager.GetOffset("DT_PropVehicleDriveable", "m_nHasBoost");

            public static int m_nScannerDisabledWeapons =
                NetVarManager.GetOffset("DT_PropVehicleDriveable", "m_nScannerDisabledWeapons");

            public static int m_nScannerDisabledVehicle =
                NetVarManager.GetOffset("DT_PropVehicleDriveable", "m_nScannerDisabledVehicle");

            public static int m_bEnterAnimOn = NetVarManager.GetOffset("DT_PropVehicleDriveable", "m_bEnterAnimOn");
            public static int m_bExitAnimOn = NetVarManager.GetOffset("DT_PropVehicleDriveable", "m_bExitAnimOn");
            public static int m_bUnableToFire = NetVarManager.GetOffset("DT_PropVehicleDriveable", "m_bUnableToFire");

            public static int m_vecEyeExitEndpoint =
                NetVarManager.GetOffset("DT_PropVehicleDriveable", "m_vecEyeExitEndpoint");

            public static int m_bHasGun = NetVarManager.GetOffset("DT_PropVehicleDriveable", "m_bHasGun");

            public static int m_vecGunCrosshair =
                NetVarManager.GetOffset("DT_PropVehicleDriveable", "m_vecGunCrosshair");
        }

        public static class DT_ParticleSmokeGrenade
        {
            public static int m_flSpawnTime = NetVarManager.GetOffset("DT_ParticleSmokeGrenade", "m_flSpawnTime");
            public static int m_FadeStartTime = NetVarManager.GetOffset("DT_ParticleSmokeGrenade", "m_FadeStartTime");
            public static int m_FadeEndTime = NetVarManager.GetOffset("DT_ParticleSmokeGrenade", "m_FadeEndTime");
            public static int m_MinColor = NetVarManager.GetOffset("DT_ParticleSmokeGrenade", "m_MinColor");
            public static int m_MaxColor = NetVarManager.GetOffset("DT_ParticleSmokeGrenade", "m_MaxColor");
            public static int m_CurrentStage = NetVarManager.GetOffset("DT_ParticleSmokeGrenade", "m_CurrentStage");
        }

        public static class DT_ParticleFire
        {
            public static int m_vOrigin = NetVarManager.GetOffset("DT_ParticleFire", "m_vOrigin");
            public static int m_vDirection = NetVarManager.GetOffset("DT_ParticleFire", "m_vDirection");
        }

        public static class DT_TEGaussExplosion
        {
            public static int m_nType = NetVarManager.GetOffset("DT_TEGaussExplosion", "m_nType");
            public static int m_vecDirection = NetVarManager.GetOffset("DT_TEGaussExplosion", "m_vecDirection");
        }

        public static class DT_QuadraticBeam
        {
            public static int m_targetPosition = NetVarManager.GetOffset("DT_QuadraticBeam", "m_targetPosition");
            public static int m_controlPosition = NetVarManager.GetOffset("DT_QuadraticBeam", "m_controlPosition");
            public static int m_scrollRate = NetVarManager.GetOffset("DT_QuadraticBeam", "m_scrollRate");
            public static int m_flWidth = NetVarManager.GetOffset("DT_QuadraticBeam", "m_flWidth");
        }

        public static class DT_Embers
        {
            public static int m_nDensity = NetVarManager.GetOffset("DT_Embers", "m_nDensity");
            public static int m_nLifetime = NetVarManager.GetOffset("DT_Embers", "m_nLifetime");
            public static int m_nSpeed = NetVarManager.GetOffset("DT_Embers", "m_nSpeed");
            public static int m_bEmit = NetVarManager.GetOffset("DT_Embers", "m_bEmit");
        }

        public static class DT_EnvWind
        {
            public static int m_EnvWindShared = NetVarManager.GetOffset("DT_EnvWind", "m_EnvWindShared");
            public static int m_iMinWind = NetVarManager.GetOffset("DT_EnvWind", "m_iMinWind");
            public static int m_iMaxWind = NetVarManager.GetOffset("DT_EnvWind", "m_iMaxWind");
            public static int m_iMinGust = NetVarManager.GetOffset("DT_EnvWind", "m_iMinGust");
            public static int m_iMaxGust = NetVarManager.GetOffset("DT_EnvWind", "m_iMaxGust");
            public static int m_flMinGustDelay = NetVarManager.GetOffset("DT_EnvWind", "m_flMinGustDelay");
            public static int m_flMaxGustDelay = NetVarManager.GetOffset("DT_EnvWind", "m_flMaxGustDelay");
            public static int m_iGustDirChange = NetVarManager.GetOffset("DT_EnvWind", "m_iGustDirChange");
            public static int m_iWindSeed = NetVarManager.GetOffset("DT_EnvWind", "m_iWindSeed");
            public static int m_iInitialWindDir = NetVarManager.GetOffset("DT_EnvWind", "m_iInitialWindDir");
            public static int m_flInitialWindSpeed = NetVarManager.GetOffset("DT_EnvWind", "m_flInitialWindSpeed");
            public static int m_flStartTime = NetVarManager.GetOffset("DT_EnvWind", "m_flStartTime");
            public static int m_flGustDuration = NetVarManager.GetOffset("DT_EnvWind", "m_flGustDuration");
        }

        public static class DT_Precipitation
        {
            public static int m_nPrecipType = NetVarManager.GetOffset("DT_Precipitation", "m_nPrecipType");
        }

        public static class DT_BaseAttributableItem
        {
            public static int m_AttributeManager =
                NetVarManager.GetOffset("DT_BaseAttributableItem", "m_AttributeManager");

            public static int m_hOuter = NetVarManager.GetOffset("DT_BaseAttributableItem", "m_hOuter");
            public static int m_ProviderType = NetVarManager.GetOffset("DT_BaseAttributableItem", "m_ProviderType");

            public static int m_iReapplyProvisionParity =
                NetVarManager.GetOffset("DT_BaseAttributableItem", "m_iReapplyProvisionParity");

            public static int m_Item = NetVarManager.GetOffset("DT_BaseAttributableItem", "m_Item");

            public static int m_iItemDefinitionIndex =
                NetVarManager.GetOffset("DT_BaseAttributableItem", "m_iItemDefinitionIndex");

            public static int m_iEntityLevel = NetVarManager.GetOffset("DT_BaseAttributableItem", "m_iEntityLevel");
            public static int m_iItemIDHigh = NetVarManager.GetOffset("DT_BaseAttributableItem", "m_iItemIDHigh");
            public static int m_iItemIDLow = NetVarManager.GetOffset("DT_BaseAttributableItem", "m_iItemIDLow");
            public static int m_iAccountID = NetVarManager.GetOffset("DT_BaseAttributableItem", "m_iAccountID");
            public static int m_iEntityQuality = NetVarManager.GetOffset("DT_BaseAttributableItem", "m_iEntityQuality");
            public static int m_bInitialized = NetVarManager.GetOffset("DT_BaseAttributableItem", "m_bInitialized");
            public static int m_szCustomName = NetVarManager.GetOffset("DT_BaseAttributableItem", "m_szCustomName");

            public static int m_NetworkedDynamicAttributesForDemos =
                NetVarManager.GetOffset("DT_BaseAttributableItem", "m_NetworkedDynamicAttributesForDemos");

            public static int m_Attributes = NetVarManager.GetOffset("DT_BaseAttributableItem", "m_Attributes");
            public static int lengthproxy = NetVarManager.GetOffset("DT_BaseAttributableItem", "lengthproxy");
            public static int lengthprop32 = NetVarManager.GetOffset("DT_BaseAttributableItem", "lengthprop32");

            public static int m_OriginalOwnerXuidLow =
                NetVarManager.GetOffset("DT_BaseAttributableItem", "m_OriginalOwnerXuidLow");

            public static int m_OriginalOwnerXuidHigh =
                NetVarManager.GetOffset("DT_BaseAttributableItem", "m_OriginalOwnerXuidHigh");

            public static int m_nFallbackPaintKit =
                NetVarManager.GetOffset("DT_BaseAttributableItem", "m_nFallbackPaintKit");

            public static int m_nFallbackSeed = NetVarManager.GetOffset("DT_BaseAttributableItem", "m_nFallbackSeed");
            public static int m_flFallbackWear = NetVarManager.GetOffset("DT_BaseAttributableItem", "m_flFallbackWear");

            public static int m_nFallbackStatTrak =
                NetVarManager.GetOffset("DT_BaseAttributableItem", "m_nFallbackStatTrak");
        }

        public static class DT_EconEntity
        {
            public static int m_AttributeManager = NetVarManager.GetOffset("DT_EconEntity", "m_AttributeManager");
            public static int m_hOuter = NetVarManager.GetOffset("DT_EconEntity", "m_hOuter");
            public static int m_ProviderType = NetVarManager.GetOffset("DT_EconEntity", "m_ProviderType");

            public static int m_iReapplyProvisionParity =
                NetVarManager.GetOffset("DT_EconEntity", "m_iReapplyProvisionParity");

            public static int m_Item = NetVarManager.GetOffset("DT_EconEntity", "m_Item");

            public static int m_iItemDefinitionIndex =
                NetVarManager.GetOffset("DT_EconEntity", "m_iItemDefinitionIndex");

            public static int m_iEntityLevel = NetVarManager.GetOffset("DT_EconEntity", "m_iEntityLevel");
            public static int m_iItemIDHigh = NetVarManager.GetOffset("DT_EconEntity", "m_iItemIDHigh");
            public static int m_iItemIDLow = NetVarManager.GetOffset("DT_EconEntity", "m_iItemIDLow");
            public static int m_iAccountID = NetVarManager.GetOffset("DT_EconEntity", "m_iAccountID");
            public static int m_iEntityQuality = NetVarManager.GetOffset("DT_EconEntity", "m_iEntityQuality");
            public static int m_bInitialized = NetVarManager.GetOffset("DT_EconEntity", "m_bInitialized");
            public static int m_szCustomName = NetVarManager.GetOffset("DT_EconEntity", "m_szCustomName");

            public static int m_NetworkedDynamicAttributesForDemos =
                NetVarManager.GetOffset("DT_EconEntity", "m_NetworkedDynamicAttributesForDemos");

            public static int m_Attributes = NetVarManager.GetOffset("DT_EconEntity", "m_Attributes");
            public static int lengthproxy = NetVarManager.GetOffset("DT_EconEntity", "lengthproxy");
            public static int lengthprop32 = NetVarManager.GetOffset("DT_EconEntity", "lengthprop32");

            public static int m_OriginalOwnerXuidLow =
                NetVarManager.GetOffset("DT_EconEntity", "m_OriginalOwnerXuidLow");

            public static int m_OriginalOwnerXuidHigh =
                NetVarManager.GetOffset("DT_EconEntity", "m_OriginalOwnerXuidHigh");

            public static int m_nFallbackPaintKit = NetVarManager.GetOffset("DT_EconEntity", "m_nFallbackPaintKit");
            public static int m_nFallbackSeed = NetVarManager.GetOffset("DT_EconEntity", "m_nFallbackSeed");
            public static int m_flFallbackWear = NetVarManager.GetOffset("DT_EconEntity", "m_flFallbackWear");
            public static int m_nFallbackStatTrak = NetVarManager.GetOffset("DT_EconEntity", "m_nFallbackStatTrak");
        }

        public static class DT_WeaponXM1014
        {
            public static int m_reloadState = NetVarManager.GetOffset("DT_WeaponXM1014", "m_reloadState");
        }

        public static class DT_WeaponTaser
        {
            public static int m_fFireTime = NetVarManager.GetOffset("DT_WeaponTaser", "m_fFireTime");
        }

        public static class DT_WeaponTablet
        {
            public static int m_flUpgradeExpirationTime_0 =
                NetVarManager.GetOffset("DT_WeaponTablet", "m_flUpgradeExpirationTime[0]");

            public static int m_flUpgradeExpirationTime =
                NetVarManager.GetOffset("DT_WeaponTablet", "m_flUpgradeExpirationTime");

            public static int m_vecLocalHexFlags_0 =
                NetVarManager.GetOffset("DT_WeaponTablet", "m_vecLocalHexFlags[0]");

            public static int m_vecLocalHexFlags = NetVarManager.GetOffset("DT_WeaponTablet", "m_vecLocalHexFlags");

            public static int m_nContractKillGridIndex =
                NetVarManager.GetOffset("DT_WeaponTablet", "m_nContractKillGridIndex");

            public static int m_nContractKillGridHighResIndex =
                NetVarManager.GetOffset("DT_WeaponTablet", "m_nContractKillGridHighResIndex");

            public static int m_bTabletReceptionIsBlocked =
                NetVarManager.GetOffset("DT_WeaponTablet", "m_bTabletReceptionIsBlocked");

            public static int m_flScanProgress = NetVarManager.GetOffset("DT_WeaponTablet", "m_flScanProgress");
            public static int m_flBootTime = NetVarManager.GetOffset("DT_WeaponTablet", "m_flBootTime");
            public static int m_flShowMapTime = NetVarManager.GetOffset("DT_WeaponTablet", "m_flShowMapTime");

            public static int m_vecNotificationIds_0 =
                NetVarManager.GetOffset("DT_WeaponTablet", "m_vecNotificationIds[0]");

            public static int m_vecNotificationIds = NetVarManager.GetOffset("DT_WeaponTablet", "m_vecNotificationIds");

            public static int m_vecNotificationTimestamps_0 =
                NetVarManager.GetOffset("DT_WeaponTablet", "m_vecNotificationTimestamps[0]");

            public static int m_vecNotificationTimestamps =
                NetVarManager.GetOffset("DT_WeaponTablet", "m_vecNotificationTimestamps");

            public static int m_vecPlayerPositionHistory_0 =
                NetVarManager.GetOffset("DT_WeaponTablet", "m_vecPlayerPositionHistory[0]");

            public static int m_vecPlayerPositionHistory =
                NetVarManager.GetOffset("DT_WeaponTablet", "m_vecPlayerPositionHistory");

            public static int m_nLastPurchaseIndex = NetVarManager.GetOffset("DT_WeaponTablet", "m_nLastPurchaseIndex");

            public static int m_vecNearestMetalCratePos =
                NetVarManager.GetOffset("DT_WeaponTablet", "m_vecNearestMetalCratePos");
        }

        public static class DT_WeaponSawedoff
        {
            public static int m_reloadState = NetVarManager.GetOffset("DT_WeaponSawedoff", "m_reloadState");
        }

        public static class DT_WeaponNOVA
        {
            public static int m_reloadState = NetVarManager.GetOffset("DT_WeaponNOVA", "m_reloadState");
        }

        public static class DT_WeaponMelee
        {
            public static int m_flThrowAt = NetVarManager.GetOffset("DT_WeaponMelee", "m_flThrowAt");
        }

        public static class DT_WeaponM3
        {
            public static int m_reloadState = NetVarManager.GetOffset("DT_WeaponM3", "m_reloadState");
        }

        public static class DT_WeaponFists
        {
            public static int m_bPlayingUninterruptableAct =
                NetVarManager.GetOffset("DT_WeaponFists", "m_bPlayingUninterruptableAct");
        }

        public static class DT_WeaponCSBaseGun
        {
            public static int m_zoomLevel = NetVarManager.GetOffset("DT_WeaponCSBaseGun", "m_zoomLevel");

            public static int m_iBurstShotsRemaining =
                NetVarManager.GetOffset("DT_WeaponCSBaseGun", "m_iBurstShotsRemaining");
        }

        public static class DT_WeaponCSBase
        {
            public static int m_weaponMode = NetVarManager.GetOffset("DT_WeaponCSBase", "m_weaponMode");
            public static int m_fAccuracyPenalty = NetVarManager.GetOffset("DT_WeaponCSBase", "m_fAccuracyPenalty");
            public static int m_fLastShotTime = NetVarManager.GetOffset("DT_WeaponCSBase", "m_fLastShotTime");
            public static int m_iRecoilIndex = NetVarManager.GetOffset("DT_WeaponCSBase", "m_iRecoilIndex");
            public static int m_flRecoilIndex = NetVarManager.GetOffset("DT_WeaponCSBase", "m_flRecoilIndex");
            public static int m_hPrevOwner = NetVarManager.GetOffset("DT_WeaponCSBase", "m_hPrevOwner");
            public static int m_bBurstMode = NetVarManager.GetOffset("DT_WeaponCSBase", "m_bBurstMode");

            public static int m_flPostponeFireReadyTime =
                NetVarManager.GetOffset("DT_WeaponCSBase", "m_flPostponeFireReadyTime");

            public static int m_bReloadVisuallyComplete =
                NetVarManager.GetOffset("DT_WeaponCSBase", "m_bReloadVisuallyComplete");

            public static int m_bSilencerOn = NetVarManager.GetOffset("DT_WeaponCSBase", "m_bSilencerOn");

            public static int m_flDoneSwitchingSilencer =
                NetVarManager.GetOffset("DT_WeaponCSBase", "m_flDoneSwitchingSilencer");

            public static int m_iOriginalTeamNumber =
                NetVarManager.GetOffset("DT_WeaponCSBase", "m_iOriginalTeamNumber");

            public static int m_iIronSightMode = NetVarManager.GetOffset("DT_WeaponCSBase", "m_iIronSightMode");
        }

        public static class DT_WeaponC4
        {
            public static int m_bStartedArming = NetVarManager.GetOffset("DT_WeaponC4", "m_bStartedArming");
            public static int m_bBombPlacedAnimation = NetVarManager.GetOffset("DT_WeaponC4", "m_bBombPlacedAnimation");
            public static int m_fArmedTime = NetVarManager.GetOffset("DT_WeaponC4", "m_fArmedTime");
            public static int m_bShowC4LED = NetVarManager.GetOffset("DT_WeaponC4", "m_bShowC4LED");
            public static int m_bIsPlantingViaUse = NetVarManager.GetOffset("DT_WeaponC4", "m_bIsPlantingViaUse");
        }

        public static class DT_BumpMineProjectile
        {
            public static int m_nParentBoneIndex =
                NetVarManager.GetOffset("DT_BumpMineProjectile", "m_nParentBoneIndex");

            public static int m_vecParentBonePos =
                NetVarManager.GetOffset("DT_BumpMineProjectile", "m_vecParentBonePos");

            public static int m_bArmed = NetVarManager.GetOffset("DT_BumpMineProjectile", "m_bArmed");
        }

        public static class DT_BreachChargeProjectile
        {
            public static int m_bShouldExplode =
                NetVarManager.GetOffset("DT_BreachChargeProjectile", "m_bShouldExplode");

            public static int m_weaponThatThrewMe =
                NetVarManager.GetOffset("DT_BreachChargeProjectile", "m_weaponThatThrewMe");

            public static int m_nParentBoneIndex =
                NetVarManager.GetOffset("DT_BreachChargeProjectile", "m_nParentBoneIndex");

            public static int m_vecParentBonePos =
                NetVarManager.GetOffset("DT_BreachChargeProjectile", "m_vecParentBonePos");
        }

        public static class DT_WeaponBaseItem
        {
            public static int m_bRedraw = NetVarManager.GetOffset("DT_WeaponBaseItem", "m_bRedraw");
        }

        public static class DT_BaseCSGrenade
        {
            public static int m_bRedraw = NetVarManager.GetOffset("DT_BaseCSGrenade", "m_bRedraw");
            public static int m_bIsHeldByPlayer = NetVarManager.GetOffset("DT_BaseCSGrenade", "m_bIsHeldByPlayer");
            public static int m_bPinPulled = NetVarManager.GetOffset("DT_BaseCSGrenade", "m_bPinPulled");
            public static int m_fThrowTime = NetVarManager.GetOffset("DT_BaseCSGrenade", "m_fThrowTime");

            public static int m_bLoopingSoundPlaying =
                NetVarManager.GetOffset("DT_BaseCSGrenade", "m_bLoopingSoundPlaying");

            public static int m_flThrowStrength = NetVarManager.GetOffset("DT_BaseCSGrenade", "m_flThrowStrength");
        }

        public static class DT_SmokeGrenadeProjectile
        {
            public static int m_bDidSmokeEffect =
                NetVarManager.GetOffset("DT_SmokeGrenadeProjectile", "m_bDidSmokeEffect");

            public static int m_nSmokeEffectTickBegin =
                NetVarManager.GetOffset("DT_SmokeGrenadeProjectile", "m_nSmokeEffectTickBegin");
        }

        public static class DT_MolotovProjectile
        {
            public static int m_bIsIncGrenade = NetVarManager.GetOffset("DT_MolotovProjectile", "m_bIsIncGrenade");
        }

        public static class DT_ItemDogtags
        {
            public static int m_OwningPlayer = NetVarManager.GetOffset("DT_ItemDogtags", "m_OwningPlayer");
            public static int m_KillingPlayer = NetVarManager.GetOffset("DT_ItemDogtags", "m_KillingPlayer");
        }

        public static class DT_PhysPropLootCrate
        {
            public static int m_bRenderInPSPM = NetVarManager.GetOffset("DT_PhysPropLootCrate", "m_bRenderInPSPM");
            public static int m_bRenderInTablet = NetVarManager.GetOffset("DT_PhysPropLootCrate", "m_bRenderInTablet");
            public static int m_iHealth = NetVarManager.GetOffset("DT_PhysPropLootCrate", "m_iHealth");
            public static int m_iMaxHealth = NetVarManager.GetOffset("DT_PhysPropLootCrate", "m_iMaxHealth");
        }

        public static class DT_EnvGasCanister
        {
            public static int m_flFlightSpeed = NetVarManager.GetOffset("DT_EnvGasCanister", "m_flFlightSpeed");
            public static int m_flLaunchTime = NetVarManager.GetOffset("DT_EnvGasCanister", "m_flLaunchTime");

            public static int m_vecParabolaDirection =
                NetVarManager.GetOffset("DT_EnvGasCanister", "m_vecParabolaDirection");

            public static int m_flFlightTime = NetVarManager.GetOffset("DT_EnvGasCanister", "m_flFlightTime");
            public static int m_flWorldEnterTime = NetVarManager.GetOffset("DT_EnvGasCanister", "m_flWorldEnterTime");
            public static int m_flInitialZSpeed = NetVarManager.GetOffset("DT_EnvGasCanister", "m_flInitialZSpeed");
            public static int m_flZAcceleration = NetVarManager.GetOffset("DT_EnvGasCanister", "m_flZAcceleration");
            public static int m_flHorizSpeed = NetVarManager.GetOffset("DT_EnvGasCanister", "m_flHorizSpeed");

            public static int m_bLaunchedFromWithinWorld =
                NetVarManager.GetOffset("DT_EnvGasCanister", "m_bLaunchedFromWithinWorld");

            public static int m_vecImpactPosition = NetVarManager.GetOffset("DT_EnvGasCanister", "m_vecImpactPosition");
            public static int m_vecStartPosition = NetVarManager.GetOffset("DT_EnvGasCanister", "m_vecStartPosition");

            public static int m_vecEnterWorldPosition =
                NetVarManager.GetOffset("DT_EnvGasCanister", "m_vecEnterWorldPosition");

            public static int m_vecDirection = NetVarManager.GetOffset("DT_EnvGasCanister", "m_vecDirection");
            public static int m_vecStartAngles = NetVarManager.GetOffset("DT_EnvGasCanister", "m_vecStartAngles");
            public static int m_vecSkyboxOrigin = NetVarManager.GetOffset("DT_EnvGasCanister", "m_vecSkyboxOrigin");
            public static int m_flSkyboxScale = NetVarManager.GetOffset("DT_EnvGasCanister", "m_flSkyboxScale");
            public static int m_bInSkybox = NetVarManager.GetOffset("DT_EnvGasCanister", "m_bInSkybox");
            public static int m_bDoImpactEffects = NetVarManager.GetOffset("DT_EnvGasCanister", "m_bDoImpactEffects");
            public static int m_bLanded = NetVarManager.GetOffset("DT_EnvGasCanister", "m_bLanded");
            public static int m_hSkyboxCopy = NetVarManager.GetOffset("DT_EnvGasCanister", "m_hSkyboxCopy");
            public static int m_nMyZoneIndex = NetVarManager.GetOffset("DT_EnvGasCanister", "m_nMyZoneIndex");
            public static int m_vecOrigin = NetVarManager.GetOffset("DT_EnvGasCanister", "m_vecOrigin");
            public static int m_vecOrigin_2 = NetVarManager.GetOffset("DT_EnvGasCanister", "m_vecOrigin[2]");
        }

        public static class DT_Dronegun
        {
            public static int m_vecAttentionTarget = NetVarManager.GetOffset("DT_Dronegun", "m_vecAttentionTarget");
            public static int m_vecTargetOffset = NetVarManager.GetOffset("DT_Dronegun", "m_vecTargetOffset");
            public static int m_iHealth = NetVarManager.GetOffset("DT_Dronegun", "m_iHealth");
            public static int m_bHasTarget = NetVarManager.GetOffset("DT_Dronegun", "m_bHasTarget");
        }

        public static class DT_ParadropChopper
        {
            public static int m_vecOrigin = NetVarManager.GetOffset("DT_ParadropChopper", "m_vecOrigin");
            public static int m_vecOrigin_2 = NetVarManager.GetOffset("DT_ParadropChopper", "m_vecOrigin[2]");
            public static int m_hCallingPlayer = NetVarManager.GetOffset("DT_ParadropChopper", "m_hCallingPlayer");
        }

        public static class DT_SurvivalSpawnChopper
        {
            public static int m_vecOrigin = NetVarManager.GetOffset("DT_SurvivalSpawnChopper", "m_vecOrigin");
            public static int m_vecOrigin_2 = NetVarManager.GetOffset("DT_SurvivalSpawnChopper", "m_vecOrigin[2]");
        }

        public static class DT_BRC4Target
        {
            public static int m_bBrokenOpen = NetVarManager.GetOffset("DT_BRC4Target", "m_bBrokenOpen");
            public static int m_flRadius = NetVarManager.GetOffset("DT_BRC4Target", "m_flRadius");
        }

        public static class DT_InfoMapRegion
        {
            public static int m_flRadius = NetVarManager.GetOffset("DT_InfoMapRegion", "m_flRadius");
            public static int m_szLocToken = NetVarManager.GetOffset("DT_InfoMapRegion", "m_szLocToken");
        }

        public static class DT_Inferno
        {
            public static int m_fireXDelta = NetVarManager.GetOffset("DT_Inferno", "m_fireXDelta");
            public static int m_fireYDelta = NetVarManager.GetOffset("DT_Inferno", "m_fireYDelta");
            public static int m_fireZDelta = NetVarManager.GetOffset("DT_Inferno", "m_fireZDelta");
            public static int m_bFireIsBurning = NetVarManager.GetOffset("DT_Inferno", "m_bFireIsBurning");
            public static int m_nFireEffectTickBegin = NetVarManager.GetOffset("DT_Inferno", "m_nFireEffectTickBegin");
            public static int m_fireCount = NetVarManager.GetOffset("DT_Inferno", "m_fireCount");
        }

        public static class DT_CChicken
        {
            public static int m_jumpedThisFrame = NetVarManager.GetOffset("DT_CChicken", "m_jumpedThisFrame");
            public static int m_leader = NetVarManager.GetOffset("DT_CChicken", "m_leader");
        }

        public static class DT_Drone
        {
            public static int m_hMoveToThisEntity = NetVarManager.GetOffset("DT_Drone", "m_hMoveToThisEntity");
            public static int m_hDeliveryCargo = NetVarManager.GetOffset("DT_Drone", "m_hDeliveryCargo");
            public static int m_bPilotTakeoverAllowed = NetVarManager.GetOffset("DT_Drone", "m_bPilotTakeoverAllowed");
            public static int m_hPotentialCargo = NetVarManager.GetOffset("DT_Drone", "m_hPotentialCargo");
            public static int m_hCurrentPilot = NetVarManager.GetOffset("DT_Drone", "m_hCurrentPilot");
            public static int m_vecTagPositions_0 = NetVarManager.GetOffset("DT_Drone", "m_vecTagPositions[0]");
            public static int m_vecTagPositions = NetVarManager.GetOffset("DT_Drone", "m_vecTagPositions");
            public static int m_vecTagIncrements_0 = NetVarManager.GetOffset("DT_Drone", "m_vecTagIncrements[0]");
            public static int m_vecTagIncrements = NetVarManager.GetOffset("DT_Drone", "m_vecTagIncrements");
        }

        public static class DT_FootstepControl
        {
            public static int m_source = NetVarManager.GetOffset("DT_FootstepControl", "m_source");
            public static int m_destination = NetVarManager.GetOffset("DT_FootstepControl", "m_destination");
        }

        public static class DT_CSGameRulesProxy
        {
            public static int cs_gamerules_data = NetVarManager.GetOffset("DT_CSGameRulesProxy", "cs_gamerules_data");
            public static int m_bFreezePeriod = NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_bFreezePeriod");

            public static int m_bMatchWaitingForResume =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_bMatchWaitingForResume");

            public static int m_bWarmupPeriod = NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_bWarmupPeriod");
            public static int m_fWarmupPeriodEnd = NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_fWarmupPeriodEnd");

            public static int m_fWarmupPeriodStart =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_fWarmupPeriodStart");

            public static int m_bTerroristTimeOutActive =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_bTerroristTimeOutActive");

            public static int m_bCTTimeOutActive = NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_bCTTimeOutActive");

            public static int m_flTerroristTimeOutRemaining =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_flTerroristTimeOutRemaining");

            public static int m_flCTTimeOutRemaining =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_flCTTimeOutRemaining");

            public static int m_nTerroristTimeOuts =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_nTerroristTimeOuts");

            public static int m_nCTTimeOuts = NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_nCTTimeOuts");
            public static int m_iRoundTime = NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_iRoundTime");
            public static int m_gamePhase = NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_gamePhase");

            public static int m_totalRoundsPlayed =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_totalRoundsPlayed");

            public static int m_nOvertimePlaying = NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_nOvertimePlaying");

            public static int m_timeUntilNextPhaseStarts =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_timeUntilNextPhaseStarts");

            public static int m_flCMMItemDropRevealStartTime =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_flCMMItemDropRevealStartTime");

            public static int m_flCMMItemDropRevealEndTime =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_flCMMItemDropRevealEndTime");

            public static int m_fRoundStartTime = NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_fRoundStartTime");
            public static int m_bGameRestart = NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_bGameRestart");

            public static int m_flRestartRoundTime =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_flRestartRoundTime");

            public static int m_flGameStartTime = NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_flGameStartTime");

            public static int m_iHostagesRemaining =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_iHostagesRemaining");

            public static int m_bAnyHostageReached =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_bAnyHostageReached");

            public static int m_bMapHasBombTarget =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_bMapHasBombTarget");

            public static int m_bMapHasRescueZone =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_bMapHasRescueZone");

            public static int m_bMapHasBuyZone = NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_bMapHasBuyZone");

            public static int m_bIsQueuedMatchmaking =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_bIsQueuedMatchmaking");

            public static int m_bIsValveDS = NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_bIsValveDS");
            public static int m_bIsQuestEligible = NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_bIsQuestEligible");
            public static int m_bLogoMap = NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_bLogoMap");

            public static int m_bPlayAllStepSoundsOnServer =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_bPlayAllStepSoundsOnServer");

            public static int m_iNumGunGameProgressiveWeaponsCT =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_iNumGunGameProgressiveWeaponsCT");

            public static int m_iNumGunGameProgressiveWeaponsT =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_iNumGunGameProgressiveWeaponsT");

            public static int m_iSpectatorSlotCount =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_iSpectatorSlotCount");

            public static int m_bBombDropped = NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_bBombDropped");
            public static int m_bBombPlanted = NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_bBombPlanted");
            public static int m_iRoundWinStatus = NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_iRoundWinStatus");
            public static int m_eRoundWinReason = NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_eRoundWinReason");

            public static int m_flDMBonusStartTime =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_flDMBonusStartTime");

            public static int m_flDMBonusTimeLength =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_flDMBonusTimeLength");

            public static int m_unDMBonusWeaponLoadoutSlot =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_unDMBonusWeaponLoadoutSlot");

            public static int m_bDMBonusActive = NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_bDMBonusActive");
            public static int m_bTCantBuy = NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_bTCantBuy");
            public static int m_bCTCantBuy = NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_bCTCantBuy");

            public static int m_flGuardianBuyUntilTime =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_flGuardianBuyUntilTime");

            public static int m_iMatchStats_RoundResults =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_iMatchStats_RoundResults");

            public static int m_iMatchStats_PlayersAlive_T =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_iMatchStats_PlayersAlive_T");

            public static int m_iMatchStats_PlayersAlive_CT =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_iMatchStats_PlayersAlive_CT");

            public static int m_GGProgressiveWeaponOrderCT =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_GGProgressiveWeaponOrderCT");

            public static int m_GGProgressiveWeaponOrderT =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_GGProgressiveWeaponOrderT");

            public static int m_GGProgressiveWeaponKillUpgradeOrderCT =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_GGProgressiveWeaponKillUpgradeOrderCT");

            public static int m_GGProgressiveWeaponKillUpgradeOrderT =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_GGProgressiveWeaponKillUpgradeOrderT");

            public static int m_MatchDevice = NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_MatchDevice");
            public static int m_bHasMatchStarted = NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_bHasMatchStarted");

            public static int m_TeamRespawnWaveTimes =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_TeamRespawnWaveTimes");

            public static int m_flNextRespawnWave =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_flNextRespawnWave");

            public static int m_nNextMapInMapgroup =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_nNextMapInMapgroup");

            public static int m_nEndMatchMapGroupVoteTypes =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_nEndMatchMapGroupVoteTypes");

            public static int m_nEndMatchMapGroupVoteOptions =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_nEndMatchMapGroupVoteOptions");

            public static int m_nEndMatchMapVoteWinner =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_nEndMatchMapVoteWinner");

            public static int m_bIsDroppingItems = NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_bIsDroppingItems");

            public static int m_iActiveAssassinationTargetMissionID =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_iActiveAssassinationTargetMissionID");

            public static int m_fMatchStartTime = NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_fMatchStartTime");

            public static int m_szTournamentEventName =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_szTournamentEventName");

            public static int m_szTournamentEventStage =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_szTournamentEventStage");

            public static int m_szTournamentPredictionsTxt =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_szTournamentPredictionsTxt");

            public static int m_nTournamentPredictionsPct =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_nTournamentPredictionsPct");

            public static int m_szMatchStatTxt = NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_szMatchStatTxt");

            public static int m_nGuardianModeWaveNumber =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_nGuardianModeWaveNumber");

            public static int m_nGuardianModeSpecialKillsRemaining =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_nGuardianModeSpecialKillsRemaining");

            public static int m_nGuardianModeSpecialWeaponNeeded =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_nGuardianModeSpecialWeaponNeeded");

            public static int m_nHalloweenMaskListSeed =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_nHalloweenMaskListSeed");

            public static int m_numGlobalGiftsGiven =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_numGlobalGiftsGiven");

            public static int m_numGlobalGifters = NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_numGlobalGifters");

            public static int m_numGlobalGiftsPeriodSeconds =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_numGlobalGiftsPeriodSeconds");

            public static int m_arrFeaturedGiftersAccounts =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_arrFeaturedGiftersAccounts");

            public static int m_arrFeaturedGiftersGifts =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_arrFeaturedGiftersGifts");

            public static int m_arrProhibitedItemIndices =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_arrProhibitedItemIndices");

            public static int m_numBestOfMaps = NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_numBestOfMaps");

            public static int m_arrTournamentActiveCasterAccounts =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_arrTournamentActiveCasterAccounts");

            public static int m_iNumConsecutiveCTLoses =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_iNumConsecutiveCTLoses");

            public static int m_iNumConsecutiveTerroristLoses =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_iNumConsecutiveTerroristLoses");

            public static int m_SurvivalRules = NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_SurvivalRules");
            public static int m_vecPlayAreaMins = NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_vecPlayAreaMins");
            public static int m_vecPlayAreaMaxs = NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_vecPlayAreaMaxs");

            public static int m_iPlayerSpawnHexIndices =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_iPlayerSpawnHexIndices");

            public static int m_SpawnTileState = NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_SpawnTileState");

            public static int m_flSpawnSelectionTimeStart =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_flSpawnSelectionTimeStart");

            public static int m_flSpawnSelectionTimeEnd =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_flSpawnSelectionTimeEnd");

            public static int m_flSpawnSelectionTimeLoadout =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_flSpawnSelectionTimeLoadout");

            public static int m_spawnStage = NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_spawnStage");

            public static int m_flTabletHexOriginX =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_flTabletHexOriginX");

            public static int m_flTabletHexOriginY =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_flTabletHexOriginY");

            public static int m_flTabletHexSize = NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_flTabletHexSize");

            public static int m_roundData_playerXuids =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_roundData_playerXuids");

            public static int m_roundData_playerPositions =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_roundData_playerPositions");

            public static int m_roundData_playerTeams =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_roundData_playerTeams");

            public static int m_SurvivalGameRuleDecisionTypes =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_SurvivalGameRuleDecisionTypes");

            public static int m_SurvivalGameRuleDecisionValues =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_SurvivalGameRuleDecisionValues");

            public static int m_flSurvivalStartTime =
                NetVarManager.GetOffset("DT_CSGameRulesProxy", "m_flSurvivalStartTime");
        }

        public static class DT_TEPlantBomb
        {
            public static int m_vecOrigin = NetVarManager.GetOffset("DT_TEPlantBomb", "m_vecOrigin");
            public static int m_iPlayer = NetVarManager.GetOffset("DT_TEPlantBomb", "m_iPlayer");
            public static int m_option = NetVarManager.GetOffset("DT_TEPlantBomb", "m_option");
        }

        public static class DT_TEFireBullets
        {
            public static int m_vecOrigin = NetVarManager.GetOffset("DT_TEFireBullets", "m_vecOrigin");
            public static int m_vecAngles_0 = NetVarManager.GetOffset("DT_TEFireBullets", "m_vecAngles[0]");
            public static int m_vecAngles_1 = NetVarManager.GetOffset("DT_TEFireBullets", "m_vecAngles[1]");
            public static int m_iWeaponID = NetVarManager.GetOffset("DT_TEFireBullets", "m_iWeaponID");
            public static int m_weapon = NetVarManager.GetOffset("DT_TEFireBullets", "m_weapon");
            public static int m_iMode = NetVarManager.GetOffset("DT_TEFireBullets", "m_iMode");
            public static int m_iSeed = NetVarManager.GetOffset("DT_TEFireBullets", "m_iSeed");
            public static int m_iPlayer = NetVarManager.GetOffset("DT_TEFireBullets", "m_iPlayer");
            public static int m_fInaccuracy = NetVarManager.GetOffset("DT_TEFireBullets", "m_fInaccuracy");
            public static int m_fSpread = NetVarManager.GetOffset("DT_TEFireBullets", "m_fSpread");
            public static int m_nItemDefIndex = NetVarManager.GetOffset("DT_TEFireBullets", "m_nItemDefIndex");
            public static int m_iSoundType = NetVarManager.GetOffset("DT_TEFireBullets", "m_iSoundType");
            public static int m_flRecoilIndex = NetVarManager.GetOffset("DT_TEFireBullets", "m_flRecoilIndex");
        }

        public static class DT_TERadioIcon
        {
            public static int m_iAttachToClient = NetVarManager.GetOffset("DT_TERadioIcon", "m_iAttachToClient");
        }

        public static class DT_PlantedC4
        {
            public static int m_bBombTicking = NetVarManager.GetOffset("DT_PlantedC4", "m_bBombTicking");
            public static int m_nBombSite = NetVarManager.GetOffset("DT_PlantedC4", "m_nBombSite");
            public static int m_flC4Blow = NetVarManager.GetOffset("DT_PlantedC4", "m_flC4Blow");
            public static int m_flTimerLength = NetVarManager.GetOffset("DT_PlantedC4", "m_flTimerLength");
            public static int m_flDefuseLength = NetVarManager.GetOffset("DT_PlantedC4", "m_flDefuseLength");
            public static int m_flDefuseCountDown = NetVarManager.GetOffset("DT_PlantedC4", "m_flDefuseCountDown");
            public static int m_bBombDefused = NetVarManager.GetOffset("DT_PlantedC4", "m_bBombDefused");
            public static int m_hBombDefuser = NetVarManager.GetOffset("DT_PlantedC4", "m_hBombDefuser");
        }

        public static class DT_CSPlayerResource
        {
            public static int m_iPlayerC4 = NetVarManager.GetOffset("DT_CSPlayerResource", "m_iPlayerC4");
            public static int m_iPlayerVIP = NetVarManager.GetOffset("DT_CSPlayerResource", "m_iPlayerVIP");
            public static int m_bHostageAlive = NetVarManager.GetOffset("DT_CSPlayerResource", "m_bHostageAlive");

            public static int m_isHostageFollowingSomeone =
                NetVarManager.GetOffset("DT_CSPlayerResource", "m_isHostageFollowingSomeone");

            public static int m_iHostageEntityIDs =
                NetVarManager.GetOffset("DT_CSPlayerResource", "m_iHostageEntityIDs");

            public static int m_bombsiteCenterA = NetVarManager.GetOffset("DT_CSPlayerResource", "m_bombsiteCenterA");
            public static int m_bombsiteCenterB = NetVarManager.GetOffset("DT_CSPlayerResource", "m_bombsiteCenterB");
            public static int m_hostageRescueX = NetVarManager.GetOffset("DT_CSPlayerResource", "m_hostageRescueX");
            public static int m_hostageRescueY = NetVarManager.GetOffset("DT_CSPlayerResource", "m_hostageRescueY");
            public static int m_hostageRescueZ = NetVarManager.GetOffset("DT_CSPlayerResource", "m_hostageRescueZ");
            public static int m_iMVPs = NetVarManager.GetOffset("DT_CSPlayerResource", "m_iMVPs");
            public static int m_iArmor = NetVarManager.GetOffset("DT_CSPlayerResource", "m_iArmor");
            public static int m_bHasHelmet = NetVarManager.GetOffset("DT_CSPlayerResource", "m_bHasHelmet");
            public static int m_bHasDefuser = NetVarManager.GetOffset("DT_CSPlayerResource", "m_bHasDefuser");
            public static int m_iScore = NetVarManager.GetOffset("DT_CSPlayerResource", "m_iScore");

            public static int m_iCompetitiveRanking =
                NetVarManager.GetOffset("DT_CSPlayerResource", "m_iCompetitiveRanking");

            public static int m_iCompetitiveWins = NetVarManager.GetOffset("DT_CSPlayerResource", "m_iCompetitiveWins");

            public static int m_iCompetitiveRankType =
                NetVarManager.GetOffset("DT_CSPlayerResource", "m_iCompetitiveRankType");

            public static int m_iCompTeammateColor =
                NetVarManager.GetOffset("DT_CSPlayerResource", "m_iCompTeammateColor");

            public static int m_iLifetimeStart = NetVarManager.GetOffset("DT_CSPlayerResource", "m_iLifetimeStart");
            public static int m_iLifetimeEnd = NetVarManager.GetOffset("DT_CSPlayerResource", "m_iLifetimeEnd");
            public static int m_bControllingBot = NetVarManager.GetOffset("DT_CSPlayerResource", "m_bControllingBot");

            public static int m_iControlledPlayer =
                NetVarManager.GetOffset("DT_CSPlayerResource", "m_iControlledPlayer");

            public static int m_iControlledByPlayer =
                NetVarManager.GetOffset("DT_CSPlayerResource", "m_iControlledByPlayer");

            public static int m_iBotDifficulty = NetVarManager.GetOffset("DT_CSPlayerResource", "m_iBotDifficulty");
            public static int m_szClan = NetVarManager.GetOffset("DT_CSPlayerResource", "m_szClan");

            public static int m_nCharacterDefIndex =
                NetVarManager.GetOffset("DT_CSPlayerResource", "m_nCharacterDefIndex");

            public static int m_iTotalCashSpent = NetVarManager.GetOffset("DT_CSPlayerResource", "m_iTotalCashSpent");
            public static int m_iGunGameLevel = NetVarManager.GetOffset("DT_CSPlayerResource", "m_iGunGameLevel");

            public static int m_iCashSpentThisRound =
                NetVarManager.GetOffset("DT_CSPlayerResource", "m_iCashSpentThisRound");

            public static int m_nEndMatchNextMapVotes =
                NetVarManager.GetOffset("DT_CSPlayerResource", "m_nEndMatchNextMapVotes");

            public static int m_bEndMatchNextMapAllVoted =
                NetVarManager.GetOffset("DT_CSPlayerResource", "m_bEndMatchNextMapAllVoted");

            public static int m_nActiveCoinRank = NetVarManager.GetOffset("DT_CSPlayerResource", "m_nActiveCoinRank");
            public static int m_nMusicID = NetVarManager.GetOffset("DT_CSPlayerResource", "m_nMusicID");

            public static int m_nPersonaDataPublicLevel =
                NetVarManager.GetOffset("DT_CSPlayerResource", "m_nPersonaDataPublicLevel");

            public static int m_nPersonaDataPublicCommendsLeader =
                NetVarManager.GetOffset("DT_CSPlayerResource", "m_nPersonaDataPublicCommendsLeader");

            public static int m_nPersonaDataPublicCommendsTeacher =
                NetVarManager.GetOffset("DT_CSPlayerResource", "m_nPersonaDataPublicCommendsTeacher");

            public static int m_nPersonaDataPublicCommendsFriendly =
                NetVarManager.GetOffset("DT_CSPlayerResource", "m_nPersonaDataPublicCommendsFriendly");

            public static int m_bHasCommunicationAbuseMute =
                NetVarManager.GetOffset("DT_CSPlayerResource", "m_bHasCommunicationAbuseMute");

            public static int m_szCrosshairCodes = NetVarManager.GetOffset("DT_CSPlayerResource", "m_szCrosshairCodes");

            public static int m_iMatchStats_Kills_Total =
                NetVarManager.GetOffset("DT_CSPlayerResource", "m_iMatchStats_Kills_Total");

            public static int m_iMatchStats_5k_Total =
                NetVarManager.GetOffset("DT_CSPlayerResource", "m_iMatchStats_5k_Total");

            public static int m_iMatchStats_4k_Total =
                NetVarManager.GetOffset("DT_CSPlayerResource", "m_iMatchStats_4k_Total");

            public static int m_iMatchStats_3k_Total =
                NetVarManager.GetOffset("DT_CSPlayerResource", "m_iMatchStats_3k_Total");

            public static int m_iMatchStats_Damage_Total =
                NetVarManager.GetOffset("DT_CSPlayerResource", "m_iMatchStats_Damage_Total");

            public static int m_iMatchStats_EquipmentValue_Total =
                NetVarManager.GetOffset("DT_CSPlayerResource", "m_iMatchStats_EquipmentValue_Total");

            public static int m_iMatchStats_KillReward_Total =
                NetVarManager.GetOffset("DT_CSPlayerResource", "m_iMatchStats_KillReward_Total");

            public static int m_iMatchStats_LiveTime_Total =
                NetVarManager.GetOffset("DT_CSPlayerResource", "m_iMatchStats_LiveTime_Total");

            public static int m_iMatchStats_Deaths_Total =
                NetVarManager.GetOffset("DT_CSPlayerResource", "m_iMatchStats_Deaths_Total");

            public static int m_iMatchStats_Assists_Total =
                NetVarManager.GetOffset("DT_CSPlayerResource", "m_iMatchStats_Assists_Total");

            public static int m_iMatchStats_HeadShotKills_Total =
                NetVarManager.GetOffset("DT_CSPlayerResource", "m_iMatchStats_HeadShotKills_Total");

            public static int m_iMatchStats_Objective_Total =
                NetVarManager.GetOffset("DT_CSPlayerResource", "m_iMatchStats_Objective_Total");

            public static int m_iMatchStats_CashEarned_Total =
                NetVarManager.GetOffset("DT_CSPlayerResource", "m_iMatchStats_CashEarned_Total");

            public static int m_iMatchStats_UtilityDamage_Total =
                NetVarManager.GetOffset("DT_CSPlayerResource", "m_iMatchStats_UtilityDamage_Total");

            public static int m_iMatchStats_EnemiesFlashed_Total =
                NetVarManager.GetOffset("DT_CSPlayerResource", "m_iMatchStats_EnemiesFlashed_Total");
        }

        public static class DT_CSPlayer
        {
            public static int cslocaldata = NetVarManager.GetOffset("DT_CSPlayer", "cslocaldata");
            public static int m_vecOrigin = NetVarManager.GetOffset("DT_CSPlayer", "m_vecOrigin");
            public static int m_vecOrigin_2 = NetVarManager.GetOffset("DT_CSPlayer", "m_vecOrigin[2]");
            public static int m_flStamina = NetVarManager.GetOffset("DT_CSPlayer", "m_flStamina");
            public static int m_iDirection = NetVarManager.GetOffset("DT_CSPlayer", "m_iDirection");
            public static int m_iShotsFired = NetVarManager.GetOffset("DT_CSPlayer", "m_iShotsFired");
            public static int m_nNumFastDucks = NetVarManager.GetOffset("DT_CSPlayer", "m_nNumFastDucks");
            public static int m_bDuckOverride = NetVarManager.GetOffset("DT_CSPlayer", "m_bDuckOverride");
            public static int m_flVelocityModifier = NetVarManager.GetOffset("DT_CSPlayer", "m_flVelocityModifier");
            public static int m_bPlayerDominated = NetVarManager.GetOffset("DT_CSPlayer", "m_bPlayerDominated");
            public static int m_bPlayerDominatingMe = NetVarManager.GetOffset("DT_CSPlayer", "m_bPlayerDominatingMe");

            public static int m_iWeaponPurchasesThisRound =
                NetVarManager.GetOffset("DT_CSPlayer", "m_iWeaponPurchasesThisRound");

            public static int m_unActiveQuestId = NetVarManager.GetOffset("DT_CSPlayer", "m_unActiveQuestId");
            public static int m_nQuestProgressReason = NetVarManager.GetOffset("DT_CSPlayer", "m_nQuestProgressReason");
            public static int csnonlocaldata = NetVarManager.GetOffset("DT_CSPlayer", "csnonlocaldata");
            public static int csteamdata = NetVarManager.GetOffset("DT_CSPlayer", "csteamdata");

            public static int m_iWeaponPurchasesThisMatch =
                NetVarManager.GetOffset("DT_CSPlayer", "m_iWeaponPurchasesThisMatch");

            public static int _300 = NetVarManager.GetOffset("DT_CSPlayer", "300");
            public static int _301 = NetVarManager.GetOffset("DT_CSPlayer", "301");
            public static int _302 = NetVarManager.GetOffset("DT_CSPlayer", "302");
            public static int _303 = NetVarManager.GetOffset("DT_CSPlayer", "303");
            public static int _304 = NetVarManager.GetOffset("DT_CSPlayer", "304");
            public static int _305 = NetVarManager.GetOffset("DT_CSPlayer", "305");
            public static int _306 = NetVarManager.GetOffset("DT_CSPlayer", "306");
            public static int _307 = NetVarManager.GetOffset("DT_CSPlayer", "307");
            public static int _308 = NetVarManager.GetOffset("DT_CSPlayer", "308");
            public static int _309 = NetVarManager.GetOffset("DT_CSPlayer", "309");
            public static int _310 = NetVarManager.GetOffset("DT_CSPlayer", "310");
            public static int _311 = NetVarManager.GetOffset("DT_CSPlayer", "311");
            public static int _312 = NetVarManager.GetOffset("DT_CSPlayer", "312");
            public static int _313 = NetVarManager.GetOffset("DT_CSPlayer", "313");
            public static int _314 = NetVarManager.GetOffset("DT_CSPlayer", "314");
            public static int _315 = NetVarManager.GetOffset("DT_CSPlayer", "315");
            public static int _316 = NetVarManager.GetOffset("DT_CSPlayer", "316");
            public static int _317 = NetVarManager.GetOffset("DT_CSPlayer", "317");
            public static int _318 = NetVarManager.GetOffset("DT_CSPlayer", "318");
            public static int _319 = NetVarManager.GetOffset("DT_CSPlayer", "319");
            public static int _320 = NetVarManager.GetOffset("DT_CSPlayer", "320");
            public static int _321 = NetVarManager.GetOffset("DT_CSPlayer", "321");
            public static int _322 = NetVarManager.GetOffset("DT_CSPlayer", "322");
            public static int _323 = NetVarManager.GetOffset("DT_CSPlayer", "323");
            public static int _324 = NetVarManager.GetOffset("DT_CSPlayer", "324");
            public static int _325 = NetVarManager.GetOffset("DT_CSPlayer", "325");
            public static int _326 = NetVarManager.GetOffset("DT_CSPlayer", "326");
            public static int _327 = NetVarManager.GetOffset("DT_CSPlayer", "327");
            public static int _328 = NetVarManager.GetOffset("DT_CSPlayer", "328");
            public static int _329 = NetVarManager.GetOffset("DT_CSPlayer", "329");
            public static int _330 = NetVarManager.GetOffset("DT_CSPlayer", "330");
            public static int _331 = NetVarManager.GetOffset("DT_CSPlayer", "331");
            public static int _332 = NetVarManager.GetOffset("DT_CSPlayer", "332");
            public static int _333 = NetVarManager.GetOffset("DT_CSPlayer", "333");
            public static int _334 = NetVarManager.GetOffset("DT_CSPlayer", "334");
            public static int _335 = NetVarManager.GetOffset("DT_CSPlayer", "335");
            public static int _336 = NetVarManager.GetOffset("DT_CSPlayer", "336");
            public static int _337 = NetVarManager.GetOffset("DT_CSPlayer", "337");
            public static int _338 = NetVarManager.GetOffset("DT_CSPlayer", "338");
            public static int _339 = NetVarManager.GetOffset("DT_CSPlayer", "339");
            public static int _340 = NetVarManager.GetOffset("DT_CSPlayer", "340");
            public static int _341 = NetVarManager.GetOffset("DT_CSPlayer", "341");
            public static int _342 = NetVarManager.GetOffset("DT_CSPlayer", "342");
            public static int _343 = NetVarManager.GetOffset("DT_CSPlayer", "343");
            public static int _344 = NetVarManager.GetOffset("DT_CSPlayer", "344");
            public static int _345 = NetVarManager.GetOffset("DT_CSPlayer", "345");
            public static int _346 = NetVarManager.GetOffset("DT_CSPlayer", "346");
            public static int _347 = NetVarManager.GetOffset("DT_CSPlayer", "347");
            public static int _348 = NetVarManager.GetOffset("DT_CSPlayer", "348");
            public static int _349 = NetVarManager.GetOffset("DT_CSPlayer", "349");
            public static int _350 = NetVarManager.GetOffset("DT_CSPlayer", "350");
            public static int _351 = NetVarManager.GetOffset("DT_CSPlayer", "351");
            public static int _352 = NetVarManager.GetOffset("DT_CSPlayer", "352");
            public static int _353 = NetVarManager.GetOffset("DT_CSPlayer", "353");
            public static int _354 = NetVarManager.GetOffset("DT_CSPlayer", "354");
            public static int _355 = NetVarManager.GetOffset("DT_CSPlayer", "355");
            public static int _356 = NetVarManager.GetOffset("DT_CSPlayer", "356");
            public static int _357 = NetVarManager.GetOffset("DT_CSPlayer", "357");
            public static int _358 = NetVarManager.GetOffset("DT_CSPlayer", "358");
            public static int _359 = NetVarManager.GetOffset("DT_CSPlayer", "359");
            public static int _360 = NetVarManager.GetOffset("DT_CSPlayer", "360");
            public static int _361 = NetVarManager.GetOffset("DT_CSPlayer", "361");
            public static int _362 = NetVarManager.GetOffset("DT_CSPlayer", "362");
            public static int _363 = NetVarManager.GetOffset("DT_CSPlayer", "363");
            public static int _364 = NetVarManager.GetOffset("DT_CSPlayer", "364");
            public static int _365 = NetVarManager.GetOffset("DT_CSPlayer", "365");
            public static int _366 = NetVarManager.GetOffset("DT_CSPlayer", "366");
            public static int _367 = NetVarManager.GetOffset("DT_CSPlayer", "367");
            public static int _368 = NetVarManager.GetOffset("DT_CSPlayer", "368");
            public static int _369 = NetVarManager.GetOffset("DT_CSPlayer", "369");
            public static int _370 = NetVarManager.GetOffset("DT_CSPlayer", "370");
            public static int _371 = NetVarManager.GetOffset("DT_CSPlayer", "371");
            public static int _372 = NetVarManager.GetOffset("DT_CSPlayer", "372");
            public static int _373 = NetVarManager.GetOffset("DT_CSPlayer", "373");
            public static int _374 = NetVarManager.GetOffset("DT_CSPlayer", "374");
            public static int _375 = NetVarManager.GetOffset("DT_CSPlayer", "375");
            public static int _376 = NetVarManager.GetOffset("DT_CSPlayer", "376");
            public static int _377 = NetVarManager.GetOffset("DT_CSPlayer", "377");
            public static int _378 = NetVarManager.GetOffset("DT_CSPlayer", "378");
            public static int _379 = NetVarManager.GetOffset("DT_CSPlayer", "379");
            public static int _380 = NetVarManager.GetOffset("DT_CSPlayer", "380");
            public static int _381 = NetVarManager.GetOffset("DT_CSPlayer", "381");
            public static int _382 = NetVarManager.GetOffset("DT_CSPlayer", "382");
            public static int _383 = NetVarManager.GetOffset("DT_CSPlayer", "383");
            public static int _384 = NetVarManager.GetOffset("DT_CSPlayer", "384");
            public static int _385 = NetVarManager.GetOffset("DT_CSPlayer", "385");
            public static int _386 = NetVarManager.GetOffset("DT_CSPlayer", "386");
            public static int _387 = NetVarManager.GetOffset("DT_CSPlayer", "387");
            public static int _388 = NetVarManager.GetOffset("DT_CSPlayer", "388");
            public static int _389 = NetVarManager.GetOffset("DT_CSPlayer", "389");
            public static int _390 = NetVarManager.GetOffset("DT_CSPlayer", "390");
            public static int _391 = NetVarManager.GetOffset("DT_CSPlayer", "391");
            public static int _392 = NetVarManager.GetOffset("DT_CSPlayer", "392");
            public static int _393 = NetVarManager.GetOffset("DT_CSPlayer", "393");
            public static int _394 = NetVarManager.GetOffset("DT_CSPlayer", "394");
            public static int _395 = NetVarManager.GetOffset("DT_CSPlayer", "395");
            public static int _396 = NetVarManager.GetOffset("DT_CSPlayer", "396");
            public static int _397 = NetVarManager.GetOffset("DT_CSPlayer", "397");
            public static int _398 = NetVarManager.GetOffset("DT_CSPlayer", "398");
            public static int _399 = NetVarManager.GetOffset("DT_CSPlayer", "399");
            public static int _400 = NetVarManager.GetOffset("DT_CSPlayer", "400");
            public static int _401 = NetVarManager.GetOffset("DT_CSPlayer", "401");
            public static int _402 = NetVarManager.GetOffset("DT_CSPlayer", "402");
            public static int _403 = NetVarManager.GetOffset("DT_CSPlayer", "403");
            public static int _404 = NetVarManager.GetOffset("DT_CSPlayer", "404");
            public static int _405 = NetVarManager.GetOffset("DT_CSPlayer", "405");
            public static int _406 = NetVarManager.GetOffset("DT_CSPlayer", "406");
            public static int _407 = NetVarManager.GetOffset("DT_CSPlayer", "407");
            public static int _408 = NetVarManager.GetOffset("DT_CSPlayer", "408");
            public static int _409 = NetVarManager.GetOffset("DT_CSPlayer", "409");
            public static int _410 = NetVarManager.GetOffset("DT_CSPlayer", "410");
            public static int _411 = NetVarManager.GetOffset("DT_CSPlayer", "411");
            public static int _412 = NetVarManager.GetOffset("DT_CSPlayer", "412");
            public static int _413 = NetVarManager.GetOffset("DT_CSPlayer", "413");
            public static int _414 = NetVarManager.GetOffset("DT_CSPlayer", "414");
            public static int _415 = NetVarManager.GetOffset("DT_CSPlayer", "415");
            public static int _416 = NetVarManager.GetOffset("DT_CSPlayer", "416");
            public static int _417 = NetVarManager.GetOffset("DT_CSPlayer", "417");
            public static int _418 = NetVarManager.GetOffset("DT_CSPlayer", "418");
            public static int _419 = NetVarManager.GetOffset("DT_CSPlayer", "419");
            public static int _420 = NetVarManager.GetOffset("DT_CSPlayer", "420");
            public static int _421 = NetVarManager.GetOffset("DT_CSPlayer", "421");
            public static int _422 = NetVarManager.GetOffset("DT_CSPlayer", "422");
            public static int _423 = NetVarManager.GetOffset("DT_CSPlayer", "423");
            public static int _424 = NetVarManager.GetOffset("DT_CSPlayer", "424");
            public static int _425 = NetVarManager.GetOffset("DT_CSPlayer", "425");
            public static int _426 = NetVarManager.GetOffset("DT_CSPlayer", "426");
            public static int _427 = NetVarManager.GetOffset("DT_CSPlayer", "427");
            public static int _428 = NetVarManager.GetOffset("DT_CSPlayer", "428");
            public static int _429 = NetVarManager.GetOffset("DT_CSPlayer", "429");
            public static int _430 = NetVarManager.GetOffset("DT_CSPlayer", "430");
            public static int _431 = NetVarManager.GetOffset("DT_CSPlayer", "431");
            public static int _432 = NetVarManager.GetOffset("DT_CSPlayer", "432");
            public static int _433 = NetVarManager.GetOffset("DT_CSPlayer", "433");
            public static int _434 = NetVarManager.GetOffset("DT_CSPlayer", "434");
            public static int _435 = NetVarManager.GetOffset("DT_CSPlayer", "435");
            public static int _436 = NetVarManager.GetOffset("DT_CSPlayer", "436");
            public static int _437 = NetVarManager.GetOffset("DT_CSPlayer", "437");
            public static int _438 = NetVarManager.GetOffset("DT_CSPlayer", "438");
            public static int _439 = NetVarManager.GetOffset("DT_CSPlayer", "439");
            public static int _440 = NetVarManager.GetOffset("DT_CSPlayer", "440");
            public static int _441 = NetVarManager.GetOffset("DT_CSPlayer", "441");
            public static int _442 = NetVarManager.GetOffset("DT_CSPlayer", "442");
            public static int _443 = NetVarManager.GetOffset("DT_CSPlayer", "443");
            public static int _444 = NetVarManager.GetOffset("DT_CSPlayer", "444");
            public static int _445 = NetVarManager.GetOffset("DT_CSPlayer", "445");
            public static int _446 = NetVarManager.GetOffset("DT_CSPlayer", "446");
            public static int _447 = NetVarManager.GetOffset("DT_CSPlayer", "447");
            public static int _448 = NetVarManager.GetOffset("DT_CSPlayer", "448");
            public static int _449 = NetVarManager.GetOffset("DT_CSPlayer", "449");
            public static int _450 = NetVarManager.GetOffset("DT_CSPlayer", "450");
            public static int _451 = NetVarManager.GetOffset("DT_CSPlayer", "451");
            public static int _452 = NetVarManager.GetOffset("DT_CSPlayer", "452");
            public static int _453 = NetVarManager.GetOffset("DT_CSPlayer", "453");
            public static int _454 = NetVarManager.GetOffset("DT_CSPlayer", "454");
            public static int _455 = NetVarManager.GetOffset("DT_CSPlayer", "455");
            public static int _456 = NetVarManager.GetOffset("DT_CSPlayer", "456");
            public static int _457 = NetVarManager.GetOffset("DT_CSPlayer", "457");
            public static int _458 = NetVarManager.GetOffset("DT_CSPlayer", "458");
            public static int _459 = NetVarManager.GetOffset("DT_CSPlayer", "459");
            public static int _460 = NetVarManager.GetOffset("DT_CSPlayer", "460");
            public static int _461 = NetVarManager.GetOffset("DT_CSPlayer", "461");
            public static int _462 = NetVarManager.GetOffset("DT_CSPlayer", "462");
            public static int _463 = NetVarManager.GetOffset("DT_CSPlayer", "463");
            public static int _464 = NetVarManager.GetOffset("DT_CSPlayer", "464");
            public static int _465 = NetVarManager.GetOffset("DT_CSPlayer", "465");
            public static int _466 = NetVarManager.GetOffset("DT_CSPlayer", "466");
            public static int _467 = NetVarManager.GetOffset("DT_CSPlayer", "467");
            public static int _468 = NetVarManager.GetOffset("DT_CSPlayer", "468");
            public static int _469 = NetVarManager.GetOffset("DT_CSPlayer", "469");
            public static int _470 = NetVarManager.GetOffset("DT_CSPlayer", "470");
            public static int _471 = NetVarManager.GetOffset("DT_CSPlayer", "471");
            public static int _472 = NetVarManager.GetOffset("DT_CSPlayer", "472");
            public static int _473 = NetVarManager.GetOffset("DT_CSPlayer", "473");
            public static int _474 = NetVarManager.GetOffset("DT_CSPlayer", "474");
            public static int _475 = NetVarManager.GetOffset("DT_CSPlayer", "475");
            public static int _476 = NetVarManager.GetOffset("DT_CSPlayer", "476");
            public static int _477 = NetVarManager.GetOffset("DT_CSPlayer", "477");
            public static int _478 = NetVarManager.GetOffset("DT_CSPlayer", "478");
            public static int _479 = NetVarManager.GetOffset("DT_CSPlayer", "479");
            public static int _480 = NetVarManager.GetOffset("DT_CSPlayer", "480");
            public static int _481 = NetVarManager.GetOffset("DT_CSPlayer", "481");
            public static int _482 = NetVarManager.GetOffset("DT_CSPlayer", "482");
            public static int _483 = NetVarManager.GetOffset("DT_CSPlayer", "483");
            public static int _484 = NetVarManager.GetOffset("DT_CSPlayer", "484");
            public static int _485 = NetVarManager.GetOffset("DT_CSPlayer", "485");
            public static int _486 = NetVarManager.GetOffset("DT_CSPlayer", "486");
            public static int _487 = NetVarManager.GetOffset("DT_CSPlayer", "487");
            public static int _488 = NetVarManager.GetOffset("DT_CSPlayer", "488");
            public static int _489 = NetVarManager.GetOffset("DT_CSPlayer", "489");
            public static int _490 = NetVarManager.GetOffset("DT_CSPlayer", "490");
            public static int _491 = NetVarManager.GetOffset("DT_CSPlayer", "491");
            public static int _492 = NetVarManager.GetOffset("DT_CSPlayer", "492");
            public static int _493 = NetVarManager.GetOffset("DT_CSPlayer", "493");
            public static int _494 = NetVarManager.GetOffset("DT_CSPlayer", "494");
            public static int _495 = NetVarManager.GetOffset("DT_CSPlayer", "495");
            public static int _496 = NetVarManager.GetOffset("DT_CSPlayer", "496");
            public static int _497 = NetVarManager.GetOffset("DT_CSPlayer", "497");
            public static int _498 = NetVarManager.GetOffset("DT_CSPlayer", "498");

            public static int m_EquippedLoadoutItemDefIndices =
                NetVarManager.GetOffset("DT_CSPlayer", "m_EquippedLoadoutItemDefIndices");

            public static int m_angEyeAngles_0 = NetVarManager.GetOffset("DT_CSPlayer", "m_angEyeAngles[0]");
            public static int m_angEyeAngles_1 = NetVarManager.GetOffset("DT_CSPlayer", "m_angEyeAngles[1]");
            public static int m_iAddonBits = NetVarManager.GetOffset("DT_CSPlayer", "m_iAddonBits");
            public static int m_iPrimaryAddon = NetVarManager.GetOffset("DT_CSPlayer", "m_iPrimaryAddon");
            public static int m_iSecondaryAddon = NetVarManager.GetOffset("DT_CSPlayer", "m_iSecondaryAddon");
            public static int m_iThrowGrenadeCounter = NetVarManager.GetOffset("DT_CSPlayer", "m_iThrowGrenadeCounter");
            public static int m_bWaitForNoAttack = NetVarManager.GetOffset("DT_CSPlayer", "m_bWaitForNoAttack");

            public static int m_bIsRespawningForDMBonus =
                NetVarManager.GetOffset("DT_CSPlayer", "m_bIsRespawningForDMBonus");

            public static int m_iPlayerState = NetVarManager.GetOffset("DT_CSPlayer", "m_iPlayerState");
            public static int m_iAccount = NetVarManager.GetOffset("DT_CSPlayer", "m_iAccount");
            public static int m_iStartAccount = NetVarManager.GetOffset("DT_CSPlayer", "m_iStartAccount");
            public static int m_totalHitsOnServer = NetVarManager.GetOffset("DT_CSPlayer", "m_totalHitsOnServer");
            public static int m_bInBombZone = NetVarManager.GetOffset("DT_CSPlayer", "m_bInBombZone");
            public static int m_bInBuyZone = NetVarManager.GetOffset("DT_CSPlayer", "m_bInBuyZone");
            public static int m_bInNoDefuseArea = NetVarManager.GetOffset("DT_CSPlayer", "m_bInNoDefuseArea");
            public static int m_bKilledByTaser = NetVarManager.GetOffset("DT_CSPlayer", "m_bKilledByTaser");
            public static int m_iMoveState = NetVarManager.GetOffset("DT_CSPlayer", "m_iMoveState");
            public static int m_iClass = NetVarManager.GetOffset("DT_CSPlayer", "m_iClass");
            public static int m_ArmorValue = NetVarManager.GetOffset("DT_CSPlayer", "m_ArmorValue");
            public static int m_angEyeAngles = NetVarManager.GetOffset("DT_CSPlayer", "m_angEyeAngles");
            public static int m_bHasDefuser = NetVarManager.GetOffset("DT_CSPlayer", "m_bHasDefuser");
            public static int m_bNightVisionOn = NetVarManager.GetOffset("DT_CSPlayer", "m_bNightVisionOn");
            public static int m_bHasNightVision = NetVarManager.GetOffset("DT_CSPlayer", "m_bHasNightVision");
            public static int m_bInHostageRescueZone = NetVarManager.GetOffset("DT_CSPlayer", "m_bInHostageRescueZone");
            public static int m_bIsDefusing = NetVarManager.GetOffset("DT_CSPlayer", "m_bIsDefusing");
            public static int m_bIsGrabbingHostage = NetVarManager.GetOffset("DT_CSPlayer", "m_bIsGrabbingHostage");

            public static int m_iBlockingUseActionInProgress =
                NetVarManager.GetOffset("DT_CSPlayer", "m_iBlockingUseActionInProgress");

            public static int m_bIsScoped = NetVarManager.GetOffset("DT_CSPlayer", "m_bIsScoped");
            public static int m_bIsWalking = NetVarManager.GetOffset("DT_CSPlayer", "m_bIsWalking");
            public static int m_nIsAutoMounting = NetVarManager.GetOffset("DT_CSPlayer", "m_nIsAutoMounting");
            public static int m_bResumeZoom = NetVarManager.GetOffset("DT_CSPlayer", "m_bResumeZoom");

            public static int m_fImmuneToGunGameDamageTime =
                NetVarManager.GetOffset("DT_CSPlayer", "m_fImmuneToGunGameDamageTime");

            public static int m_bGunGameImmunity = NetVarManager.GetOffset("DT_CSPlayer", "m_bGunGameImmunity");
            public static int m_bHasMovedSinceSpawn = NetVarManager.GetOffset("DT_CSPlayer", "m_bHasMovedSinceSpawn");

            public static int m_bMadeFinalGunGameProgressiveKill =
                NetVarManager.GetOffset("DT_CSPlayer", "m_bMadeFinalGunGameProgressiveKill");

            public static int m_iGunGameProgressiveWeaponIndex =
                NetVarManager.GetOffset("DT_CSPlayer", "m_iGunGameProgressiveWeaponIndex");

            public static int m_iNumGunGameTRKillPoints =
                NetVarManager.GetOffset("DT_CSPlayer", "m_iNumGunGameTRKillPoints");

            public static int m_iNumGunGameKillsWithCurrentWeapon =
                NetVarManager.GetOffset("DT_CSPlayer", "m_iNumGunGameKillsWithCurrentWeapon");

            public static int m_iNumRoundKills = NetVarManager.GetOffset("DT_CSPlayer", "m_iNumRoundKills");
            public static int m_fMolotovUseTime = NetVarManager.GetOffset("DT_CSPlayer", "m_fMolotovUseTime");
            public static int m_fMolotovDamageTime = NetVarManager.GetOffset("DT_CSPlayer", "m_fMolotovDamageTime");
            public static int m_szArmsModel = NetVarManager.GetOffset("DT_CSPlayer", "m_szArmsModel");
            public static int m_hCarriedHostage = NetVarManager.GetOffset("DT_CSPlayer", "m_hCarriedHostage");
            public static int m_hCarriedHostageProp = NetVarManager.GetOffset("DT_CSPlayer", "m_hCarriedHostageProp");
            public static int m_bIsRescuing = NetVarManager.GetOffset("DT_CSPlayer", "m_bIsRescuing");

            public static int m_flGroundAccelLinearFracLastTime =
                NetVarManager.GetOffset("DT_CSPlayer", "m_flGroundAccelLinearFracLastTime");

            public static int m_bCanMoveDuringFreezePeriod =
                NetVarManager.GetOffset("DT_CSPlayer", "m_bCanMoveDuringFreezePeriod");

            public static int m_isCurrentGunGameLeader =
                NetVarManager.GetOffset("DT_CSPlayer", "m_isCurrentGunGameLeader");

            public static int m_isCurrentGunGameTeamLeader =
                NetVarManager.GetOffset("DT_CSPlayer", "m_isCurrentGunGameTeamLeader");

            public static int m_flGuardianTooFarDistFrac =
                NetVarManager.GetOffset("DT_CSPlayer", "m_flGuardianTooFarDistFrac");

            public static int m_flDetectedByEnemySensorTime =
                NetVarManager.GetOffset("DT_CSPlayer", "m_flDetectedByEnemySensorTime");

            public static int m_bIsPlayerGhost = NetVarManager.GetOffset("DT_CSPlayer", "m_bIsPlayerGhost");
            public static int m_iMatchStats_Kills = NetVarManager.GetOffset("DT_CSPlayer", "m_iMatchStats_Kills");
            public static int m_iMatchStats_Damage = NetVarManager.GetOffset("DT_CSPlayer", "m_iMatchStats_Damage");

            public static int m_iMatchStats_EquipmentValue =
                NetVarManager.GetOffset("DT_CSPlayer", "m_iMatchStats_EquipmentValue");

            public static int m_iMatchStats_MoneySaved =
                NetVarManager.GetOffset("DT_CSPlayer", "m_iMatchStats_MoneySaved");

            public static int m_iMatchStats_KillReward =
                NetVarManager.GetOffset("DT_CSPlayer", "m_iMatchStats_KillReward");

            public static int m_iMatchStats_LiveTime = NetVarManager.GetOffset("DT_CSPlayer", "m_iMatchStats_LiveTime");
            public static int m_iMatchStats_Deaths = NetVarManager.GetOffset("DT_CSPlayer", "m_iMatchStats_Deaths");
            public static int m_iMatchStats_Assists = NetVarManager.GetOffset("DT_CSPlayer", "m_iMatchStats_Assists");

            public static int m_iMatchStats_HeadShotKills =
                NetVarManager.GetOffset("DT_CSPlayer", "m_iMatchStats_HeadShotKills");

            public static int m_iMatchStats_Objective =
                NetVarManager.GetOffset("DT_CSPlayer", "m_iMatchStats_Objective");

            public static int m_iMatchStats_CashEarned =
                NetVarManager.GetOffset("DT_CSPlayer", "m_iMatchStats_CashEarned");

            public static int m_iMatchStats_UtilityDamage =
                NetVarManager.GetOffset("DT_CSPlayer", "m_iMatchStats_UtilityDamage");

            public static int m_iMatchStats_EnemiesFlashed =
                NetVarManager.GetOffset("DT_CSPlayer", "m_iMatchStats_EnemiesFlashed");

            public static int m_rank = NetVarManager.GetOffset("DT_CSPlayer", "m_rank");
            public static int m_passiveItems = NetVarManager.GetOffset("DT_CSPlayer", "m_passiveItems");
            public static int m_bHasParachute = NetVarManager.GetOffset("DT_CSPlayer", "m_bHasParachute");
            public static int m_unMusicID = NetVarManager.GetOffset("DT_CSPlayer", "m_unMusicID");
            public static int m_bHasHelmet = NetVarManager.GetOffset("DT_CSPlayer", "m_bHasHelmet");
            public static int m_bHasHeavyArmor = NetVarManager.GetOffset("DT_CSPlayer", "m_bHasHeavyArmor");

            public static int m_nHeavyAssaultSuitCooldownRemaining =
                NetVarManager.GetOffset("DT_CSPlayer", "m_nHeavyAssaultSuitCooldownRemaining");

            public static int m_flFlashDuration = NetVarManager.GetOffset("DT_CSPlayer", "m_flFlashDuration");
            public static int m_flFlashMaxAlpha = NetVarManager.GetOffset("DT_CSPlayer", "m_flFlashMaxAlpha");
            public static int m_iProgressBarDuration = NetVarManager.GetOffset("DT_CSPlayer", "m_iProgressBarDuration");

            public static int m_flProgressBarStartTime =
                NetVarManager.GetOffset("DT_CSPlayer", "m_flProgressBarStartTime");

            public static int m_hRagdoll = NetVarManager.GetOffset("DT_CSPlayer", "m_hRagdoll");
            public static int m_hPlayerPing = NetVarManager.GetOffset("DT_CSPlayer", "m_hPlayerPing");
            public static int m_cycleLatch = NetVarManager.GetOffset("DT_CSPlayer", "m_cycleLatch");

            public static int m_unCurrentEquipmentValue =
                NetVarManager.GetOffset("DT_CSPlayer", "m_unCurrentEquipmentValue");

            public static int m_unRoundStartEquipmentValue =
                NetVarManager.GetOffset("DT_CSPlayer", "m_unRoundStartEquipmentValue");

            public static int m_unFreezetimeEndEquipmentValue =
                NetVarManager.GetOffset("DT_CSPlayer", "m_unFreezetimeEndEquipmentValue");

            public static int m_bIsControllingBot = NetVarManager.GetOffset("DT_CSPlayer", "m_bIsControllingBot");

            public static int m_bHasControlledBotThisRound =
                NetVarManager.GetOffset("DT_CSPlayer", "m_bHasControlledBotThisRound");

            public static int m_bCanControlObservedBot =
                NetVarManager.GetOffset("DT_CSPlayer", "m_bCanControlObservedBot");

            public static int m_iControlledBotEntIndex =
                NetVarManager.GetOffset("DT_CSPlayer", "m_iControlledBotEntIndex");

            public static int m_vecAutomoveTargetEnd = NetVarManager.GetOffset("DT_CSPlayer", "m_vecAutomoveTargetEnd");
            public static int m_flAutoMoveStartTime = NetVarManager.GetOffset("DT_CSPlayer", "m_flAutoMoveStartTime");
            public static int m_flAutoMoveTargetTime = NetVarManager.GetOffset("DT_CSPlayer", "m_flAutoMoveTargetTime");

            public static int m_bIsAssassinationTarget =
                NetVarManager.GetOffset("DT_CSPlayer", "m_bIsAssassinationTarget");

            public static int m_bHud_MiniScoreHidden = NetVarManager.GetOffset("DT_CSPlayer", "m_bHud_MiniScoreHidden");
            public static int m_bHud_RadarHidden = NetVarManager.GetOffset("DT_CSPlayer", "m_bHud_RadarHidden");
            public static int m_nLastKillerIndex = NetVarManager.GetOffset("DT_CSPlayer", "m_nLastKillerIndex");

            public static int m_nLastConcurrentKilled =
                NetVarManager.GetOffset("DT_CSPlayer", "m_nLastConcurrentKilled");

            public static int m_nDeathCamMusic = NetVarManager.GetOffset("DT_CSPlayer", "m_nDeathCamMusic");

            public static int m_bIsHoldingLookAtWeapon =
                NetVarManager.GetOffset("DT_CSPlayer", "m_bIsHoldingLookAtWeapon");

            public static int m_bIsLookingAtWeapon = NetVarManager.GetOffset("DT_CSPlayer", "m_bIsLookingAtWeapon");

            public static int m_iNumRoundKillsHeadshots =
                NetVarManager.GetOffset("DT_CSPlayer", "m_iNumRoundKillsHeadshots");

            public static int m_unTotalRoundDamageDealt =
                NetVarManager.GetOffset("DT_CSPlayer", "m_unTotalRoundDamageDealt");

            public static int m_flLowerBodyYawTarget = NetVarManager.GetOffset("DT_CSPlayer", "m_flLowerBodyYawTarget");
            public static int m_bStrafing = NetVarManager.GetOffset("DT_CSPlayer", "m_bStrafing");
            public static int m_flThirdpersonRecoil = NetVarManager.GetOffset("DT_CSPlayer", "m_flThirdpersonRecoil");
            public static int m_bHideTargetID = NetVarManager.GetOffset("DT_CSPlayer", "m_bHideTargetID");
            public static int m_bIsSpawnRappelling = NetVarManager.GetOffset("DT_CSPlayer", "m_bIsSpawnRappelling");

            public static int m_vecSpawnRappellingRopeOrigin =
                NetVarManager.GetOffset("DT_CSPlayer", "m_vecSpawnRappellingRopeOrigin");

            public static int m_nSurvivalTeam = NetVarManager.GetOffset("DT_CSPlayer", "m_nSurvivalTeam");

            public static int m_hSurvivalAssassinationTarget =
                NetVarManager.GetOffset("DT_CSPlayer", "m_hSurvivalAssassinationTarget");

            public static int m_flHealthShotBoostExpirationTime =
                NetVarManager.GetOffset("DT_CSPlayer", "m_flHealthShotBoostExpirationTime");

            public static int m_flLastExoJumpTime = NetVarManager.GetOffset("DT_CSPlayer", "m_flLastExoJumpTime");

            public static int m_vecPlayerPatchEconIndices =
                NetVarManager.GetOffset("DT_CSPlayer", "m_vecPlayerPatchEconIndices");
        }

        public static class DT_PlayerPing
        {
            public static int m_hPlayer = NetVarManager.GetOffset("DT_PlayerPing", "m_hPlayer");
            public static int m_hPingedEntity = NetVarManager.GetOffset("DT_PlayerPing", "m_hPingedEntity");
            public static int m_iType = NetVarManager.GetOffset("DT_PlayerPing", "m_iType");
        }

        public static class DT_CSRagdoll
        {
            public static int m_vecOrigin = NetVarManager.GetOffset("DT_CSRagdoll", "m_vecOrigin");
            public static int m_vecRagdollOrigin = NetVarManager.GetOffset("DT_CSRagdoll", "m_vecRagdollOrigin");
            public static int m_hPlayer = NetVarManager.GetOffset("DT_CSRagdoll", "m_hPlayer");
            public static int m_nModelIndex = NetVarManager.GetOffset("DT_CSRagdoll", "m_nModelIndex");
            public static int m_nForceBone = NetVarManager.GetOffset("DT_CSRagdoll", "m_nForceBone");
            public static int m_vecForce = NetVarManager.GetOffset("DT_CSRagdoll", "m_vecForce");
            public static int m_vecRagdollVelocity = NetVarManager.GetOffset("DT_CSRagdoll", "m_vecRagdollVelocity");
            public static int m_iDeathPose = NetVarManager.GetOffset("DT_CSRagdoll", "m_iDeathPose");
            public static int m_iDeathFrame = NetVarManager.GetOffset("DT_CSRagdoll", "m_iDeathFrame");
            public static int m_iTeamNum = NetVarManager.GetOffset("DT_CSRagdoll", "m_iTeamNum");

            public static int m_bClientSideAnimation =
                NetVarManager.GetOffset("DT_CSRagdoll", "m_bClientSideAnimation");

            public static int m_flDeathYaw = NetVarManager.GetOffset("DT_CSRagdoll", "m_flDeathYaw");
            public static int m_flAbsYaw = NetVarManager.GetOffset("DT_CSRagdoll", "m_flAbsYaw");
        }

        public static class DT_TEPlayerAnimEvent
        {
            public static int m_hPlayer = NetVarManager.GetOffset("DT_TEPlayerAnimEvent", "m_hPlayer");
            public static int m_iEvent = NetVarManager.GetOffset("DT_TEPlayerAnimEvent", "m_iEvent");
            public static int m_nData = NetVarManager.GetOffset("DT_TEPlayerAnimEvent", "m_nData");
        }

        public static class DT_CHostage
        {
            public static int m_isRescued = NetVarManager.GetOffset("DT_CHostage", "m_isRescued");
            public static int m_jumpedThisFrame = NetVarManager.GetOffset("DT_CHostage", "m_jumpedThisFrame");
            public static int m_iHealth = NetVarManager.GetOffset("DT_CHostage", "m_iHealth");
            public static int m_iMaxHealth = NetVarManager.GetOffset("DT_CHostage", "m_iMaxHealth");
            public static int m_lifeState = NetVarManager.GetOffset("DT_CHostage", "m_lifeState");
            public static int m_fFlags = NetVarManager.GetOffset("DT_CHostage", "m_fFlags");
            public static int m_nHostageState = NetVarManager.GetOffset("DT_CHostage", "m_nHostageState");
            public static int m_flRescueStartTime = NetVarManager.GetOffset("DT_CHostage", "m_flRescueStartTime");
            public static int m_flGrabSuccessTime = NetVarManager.GetOffset("DT_CHostage", "m_flGrabSuccessTime");
            public static int m_flDropStartTime = NetVarManager.GetOffset("DT_CHostage", "m_flDropStartTime");
            public static int m_vel = NetVarManager.GetOffset("DT_CHostage", "m_vel");
            public static int m_leader = NetVarManager.GetOffset("DT_CHostage", "m_leader");
        }

        public static class DT_BaseCSGrenadeProjectile
        {
            public static int m_vInitialVelocity =
                NetVarManager.GetOffset("DT_BaseCSGrenadeProjectile", "m_vInitialVelocity");

            public static int m_nBounces = NetVarManager.GetOffset("DT_BaseCSGrenadeProjectile", "m_nBounces");

            public static int m_nExplodeEffectIndex =
                NetVarManager.GetOffset("DT_BaseCSGrenadeProjectile", "m_nExplodeEffectIndex");

            public static int m_nExplodeEffectTickBegin =
                NetVarManager.GetOffset("DT_BaseCSGrenadeProjectile", "m_nExplodeEffectTickBegin");

            public static int m_vecExplodeEffectOrigin =
                NetVarManager.GetOffset("DT_BaseCSGrenadeProjectile", "m_vecExplodeEffectOrigin");
        }

        public static class DT_HandleTest
        {
            public static int m_Handle = NetVarManager.GetOffset("DT_HandleTest", "m_Handle");
            public static int m_bSendHandle = NetVarManager.GetOffset("DT_HandleTest", "m_bSendHandle");
        }

        public static class DT_TeamplayRoundBasedRulesProxy
        {
            public static int teamplayroundbased_gamerules_data =
                NetVarManager.GetOffset("DT_TeamplayRoundBasedRulesProxy", "teamplayroundbased_gamerules_data");

            public static int m_iRoundState =
                NetVarManager.GetOffset("DT_TeamplayRoundBasedRulesProxy", "m_iRoundState");

            public static int m_bInWaitingForPlayers =
                NetVarManager.GetOffset("DT_TeamplayRoundBasedRulesProxy", "m_bInWaitingForPlayers");

            public static int m_iWinningTeam =
                NetVarManager.GetOffset("DT_TeamplayRoundBasedRulesProxy", "m_iWinningTeam");

            public static int m_bInOvertime =
                NetVarManager.GetOffset("DT_TeamplayRoundBasedRulesProxy", "m_bInOvertime");

            public static int m_bInSetup = NetVarManager.GetOffset("DT_TeamplayRoundBasedRulesProxy", "m_bInSetup");

            public static int m_bSwitchedTeamsThisRound =
                NetVarManager.GetOffset("DT_TeamplayRoundBasedRulesProxy", "m_bSwitchedTeamsThisRound");

            public static int m_bAwaitingReadyRestart =
                NetVarManager.GetOffset("DT_TeamplayRoundBasedRulesProxy", "m_bAwaitingReadyRestart");

            public static int m_flRestartRoundTime =
                NetVarManager.GetOffset("DT_TeamplayRoundBasedRulesProxy", "m_flRestartRoundTime");

            public static int m_flMapResetTime =
                NetVarManager.GetOffset("DT_TeamplayRoundBasedRulesProxy", "m_flMapResetTime");

            public static int m_flNextRespawnWave =
                NetVarManager.GetOffset("DT_TeamplayRoundBasedRulesProxy", "m_flNextRespawnWave");

            public static int m_TeamRespawnWaveTimes =
                NetVarManager.GetOffset("DT_TeamplayRoundBasedRulesProxy", "m_TeamRespawnWaveTimes");

            public static int m_bTeamReady = NetVarManager.GetOffset("DT_TeamplayRoundBasedRulesProxy", "m_bTeamReady");
            public static int m_bStopWatch = NetVarManager.GetOffset("DT_TeamplayRoundBasedRulesProxy", "m_bStopWatch");
        }

        public static class DT_SpriteTrail
        {
            public static int m_flLifeTime = NetVarManager.GetOffset("DT_SpriteTrail", "m_flLifeTime");
            public static int m_flStartWidth = NetVarManager.GetOffset("DT_SpriteTrail", "m_flStartWidth");
            public static int m_flEndWidth = NetVarManager.GetOffset("DT_SpriteTrail", "m_flEndWidth");

            public static int m_flStartWidthVariance =
                NetVarManager.GetOffset("DT_SpriteTrail", "m_flStartWidthVariance");

            public static int m_flTextureRes = NetVarManager.GetOffset("DT_SpriteTrail", "m_flTextureRes");
            public static int m_flMinFadeLength = NetVarManager.GetOffset("DT_SpriteTrail", "m_flMinFadeLength");
            public static int m_vecSkyboxOrigin = NetVarManager.GetOffset("DT_SpriteTrail", "m_vecSkyboxOrigin");
            public static int m_flSkyboxScale = NetVarManager.GetOffset("DT_SpriteTrail", "m_flSkyboxScale");
        }

        public static class DT_Sprite
        {
            public static int m_hAttachedToEntity = NetVarManager.GetOffset("DT_Sprite", "m_hAttachedToEntity");
            public static int m_nAttachment = NetVarManager.GetOffset("DT_Sprite", "m_nAttachment");
            public static int m_flScaleTime = NetVarManager.GetOffset("DT_Sprite", "m_flScaleTime");
            public static int m_flSpriteScale = NetVarManager.GetOffset("DT_Sprite", "m_flSpriteScale");
            public static int m_flSpriteFramerate = NetVarManager.GetOffset("DT_Sprite", "m_flSpriteFramerate");
            public static int m_flGlowProxySize = NetVarManager.GetOffset("DT_Sprite", "m_flGlowProxySize");
            public static int m_flHDRColorScale = NetVarManager.GetOffset("DT_Sprite", "m_flHDRColorScale");
            public static int m_flFrame = NetVarManager.GetOffset("DT_Sprite", "m_flFrame");
            public static int m_flBrightnessTime = NetVarManager.GetOffset("DT_Sprite", "m_flBrightnessTime");
            public static int m_nBrightness = NetVarManager.GetOffset("DT_Sprite", "m_nBrightness");
            public static int m_bWorldSpaceScale = NetVarManager.GetOffset("DT_Sprite", "m_bWorldSpaceScale");
        }

        public static class DT_Ragdoll_Attached
        {
            public static int m_boneIndexAttached =
                NetVarManager.GetOffset("DT_Ragdoll_Attached", "m_boneIndexAttached");

            public static int m_ragdollAttachedObjectIndex =
                NetVarManager.GetOffset("DT_Ragdoll_Attached", "m_ragdollAttachedObjectIndex");

            public static int m_attachmentPointBoneSpace =
                NetVarManager.GetOffset("DT_Ragdoll_Attached", "m_attachmentPointBoneSpace");

            public static int m_attachmentPointRagdollSpace =
                NetVarManager.GetOffset("DT_Ragdoll_Attached", "m_attachmentPointRagdollSpace");
        }

        public static class DT_Ragdoll
        {
            public static int m_ragAngles_0 = NetVarManager.GetOffset("DT_Ragdoll", "m_ragAngles[0]");
            public static int m_ragAngles = NetVarManager.GetOffset("DT_Ragdoll", "m_ragAngles");
            public static int m_ragPos_0 = NetVarManager.GetOffset("DT_Ragdoll", "m_ragPos[0]");
            public static int m_ragPos = NetVarManager.GetOffset("DT_Ragdoll", "m_ragPos");
            public static int m_hUnragdoll = NetVarManager.GetOffset("DT_Ragdoll", "m_hUnragdoll");
            public static int m_flBlendWeight = NetVarManager.GetOffset("DT_Ragdoll", "m_flBlendWeight");
            public static int m_nOverlaySequence = NetVarManager.GetOffset("DT_Ragdoll", "m_nOverlaySequence");
        }

        public static class DT_PropCounter
        {
            public static int m_flDisplayValue = NetVarManager.GetOffset("DT_PropCounter", "m_flDisplayValue");
        }

        public static class DT_PoseController
        {
            public static int m_hProps = NetVarManager.GetOffset("DT_PoseController", "m_hProps");
            public static int m_chPoseIndex = NetVarManager.GetOffset("DT_PoseController", "m_chPoseIndex");
            public static int m_bPoseValueParity = NetVarManager.GetOffset("DT_PoseController", "m_bPoseValueParity");
            public static int m_fPoseValue = NetVarManager.GetOffset("DT_PoseController", "m_fPoseValue");

            public static int m_fInterpolationTime =
                NetVarManager.GetOffset("DT_PoseController", "m_fInterpolationTime");

            public static int m_bInterpolationWrap =
                NetVarManager.GetOffset("DT_PoseController", "m_bInterpolationWrap");

            public static int m_fCycleFrequency = NetVarManager.GetOffset("DT_PoseController", "m_fCycleFrequency");
            public static int m_nFModType = NetVarManager.GetOffset("DT_PoseController", "m_nFModType");
            public static int m_fFModTimeOffset = NetVarManager.GetOffset("DT_PoseController", "m_fFModTimeOffset");
            public static int m_fFModRate = NetVarManager.GetOffset("DT_PoseController", "m_fFModRate");
            public static int m_fFModAmplitude = NetVarManager.GetOffset("DT_PoseController", "m_fFModAmplitude");
        }

        public static class DT_GrassBurn
        {
            public static int m_flGrassBurnClearTime =
                NetVarManager.GetOffset("DT_GrassBurn", "m_flGrassBurnClearTime");
        }

        public static class DT_FuncLadder
        {
            public static int m_vecPlayerMountPositionTop =
                NetVarManager.GetOffset("DT_FuncLadder", "m_vecPlayerMountPositionTop");

            public static int m_vecPlayerMountPositionBottom =
                NetVarManager.GetOffset("DT_FuncLadder", "m_vecPlayerMountPositionBottom");

            public static int m_vecLadderDir = NetVarManager.GetOffset("DT_FuncLadder", "m_vecLadderDir");
            public static int m_bFakeLadder = NetVarManager.GetOffset("DT_FuncLadder", "m_bFakeLadder");
        }

        public static class DT_TEFoundryHelpers
        {
            public static int m_iEntity = NetVarManager.GetOffset("DT_TEFoundryHelpers", "m_iEntity");
        }

        public static class DT_DetailController
        {
            public static int m_flFadeStartDist = NetVarManager.GetOffset("DT_DetailController", "m_flFadeStartDist");
            public static int m_flFadeEndDist = NetVarManager.GetOffset("DT_DetailController", "m_flFadeEndDist");
        }

        public static class DT_DangerZone
        {
            public static int m_vecDangerZoneOriginStartedAt =
                NetVarManager.GetOffset("DT_DangerZone", "m_vecDangerZoneOriginStartedAt");

            public static int m_flBombLaunchTime = NetVarManager.GetOffset("DT_DangerZone", "m_flBombLaunchTime");
            public static int m_flExtraRadius = NetVarManager.GetOffset("DT_DangerZone", "m_flExtraRadius");

            public static int m_flExtraRadiusStartTime =
                NetVarManager.GetOffset("DT_DangerZone", "m_flExtraRadiusStartTime");

            public static int m_flExtraRadiusTotalLerpTime =
                NetVarManager.GetOffset("DT_DangerZone", "m_flExtraRadiusTotalLerpTime");

            public static int m_nDropOrder = NetVarManager.GetOffset("DT_DangerZone", "m_nDropOrder");
            public static int m_iWave = NetVarManager.GetOffset("DT_DangerZone", "m_iWave");
        }

        public static class DT_DangerZoneController
        {
            public static int m_bDangerZoneControllerEnabled =
                NetVarManager.GetOffset("DT_DangerZoneController", "m_bDangerZoneControllerEnabled");

            public static int m_bMissionControlledExplosions =
                NetVarManager.GetOffset("DT_DangerZoneController", "m_bMissionControlledExplosions");

            public static int m_flStartTime = NetVarManager.GetOffset("DT_DangerZoneController", "m_flStartTime");

            public static int m_flFinalExpansionTime =
                NetVarManager.GetOffset("DT_DangerZoneController", "m_flFinalExpansionTime");

            public static int m_vecEndGameCircleStart =
                NetVarManager.GetOffset("DT_DangerZoneController", "m_vecEndGameCircleStart");

            public static int m_vecEndGameCircleEnd =
                NetVarManager.GetOffset("DT_DangerZoneController", "m_vecEndGameCircleEnd");

            public static int m_DangerZones = NetVarManager.GetOffset("DT_DangerZoneController", "m_DangerZones");
            public static int m_flWaveEndTimes = NetVarManager.GetOffset("DT_DangerZoneController", "m_flWaveEndTimes");
            public static int m_hTheFinalZone = NetVarManager.GetOffset("DT_DangerZoneController", "m_hTheFinalZone");
        }

        public static class DT_WorldVguiText
        {
            public static int m_bEnabled = NetVarManager.GetOffset("DT_WorldVguiText", "m_bEnabled");
            public static int m_szDisplayText = NetVarManager.GetOffset("DT_WorldVguiText", "m_szDisplayText");

            public static int m_szDisplayTextOption =
                NetVarManager.GetOffset("DT_WorldVguiText", "m_szDisplayTextOption");

            public static int m_szFont = NetVarManager.GetOffset("DT_WorldVguiText", "m_szFont");
            public static int m_iTextPanelWidth = NetVarManager.GetOffset("DT_WorldVguiText", "m_iTextPanelWidth");
            public static int m_clrText = NetVarManager.GetOffset("DT_WorldVguiText", "m_clrText");
        }

        public static class DT_World
        {
            public static int m_flWaveHeight = NetVarManager.GetOffset("DT_World", "m_flWaveHeight");
            public static int m_WorldMins = NetVarManager.GetOffset("DT_World", "m_WorldMins");
            public static int m_WorldMaxs = NetVarManager.GetOffset("DT_World", "m_WorldMaxs");
            public static int m_bStartDark = NetVarManager.GetOffset("DT_World", "m_bStartDark");
            public static int m_flMaxOccludeeArea = NetVarManager.GetOffset("DT_World", "m_flMaxOccludeeArea");
            public static int m_flMinOccluderArea = NetVarManager.GetOffset("DT_World", "m_flMinOccluderArea");

            public static int m_flMaxPropScreenSpaceWidth =
                NetVarManager.GetOffset("DT_World", "m_flMaxPropScreenSpaceWidth");

            public static int m_flMinPropScreenSpaceWidth =
                NetVarManager.GetOffset("DT_World", "m_flMinPropScreenSpaceWidth");

            public static int m_iszDetailSpriteMaterial =
                NetVarManager.GetOffset("DT_World", "m_iszDetailSpriteMaterial");

            public static int m_bColdWorld = NetVarManager.GetOffset("DT_World", "m_bColdWorld");
            public static int m_iTimeOfDay = NetVarManager.GetOffset("DT_World", "m_iTimeOfDay");
        }

        public static class DT_WaterLODControl
        {
            public static int m_flCheapWaterStartDistance =
                NetVarManager.GetOffset("DT_WaterLODControl", "m_flCheapWaterStartDistance");

            public static int m_flCheapWaterEndDistance =
                NetVarManager.GetOffset("DT_WaterLODControl", "m_flCheapWaterEndDistance");
        }

        public static class DT_VoteController
        {
            public static int m_iActiveIssueIndex = NetVarManager.GetOffset("DT_VoteController", "m_iActiveIssueIndex");
            public static int m_iOnlyTeamToVote = NetVarManager.GetOffset("DT_VoteController", "m_iOnlyTeamToVote");
            public static int m_nVoteOptionCount = NetVarManager.GetOffset("DT_VoteController", "m_nVoteOptionCount");
            public static int m_nPotentialVotes = NetVarManager.GetOffset("DT_VoteController", "m_nPotentialVotes");
            public static int m_bIsYesNoVote = NetVarManager.GetOffset("DT_VoteController", "m_bIsYesNoVote");
        }

        public static class DT_VGuiScreen
        {
            public static int m_flWidth = NetVarManager.GetOffset("DT_VGuiScreen", "m_flWidth");
            public static int m_flHeight = NetVarManager.GetOffset("DT_VGuiScreen", "m_flHeight");
            public static int m_fScreenFlags = NetVarManager.GetOffset("DT_VGuiScreen", "m_fScreenFlags");
            public static int m_nPanelName = NetVarManager.GetOffset("DT_VGuiScreen", "m_nPanelName");
            public static int m_nAttachmentIndex = NetVarManager.GetOffset("DT_VGuiScreen", "m_nAttachmentIndex");
            public static int m_nOverlayMaterial = NetVarManager.GetOffset("DT_VGuiScreen", "m_nOverlayMaterial");
            public static int m_hPlayerOwner = NetVarManager.GetOffset("DT_VGuiScreen", "m_hPlayerOwner");
        }

        public static class DT_PropJeep
        {
            public static int m_bHeadlightIsOn = NetVarManager.GetOffset("DT_PropJeep", "m_bHeadlightIsOn");
        }

        public static class DT_PropVehicleChoreoGeneric
        {
            public static int m_hPlayer = NetVarManager.GetOffset("DT_PropVehicleChoreoGeneric", "m_hPlayer");
            public static int m_bEnterAnimOn = NetVarManager.GetOffset("DT_PropVehicleChoreoGeneric", "m_bEnterAnimOn");
            public static int m_bExitAnimOn = NetVarManager.GetOffset("DT_PropVehicleChoreoGeneric", "m_bExitAnimOn");

            public static int m_bForceEyesToAttachment =
                NetVarManager.GetOffset("DT_PropVehicleChoreoGeneric", "m_bForceEyesToAttachment");

            public static int m_vecEyeExitEndpoint =
                NetVarManager.GetOffset("DT_PropVehicleChoreoGeneric", "m_vecEyeExitEndpoint");

            public static int m_vehicleView_bClampEyeAngles =
                NetVarManager.GetOffset("DT_PropVehicleChoreoGeneric", "m_vehicleView.bClampEyeAngles");

            public static int m_vehicleView_flPitchCurveZero =
                NetVarManager.GetOffset("DT_PropVehicleChoreoGeneric", "m_vehicleView.flPitchCurveZero");

            public static int m_vehicleView_flPitchCurveLinear =
                NetVarManager.GetOffset("DT_PropVehicleChoreoGeneric", "m_vehicleView.flPitchCurveLinear");

            public static int m_vehicleView_flRollCurveZero =
                NetVarManager.GetOffset("DT_PropVehicleChoreoGeneric", "m_vehicleView.flRollCurveZero");

            public static int m_vehicleView_flRollCurveLinear =
                NetVarManager.GetOffset("DT_PropVehicleChoreoGeneric", "m_vehicleView.flRollCurveLinear");

            public static int m_vehicleView_flFOV =
                NetVarManager.GetOffset("DT_PropVehicleChoreoGeneric", "m_vehicleView.flFOV");

            public static int m_vehicleView_flYawMin =
                NetVarManager.GetOffset("DT_PropVehicleChoreoGeneric", "m_vehicleView.flYawMin");

            public static int m_vehicleView_flYawMax =
                NetVarManager.GetOffset("DT_PropVehicleChoreoGeneric", "m_vehicleView.flYawMax");

            public static int m_vehicleView_flPitchMin =
                NetVarManager.GetOffset("DT_PropVehicleChoreoGeneric", "m_vehicleView.flPitchMin");

            public static int m_vehicleView_flPitchMax =
                NetVarManager.GetOffset("DT_PropVehicleChoreoGeneric", "m_vehicleView.flPitchMax");
        }

        public static class DT_TriggerSoundOperator
        {
            public static int m_nSoundOperator = NetVarManager.GetOffset("DT_TriggerSoundOperator", "m_nSoundOperator");
        }

        public static class DT_BaseTrigger
        {
            public static int m_bClientSidePredicted =
                NetVarManager.GetOffset("DT_BaseTrigger", "m_bClientSidePredicted");

            public static int m_spawnflags = NetVarManager.GetOffset("DT_BaseTrigger", "m_spawnflags");
        }

        public static class DT_ProxyToggle
        {
            public static int blah = NetVarManager.GetOffset("DT_ProxyToggle", "blah");
            public static int m_WithProxy = NetVarManager.GetOffset("DT_ProxyToggle", "m_WithProxy");
        }

        public static class DT_Tesla
        {
            public static int m_SoundName = NetVarManager.GetOffset("DT_Tesla", "m_SoundName");
            public static int m_iszSpriteName = NetVarManager.GetOffset("DT_Tesla", "m_iszSpriteName");
        }

        public static class DT_BaseTeamObjectiveResource
        {
            public static int m_iTimerToShowInHUD =
                NetVarManager.GetOffset("DT_BaseTeamObjectiveResource", "m_iTimerToShowInHUD");

            public static int m_iStopWatchTimer =
                NetVarManager.GetOffset("DT_BaseTeamObjectiveResource", "m_iStopWatchTimer");

            public static int m_iNumControlPoints =
                NetVarManager.GetOffset("DT_BaseTeamObjectiveResource", "m_iNumControlPoints");

            public static int m_bPlayingMiniRounds =
                NetVarManager.GetOffset("DT_BaseTeamObjectiveResource", "m_bPlayingMiniRounds");

            public static int m_bControlPointsReset =
                NetVarManager.GetOffset("DT_BaseTeamObjectiveResource", "m_bControlPointsReset");

            public static int m_iUpdateCapHudParity =
                NetVarManager.GetOffset("DT_BaseTeamObjectiveResource", "m_iUpdateCapHudParity");

            public static int m_vCPPositions_0 =
                NetVarManager.GetOffset("DT_BaseTeamObjectiveResource", "m_vCPPositions[0]");

            public static int m_vCPPositions =
                NetVarManager.GetOffset("DT_BaseTeamObjectiveResource", "m_vCPPositions");

            public static int m_bCPIsVisible =
                NetVarManager.GetOffset("DT_BaseTeamObjectiveResource", "m_bCPIsVisible");

            public static int m_flLazyCapPerc =
                NetVarManager.GetOffset("DT_BaseTeamObjectiveResource", "m_flLazyCapPerc");

            public static int m_iTeamIcons = NetVarManager.GetOffset("DT_BaseTeamObjectiveResource", "m_iTeamIcons");

            public static int m_iTeamOverlays =
                NetVarManager.GetOffset("DT_BaseTeamObjectiveResource", "m_iTeamOverlays");

            public static int m_iTeamReqCappers =
                NetVarManager.GetOffset("DT_BaseTeamObjectiveResource", "m_iTeamReqCappers");

            public static int m_flTeamCapTime =
                NetVarManager.GetOffset("DT_BaseTeamObjectiveResource", "m_flTeamCapTime");

            public static int m_iPreviousPoints =
                NetVarManager.GetOffset("DT_BaseTeamObjectiveResource", "m_iPreviousPoints");

            public static int m_bTeamCanCap = NetVarManager.GetOffset("DT_BaseTeamObjectiveResource", "m_bTeamCanCap");

            public static int m_iTeamBaseIcons =
                NetVarManager.GetOffset("DT_BaseTeamObjectiveResource", "m_iTeamBaseIcons");

            public static int m_iBaseControlPoints =
                NetVarManager.GetOffset("DT_BaseTeamObjectiveResource", "m_iBaseControlPoints");

            public static int m_bInMiniRound =
                NetVarManager.GetOffset("DT_BaseTeamObjectiveResource", "m_bInMiniRound");

            public static int m_iWarnOnCap = NetVarManager.GetOffset("DT_BaseTeamObjectiveResource", "m_iWarnOnCap");

            public static int m_iszWarnSound_0 =
                NetVarManager.GetOffset("DT_BaseTeamObjectiveResource", "m_iszWarnSound[0]");

            public static int m_iszWarnSound =
                NetVarManager.GetOffset("DT_BaseTeamObjectiveResource", "m_iszWarnSound");

            public static int m_flPathDistance =
                NetVarManager.GetOffset("DT_BaseTeamObjectiveResource", "m_flPathDistance");

            public static int m_iNumTeamMembers =
                NetVarManager.GetOffset("DT_BaseTeamObjectiveResource", "m_iNumTeamMembers");

            public static int m_iCappingTeam =
                NetVarManager.GetOffset("DT_BaseTeamObjectiveResource", "m_iCappingTeam");

            public static int m_iTeamInZone = NetVarManager.GetOffset("DT_BaseTeamObjectiveResource", "m_iTeamInZone");
            public static int m_bBlocked = NetVarManager.GetOffset("DT_BaseTeamObjectiveResource", "m_bBlocked");
            public static int m_iOwner = NetVarManager.GetOffset("DT_BaseTeamObjectiveResource", "m_iOwner");

            public static int m_pszCapLayoutInHUD =
                NetVarManager.GetOffset("DT_BaseTeamObjectiveResource", "m_pszCapLayoutInHUD");
        }

        public static class DT_Team
        {
            public static int m_iTeamNum = NetVarManager.GetOffset("DT_Team", "m_iTeamNum");
            public static int m_bSurrendered = NetVarManager.GetOffset("DT_Team", "m_bSurrendered");
            public static int m_scoreTotal = NetVarManager.GetOffset("DT_Team", "m_scoreTotal");
            public static int m_scoreFirstHalf = NetVarManager.GetOffset("DT_Team", "m_scoreFirstHalf");
            public static int m_scoreSecondHalf = NetVarManager.GetOffset("DT_Team", "m_scoreSecondHalf");
            public static int m_scoreOvertime = NetVarManager.GetOffset("DT_Team", "m_scoreOvertime");
            public static int m_iClanID = NetVarManager.GetOffset("DT_Team", "m_iClanID");
            public static int m_szTeamname = NetVarManager.GetOffset("DT_Team", "m_szTeamname");
            public static int m_szClanTeamname = NetVarManager.GetOffset("DT_Team", "m_szClanTeamname");
            public static int m_szTeamFlagImage = NetVarManager.GetOffset("DT_Team", "m_szTeamFlagImage");
            public static int m_szTeamLogoImage = NetVarManager.GetOffset("DT_Team", "m_szTeamLogoImage");
            public static int m_szTeamMatchStat = NetVarManager.GetOffset("DT_Team", "m_szTeamMatchStat");
            public static int m_nGGLeaderEntIndex_CT = NetVarManager.GetOffset("DT_Team", "m_nGGLeaderEntIndex_CT");
            public static int m_nGGLeaderEntIndex_T = NetVarManager.GetOffset("DT_Team", "m_nGGLeaderEntIndex_T");
            public static int m_numMapVictories = NetVarManager.GetOffset("DT_Team", "m_numMapVictories");
            public static int player_array_element = NetVarManager.GetOffset("DT_Team", "player_array_element");
            public static int player_array = NetVarManager.GetOffset("DT_Team", "player_array");
        }

        public static class DT_SunlightShadowControl
        {
            public static int m_shadowDirection =
                NetVarManager.GetOffset("DT_SunlightShadowControl", "m_shadowDirection");

            public static int m_bEnabled = NetVarManager.GetOffset("DT_SunlightShadowControl", "m_bEnabled");
            public static int m_TextureName = NetVarManager.GetOffset("DT_SunlightShadowControl", "m_TextureName");
            public static int m_LightColor = NetVarManager.GetOffset("DT_SunlightShadowControl", "m_LightColor");

            public static int m_flColorTransitionTime =
                NetVarManager.GetOffset("DT_SunlightShadowControl", "m_flColorTransitionTime");

            public static int m_flSunDistance = NetVarManager.GetOffset("DT_SunlightShadowControl", "m_flSunDistance");
            public static int m_flFOV = NetVarManager.GetOffset("DT_SunlightShadowControl", "m_flFOV");
            public static int m_flNearZ = NetVarManager.GetOffset("DT_SunlightShadowControl", "m_flNearZ");
            public static int m_flNorthOffset = NetVarManager.GetOffset("DT_SunlightShadowControl", "m_flNorthOffset");

            public static int m_bEnableShadows =
                NetVarManager.GetOffset("DT_SunlightShadowControl", "m_bEnableShadows");
        }

        public static class DT_Sun
        {
            public static int m_clrRender = NetVarManager.GetOffset("DT_Sun", "m_clrRender");
            public static int m_clrOverlay = NetVarManager.GetOffset("DT_Sun", "m_clrOverlay");
            public static int m_vDirection = NetVarManager.GetOffset("DT_Sun", "m_vDirection");
            public static int m_bOn = NetVarManager.GetOffset("DT_Sun", "m_bOn");
            public static int m_nSize = NetVarManager.GetOffset("DT_Sun", "m_nSize");
            public static int m_nOverlaySize = NetVarManager.GetOffset("DT_Sun", "m_nOverlaySize");
            public static int m_nMaterial = NetVarManager.GetOffset("DT_Sun", "m_nMaterial");
            public static int m_nOverlayMaterial = NetVarManager.GetOffset("DT_Sun", "m_nOverlayMaterial");
            public static int HDRColorScale = NetVarManager.GetOffset("DT_Sun", "HDRColorScale");
            public static int glowDistanceScale = NetVarManager.GetOffset("DT_Sun", "glowDistanceScale");
        }

        public static class DT_ParticlePerformanceMonitor
        {
            public static int m_bMeasurePerf =
                NetVarManager.GetOffset("DT_ParticlePerformanceMonitor", "m_bMeasurePerf");

            public static int m_bDisplayPerf =
                NetVarManager.GetOffset("DT_ParticlePerformanceMonitor", "m_bDisplayPerf");
        }

        public static class DT_SpotlightEnd
        {
            public static int m_flLightScale = NetVarManager.GetOffset("DT_SpotlightEnd", "m_flLightScale");
            public static int m_Radius = NetVarManager.GetOffset("DT_SpotlightEnd", "m_Radius");
        }

        public static class DT_SpatialEntity
        {
            public static int m_vecOrigin = NetVarManager.GetOffset("DT_SpatialEntity", "m_vecOrigin");
            public static int m_minFalloff = NetVarManager.GetOffset("DT_SpatialEntity", "m_minFalloff");
            public static int m_maxFalloff = NetVarManager.GetOffset("DT_SpatialEntity", "m_maxFalloff");
            public static int m_flCurWeight = NetVarManager.GetOffset("DT_SpatialEntity", "m_flCurWeight");
            public static int m_bEnabled = NetVarManager.GetOffset("DT_SpatialEntity", "m_bEnabled");
        }

        public static class DT_SlideshowDisplay
        {
            public static int m_bEnabled = NetVarManager.GetOffset("DT_SlideshowDisplay", "m_bEnabled");
            public static int m_szDisplayText = NetVarManager.GetOffset("DT_SlideshowDisplay", "m_szDisplayText");

            public static int m_szSlideshowDirectory =
                NetVarManager.GetOffset("DT_SlideshowDisplay", "m_szSlideshowDirectory");

            public static int m_chCurrentSlideLists =
                NetVarManager.GetOffset("DT_SlideshowDisplay", "m_chCurrentSlideLists");

            public static int m_fMinSlideTime = NetVarManager.GetOffset("DT_SlideshowDisplay", "m_fMinSlideTime");
            public static int m_fMaxSlideTime = NetVarManager.GetOffset("DT_SlideshowDisplay", "m_fMaxSlideTime");
            public static int m_iCycleType = NetVarManager.GetOffset("DT_SlideshowDisplay", "m_iCycleType");
            public static int m_bNoListRepeats = NetVarManager.GetOffset("DT_SlideshowDisplay", "m_bNoListRepeats");
        }

        public static class DT_ShadowControl
        {
            public static int m_shadowDirection = NetVarManager.GetOffset("DT_ShadowControl", "m_shadowDirection");
            public static int m_shadowColor = NetVarManager.GetOffset("DT_ShadowControl", "m_shadowColor");
            public static int m_flShadowMaxDist = NetVarManager.GetOffset("DT_ShadowControl", "m_flShadowMaxDist");
            public static int m_bDisableShadows = NetVarManager.GetOffset("DT_ShadowControl", "m_bDisableShadows");

            public static int m_bEnableLocalLightShadows =
                NetVarManager.GetOffset("DT_ShadowControl", "m_bEnableLocalLightShadows");
        }

        public static class DT_SceneEntity
        {
            public static int m_nSceneStringIndex = NetVarManager.GetOffset("DT_SceneEntity", "m_nSceneStringIndex");
            public static int m_bIsPlayingBack = NetVarManager.GetOffset("DT_SceneEntity", "m_bIsPlayingBack");
            public static int m_bPaused = NetVarManager.GetOffset("DT_SceneEntity", "m_bPaused");
            public static int m_bMultiplayer = NetVarManager.GetOffset("DT_SceneEntity", "m_bMultiplayer");
            public static int m_flForceClientTime = NetVarManager.GetOffset("DT_SceneEntity", "m_flForceClientTime");
            public static int m_hActorList = NetVarManager.GetOffset("DT_SceneEntity", "m_hActorList");
            public static int lengthproxy = NetVarManager.GetOffset("DT_SceneEntity", "lengthproxy");
            public static int lengthprop16 = NetVarManager.GetOffset("DT_SceneEntity", "lengthprop16");
        }

        public static class DT_RopeKeyframe
        {
            public static int m_nChangeCount = NetVarManager.GetOffset("DT_RopeKeyframe", "m_nChangeCount");

            public static int m_iRopeMaterialModelIndex =
                NetVarManager.GetOffset("DT_RopeKeyframe", "m_iRopeMaterialModelIndex");

            public static int m_hStartPoint = NetVarManager.GetOffset("DT_RopeKeyframe", "m_hStartPoint");
            public static int m_hEndPoint = NetVarManager.GetOffset("DT_RopeKeyframe", "m_hEndPoint");
            public static int m_iStartAttachment = NetVarManager.GetOffset("DT_RopeKeyframe", "m_iStartAttachment");
            public static int m_iEndAttachment = NetVarManager.GetOffset("DT_RopeKeyframe", "m_iEndAttachment");
            public static int m_fLockedPoints = NetVarManager.GetOffset("DT_RopeKeyframe", "m_fLockedPoints");
            public static int m_Slack = NetVarManager.GetOffset("DT_RopeKeyframe", "m_Slack");
            public static int m_RopeLength = NetVarManager.GetOffset("DT_RopeKeyframe", "m_RopeLength");
            public static int m_RopeFlags = NetVarManager.GetOffset("DT_RopeKeyframe", "m_RopeFlags");
            public static int m_TextureScale = NetVarManager.GetOffset("DT_RopeKeyframe", "m_TextureScale");
            public static int m_nSegments = NetVarManager.GetOffset("DT_RopeKeyframe", "m_nSegments");

            public static int m_bConstrainBetweenEndpoints =
                NetVarManager.GetOffset("DT_RopeKeyframe", "m_bConstrainBetweenEndpoints");

            public static int m_Subdiv = NetVarManager.GetOffset("DT_RopeKeyframe", "m_Subdiv");
            public static int m_Width = NetVarManager.GetOffset("DT_RopeKeyframe", "m_Width");
            public static int m_flScrollSpeed = NetVarManager.GetOffset("DT_RopeKeyframe", "m_flScrollSpeed");
            public static int m_vecOrigin = NetVarManager.GetOffset("DT_RopeKeyframe", "m_vecOrigin");
            public static int moveparent = NetVarManager.GetOffset("DT_RopeKeyframe", "moveparent");
            public static int m_iParentAttachment = NetVarManager.GetOffset("DT_RopeKeyframe", "m_iParentAttachment");

            public static int m_iDefaultRopeMaterialModelIndex =
                NetVarManager.GetOffset("DT_RopeKeyframe", "m_iDefaultRopeMaterialModelIndex");

            public static int m_nMinCPULevel = NetVarManager.GetOffset("DT_RopeKeyframe", "m_nMinCPULevel");
            public static int m_nMaxCPULevel = NetVarManager.GetOffset("DT_RopeKeyframe", "m_nMaxCPULevel");
            public static int m_nMinGPULevel = NetVarManager.GetOffset("DT_RopeKeyframe", "m_nMinGPULevel");
            public static int m_nMaxGPULevel = NetVarManager.GetOffset("DT_RopeKeyframe", "m_nMaxGPULevel");
        }

        public static class DT_RagdollManager
        {
            public static int m_iCurrentMaxRagdollCount =
                NetVarManager.GetOffset("DT_RagdollManager", "m_iCurrentMaxRagdollCount");
        }

        public static class DT_PhysicsPropMultiplayer
        {
            public static int m_iPhysicsMode = NetVarManager.GetOffset("DT_PhysicsPropMultiplayer", "m_iPhysicsMode");
            public static int m_fMass = NetVarManager.GetOffset("DT_PhysicsPropMultiplayer", "m_fMass");
            public static int m_collisionMins = NetVarManager.GetOffset("DT_PhysicsPropMultiplayer", "m_collisionMins");
            public static int m_collisionMaxs = NetVarManager.GetOffset("DT_PhysicsPropMultiplayer", "m_collisionMaxs");
        }

        public static class DT_PhysBoxMultiplayer
        {
            public static int m_iPhysicsMode = NetVarManager.GetOffset("DT_PhysBoxMultiplayer", "m_iPhysicsMode");
            public static int m_fMass = NetVarManager.GetOffset("DT_PhysBoxMultiplayer", "m_fMass");
        }

        public static class DT_DynamicProp
        {
            public static int m_bUseHitboxesForRenderBox =
                NetVarManager.GetOffset("DT_DynamicProp", "m_bUseHitboxesForRenderBox");

            public static int m_flGlowMaxDist = NetVarManager.GetOffset("DT_DynamicProp", "m_flGlowMaxDist");
            public static int m_bShouldGlow = NetVarManager.GetOffset("DT_DynamicProp", "m_bShouldGlow");
            public static int m_clrGlow = NetVarManager.GetOffset("DT_DynamicProp", "m_clrGlow");
            public static int m_nGlowStyle = NetVarManager.GetOffset("DT_DynamicProp", "m_nGlowStyle");
        }

        public static class DT_Prop_Hallucination
        {
            public static int m_bEnabled = NetVarManager.GetOffset("DT_Prop_Hallucination", "m_bEnabled");
            public static int m_fVisibleTime = NetVarManager.GetOffset("DT_Prop_Hallucination", "m_fVisibleTime");
            public static int m_fRechargeTime = NetVarManager.GetOffset("DT_Prop_Hallucination", "m_fRechargeTime");
        }

        public static class DT_PostProcessController
        {
            public static int m_flPostProcessParameters =
                NetVarManager.GetOffset("DT_PostProcessController", "m_flPostProcessParameters");

            public static int m_bMaster = NetVarManager.GetOffset("DT_PostProcessController", "m_bMaster");
        }

        public static class DT_PointWorldText
        {
            public static int m_szText = NetVarManager.GetOffset("DT_PointWorldText", "m_szText");
            public static int m_flTextSize = NetVarManager.GetOffset("DT_PointWorldText", "m_flTextSize");
            public static int m_textColor = NetVarManager.GetOffset("DT_PointWorldText", "m_textColor");
        }

        public static class DT_PointCommentaryNode
        {
            public static int m_bActive = NetVarManager.GetOffset("DT_PointCommentaryNode", "m_bActive");
            public static int m_flStartTime = NetVarManager.GetOffset("DT_PointCommentaryNode", "m_flStartTime");

            public static int m_iszCommentaryFile =
                NetVarManager.GetOffset("DT_PointCommentaryNode", "m_iszCommentaryFile");

            public static int m_iszCommentaryFileNoHDR =
                NetVarManager.GetOffset("DT_PointCommentaryNode", "m_iszCommentaryFileNoHDR");

            public static int m_iszSpeakers = NetVarManager.GetOffset("DT_PointCommentaryNode", "m_iszSpeakers");
            public static int m_iNodeNumber = NetVarManager.GetOffset("DT_PointCommentaryNode", "m_iNodeNumber");
            public static int m_iNodeNumberMax = NetVarManager.GetOffset("DT_PointCommentaryNode", "m_iNodeNumberMax");
            public static int m_hViewPosition = NetVarManager.GetOffset("DT_PointCommentaryNode", "m_hViewPosition");
        }

        public static class DT_PointCamera
        {
            public static int m_FOV = NetVarManager.GetOffset("DT_PointCamera", "m_FOV");
            public static int m_Resolution = NetVarManager.GetOffset("DT_PointCamera", "m_Resolution");
            public static int m_bFogEnable = NetVarManager.GetOffset("DT_PointCamera", "m_bFogEnable");
            public static int m_FogColor = NetVarManager.GetOffset("DT_PointCamera", "m_FogColor");
            public static int m_flFogStart = NetVarManager.GetOffset("DT_PointCamera", "m_flFogStart");
            public static int m_flFogEnd = NetVarManager.GetOffset("DT_PointCamera", "m_flFogEnd");
            public static int m_flFogMaxDensity = NetVarManager.GetOffset("DT_PointCamera", "m_flFogMaxDensity");
            public static int m_bActive = NetVarManager.GetOffset("DT_PointCamera", "m_bActive");

            public static int m_bUseScreenAspectRatio =
                NetVarManager.GetOffset("DT_PointCamera", "m_bUseScreenAspectRatio");
        }

        public static class DT_PlayerResource
        {
            public static int m_iPing = NetVarManager.GetOffset("DT_PlayerResource", "m_iPing");
            public static int m_iKills = NetVarManager.GetOffset("DT_PlayerResource", "m_iKills");
            public static int m_iAssists = NetVarManager.GetOffset("DT_PlayerResource", "m_iAssists");
            public static int m_iDeaths = NetVarManager.GetOffset("DT_PlayerResource", "m_iDeaths");
            public static int m_bConnected = NetVarManager.GetOffset("DT_PlayerResource", "m_bConnected");
            public static int m_iTeam = NetVarManager.GetOffset("DT_PlayerResource", "m_iTeam");
            public static int m_iPendingTeam = NetVarManager.GetOffset("DT_PlayerResource", "m_iPendingTeam");
            public static int m_bAlive = NetVarManager.GetOffset("DT_PlayerResource", "m_bAlive");
            public static int m_iHealth = NetVarManager.GetOffset("DT_PlayerResource", "m_iHealth");
            public static int m_iCoachingTeam = NetVarManager.GetOffset("DT_PlayerResource", "m_iCoachingTeam");
        }

        public static class DT_Plasma
        {
            public static int m_flStartScale = NetVarManager.GetOffset("DT_Plasma", "m_flStartScale");
            public static int m_flScale = NetVarManager.GetOffset("DT_Plasma", "m_flScale");
            public static int m_flScaleTime = NetVarManager.GetOffset("DT_Plasma", "m_flScaleTime");
            public static int m_nFlags = NetVarManager.GetOffset("DT_Plasma", "m_nFlags");
            public static int m_nPlasmaModelIndex = NetVarManager.GetOffset("DT_Plasma", "m_nPlasmaModelIndex");
            public static int m_nPlasmaModelIndex2 = NetVarManager.GetOffset("DT_Plasma", "m_nPlasmaModelIndex2");
            public static int m_nGlowModelIndex = NetVarManager.GetOffset("DT_Plasma", "m_nGlowModelIndex");
        }

        public static class DT_PhysicsProp
        {
            public static int m_bAwake = NetVarManager.GetOffset("DT_PhysicsProp", "m_bAwake");
            public static int m_spawnflags = NetVarManager.GetOffset("DT_PhysicsProp", "m_spawnflags");
        }

        public static class DT_StatueProp
        {
            public static int m_hInitBaseAnimating = NetVarManager.GetOffset("DT_StatueProp", "m_hInitBaseAnimating");
            public static int m_bShatter = NetVarManager.GetOffset("DT_StatueProp", "m_bShatter");
            public static int m_nShatterFlags = NetVarManager.GetOffset("DT_StatueProp", "m_nShatterFlags");
            public static int m_vShatterPosition = NetVarManager.GetOffset("DT_StatueProp", "m_vShatterPosition");
            public static int m_vShatterForce = NetVarManager.GetOffset("DT_StatueProp", "m_vShatterForce");
        }

        public static class DT_PhysBox
        {
            public static int m_mass = NetVarManager.GetOffset("DT_PhysBox", "m_mass");
        }

        public static class DT_ParticleSystem
        {
            public static int m_vecOrigin = NetVarManager.GetOffset("DT_ParticleSystem", "m_vecOrigin");
            public static int m_fEffects = NetVarManager.GetOffset("DT_ParticleSystem", "m_fEffects");
            public static int m_hOwnerEntity = NetVarManager.GetOffset("DT_ParticleSystem", "m_hOwnerEntity");
            public static int moveparent = NetVarManager.GetOffset("DT_ParticleSystem", "moveparent");
            public static int m_iParentAttachment = NetVarManager.GetOffset("DT_ParticleSystem", "m_iParentAttachment");
            public static int m_angRotation = NetVarManager.GetOffset("DT_ParticleSystem", "m_angRotation");
            public static int m_iEffectIndex = NetVarManager.GetOffset("DT_ParticleSystem", "m_iEffectIndex");
            public static int m_bActive = NetVarManager.GetOffset("DT_ParticleSystem", "m_bActive");
            public static int m_nStopType = NetVarManager.GetOffset("DT_ParticleSystem", "m_nStopType");
            public static int m_flStartTime = NetVarManager.GetOffset("DT_ParticleSystem", "m_flStartTime");

            public static int m_szSnapshotFileName =
                NetVarManager.GetOffset("DT_ParticleSystem", "m_szSnapshotFileName");

            public static int m_vServerControlPoints =
                NetVarManager.GetOffset("DT_ParticleSystem", "m_vServerControlPoints");

            public static int m_iServerControlPointAssignments =
                NetVarManager.GetOffset("DT_ParticleSystem", "m_iServerControlPointAssignments");

            public static int m_hControlPointEnts = NetVarManager.GetOffset("DT_ParticleSystem", "m_hControlPointEnts");

            public static int m_iControlPointParents =
                NetVarManager.GetOffset("DT_ParticleSystem", "m_iControlPointParents");
        }

        public static class DT_MovieDisplay
        {
            public static int m_bEnabled = NetVarManager.GetOffset("DT_MovieDisplay", "m_bEnabled");
            public static int m_bLooping = NetVarManager.GetOffset("DT_MovieDisplay", "m_bLooping");
            public static int m_szMovieFilename = NetVarManager.GetOffset("DT_MovieDisplay", "m_szMovieFilename");
            public static int m_szGroupName = NetVarManager.GetOffset("DT_MovieDisplay", "m_szGroupName");
            public static int m_bStretchToFill = NetVarManager.GetOffset("DT_MovieDisplay", "m_bStretchToFill");
            public static int m_bForcedSlave = NetVarManager.GetOffset("DT_MovieDisplay", "m_bForcedSlave");
            public static int m_bUseCustomUVs = NetVarManager.GetOffset("DT_MovieDisplay", "m_bUseCustomUVs");
            public static int m_flUMin = NetVarManager.GetOffset("DT_MovieDisplay", "m_flUMin");
            public static int m_flUMax = NetVarManager.GetOffset("DT_MovieDisplay", "m_flUMax");
            public static int m_flVMin = NetVarManager.GetOffset("DT_MovieDisplay", "m_flVMin");
            public static int m_flVMax = NetVarManager.GetOffset("DT_MovieDisplay", "m_flVMax");
        }

        public static class DT_MaterialModifyControl
        {
            public static int m_szMaterialName =
                NetVarManager.GetOffset("DT_MaterialModifyControl", "m_szMaterialName");

            public static int m_szMaterialVar = NetVarManager.GetOffset("DT_MaterialModifyControl", "m_szMaterialVar");

            public static int m_szMaterialVarValue =
                NetVarManager.GetOffset("DT_MaterialModifyControl", "m_szMaterialVarValue");

            public static int m_iFrameStart = NetVarManager.GetOffset("DT_MaterialModifyControl", "m_iFrameStart");
            public static int m_iFrameEnd = NetVarManager.GetOffset("DT_MaterialModifyControl", "m_iFrameEnd");
            public static int m_bWrap = NetVarManager.GetOffset("DT_MaterialModifyControl", "m_bWrap");
            public static int m_flFramerate = NetVarManager.GetOffset("DT_MaterialModifyControl", "m_flFramerate");

            public static int m_bNewAnimCommandsSemaphore =
                NetVarManager.GetOffset("DT_MaterialModifyControl", "m_bNewAnimCommandsSemaphore");

            public static int m_flFloatLerpStartValue =
                NetVarManager.GetOffset("DT_MaterialModifyControl", "m_flFloatLerpStartValue");

            public static int m_flFloatLerpEndValue =
                NetVarManager.GetOffset("DT_MaterialModifyControl", "m_flFloatLerpEndValue");

            public static int m_flFloatLerpTransitionTime =
                NetVarManager.GetOffset("DT_MaterialModifyControl", "m_flFloatLerpTransitionTime");

            public static int m_bFloatLerpWrap =
                NetVarManager.GetOffset("DT_MaterialModifyControl", "m_bFloatLerpWrap");

            public static int m_nModifyMode = NetVarManager.GetOffset("DT_MaterialModifyControl", "m_nModifyMode");
        }

        public static class DT_LightGlow
        {
            public static int m_clrRender = NetVarManager.GetOffset("DT_LightGlow", "m_clrRender");
            public static int m_nHorizontalSize = NetVarManager.GetOffset("DT_LightGlow", "m_nHorizontalSize");
            public static int m_nVerticalSize = NetVarManager.GetOffset("DT_LightGlow", "m_nVerticalSize");
            public static int m_nMinDist = NetVarManager.GetOffset("DT_LightGlow", "m_nMinDist");
            public static int m_nMaxDist = NetVarManager.GetOffset("DT_LightGlow", "m_nMaxDist");
            public static int m_nOuterMaxDist = NetVarManager.GetOffset("DT_LightGlow", "m_nOuterMaxDist");
            public static int m_spawnflags = NetVarManager.GetOffset("DT_LightGlow", "m_spawnflags");
            public static int m_vecOrigin = NetVarManager.GetOffset("DT_LightGlow", "m_vecOrigin");
            public static int m_angRotation = NetVarManager.GetOffset("DT_LightGlow", "m_angRotation");
            public static int moveparent = NetVarManager.GetOffset("DT_LightGlow", "moveparent");
            public static int m_flGlowProxySize = NetVarManager.GetOffset("DT_LightGlow", "m_flGlowProxySize");
            public static int HDRColorScale = NetVarManager.GetOffset("DT_LightGlow", "HDRColorScale");
        }

        public static class DT_ItemAssaultSuitUseable
        {
            public static int m_nArmorValue = NetVarManager.GetOffset("DT_ItemAssaultSuitUseable", "m_nArmorValue");

            public static int m_bIsHeavyAssaultSuit =
                NetVarManager.GetOffset("DT_ItemAssaultSuitUseable", "m_bIsHeavyAssaultSuit");
        }

        public static class DT_Item
        {
            public static int m_bShouldGlow = NetVarManager.GetOffset("DT_Item", "m_bShouldGlow");
        }

        public static class DT_InfoOverlayAccessor
        {
            public static int m_iTextureFrameIndex =
                NetVarManager.GetOffset("DT_InfoOverlayAccessor", "m_iTextureFrameIndex");

            public static int m_iOverlayID = NetVarManager.GetOffset("DT_InfoOverlayAccessor", "m_iOverlayID");
        }

        public static class DT_FuncSmokeVolume
        {
            public static int m_Color1 = NetVarManager.GetOffset("DT_FuncSmokeVolume", "m_Color1");
            public static int m_Color2 = NetVarManager.GetOffset("DT_FuncSmokeVolume", "m_Color2");
            public static int m_MaterialName = NetVarManager.GetOffset("DT_FuncSmokeVolume", "m_MaterialName");

            public static int m_ParticleDrawWidth =
                NetVarManager.GetOffset("DT_FuncSmokeVolume", "m_ParticleDrawWidth");

            public static int m_ParticleSpacingDistance =
                NetVarManager.GetOffset("DT_FuncSmokeVolume", "m_ParticleSpacingDistance");

            public static int m_DensityRampSpeed = NetVarManager.GetOffset("DT_FuncSmokeVolume", "m_DensityRampSpeed");
            public static int m_RotationSpeed = NetVarManager.GetOffset("DT_FuncSmokeVolume", "m_RotationSpeed");
            public static int m_MovementSpeed = NetVarManager.GetOffset("DT_FuncSmokeVolume", "m_MovementSpeed");
            public static int m_Density = NetVarManager.GetOffset("DT_FuncSmokeVolume", "m_Density");
            public static int m_maxDrawDistance = NetVarManager.GetOffset("DT_FuncSmokeVolume", "m_maxDrawDistance");
            public static int m_spawnflags = NetVarManager.GetOffset("DT_FuncSmokeVolume", "m_spawnflags");
            public static int m_Collision = NetVarManager.GetOffset("DT_FuncSmokeVolume", "m_Collision");
            public static int m_vecMins = NetVarManager.GetOffset("DT_FuncSmokeVolume", "m_vecMins");
            public static int m_vecMaxs = NetVarManager.GetOffset("DT_FuncSmokeVolume", "m_vecMaxs");
            public static int m_nSolidType = NetVarManager.GetOffset("DT_FuncSmokeVolume", "m_nSolidType");
            public static int m_usSolidFlags = NetVarManager.GetOffset("DT_FuncSmokeVolume", "m_usSolidFlags");
            public static int m_nSurroundType = NetVarManager.GetOffset("DT_FuncSmokeVolume", "m_nSurroundType");
            public static int m_triggerBloat = NetVarManager.GetOffset("DT_FuncSmokeVolume", "m_triggerBloat");

            public static int m_vecSpecifiedSurroundingMins =
                NetVarManager.GetOffset("DT_FuncSmokeVolume", "m_vecSpecifiedSurroundingMins");

            public static int m_vecSpecifiedSurroundingMaxs =
                NetVarManager.GetOffset("DT_FuncSmokeVolume", "m_vecSpecifiedSurroundingMaxs");
        }

        public static class DT_FuncRotating
        {
            public static int m_vecOrigin = NetVarManager.GetOffset("DT_FuncRotating", "m_vecOrigin");
            public static int m_angRotation_0 = NetVarManager.GetOffset("DT_FuncRotating", "m_angRotation[0]");
            public static int m_angRotation_1 = NetVarManager.GetOffset("DT_FuncRotating", "m_angRotation[1]");
            public static int m_angRotation_2 = NetVarManager.GetOffset("DT_FuncRotating", "m_angRotation[2]");
            public static int m_flSimulationTime = NetVarManager.GetOffset("DT_FuncRotating", "m_flSimulationTime");
        }

        public static class DT_FuncOccluder
        {
            public static int m_bActive = NetVarManager.GetOffset("DT_FuncOccluder", "m_bActive");
            public static int m_nOccluderIndex = NetVarManager.GetOffset("DT_FuncOccluder", "m_nOccluderIndex");
        }

        public static class DT_FuncMoveLinear
        {
            public static int m_vecVelocity = NetVarManager.GetOffset("DT_FuncMoveLinear", "m_vecVelocity");
            public static int m_fFlags = NetVarManager.GetOffset("DT_FuncMoveLinear", "m_fFlags");
        }

        public static class DT_Func_LOD
        {
            public static int m_nDisappearMinDist = NetVarManager.GetOffset("DT_Func_LOD", "m_nDisappearMinDist");
            public static int m_nDisappearMaxDist = NetVarManager.GetOffset("DT_Func_LOD", "m_nDisappearMaxDist");
        }

        public static class DT_TEDust
        {
            public static int m_flSize = NetVarManager.GetOffset("DT_TEDust", "m_flSize");
            public static int m_flSpeed = NetVarManager.GetOffset("DT_TEDust", "m_flSpeed");
            public static int m_vecDirection = NetVarManager.GetOffset("DT_TEDust", "m_vecDirection");
        }

        public static class DT_Func_Dust
        {
            public static int m_Color = NetVarManager.GetOffset("DT_Func_Dust", "m_Color");
            public static int m_SpawnRate = NetVarManager.GetOffset("DT_Func_Dust", "m_SpawnRate");
            public static int m_flSizeMin = NetVarManager.GetOffset("DT_Func_Dust", "m_flSizeMin");
            public static int m_flSizeMax = NetVarManager.GetOffset("DT_Func_Dust", "m_flSizeMax");
            public static int m_LifetimeMin = NetVarManager.GetOffset("DT_Func_Dust", "m_LifetimeMin");
            public static int m_LifetimeMax = NetVarManager.GetOffset("DT_Func_Dust", "m_LifetimeMax");
            public static int m_DustFlags = NetVarManager.GetOffset("DT_Func_Dust", "m_DustFlags");
            public static int m_SpeedMax = NetVarManager.GetOffset("DT_Func_Dust", "m_SpeedMax");
            public static int m_DistMax = NetVarManager.GetOffset("DT_Func_Dust", "m_DistMax");
            public static int m_nModelIndex = NetVarManager.GetOffset("DT_Func_Dust", "m_nModelIndex");
            public static int m_FallSpeed = NetVarManager.GetOffset("DT_Func_Dust", "m_FallSpeed");
            public static int m_bAffectedByWind = NetVarManager.GetOffset("DT_Func_Dust", "m_bAffectedByWind");
            public static int m_Collision = NetVarManager.GetOffset("DT_Func_Dust", "m_Collision");
            public static int m_vecMins = NetVarManager.GetOffset("DT_Func_Dust", "m_vecMins");
            public static int m_vecMaxs = NetVarManager.GetOffset("DT_Func_Dust", "m_vecMaxs");
            public static int m_nSolidType = NetVarManager.GetOffset("DT_Func_Dust", "m_nSolidType");
            public static int m_usSolidFlags = NetVarManager.GetOffset("DT_Func_Dust", "m_usSolidFlags");
            public static int m_nSurroundType = NetVarManager.GetOffset("DT_Func_Dust", "m_nSurroundType");
            public static int m_triggerBloat = NetVarManager.GetOffset("DT_Func_Dust", "m_triggerBloat");

            public static int m_vecSpecifiedSurroundingMins =
                NetVarManager.GetOffset("DT_Func_Dust", "m_vecSpecifiedSurroundingMins");

            public static int m_vecSpecifiedSurroundingMaxs =
                NetVarManager.GetOffset("DT_Func_Dust", "m_vecSpecifiedSurroundingMaxs");
        }

        public static class DT_FuncConveyor
        {
            public static int m_flConveyorSpeed = NetVarManager.GetOffset("DT_FuncConveyor", "m_flConveyorSpeed");
        }

        public static class DT_BreakableSurface
        {
            public static int m_nNumWide = NetVarManager.GetOffset("DT_BreakableSurface", "m_nNumWide");
            public static int m_nNumHigh = NetVarManager.GetOffset("DT_BreakableSurface", "m_nNumHigh");
            public static int m_flPanelWidth = NetVarManager.GetOffset("DT_BreakableSurface", "m_flPanelWidth");
            public static int m_flPanelHeight = NetVarManager.GetOffset("DT_BreakableSurface", "m_flPanelHeight");
            public static int m_vNormal = NetVarManager.GetOffset("DT_BreakableSurface", "m_vNormal");
            public static int m_vCorner = NetVarManager.GetOffset("DT_BreakableSurface", "m_vCorner");
            public static int m_bIsBroken = NetVarManager.GetOffset("DT_BreakableSurface", "m_bIsBroken");
            public static int m_nSurfaceType = NetVarManager.GetOffset("DT_BreakableSurface", "m_nSurfaceType");
            public static int m_RawPanelBitVec = NetVarManager.GetOffset("DT_BreakableSurface", "m_RawPanelBitVec");
        }

        public static class DT_FuncAreaPortalWindow
        {
            public static int m_flFadeStartDist =
                NetVarManager.GetOffset("DT_FuncAreaPortalWindow", "m_flFadeStartDist");

            public static int m_flFadeDist = NetVarManager.GetOffset("DT_FuncAreaPortalWindow", "m_flFadeDist");

            public static int m_flTranslucencyLimit =
                NetVarManager.GetOffset("DT_FuncAreaPortalWindow", "m_flTranslucencyLimit");

            public static int m_iBackgroundModelIndex =
                NetVarManager.GetOffset("DT_FuncAreaPortalWindow", "m_iBackgroundModelIndex");
        }

        public static class DT_CFish
        {
            public static int m_poolOrigin = NetVarManager.GetOffset("DT_CFish", "m_poolOrigin");
            public static int m_x = NetVarManager.GetOffset("DT_CFish", "m_x");
            public static int m_y = NetVarManager.GetOffset("DT_CFish", "m_y");
            public static int m_z = NetVarManager.GetOffset("DT_CFish", "m_z");
            public static int m_angle = NetVarManager.GetOffset("DT_CFish", "m_angle");
            public static int m_nModelIndex = NetVarManager.GetOffset("DT_CFish", "m_nModelIndex");
            public static int m_lifeState = NetVarManager.GetOffset("DT_CFish", "m_lifeState");
            public static int m_waterLevel = NetVarManager.GetOffset("DT_CFish", "m_waterLevel");
        }

        public static class DT_FireSmoke
        {
            public static int m_flStartScale = NetVarManager.GetOffset("DT_FireSmoke", "m_flStartScale");
            public static int m_flScale = NetVarManager.GetOffset("DT_FireSmoke", "m_flScale");
            public static int m_flScaleTime = NetVarManager.GetOffset("DT_FireSmoke", "m_flScaleTime");
            public static int m_nFlags = NetVarManager.GetOffset("DT_FireSmoke", "m_nFlags");
            public static int m_nFlameModelIndex = NetVarManager.GetOffset("DT_FireSmoke", "m_nFlameModelIndex");

            public static int m_nFlameFromAboveModelIndex =
                NetVarManager.GetOffset("DT_FireSmoke", "m_nFlameFromAboveModelIndex");
        }

        public static class DT_EnvTonemapController
        {
            public static int m_bUseCustomAutoExposureMin =
                NetVarManager.GetOffset("DT_EnvTonemapController", "m_bUseCustomAutoExposureMin");

            public static int m_bUseCustomAutoExposureMax =
                NetVarManager.GetOffset("DT_EnvTonemapController", "m_bUseCustomAutoExposureMax");

            public static int m_bUseCustomBloomScale =
                NetVarManager.GetOffset("DT_EnvTonemapController", "m_bUseCustomBloomScale");

            public static int m_flCustomAutoExposureMin =
                NetVarManager.GetOffset("DT_EnvTonemapController", "m_flCustomAutoExposureMin");

            public static int m_flCustomAutoExposureMax =
                NetVarManager.GetOffset("DT_EnvTonemapController", "m_flCustomAutoExposureMax");

            public static int m_flCustomBloomScale =
                NetVarManager.GetOffset("DT_EnvTonemapController", "m_flCustomBloomScale");

            public static int m_flCustomBloomScaleMinimum =
                NetVarManager.GetOffset("DT_EnvTonemapController", "m_flCustomBloomScaleMinimum");

            public static int m_flBloomExponent =
                NetVarManager.GetOffset("DT_EnvTonemapController", "m_flBloomExponent");

            public static int m_flBloomSaturation =
                NetVarManager.GetOffset("DT_EnvTonemapController", "m_flBloomSaturation");

            public static int m_flTonemapPercentTarget =
                NetVarManager.GetOffset("DT_EnvTonemapController", "m_flTonemapPercentTarget");

            public static int m_flTonemapPercentBrightPixels =
                NetVarManager.GetOffset("DT_EnvTonemapController", "m_flTonemapPercentBrightPixels");

            public static int m_flTonemapMinAvgLum =
                NetVarManager.GetOffset("DT_EnvTonemapController", "m_flTonemapMinAvgLum");

            public static int m_flTonemapRate = NetVarManager.GetOffset("DT_EnvTonemapController", "m_flTonemapRate");
        }

        public static class DT_EnvScreenEffect
        {
            public static int m_flDuration = NetVarManager.GetOffset("DT_EnvScreenEffect", "m_flDuration");
            public static int m_nType = NetVarManager.GetOffset("DT_EnvScreenEffect", "m_nType");
        }

        public static class DT_EnvScreenOverlay
        {
            public static int m_iszOverlayNames_0 =
                NetVarManager.GetOffset("DT_EnvScreenOverlay", "m_iszOverlayNames[0]");

            public static int m_iszOverlayNames = NetVarManager.GetOffset("DT_EnvScreenOverlay", "m_iszOverlayNames");

            public static int m_flOverlayTimes_0 =
                NetVarManager.GetOffset("DT_EnvScreenOverlay", "m_flOverlayTimes[0]");

            public static int m_flOverlayTimes = NetVarManager.GetOffset("DT_EnvScreenOverlay", "m_flOverlayTimes");
            public static int m_flStartTime = NetVarManager.GetOffset("DT_EnvScreenOverlay", "m_flStartTime");
            public static int m_iDesiredOverlay = NetVarManager.GetOffset("DT_EnvScreenOverlay", "m_iDesiredOverlay");
            public static int m_bIsActive = NetVarManager.GetOffset("DT_EnvScreenOverlay", "m_bIsActive");
        }

        public static class DT_EnvProjectedTexture
        {
            public static int m_hTargetEntity = NetVarManager.GetOffset("DT_EnvProjectedTexture", "m_hTargetEntity");
            public static int m_bState = NetVarManager.GetOffset("DT_EnvProjectedTexture", "m_bState");
            public static int m_bAlwaysUpdate = NetVarManager.GetOffset("DT_EnvProjectedTexture", "m_bAlwaysUpdate");
            public static int m_flLightFOV = NetVarManager.GetOffset("DT_EnvProjectedTexture", "m_flLightFOV");
            public static int m_bEnableShadows = NetVarManager.GetOffset("DT_EnvProjectedTexture", "m_bEnableShadows");

            public static int m_bSimpleProjection =
                NetVarManager.GetOffset("DT_EnvProjectedTexture", "m_bSimpleProjection");

            public static int m_bLightOnlyTarget =
                NetVarManager.GetOffset("DT_EnvProjectedTexture", "m_bLightOnlyTarget");

            public static int m_bLightWorld = NetVarManager.GetOffset("DT_EnvProjectedTexture", "m_bLightWorld");
            public static int m_bCameraSpace = NetVarManager.GetOffset("DT_EnvProjectedTexture", "m_bCameraSpace");

            public static int m_flBrightnessScale =
                NetVarManager.GetOffset("DT_EnvProjectedTexture", "m_flBrightnessScale");

            public static int m_LightColor = NetVarManager.GetOffset("DT_EnvProjectedTexture", "m_LightColor");

            public static int m_flColorTransitionTime =
                NetVarManager.GetOffset("DT_EnvProjectedTexture", "m_flColorTransitionTime");

            public static int m_flAmbient = NetVarManager.GetOffset("DT_EnvProjectedTexture", "m_flAmbient");

            public static int m_SpotlightTextureName =
                NetVarManager.GetOffset("DT_EnvProjectedTexture", "m_SpotlightTextureName");

            public static int m_nSpotlightTextureFrame =
                NetVarManager.GetOffset("DT_EnvProjectedTexture", "m_nSpotlightTextureFrame");

            public static int m_flNearZ = NetVarManager.GetOffset("DT_EnvProjectedTexture", "m_flNearZ");
            public static int m_flFarZ = NetVarManager.GetOffset("DT_EnvProjectedTexture", "m_flFarZ");
            public static int m_nShadowQuality = NetVarManager.GetOffset("DT_EnvProjectedTexture", "m_nShadowQuality");

            public static int m_flProjectionSize =
                NetVarManager.GetOffset("DT_EnvProjectedTexture", "m_flProjectionSize");

            public static int m_flRotation = NetVarManager.GetOffset("DT_EnvProjectedTexture", "m_flRotation");
            public static int m_iStyle = NetVarManager.GetOffset("DT_EnvProjectedTexture", "m_iStyle");
        }

        public static class DT_EnvParticleScript
        {
            public static int m_flSequenceScale = NetVarManager.GetOffset("DT_EnvParticleScript", "m_flSequenceScale");
        }

        public static class DT_FogController
        {
            public static int m_fog_enable = NetVarManager.GetOffset("DT_FogController", "m_fog.enable");
            public static int m_fog_blend = NetVarManager.GetOffset("DT_FogController", "m_fog.blend");
            public static int m_fog_dirPrimary = NetVarManager.GetOffset("DT_FogController", "m_fog.dirPrimary");
            public static int m_fog_colorPrimary = NetVarManager.GetOffset("DT_FogController", "m_fog.colorPrimary");

            public static int m_fog_colorSecondary =
                NetVarManager.GetOffset("DT_FogController", "m_fog.colorSecondary");

            public static int m_fog_start = NetVarManager.GetOffset("DT_FogController", "m_fog.start");
            public static int m_fog_end = NetVarManager.GetOffset("DT_FogController", "m_fog.end");
            public static int m_fog_farz = NetVarManager.GetOffset("DT_FogController", "m_fog.farz");
            public static int m_fog_maxdensity = NetVarManager.GetOffset("DT_FogController", "m_fog.maxdensity");

            public static int m_fog_colorPrimaryLerpTo =
                NetVarManager.GetOffset("DT_FogController", "m_fog.colorPrimaryLerpTo");

            public static int m_fog_colorSecondaryLerpTo =
                NetVarManager.GetOffset("DT_FogController", "m_fog.colorSecondaryLerpTo");

            public static int m_fog_startLerpTo = NetVarManager.GetOffset("DT_FogController", "m_fog.startLerpTo");
            public static int m_fog_endLerpTo = NetVarManager.GetOffset("DT_FogController", "m_fog.endLerpTo");

            public static int m_fog_maxdensityLerpTo =
                NetVarManager.GetOffset("DT_FogController", "m_fog.maxdensityLerpTo");

            public static int m_fog_lerptime = NetVarManager.GetOffset("DT_FogController", "m_fog.lerptime");
            public static int m_fog_duration = NetVarManager.GetOffset("DT_FogController", "m_fog.duration");
            public static int m_fog_HDRColorScale = NetVarManager.GetOffset("DT_FogController", "m_fog.HDRColorScale");
            public static int m_fog_ZoomFogScale = NetVarManager.GetOffset("DT_FogController", "m_fog.ZoomFogScale");
        }

        public static class DT_EnvDOFController
        {
            public static int m_bDOFEnabled = NetVarManager.GetOffset("DT_EnvDOFController", "m_bDOFEnabled");
            public static int m_flNearBlurDepth = NetVarManager.GetOffset("DT_EnvDOFController", "m_flNearBlurDepth");
            public static int m_flNearFocusDepth = NetVarManager.GetOffset("DT_EnvDOFController", "m_flNearFocusDepth");
            public static int m_flFarFocusDepth = NetVarManager.GetOffset("DT_EnvDOFController", "m_flFarFocusDepth");
            public static int m_flFarBlurDepth = NetVarManager.GetOffset("DT_EnvDOFController", "m_flFarBlurDepth");
            public static int m_flNearBlurRadius = NetVarManager.GetOffset("DT_EnvDOFController", "m_flNearBlurRadius");
            public static int m_flFarBlurRadius = NetVarManager.GetOffset("DT_EnvDOFController", "m_flFarBlurRadius");
        }

        public static class DT_CascadeLight
        {
            public static int m_shadowDirection = NetVarManager.GetOffset("DT_CascadeLight", "m_shadowDirection");

            public static int m_envLightShadowDirection =
                NetVarManager.GetOffset("DT_CascadeLight", "m_envLightShadowDirection");

            public static int m_bEnabled = NetVarManager.GetOffset("DT_CascadeLight", "m_bEnabled");
            public static int m_bUseLightEnvAngles = NetVarManager.GetOffset("DT_CascadeLight", "m_bUseLightEnvAngles");
            public static int m_LightColor = NetVarManager.GetOffset("DT_CascadeLight", "m_LightColor");
            public static int m_LightColorScale = NetVarManager.GetOffset("DT_CascadeLight", "m_LightColorScale");
            public static int m_flMaxShadowDist = NetVarManager.GetOffset("DT_CascadeLight", "m_flMaxShadowDist");
        }

        public static class DT_EnvAmbientLight
        {
            public static int m_vecColor = NetVarManager.GetOffset("DT_EnvAmbientLight", "m_vecColor");
        }

        public static class DT_EntityParticleTrail
        {
            public static int m_iMaterialName = NetVarManager.GetOffset("DT_EntityParticleTrail", "m_iMaterialName");
            public static int m_Info = NetVarManager.GetOffset("DT_EntityParticleTrail", "m_Info");
            public static int m_flLifetime = NetVarManager.GetOffset("DT_EntityParticleTrail", "m_flLifetime");
            public static int m_flStartSize = NetVarManager.GetOffset("DT_EntityParticleTrail", "m_flStartSize");
            public static int m_flEndSize = NetVarManager.GetOffset("DT_EntityParticleTrail", "m_flEndSize");

            public static int m_hConstraintEntity =
                NetVarManager.GetOffset("DT_EntityParticleTrail", "m_hConstraintEntity");
        }

        public static class DT_EntityFreezing
        {
            public static int m_vFreezingOrigin = NetVarManager.GetOffset("DT_EntityFreezing", "m_vFreezingOrigin");
            public static int m_flFrozenPerHitbox = NetVarManager.GetOffset("DT_EntityFreezing", "m_flFrozenPerHitbox");
            public static int m_flFrozen = NetVarManager.GetOffset("DT_EntityFreezing", "m_flFrozen");
            public static int m_bFinishFreezing = NetVarManager.GetOffset("DT_EntityFreezing", "m_bFinishFreezing");
        }

        public static class DT_EntityFlame
        {
            public static int m_hEntAttached = NetVarManager.GetOffset("DT_EntityFlame", "m_hEntAttached");
            public static int m_bCheapEffect = NetVarManager.GetOffset("DT_EntityFlame", "m_bCheapEffect");
        }

        public static class DT_EntityDissolve
        {
            public static int m_flStartTime = NetVarManager.GetOffset("DT_EntityDissolve", "m_flStartTime");
            public static int m_flFadeOutStart = NetVarManager.GetOffset("DT_EntityDissolve", "m_flFadeOutStart");
            public static int m_flFadeOutLength = NetVarManager.GetOffset("DT_EntityDissolve", "m_flFadeOutLength");

            public static int m_flFadeOutModelStart =
                NetVarManager.GetOffset("DT_EntityDissolve", "m_flFadeOutModelStart");

            public static int m_flFadeOutModelLength =
                NetVarManager.GetOffset("DT_EntityDissolve", "m_flFadeOutModelLength");

            public static int m_flFadeInStart = NetVarManager.GetOffset("DT_EntityDissolve", "m_flFadeInStart");
            public static int m_flFadeInLength = NetVarManager.GetOffset("DT_EntityDissolve", "m_flFadeInLength");
            public static int m_nDissolveType = NetVarManager.GetOffset("DT_EntityDissolve", "m_nDissolveType");
            public static int m_vDissolverOrigin = NetVarManager.GetOffset("DT_EntityDissolve", "m_vDissolverOrigin");
            public static int m_nMagnitude = NetVarManager.GetOffset("DT_EntityDissolve", "m_nMagnitude");
        }

        public static class DT_DynamicLight
        {
            public static int m_Flags = NetVarManager.GetOffset("DT_DynamicLight", "m_Flags");
            public static int m_LightStyle = NetVarManager.GetOffset("DT_DynamicLight", "m_LightStyle");
            public static int m_Radius = NetVarManager.GetOffset("DT_DynamicLight", "m_Radius");
            public static int m_Exponent = NetVarManager.GetOffset("DT_DynamicLight", "m_Exponent");
            public static int m_InnerAngle = NetVarManager.GetOffset("DT_DynamicLight", "m_InnerAngle");
            public static int m_OuterAngle = NetVarManager.GetOffset("DT_DynamicLight", "m_OuterAngle");
            public static int m_SpotRadius = NetVarManager.GetOffset("DT_DynamicLight", "m_SpotRadius");
        }

        public static class DT_ColorCorrectionVolume
        {
            public static int m_bEnabled = NetVarManager.GetOffset("DT_ColorCorrectionVolume", "m_bEnabled");
            public static int m_MaxWeight = NetVarManager.GetOffset("DT_ColorCorrectionVolume", "m_MaxWeight");
            public static int m_FadeDuration = NetVarManager.GetOffset("DT_ColorCorrectionVolume", "m_FadeDuration");
            public static int m_Weight = NetVarManager.GetOffset("DT_ColorCorrectionVolume", "m_Weight");

            public static int m_lookupFilename =
                NetVarManager.GetOffset("DT_ColorCorrectionVolume", "m_lookupFilename");
        }

        public static class DT_ColorCorrection
        {
            public static int m_vecOrigin = NetVarManager.GetOffset("DT_ColorCorrection", "m_vecOrigin");
            public static int m_minFalloff = NetVarManager.GetOffset("DT_ColorCorrection", "m_minFalloff");
            public static int m_maxFalloff = NetVarManager.GetOffset("DT_ColorCorrection", "m_maxFalloff");
            public static int m_flCurWeight = NetVarManager.GetOffset("DT_ColorCorrection", "m_flCurWeight");
            public static int m_flMaxWeight = NetVarManager.GetOffset("DT_ColorCorrection", "m_flMaxWeight");
            public static int m_flFadeInDuration = NetVarManager.GetOffset("DT_ColorCorrection", "m_flFadeInDuration");

            public static int m_flFadeOutDuration =
                NetVarManager.GetOffset("DT_ColorCorrection", "m_flFadeOutDuration");

            public static int m_netLookupFilename =
                NetVarManager.GetOffset("DT_ColorCorrection", "m_netLookupFilename");

            public static int m_bEnabled = NetVarManager.GetOffset("DT_ColorCorrection", "m_bEnabled");
            public static int m_bMaster = NetVarManager.GetOffset("DT_ColorCorrection", "m_bMaster");
            public static int m_bClientSide = NetVarManager.GetOffset("DT_ColorCorrection", "m_bClientSide");
            public static int m_bExclusive = NetVarManager.GetOffset("DT_ColorCorrection", "m_bExclusive");
        }

        public static class DT_BreakableProp
        {
            public static int m_qPreferredPlayerCarryAngles =
                NetVarManager.GetOffset("DT_BreakableProp", "m_qPreferredPlayerCarryAngles");

            public static int m_bClientPhysics = NetVarManager.GetOffset("DT_BreakableProp", "m_bClientPhysics");
        }

        public static class DT_BeamSpotlight
        {
            public static int m_nHaloIndex = NetVarManager.GetOffset("DT_BeamSpotlight", "m_nHaloIndex");
            public static int m_bSpotlightOn = NetVarManager.GetOffset("DT_BeamSpotlight", "m_bSpotlightOn");
            public static int m_bHasDynamicLight = NetVarManager.GetOffset("DT_BeamSpotlight", "m_bHasDynamicLight");

            public static int m_flSpotlightMaxLength =
                NetVarManager.GetOffset("DT_BeamSpotlight", "m_flSpotlightMaxLength");

            public static int m_flSpotlightGoalWidth =
                NetVarManager.GetOffset("DT_BeamSpotlight", "m_flSpotlightGoalWidth");

            public static int m_flHDRColorScale = NetVarManager.GetOffset("DT_BeamSpotlight", "m_flHDRColorScale");
            public static int m_nRotationAxis = NetVarManager.GetOffset("DT_BeamSpotlight", "m_nRotationAxis");
            public static int m_flRotationSpeed = NetVarManager.GetOffset("DT_BeamSpotlight", "m_flRotationSpeed");
        }

        public static class DT_BaseButton
        {
            public static int m_usable = NetVarManager.GetOffset("DT_BaseButton", "m_usable");
        }

        public static class DT_BaseToggle
        {
            public static int m_vecFinalDest = NetVarManager.GetOffset("DT_BaseToggle", "m_vecFinalDest");
            public static int m_movementType = NetVarManager.GetOffset("DT_BaseToggle", "m_movementType");
            public static int m_flMoveTargetTime = NetVarManager.GetOffset("DT_BaseToggle", "m_flMoveTargetTime");
        }

        public static class DT_BasePlayer
        {
            public static int localdata = NetVarManager.GetOffset("DT_BasePlayer", "localdata");
            public static int m_Local = NetVarManager.GetOffset("DT_BasePlayer", "m_Local");
            public static int m_chAreaBits = NetVarManager.GetOffset("DT_BasePlayer", "m_chAreaBits");
            public static int m_chAreaPortalBits = NetVarManager.GetOffset("DT_BasePlayer", "m_chAreaPortalBits");
            public static int m_iHideHUD = NetVarManager.GetOffset("DT_BasePlayer", "m_iHideHUD");
            public static int m_flFOVRate = NetVarManager.GetOffset("DT_BasePlayer", "m_flFOVRate");
            public static int m_bDucked = NetVarManager.GetOffset("DT_BasePlayer", "m_bDucked");
            public static int m_bDucking = NetVarManager.GetOffset("DT_BasePlayer", "m_bDucking");
            public static int m_flLastDuckTime = NetVarManager.GetOffset("DT_BasePlayer", "m_flLastDuckTime");
            public static int m_bInDuckJump = NetVarManager.GetOffset("DT_BasePlayer", "m_bInDuckJump");
            public static int m_nDuckTimeMsecs = NetVarManager.GetOffset("DT_BasePlayer", "m_nDuckTimeMsecs");
            public static int m_nDuckJumpTimeMsecs = NetVarManager.GetOffset("DT_BasePlayer", "m_nDuckJumpTimeMsecs");
            public static int m_nJumpTimeMsecs = NetVarManager.GetOffset("DT_BasePlayer", "m_nJumpTimeMsecs");
            public static int m_flFallVelocity = NetVarManager.GetOffset("DT_BasePlayer", "m_flFallVelocity");
            public static int m_viewPunchAngle = NetVarManager.GetOffset("DT_BasePlayer", "m_viewPunchAngle");
            public static int m_aimPunchAngle = NetVarManager.GetOffset("DT_BasePlayer", "m_aimPunchAngle");
            public static int m_aimPunchAngleVel = NetVarManager.GetOffset("DT_BasePlayer", "m_aimPunchAngleVel");
            public static int m_bDrawViewmodel = NetVarManager.GetOffset("DT_BasePlayer", "m_bDrawViewmodel");
            public static int m_bWearingSuit = NetVarManager.GetOffset("DT_BasePlayer", "m_bWearingSuit");
            public static int m_bPoisoned = NetVarManager.GetOffset("DT_BasePlayer", "m_bPoisoned");
            public static int m_flStepSize = NetVarManager.GetOffset("DT_BasePlayer", "m_flStepSize");
            public static int m_bAllowAutoMovement = NetVarManager.GetOffset("DT_BasePlayer", "m_bAllowAutoMovement");
            public static int m_skybox3d_scale = NetVarManager.GetOffset("DT_BasePlayer", "m_skybox3d.scale");
            public static int m_skybox3d_origin = NetVarManager.GetOffset("DT_BasePlayer", "m_skybox3d.origin");
            public static int m_skybox3d_area = NetVarManager.GetOffset("DT_BasePlayer", "m_skybox3d.area");
            public static int m_skybox3d_fog_enable = NetVarManager.GetOffset("DT_BasePlayer", "m_skybox3d.fog.enable");
            public static int m_skybox3d_fog_blend = NetVarManager.GetOffset("DT_BasePlayer", "m_skybox3d.fog.blend");

            public static int m_skybox3d_fog_dirPrimary =
                NetVarManager.GetOffset("DT_BasePlayer", "m_skybox3d.fog.dirPrimary");

            public static int m_skybox3d_fog_colorPrimary =
                NetVarManager.GetOffset("DT_BasePlayer", "m_skybox3d.fog.colorPrimary");

            public static int m_skybox3d_fog_colorSecondary =
                NetVarManager.GetOffset("DT_BasePlayer", "m_skybox3d.fog.colorSecondary");

            public static int m_skybox3d_fog_start = NetVarManager.GetOffset("DT_BasePlayer", "m_skybox3d.fog.start");
            public static int m_skybox3d_fog_end = NetVarManager.GetOffset("DT_BasePlayer", "m_skybox3d.fog.end");

            public static int m_skybox3d_fog_maxdensity =
                NetVarManager.GetOffset("DT_BasePlayer", "m_skybox3d.fog.maxdensity");

            public static int m_skybox3d_fog_HDRColorScale =
                NetVarManager.GetOffset("DT_BasePlayer", "m_skybox3d.fog.HDRColorScale");

            public static int m_audio_localSound_0 = NetVarManager.GetOffset("DT_BasePlayer", "m_audio.localSound[0]");
            public static int m_audio_localSound_1 = NetVarManager.GetOffset("DT_BasePlayer", "m_audio.localSound[1]");
            public static int m_audio_localSound_2 = NetVarManager.GetOffset("DT_BasePlayer", "m_audio.localSound[2]");
            public static int m_audio_localSound_3 = NetVarManager.GetOffset("DT_BasePlayer", "m_audio.localSound[3]");
            public static int m_audio_localSound_4 = NetVarManager.GetOffset("DT_BasePlayer", "m_audio.localSound[4]");
            public static int m_audio_localSound_5 = NetVarManager.GetOffset("DT_BasePlayer", "m_audio.localSound[5]");
            public static int m_audio_localSound_6 = NetVarManager.GetOffset("DT_BasePlayer", "m_audio.localSound[6]");
            public static int m_audio_localSound_7 = NetVarManager.GetOffset("DT_BasePlayer", "m_audio.localSound[7]");

            public static int m_audio_soundscapeIndex =
                NetVarManager.GetOffset("DT_BasePlayer", "m_audio.soundscapeIndex");

            public static int m_audio_localBits = NetVarManager.GetOffset("DT_BasePlayer", "m_audio.localBits");
            public static int m_audio_entIndex = NetVarManager.GetOffset("DT_BasePlayer", "m_audio.entIndex");
            public static int m_vecViewOffset_0 = NetVarManager.GetOffset("DT_BasePlayer", "m_vecViewOffset[0]");
            public static int m_vecViewOffset_1 = NetVarManager.GetOffset("DT_BasePlayer", "m_vecViewOffset[1]");
            public static int m_vecViewOffset_2 = NetVarManager.GetOffset("DT_BasePlayer", "m_vecViewOffset[2]");
            public static int m_flFriction = NetVarManager.GetOffset("DT_BasePlayer", "m_flFriction");
            public static int m_fOnTarget = NetVarManager.GetOffset("DT_BasePlayer", "m_fOnTarget");
            public static int m_nTickBase = NetVarManager.GetOffset("DT_BasePlayer", "m_nTickBase");
            public static int m_nNextThinkTick = NetVarManager.GetOffset("DT_BasePlayer", "m_nNextThinkTick");
            public static int m_hLastWeapon = NetVarManager.GetOffset("DT_BasePlayer", "m_hLastWeapon");
            public static int m_vecVelocity_0 = NetVarManager.GetOffset("DT_BasePlayer", "m_vecVelocity[0]");
            public static int m_vecVelocity_1 = NetVarManager.GetOffset("DT_BasePlayer", "m_vecVelocity[1]");
            public static int m_vecVelocity_2 = NetVarManager.GetOffset("DT_BasePlayer", "m_vecVelocity[2]");
            public static int m_vecBaseVelocity = NetVarManager.GetOffset("DT_BasePlayer", "m_vecBaseVelocity");
            public static int m_hConstraintEntity = NetVarManager.GetOffset("DT_BasePlayer", "m_hConstraintEntity");
            public static int m_vecConstraintCenter = NetVarManager.GetOffset("DT_BasePlayer", "m_vecConstraintCenter");
            public static int m_flConstraintRadius = NetVarManager.GetOffset("DT_BasePlayer", "m_flConstraintRadius");
            public static int m_flConstraintWidth = NetVarManager.GetOffset("DT_BasePlayer", "m_flConstraintWidth");

            public static int m_flConstraintSpeedFactor =
                NetVarManager.GetOffset("DT_BasePlayer", "m_flConstraintSpeedFactor");

            public static int m_bConstraintPastRadius =
                NetVarManager.GetOffset("DT_BasePlayer", "m_bConstraintPastRadius");

            public static int m_flDeathTime = NetVarManager.GetOffset("DT_BasePlayer", "m_flDeathTime");
            public static int m_flNextDecalTime = NetVarManager.GetOffset("DT_BasePlayer", "m_flNextDecalTime");
            public static int m_fForceTeam = NetVarManager.GetOffset("DT_BasePlayer", "m_fForceTeam");

            public static int m_flLaggedMovementValue =
                NetVarManager.GetOffset("DT_BasePlayer", "m_flLaggedMovementValue");

            public static int m_hTonemapController = NetVarManager.GetOffset("DT_BasePlayer", "m_hTonemapController");
            public static int pl = NetVarManager.GetOffset("DT_BasePlayer", "pl");
            public static int deadflag = NetVarManager.GetOffset("DT_BasePlayer", "deadflag");
            public static int m_iFOV = NetVarManager.GetOffset("DT_BasePlayer", "m_iFOV");
            public static int m_iFOVStart = NetVarManager.GetOffset("DT_BasePlayer", "m_iFOVStart");
            public static int m_flFOVTime = NetVarManager.GetOffset("DT_BasePlayer", "m_flFOVTime");
            public static int m_iDefaultFOV = NetVarManager.GetOffset("DT_BasePlayer", "m_iDefaultFOV");
            public static int m_hZoomOwner = NetVarManager.GetOffset("DT_BasePlayer", "m_hZoomOwner");
            public static int m_afPhysicsFlags = NetVarManager.GetOffset("DT_BasePlayer", "m_afPhysicsFlags");
            public static int m_hVehicle = NetVarManager.GetOffset("DT_BasePlayer", "m_hVehicle");
            public static int m_hUseEntity = NetVarManager.GetOffset("DT_BasePlayer", "m_hUseEntity");
            public static int m_hGroundEntity = NetVarManager.GetOffset("DT_BasePlayer", "m_hGroundEntity");
            public static int m_iHealth = NetVarManager.GetOffset("DT_BasePlayer", "m_iHealth");
            public static int m_lifeState = NetVarManager.GetOffset("DT_BasePlayer", "m_lifeState");
            public static int m_iAmmo = NetVarManager.GetOffset("DT_BasePlayer", "m_iAmmo");
            public static int m_iBonusProgress = NetVarManager.GetOffset("DT_BasePlayer", "m_iBonusProgress");
            public static int m_iBonusChallenge = NetVarManager.GetOffset("DT_BasePlayer", "m_iBonusChallenge");
            public static int m_flMaxspeed = NetVarManager.GetOffset("DT_BasePlayer", "m_flMaxspeed");
            public static int m_fFlags = NetVarManager.GetOffset("DT_BasePlayer", "m_fFlags");
            public static int m_iObserverMode = NetVarManager.GetOffset("DT_BasePlayer", "m_iObserverMode");
            public static int m_bActiveCameraMan = NetVarManager.GetOffset("DT_BasePlayer", "m_bActiveCameraMan");
            public static int m_bCameraManXRay = NetVarManager.GetOffset("DT_BasePlayer", "m_bCameraManXRay");
            public static int m_bCameraManOverview = NetVarManager.GetOffset("DT_BasePlayer", "m_bCameraManOverview");

            public static int m_bCameraManScoreBoard =
                NetVarManager.GetOffset("DT_BasePlayer", "m_bCameraManScoreBoard");

            public static int m_uCameraManGraphs = NetVarManager.GetOffset("DT_BasePlayer", "m_uCameraManGraphs");
            public static int m_iDeathPostEffect = NetVarManager.GetOffset("DT_BasePlayer", "m_iDeathPostEffect");
            public static int m_hObserverTarget = NetVarManager.GetOffset("DT_BasePlayer", "m_hObserverTarget");
            public static int m_hViewModel_0 = NetVarManager.GetOffset("DT_BasePlayer", "m_hViewModel[0]");
            public static int m_hViewModel = NetVarManager.GetOffset("DT_BasePlayer", "m_hViewModel");
            public static int m_iCoachingTeam = NetVarManager.GetOffset("DT_BasePlayer", "m_iCoachingTeam");
            public static int m_szLastPlaceName = NetVarManager.GetOffset("DT_BasePlayer", "m_szLastPlaceName");
            public static int m_vecLadderNormal = NetVarManager.GetOffset("DT_BasePlayer", "m_vecLadderNormal");
            public static int m_ladderSurfaceProps = NetVarManager.GetOffset("DT_BasePlayer", "m_ladderSurfaceProps");
            public static int m_ubEFNoInterpParity = NetVarManager.GetOffset("DT_BasePlayer", "m_ubEFNoInterpParity");
            public static int m_hPostProcessCtrl = NetVarManager.GetOffset("DT_BasePlayer", "m_hPostProcessCtrl");

            public static int m_hColorCorrectionCtrl =
                NetVarManager.GetOffset("DT_BasePlayer", "m_hColorCorrectionCtrl");

            public static int m_PlayerFog_m_hCtrl = NetVarManager.GetOffset("DT_BasePlayer", "m_PlayerFog.m_hCtrl");

            public static int m_vphysicsCollisionState =
                NetVarManager.GetOffset("DT_BasePlayer", "m_vphysicsCollisionState");

            public static int m_hViewEntity = NetVarManager.GetOffset("DT_BasePlayer", "m_hViewEntity");

            public static int m_bShouldDrawPlayerWhileUsingViewEntity =
                NetVarManager.GetOffset("DT_BasePlayer", "m_bShouldDrawPlayerWhileUsingViewEntity");

            public static int m_flDuckAmount = NetVarManager.GetOffset("DT_BasePlayer", "m_flDuckAmount");
            public static int m_flDuckSpeed = NetVarManager.GetOffset("DT_BasePlayer", "m_flDuckSpeed");
            public static int m_nWaterLevel = NetVarManager.GetOffset("DT_BasePlayer", "m_nWaterLevel");
        }

        public static class DT_BaseFlex
        {
            public static int m_flexWeight = NetVarManager.GetOffset("DT_BaseFlex", "m_flexWeight");
            public static int m_blinktoggle = NetVarManager.GetOffset("DT_BaseFlex", "m_blinktoggle");
            public static int m_viewtarget = NetVarManager.GetOffset("DT_BaseFlex", "m_viewtarget");
        }

        public static class DT_BaseEntity
        {
            public static int AnimTimeMustBeFirst = NetVarManager.GetOffset("DT_BaseEntity", "AnimTimeMustBeFirst");
            public static int m_flAnimTime = NetVarManager.GetOffset("DT_BaseEntity", "m_flAnimTime");
            public static int m_flSimulationTime = NetVarManager.GetOffset("DT_BaseEntity", "m_flSimulationTime");
            public static int m_cellbits = NetVarManager.GetOffset("DT_BaseEntity", "m_cellbits");
            public static int m_cellX = NetVarManager.GetOffset("DT_BaseEntity", "m_cellX");
            public static int m_cellY = NetVarManager.GetOffset("DT_BaseEntity", "m_cellY");
            public static int m_cellZ = NetVarManager.GetOffset("DT_BaseEntity", "m_cellZ");
            public static int m_vecOrigin = NetVarManager.GetOffset("DT_BaseEntity", "m_vecOrigin");
            public static int m_angRotation = NetVarManager.GetOffset("DT_BaseEntity", "m_angRotation");
            public static int m_nModelIndex = NetVarManager.GetOffset("DT_BaseEntity", "m_nModelIndex");
            public static int m_fEffects = NetVarManager.GetOffset("DT_BaseEntity", "m_fEffects");
            public static int m_nRenderMode = NetVarManager.GetOffset("DT_BaseEntity", "m_nRenderMode");
            public static int m_nRenderFX = NetVarManager.GetOffset("DT_BaseEntity", "m_nRenderFX");
            public static int m_clrRender = NetVarManager.GetOffset("DT_BaseEntity", "m_clrRender");
            public static int m_iTeamNum = NetVarManager.GetOffset("DT_BaseEntity", "m_iTeamNum");
            public static int m_iPendingTeamNum = NetVarManager.GetOffset("DT_BaseEntity", "m_iPendingTeamNum");
            public static int m_CollisionGroup = NetVarManager.GetOffset("DT_BaseEntity", "m_CollisionGroup");
            public static int m_flElasticity = NetVarManager.GetOffset("DT_BaseEntity", "m_flElasticity");

            public static int m_flShadowCastDistance =
                NetVarManager.GetOffset("DT_BaseEntity", "m_flShadowCastDistance");

            public static int m_hOwnerEntity = NetVarManager.GetOffset("DT_BaseEntity", "m_hOwnerEntity");
            public static int m_hEffectEntity = NetVarManager.GetOffset("DT_BaseEntity", "m_hEffectEntity");
            public static int moveparent = NetVarManager.GetOffset("DT_BaseEntity", "moveparent");
            public static int m_iParentAttachment = NetVarManager.GetOffset("DT_BaseEntity", "m_iParentAttachment");
            public static int m_iName = NetVarManager.GetOffset("DT_BaseEntity", "m_iName");
            public static int movetype = NetVarManager.GetOffset("DT_BaseEntity", "movetype");
            public static int movecollide = NetVarManager.GetOffset("DT_BaseEntity", "movecollide");
            public static int m_Collision = NetVarManager.GetOffset("DT_BaseEntity", "m_Collision");
            public static int m_vecMins = NetVarManager.GetOffset("DT_BaseEntity", "m_vecMins");
            public static int m_vecMaxs = NetVarManager.GetOffset("DT_BaseEntity", "m_vecMaxs");
            public static int m_nSolidType = NetVarManager.GetOffset("DT_BaseEntity", "m_nSolidType");
            public static int m_usSolidFlags = NetVarManager.GetOffset("DT_BaseEntity", "m_usSolidFlags");
            public static int m_nSurroundType = NetVarManager.GetOffset("DT_BaseEntity", "m_nSurroundType");
            public static int m_triggerBloat = NetVarManager.GetOffset("DT_BaseEntity", "m_triggerBloat");

            public static int m_vecSpecifiedSurroundingMins =
                NetVarManager.GetOffset("DT_BaseEntity", "m_vecSpecifiedSurroundingMins");

            public static int m_vecSpecifiedSurroundingMaxs =
                NetVarManager.GetOffset("DT_BaseEntity", "m_vecSpecifiedSurroundingMaxs");

            public static int m_iTextureFrameIndex = NetVarManager.GetOffset("DT_BaseEntity", "m_iTextureFrameIndex");
            public static int m_bSimulatedEveryTick = NetVarManager.GetOffset("DT_BaseEntity", "m_bSimulatedEveryTick");
            public static int m_bAnimatedEveryTick = NetVarManager.GetOffset("DT_BaseEntity", "m_bAnimatedEveryTick");
            public static int m_bAlternateSorting = NetVarManager.GetOffset("DT_BaseEntity", "m_bAlternateSorting");
            public static int m_bSpotted = NetVarManager.GetOffset("DT_BaseEntity", "m_bSpotted");
            public static int m_bSpottedBy = NetVarManager.GetOffset("DT_BaseEntity", "m_bSpottedBy");
            public static int m_bSpottedByMask = NetVarManager.GetOffset("DT_BaseEntity", "m_bSpottedByMask");
            public static int m_bIsAutoaimTarget = NetVarManager.GetOffset("DT_BaseEntity", "m_bIsAutoaimTarget");
            public static int m_fadeMinDist = NetVarManager.GetOffset("DT_BaseEntity", "m_fadeMinDist");
            public static int m_fadeMaxDist = NetVarManager.GetOffset("DT_BaseEntity", "m_fadeMaxDist");
            public static int m_flFadeScale = NetVarManager.GetOffset("DT_BaseEntity", "m_flFadeScale");
            public static int m_nMinCPULevel = NetVarManager.GetOffset("DT_BaseEntity", "m_nMinCPULevel");
            public static int m_nMaxCPULevel = NetVarManager.GetOffset("DT_BaseEntity", "m_nMaxCPULevel");
            public static int m_nMinGPULevel = NetVarManager.GetOffset("DT_BaseEntity", "m_nMinGPULevel");
            public static int m_nMaxGPULevel = NetVarManager.GetOffset("DT_BaseEntity", "m_nMaxGPULevel");
            public static int m_flUseLookAtAngle = NetVarManager.GetOffset("DT_BaseEntity", "m_flUseLookAtAngle");
            public static int m_flLastMadeNoiseTime = NetVarManager.GetOffset("DT_BaseEntity", "m_flLastMadeNoiseTime");
            public static int m_flMaxFallVelocity = NetVarManager.GetOffset("DT_BaseEntity", "m_flMaxFallVelocity");

            public static int m_bEligibleForScreenHighlight =
                NetVarManager.GetOffset("DT_BaseEntity", "m_bEligibleForScreenHighlight");
        }

        public static class DT_BaseDoor
        {
            public static int m_flWaveHeight = NetVarManager.GetOffset("DT_BaseDoor", "m_flWaveHeight");
        }

        public static class DT_BaseCombatCharacter
        {
            public static int bcc_localdata = NetVarManager.GetOffset("DT_BaseCombatCharacter", "bcc_localdata");
            public static int m_flNextAttack = NetVarManager.GetOffset("DT_BaseCombatCharacter", "m_flNextAttack");
            public static int bcc_nonlocaldata = NetVarManager.GetOffset("DT_BaseCombatCharacter", "bcc_nonlocaldata");
            public static int m_hMyWeapons = NetVarManager.GetOffset("DT_BaseCombatCharacter", "m_hMyWeapons");
            public static int m_LastHitGroup = NetVarManager.GetOffset("DT_BaseCombatCharacter", "m_LastHitGroup");
            public static int m_hActiveWeapon = NetVarManager.GetOffset("DT_BaseCombatCharacter", "m_hActiveWeapon");

            public static int m_flTimeOfLastInjury =
                NetVarManager.GetOffset("DT_BaseCombatCharacter", "m_flTimeOfLastInjury");

            public static int m_nRelativeDirectionOfLastInjury =
                NetVarManager.GetOffset("DT_BaseCombatCharacter", "m_nRelativeDirectionOfLastInjury");

            public static int m_hMyWearables = NetVarManager.GetOffset("DT_BaseCombatCharacter", "m_hMyWearables");
        }

        public static class DT_BaseAnimatingOverlay
        {
            public static int overlay_vars = NetVarManager.GetOffset("DT_BaseAnimatingOverlay", "overlay_vars");
            public static int m_AnimOverlay = NetVarManager.GetOffset("DT_BaseAnimatingOverlay", "m_AnimOverlay");
            public static int lengthproxy = NetVarManager.GetOffset("DT_BaseAnimatingOverlay", "lengthproxy");
            public static int lengthprop15 = NetVarManager.GetOffset("DT_BaseAnimatingOverlay", "lengthprop15");
        }

        public static class DT_BoneFollower
        {
            public static int m_modelIndex = NetVarManager.GetOffset("DT_BoneFollower", "m_modelIndex");
            public static int m_solidIndex = NetVarManager.GetOffset("DT_BoneFollower", "m_solidIndex");
        }

        public static class DT_BaseAnimating
        {
            public static int m_nSequence = NetVarManager.GetOffset("DT_BaseAnimating", "m_nSequence");
            public static int m_nForceBone = NetVarManager.GetOffset("DT_BaseAnimating", "m_nForceBone");
            public static int m_vecForce = NetVarManager.GetOffset("DT_BaseAnimating", "m_vecForce");
            public static int m_nSkin = NetVarManager.GetOffset("DT_BaseAnimating", "m_nSkin");
            public static int m_nBody = NetVarManager.GetOffset("DT_BaseAnimating", "m_nBody");
            public static int m_nHitboxSet = NetVarManager.GetOffset("DT_BaseAnimating", "m_nHitboxSet");
            public static int m_flModelScale = NetVarManager.GetOffset("DT_BaseAnimating", "m_flModelScale");
            public static int m_flPoseParameter = NetVarManager.GetOffset("DT_BaseAnimating", "m_flPoseParameter");
            public static int m_flPlaybackRate = NetVarManager.GetOffset("DT_BaseAnimating", "m_flPlaybackRate");

            public static int m_flEncodedController =
                NetVarManager.GetOffset("DT_BaseAnimating", "m_flEncodedController");

            public static int m_bClientSideAnimation =
                NetVarManager.GetOffset("DT_BaseAnimating", "m_bClientSideAnimation");

            public static int m_bClientSideFrameReset =
                NetVarManager.GetOffset("DT_BaseAnimating", "m_bClientSideFrameReset");

            public static int m_bClientSideRagdoll =
                NetVarManager.GetOffset("DT_BaseAnimating", "m_bClientSideRagdoll");

            public static int m_nNewSequenceParity =
                NetVarManager.GetOffset("DT_BaseAnimating", "m_nNewSequenceParity");

            public static int m_nResetEventsParity =
                NetVarManager.GetOffset("DT_BaseAnimating", "m_nResetEventsParity");

            public static int m_nMuzzleFlashParity =
                NetVarManager.GetOffset("DT_BaseAnimating", "m_nMuzzleFlashParity");

            public static int m_hLightingOrigin = NetVarManager.GetOffset("DT_BaseAnimating", "m_hLightingOrigin");
            public static int serveranimdata = NetVarManager.GetOffset("DT_BaseAnimating", "serveranimdata");
            public static int m_flCycle = NetVarManager.GetOffset("DT_BaseAnimating", "m_flCycle");
            public static int m_flFrozen = NetVarManager.GetOffset("DT_BaseAnimating", "m_flFrozen");
            public static int m_ScaleType = NetVarManager.GetOffset("DT_BaseAnimating", "m_ScaleType");

            public static int m_bSuppressAnimSounds =
                NetVarManager.GetOffset("DT_BaseAnimating", "m_bSuppressAnimSounds");

            public static int m_nHighlightColorR = NetVarManager.GetOffset("DT_BaseAnimating", "m_nHighlightColorR");
            public static int m_nHighlightColorG = NetVarManager.GetOffset("DT_BaseAnimating", "m_nHighlightColorG");
            public static int m_nHighlightColorB = NetVarManager.GetOffset("DT_BaseAnimating", "m_nHighlightColorB");
        }

        public static class DT_AI_BaseNPC
        {
            public static int m_lifeState = NetVarManager.GetOffset("DT_AI_BaseNPC", "m_lifeState");
            public static int m_bPerformAvoidance = NetVarManager.GetOffset("DT_AI_BaseNPC", "m_bPerformAvoidance");
            public static int m_bIsMoving = NetVarManager.GetOffset("DT_AI_BaseNPC", "m_bIsMoving");
            public static int m_bFadeCorpse = NetVarManager.GetOffset("DT_AI_BaseNPC", "m_bFadeCorpse");
            public static int m_iDeathPose = NetVarManager.GetOffset("DT_AI_BaseNPC", "m_iDeathPose");
            public static int m_iDeathFrame = NetVarManager.GetOffset("DT_AI_BaseNPC", "m_iDeathFrame");
            public static int m_iSpeedModRadius = NetVarManager.GetOffset("DT_AI_BaseNPC", "m_iSpeedModRadius");
            public static int m_iSpeedModSpeed = NetVarManager.GetOffset("DT_AI_BaseNPC", "m_iSpeedModSpeed");
            public static int m_bSpeedModActive = NetVarManager.GetOffset("DT_AI_BaseNPC", "m_bSpeedModActive");
            public static int m_bImportanRagdoll = NetVarManager.GetOffset("DT_AI_BaseNPC", "m_bImportanRagdoll");
            public static int m_flTimePingEffect = NetVarManager.GetOffset("DT_AI_BaseNPC", "m_flTimePingEffect");
        }

        public static class DT_Beam
        {
            public static int m_nBeamType = NetVarManager.GetOffset("DT_Beam", "m_nBeamType");
            public static int m_nBeamFlags = NetVarManager.GetOffset("DT_Beam", "m_nBeamFlags");
            public static int m_nNumBeamEnts = NetVarManager.GetOffset("DT_Beam", "m_nNumBeamEnts");
            public static int m_hAttachEntity = NetVarManager.GetOffset("DT_Beam", "m_hAttachEntity");
            public static int m_nAttachIndex = NetVarManager.GetOffset("DT_Beam", "m_nAttachIndex");
            public static int m_nHaloIndex = NetVarManager.GetOffset("DT_Beam", "m_nHaloIndex");
            public static int m_fHaloScale = NetVarManager.GetOffset("DT_Beam", "m_fHaloScale");
            public static int m_fWidth = NetVarManager.GetOffset("DT_Beam", "m_fWidth");
            public static int m_fEndWidth = NetVarManager.GetOffset("DT_Beam", "m_fEndWidth");
            public static int m_fFadeLength = NetVarManager.GetOffset("DT_Beam", "m_fFadeLength");
            public static int m_fAmplitude = NetVarManager.GetOffset("DT_Beam", "m_fAmplitude");
            public static int m_fStartFrame = NetVarManager.GetOffset("DT_Beam", "m_fStartFrame");
            public static int m_fSpeed = NetVarManager.GetOffset("DT_Beam", "m_fSpeed");
            public static int m_flFrameRate = NetVarManager.GetOffset("DT_Beam", "m_flFrameRate");
            public static int m_flHDRColorScale = NetVarManager.GetOffset("DT_Beam", "m_flHDRColorScale");
            public static int m_clrRender = NetVarManager.GetOffset("DT_Beam", "m_clrRender");
            public static int m_nRenderFX = NetVarManager.GetOffset("DT_Beam", "m_nRenderFX");
            public static int m_nRenderMode = NetVarManager.GetOffset("DT_Beam", "m_nRenderMode");
            public static int m_flFrame = NetVarManager.GetOffset("DT_Beam", "m_flFrame");
            public static int m_nClipStyle = NetVarManager.GetOffset("DT_Beam", "m_nClipStyle");
            public static int m_vecEndPos = NetVarManager.GetOffset("DT_Beam", "m_vecEndPos");
            public static int m_nModelIndex = NetVarManager.GetOffset("DT_Beam", "m_nModelIndex");
            public static int m_vecOrigin = NetVarManager.GetOffset("DT_Beam", "m_vecOrigin");
            public static int moveparent = NetVarManager.GetOffset("DT_Beam", "moveparent");
        }

        public static class DT_BaseViewModel
        {
            public static int m_nModelIndex = NetVarManager.GetOffset("DT_BaseViewModel", "m_nModelIndex");
            public static int m_hWeapon = NetVarManager.GetOffset("DT_BaseViewModel", "m_hWeapon");
            public static int m_nSkin = NetVarManager.GetOffset("DT_BaseViewModel", "m_nSkin");
            public static int m_nBody = NetVarManager.GetOffset("DT_BaseViewModel", "m_nBody");
            public static int m_nSequence = NetVarManager.GetOffset("DT_BaseViewModel", "m_nSequence");
            public static int m_nViewModelIndex = NetVarManager.GetOffset("DT_BaseViewModel", "m_nViewModelIndex");
            public static int m_flPlaybackRate = NetVarManager.GetOffset("DT_BaseViewModel", "m_flPlaybackRate");
            public static int m_fEffects = NetVarManager.GetOffset("DT_BaseViewModel", "m_fEffects");
            public static int m_nAnimationParity = NetVarManager.GetOffset("DT_BaseViewModel", "m_nAnimationParity");
            public static int m_hOwner = NetVarManager.GetOffset("DT_BaseViewModel", "m_hOwner");

            public static int m_nNewSequenceParity =
                NetVarManager.GetOffset("DT_BaseViewModel", "m_nNewSequenceParity");

            public static int m_nResetEventsParity =
                NetVarManager.GetOffset("DT_BaseViewModel", "m_nResetEventsParity");

            public static int m_nMuzzleFlashParity =
                NetVarManager.GetOffset("DT_BaseViewModel", "m_nMuzzleFlashParity");

            public static int m_bShouldIgnoreOffsetAndAccuracy =
                NetVarManager.GetOffset("DT_BaseViewModel", "m_bShouldIgnoreOffsetAndAccuracy");
        }

        public static class DT_BaseGrenade
        {
            public static int m_flDamage = NetVarManager.GetOffset("DT_BaseGrenade", "m_flDamage");
            public static int m_DmgRadius = NetVarManager.GetOffset("DT_BaseGrenade", "m_DmgRadius");
            public static int m_bIsLive = NetVarManager.GetOffset("DT_BaseGrenade", "m_bIsLive");
            public static int m_hThrower = NetVarManager.GetOffset("DT_BaseGrenade", "m_hThrower");
            public static int m_vecVelocity = NetVarManager.GetOffset("DT_BaseGrenade", "m_vecVelocity");
            public static int m_fFlags = NetVarManager.GetOffset("DT_BaseGrenade", "m_fFlags");
        }

        public static class DT_BaseCombatWeapon
        {
            public static int LocalWeaponData = NetVarManager.GetOffset("DT_BaseCombatWeapon", "LocalWeaponData");
            public static int m_iPrimaryAmmoType = NetVarManager.GetOffset("DT_BaseCombatWeapon", "m_iPrimaryAmmoType");

            public static int m_iSecondaryAmmoType =
                NetVarManager.GetOffset("DT_BaseCombatWeapon", "m_iSecondaryAmmoType");

            public static int m_nViewModelIndex = NetVarManager.GetOffset("DT_BaseCombatWeapon", "m_nViewModelIndex");
            public static int m_bFlipViewModel = NetVarManager.GetOffset("DT_BaseCombatWeapon", "m_bFlipViewModel");
            public static int m_iWeaponOrigin = NetVarManager.GetOffset("DT_BaseCombatWeapon", "m_iWeaponOrigin");
            public static int m_iWeaponModule = NetVarManager.GetOffset("DT_BaseCombatWeapon", "m_iWeaponModule");

            public static int LocalActiveWeaponData =
                NetVarManager.GetOffset("DT_BaseCombatWeapon", "LocalActiveWeaponData");

            public static int m_flNextPrimaryAttack =
                NetVarManager.GetOffset("DT_BaseCombatWeapon", "m_flNextPrimaryAttack");

            public static int m_flNextSecondaryAttack =
                NetVarManager.GetOffset("DT_BaseCombatWeapon", "m_flNextSecondaryAttack");

            public static int m_nNextThinkTick = NetVarManager.GetOffset("DT_BaseCombatWeapon", "m_nNextThinkTick");
            public static int m_flTimeWeaponIdle = NetVarManager.GetOffset("DT_BaseCombatWeapon", "m_flTimeWeaponIdle");
            public static int m_iViewModelIndex = NetVarManager.GetOffset("DT_BaseCombatWeapon", "m_iViewModelIndex");
            public static int m_iWorldModelIndex = NetVarManager.GetOffset("DT_BaseCombatWeapon", "m_iWorldModelIndex");

            public static int m_iWorldDroppedModelIndex =
                NetVarManager.GetOffset("DT_BaseCombatWeapon", "m_iWorldDroppedModelIndex");

            public static int m_iState = NetVarManager.GetOffset("DT_BaseCombatWeapon", "m_iState");
            public static int m_hOwner = NetVarManager.GetOffset("DT_BaseCombatWeapon", "m_hOwner");
            public static int m_iClip1 = NetVarManager.GetOffset("DT_BaseCombatWeapon", "m_iClip1");
            public static int m_iClip2 = NetVarManager.GetOffset("DT_BaseCombatWeapon", "m_iClip2");

            public static int m_iPrimaryReserveAmmoCount =
                NetVarManager.GetOffset("DT_BaseCombatWeapon", "m_iPrimaryReserveAmmoCount");

            public static int m_iSecondaryReserveAmmoCount =
                NetVarManager.GetOffset("DT_BaseCombatWeapon", "m_iSecondaryReserveAmmoCount");

            public static int m_hWeaponWorldModel =
                NetVarManager.GetOffset("DT_BaseCombatWeapon", "m_hWeaponWorldModel");

            public static int m_iNumEmptyAttacks = NetVarManager.GetOffset("DT_BaseCombatWeapon", "m_iNumEmptyAttacks");
        }

        public static class DT_BaseWeaponWorldModel
        {
            public static int m_nModelIndex = NetVarManager.GetOffset("DT_BaseWeaponWorldModel", "m_nModelIndex");
            public static int m_nBody = NetVarManager.GetOffset("DT_BaseWeaponWorldModel", "m_nBody");
            public static int m_fEffects = NetVarManager.GetOffset("DT_BaseWeaponWorldModel", "m_fEffects");
            public static int moveparent = NetVarManager.GetOffset("DT_BaseWeaponWorldModel", "moveparent");

            public static int m_hCombatWeaponParent =
                NetVarManager.GetOffset("DT_BaseWeaponWorldModel", "m_hCombatWeaponParent");
        }
    }
}