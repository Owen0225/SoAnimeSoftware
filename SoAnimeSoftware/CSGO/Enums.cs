using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.CSGO
{
    public enum EHitGroup
    {
        Invalid = -1,
        Generic,
        Head,
        Chest,
        Stomach,
        LeftArm,
        RightArm,
        LeftLeg,
        RightLeg,
        Gear = 10
    };

    public enum EClassId
    {
        CAI_BaseNPC = 0,
        CAK47,
        CBaseAnimating,
        CBaseAnimatingOverlay,
        CBaseAttributableItem,
        CBaseButton,
        CBaseCombatCharacter,
        CBaseCombatWeapon,
        CBaseCSGrenade,
        CBaseCSGrenadeProjectile,
        CBaseDoor,
        CBaseEntity,
        CBaseFlex,
        CBaseGrenade,
        CBaseParticleEntity,
        CBasePlayer,
        CBasePropDoor,
        CBaseTeamObjectiveResource,
        CBaseTempEntity,
        CBaseToggle,
        CBaseTrigger,
        CBaseViewModel,
        CBaseVPhysicsTrigger,
        CBaseWeaponWorldModel,
        CBeam,
        CBeamSpotlight,
        CBoneFollower,
        CBRC4Target,
        CBreachCharge,
        CBreachChargeProjectile,
        CBreakableProp,
        CBreakableSurface,
        CBumpMine,
        CBumpMineProjectile,
        CC4,
        CCascadeLight,
        CChicken,
        CColorCorrection,
        CColorCorrectionVolume,
        CCSGameRulesProxy,
        CCSPlayer,
        CCSPlayerResource,
        CCSRagdoll,
        CCSTeam,
        CDangerZone,
        CDangerZoneController,
        CDEagle,
        CDecoyGrenade,
        CDecoyProjectile,
        CDrone,
        CDronegun,
        CDynamicLight,
        CDynamicProp,
        CEconEntity,
        CEconWearable,
        CEmbers,
        CEntityDissolve,
        CEntityFlame,
        CEntityFreezing,
        CEntityParticleTrail,
        CEnvAmbientLight,
        CEnvDetailController,
        CEnvDOFController,
        CEnvGasCanister,
        CEnvParticleScript,
        CEnvProjectedTexture,
        CEnvQuadraticBeam,
        CEnvScreenEffect,
        CEnvScreenOverlay,
        CEnvTonemapController,
        CEnvWind,
        CFEPlayerDecal,
        CFireCrackerBlast,
        CFireSmoke,
        CFireTrail,
        CFish,
        CFists,
        CFlashbang,
        CFogController,
        CFootstepControl,
        CFunc_Dust,
        CFunc_LOD,
        CFuncAreaPortalWindow,
        CFuncBrush,
        CFuncConveyor,
        CFuncLadder,
        CFuncMonitor,
        CFuncMoveLinear,
        CFuncOccluder,
        CFuncReflectiveGlass,
        CFuncRotating,
        CFuncSmokeVolume,
        CFuncTrackTrain,
        CGameRulesProxy,
        CGrassBurn,
        CHandleTest,
        CHEGrenade,
        CHostage,
        CHostageCarriableProp,
        CIncendiaryGrenade,
        CInferno,
        CInfoLadderDismount,
        CInfoMapRegion,
        CInfoOverlayAccessor,
        CItem_Healthshot,
        CItemCash,
        CItemDogtags,
        CKnife,
        CKnifeGG,
        CLightGlow,
        CMapVetoPickController,
        CMaterialModifyControl,
        CMelee,
        CMolotovGrenade,
        CMolotovProjectile,
        CMovieDisplay,
        CParadropChopper,
        CParticleFire,
        CParticlePerformanceMonitor,
        CParticleSystem,
        CPhysBox,
        CPhysBoxMultiplayer,
        CPhysicsProp,
        CPhysicsPropMultiplayer,
        CPhysMagnet,
        CPhysPropAmmoBox,
        CPhysPropLootCrate,
        CPhysPropRadarJammer,
        CPhysPropWeaponUpgrade,
        CPlantedC4,
        CPlasma,
        CPlayerPing,
        CPlayerResource,
        CPointCamera,
        CPointCommentaryNode,
        CPointWorldText,
        CPoseController,
        CPostProcessController,
        CPrecipitation,
        CPrecipitationBlocker,
        CPredictedViewModel,
        CProp_Hallucination,
        CPropCounter,
        CPropDoorRotating,
        CPropJeep,
        CPropVehicleDriveable,
        CRagdollManager,
        CRagdollProp,
        CRagdollPropAttached,
        CRopeKeyframe,
        CSCAR17,
        CSceneEntity,
        CSensorGrenade,
        CSensorGrenadeProjectile,
        CShadowControl,
        CSlideshowDisplay,
        CSmokeGrenade,
        CSmokeGrenadeProjectile,
        CSmokeStack,
        CSnowball,
        CSnowballPile,
        CSnowballProjectile,
        CSpatialEntity,
        CSpotlightEnd,
        CSprite,
        CSpriteOriented,
        CSpriteTrail,
        CStatueProp,
        CSteamJet,
        CSun,
        CSunlightShadowControl,
        CSurvivalSpawnChopper,
        CTablet,
        CTeam,
        CTeamplayRoundBasedRulesProxy,
        CTEArmorRicochet,
        CTEBaseBeam,
        CTEBeamEntPoint,
        CTEBeamEnts,
        CTEBeamFollow,
        CTEBeamLaser,
        CTEBeamPoints,
        CTEBeamRing,
        CTEBeamRingPoint,
        CTEBeamSpline,
        CTEBloodSprite,
        CTEBloodStream,
        CTEBreakModel,
        CTEBSPDecal,
        CTEBubbles,
        CTEBubbleTrail,
        CTEClientProjectile,
        CTEDecal,
        CTEDust,
        CTEDynamicLight,
        CTEEffectDispatch,
        CTEEnergySplash,
        CTEExplosion,
        CTEFireBullets,
        CTEFizz,
        CTEFootprintDecal,
        CTEFoundryHelpers,
        CTEGaussExplosion,
        CTEGlowSprite,
        CTEImpact,
        CTEKillPlayerAttachments,
        CTELargeFunnel,
        CTEMetalSparks,
        CTEMuzzleFlash,
        CTEParticleSystem,
        CTEPhysicsProp,
        CTEPlantBomb,
        CTEPlayerAnimEvent,
        CTEPlayerDecal,
        CTEProjectedDecal,
        CTERadioIcon,
        CTEShatterSurface,
        CTEShowLine,
        CTesla,
        CTESmoke,
        CTESparks,
        CTESprite,
        CTESpriteSpray,
        CTest_ProxyToggle_Networkable,
        CTestTraceline,
        CTEWorldDecal,
        CTriggerPlayerMovement,
        CTriggerSoundOperator,
        CVGuiScreen,
        CVoteController,
        CWaterBullet,
        CWaterLODControl,
        CWeaponAug,
        CWeaponAWP,
        CWeaponBaseItem,
        CWeaponBizon,
        CWeaponCSBase,
        CWeaponCSBaseGun,
        CWeaponCycler,
        CWeaponElite,
        CWeaponFamas,
        CWeaponFiveSeven,
        CWeaponG3SG1,
        CWeaponGalil,
        CWeaponGalilAR,
        CWeaponGlock,
        CWeaponHKP2000,
        CWeaponM249,
        CWeaponM3,
        CWeaponM4A1,
        CWeaponMAC10,
        CWeaponMag7,
        CWeaponMP5Navy,
        CWeaponMP7,
        CWeaponMP9,
        CWeaponNegev,
        CWeaponNOVA,
        CWeaponP228,
        CWeaponP250,
        CWeaponP90,
        CWeaponSawedoff,
        CWeaponSCAR20,
        CWeaponScout,
        CWeaponSG550,
        CWeaponSG552,
        CWeaponSG556,
        CWeaponShield,
        CWeaponSSG08,
        CWeaponTaser,
        CWeaponTec9,
        CWeaponTMP,
        CWeaponUMP45,
        CWeaponUSP,
        CWeaponXM1014,
        CWorld,
        CWorldVguiText,
        DustTrail,
        MovieExplosion,
        ParticleSmokeGrenade,
        RocketTrail,
        SmokeTrail,
        SporeExplosion,
        SporeTrail,
    };

    public enum EHitboxes
    {
        HITBOX_HEAD = 0, //0 голова
        HITBOX_NECK, // 1 шея
        HITBOX_PELVIS, //2 таз
        HITBOX_BELLY, //3 поясница
        HITBOX_THORAX, //4 живот
        HITBOX_LOWER_CHEST, //5 грудь
        HITBOX_UPPER_CHEST, //6 предплечье
        HITBOX_RIGHT_THIGH, //7 бедро
        HITBOX_LEFT_THIGH, //8 бедро
        HITBOX_RIGHT_CALF, //9 нога
        HITBOX_LEFT_CALF, //10 нога
        HITBOX_RIGHT_FOOT, //11 стопа
        HITBOX_LEFT_FOOT, //12 стопа
        HITBOX_RIGHT_HAND, //13 рука
        HITBOX_LEFT_HAND, //14 рука
        HITBOX_RIGHT_UPPER_ARM,
        HITBOX_RIGHT_FOREARM,
        HITBOX_LEFT_UPPER_ARM,
        HITBOX_LEFT_FOREARM,
        HITBOX_MAX
    };

    public enum EWeaponType
    {
        Knife = 0,
        Pistol,
        SubMachinegun,
        Rifle,
        Shotgun,
        SniperRifle,
        Machinegun,
        C4,
        Placeholder,
        Grenade,
        Unknown,
        StackableItem,
        Fists,
        BreachCharge,
        BumpMine,
        Tablet,
        Melee
    };

    public enum EMoveType : int
    {
        NOCLIP = 8,
        LADDER = 9,
    }

    [Flags]
    public enum EEntityFlags : int
    {
        FL_ONGROUND = (1 << 0), // At rest / on the ground
        FL_DUCKING = (1 << 1), // Player flag -- Player is fully crouched
        FL_WATERJUMP = (1 << 2), // player jumping out of water

        FL_ONTRAIN =
            (1 << 3), // Player is _controlling_ a train, so movement commands should be ignored on client during prediction.
        FL_INRAIN = (1 << 4), // Indicates the entity is standing in rain
        FL_FROZEN = (1 << 5), // Player is frozen for 3rd person camera
        FL_ATCONTROLS = (1 << 6), // Player can't move, but keeps key inputs for controlling another entity
        FL_CLIENT = (1 << 7), // Is a player
        FL_FAKECLIENT = (1 << 8), // Fake client, simulated server side; don't send network messages to them
        FL_INWATER = (1 << 10) // In water
    };

    [Flags]
    public enum EMaterialVarFlag
    {
        MATERIAL_VAR_DEBUG = (1 << 0),
        MATERIAL_VAR_NO_DEBUG_OVERRIDE = (1 << 1),
        MATERIAL_VAR_NO_DRAW = (1 << 2),
        MATERIAL_VAR_USE_IN_FILLRATE_MODE = (1 << 3),
        MATERIAL_VAR_VERTEXCOLOR = (1 << 4),
        MATERIAL_VAR_VERTEXALPHA = (1 << 5),
        MATERIAL_VAR_SELFILLUM = (1 << 6),
        MATERIAL_VAR_ADDITIVE = (1 << 7),
        MATERIAL_VAR_ALPHATEST = (1 << 8),

        //MATERIAL_VAR_UNUSED = (1 << 9),
        MATERIAL_VAR_ZNEARER = (1 << 10),
        MATERIAL_VAR_MODEL = (1 << 11),
        MATERIAL_VAR_FLAT = (1 << 12),
        MATERIAL_VAR_NOCULL = (1 << 13),
        MATERIAL_VAR_NOFOG = (1 << 14),
        MATERIAL_VAR_IGNOREZ = (1 << 15),
        MATERIAL_VAR_DECAL = (1 << 16),
        MATERIAL_VAR_ENVMAPSPHERE = (1 << 17), // OBSOLETE
        MATERIAL_VAR_UNUSED = (1 << 18), // UNUSED
        MATERIAL_VAR_ENVMAPCAMERASPACE = (1 << 19), // OBSOLETE
        MATERIAL_VAR_BASEALPHAENVMAPMASK = (1 << 20),
        MATERIAL_VAR_TRANSLUCENT = (1 << 21),
        MATERIAL_VAR_NORMALMAPALPHAENVMAPMASK = (1 << 22),
        MATERIAL_VAR_NEEDS_SOFTWARE_SKINNING = (1 << 23), // OBSOLETE
        MATERIAL_VAR_OPAQUETEXTURE = (1 << 24),
        MATERIAL_VAR_ENVMAPMODE = (1 << 25), // OBSOLETE
        MATERIAL_VAR_SUPPRESS_DECALS = (1 << 26),
        MATERIAL_VAR_HALFLAMBERT = (1 << 27),
        MATERIAL_VAR_WIREFRAME = (1 << 28),
        MATERIAL_VAR_ALLOWALPHATOCOVERAGE = (1 << 29),
        MATERIAL_VAR_ALPHA_MODIFIED_BY_PROXY = (1 << 30),
        MATERIAL_VAR_VERTEXFOG = (1 << 31),
    };

    public enum ESequence : int
    {
        SEQUENCE_DEFAULT_DRAW = 0,
        SEQUENCE_DEFAULT_IDLE1 = 1,
        SEQUENCE_DEFAULT_IDLE2 = 2,
        SEQUENCE_DEFAULT_LIGHT_MISS1 = 3,
        SEQUENCE_DEFAULT_LIGHT_MISS2 = 4,
        SEQUENCE_DEFAULT_HEAVY_MISS1 = 9,
        SEQUENCE_DEFAULT_HEAVY_HIT1 = 10,
        SEQUENCE_DEFAULT_HEAVY_BACKSTAB = 11,
        SEQUENCE_DEFAULT_LOOKAT01 = 12,

        SEQUENCE_BUTTERFLY_DRAW = 0,
        SEQUENCE_BUTTERFLY_DRAW2 = 1,
        SEQUENCE_BUTTERFLY_LOOKAT01 = 13,
        SEQUENCE_BUTTERFLY_LOOKAT03 = 15,

        SEQUENCE_FALCHION_IDLE1 = 1,
        SEQUENCE_FALCHION_HEAVY_MISS1 = 8,
        SEQUENCE_FALCHION_HEAVY_MISS1_NOFLIP = 9,
        SEQUENCE_FALCHION_LOOKAT01 = 12,
        SEQUENCE_FALCHION_LOOKAT02 = 13,

        SEQUENCE_CSS_LOOKAT01 = 14,
        SEQUENCE_CSS_LOOKAT02 = 15,

        SEQUENCE_DAGGERS_IDLE1 = 1,
        SEQUENCE_DAGGERS_LIGHT_MISS1 = 2,
        SEQUENCE_DAGGERS_LIGHT_MISS5 = 6,
        SEQUENCE_DAGGERS_HEAVY_MISS2 = 11,
        SEQUENCE_DAGGERS_HEAVY_MISS1 = 12,

        SEQUENCE_BOWIE_IDLE1 = 1,
    }


    public enum EItemDefinitionIndex
    {
        DEAGLE = 1,
        ELITE = 2,
        FIVESEVEN = 3,
        GLOCK = 4,
        AK47 = 7,
        AUG = 8,
        AWP = 9,
        FAMAS = 10,
        G3SG1 = 11,
        GALILAR = 13,
        M249 = 14,
        M4A1 = 16,
        MAC10 = 17,
        P90 = 19,
        MP5_SD = 23,
        UMP45 = 24,
        XM1014 = 25,
        BIZON = 26,
        MAG7 = 27,
        NEGEV = 28,
        SAWEDOFF = 29,
        TEC9 = 30,
        TASER = 31,
        HKP2000 = 32,
        MP7 = 33,
        MP9 = 34,
        NOVA = 35,
        P250 = 36,
        SCAR20 = 38,
        SG553 = 39,
        SSG08 = 40,
        KNIFE = 42,
        FLASHBANG = 43,
        HEGRENADE = 44,
        SMOKEGRENADE = 45,
        MOLOTOV = 46,
        DECOY = 47,
        INCGRENADE = 48,
        C4 = 49,
        _T_ = 59,
        M4A1_SILENCER = 60,
        USP_SILENCER = 61,
        CZ75A = 63,
        REVOLVER = 64,

        //Knifes

        BAYONET = 500,
        FLIP = 505,
        GUT = 506,
        KARAMBIT = 507,
        M9_BAYONET = 508,
        TACTICAL = 509,
        FALCHION = 512,
        SURVIVAL_BOWIE = 514,
        BUTTERFLY = 515,
        PUSH = 516,
        URSUS = 519,
        NAVAJA = 520,
        STILETTO = 522,
        WIDOWMAKER = 523,
        CLASSIC = 503,
        SKELETON = 525,
        SURVIVAL = 518,
        NOMAD = 521,
        PARACORD = 517,

        //Gloves

        STUDDED_BLOODHOUND = 5027,
        T_SIDE = 5028,
        C_TSIDE = 5029,
        SPORTY = 5030,
        SLICK = 5031,
        LEATHER_WRAP = 5032,
        MOTORCYCLE = 5033,
        SPECIALIST = 5034,
        GHYDRA = 5035
    }

    public enum ETraceType
    {
        TRACE_EVERYTHING = 0,
        TRACE_WORLD_ONLY,
        TRACE_ENTITIES_ONLY,
        TRACE_EVERYTHING_FILTER_PROPS,
    };

    public enum ESurf : uint
    {
        SKIP = 0x0200,
        NOLIGHT = 0x0400,
        BUMPLIGHT = 0x0800,
        NOSHADOWS = 0x1000,
        NODECALS = 0x2000,
        NOPAINT = NODECALS,
        NOCHOP = 0x4000,
        HITBOX = 0x8000
    }

    public enum ECharTex : uint
    {
        ANTLION = 65,
        BLOODYFLESH = 66,
        CONCRETE = 67,
        DIRT = 68,
        EGGSHELL = 69,
        FLESH = 70,
        GRATE = 71,
        ALIENFLESH = 72,
        CLIP = 73,
        PLASTIC = 76,
        METAL = 77,
        SAND,
        FOLIAGE,
        COMPUTER,
        SLOSH = 83,
        TILE,
        CARDBOARD,
        VENT,
        WOOD,
        GLASS = 89,
        WARPSHIELD,
    }

    [Flags]
    public enum EContents : uint
    {
        EMPTY = 0,
        SOLID = 0x1,
        WINDOW = 0x2,
        AUX = 0x4,
        GRATE = 0x8,
        SLIME = 0x10,
        WATER = 0x20,
        BLOCKLOS = 0x40,
        OPAQUE = 0x80,

        TESTFOGVOLUME = 0x100,
        UNUSED = 0x200,
        BLOCKLIGHT = 0x400,
        TEAM1 = 0x800,
        TEAM2 = 0x1000,
        IGNORE_NODRAW_OPAQUE = 0x2000,
        MOVEABLE = 0x4000,
        AREAPORTAL = 0x8000,
        PLAYERCLIP = 0x10000,
        MONSTERCLIP = 0x20000,
        CURRENT_0 = 0x40000,
        CURRENT_90 = 0x80000,
        CURRENT_180 = 0x100000,
        CURRENT_270 = 0x200000,
        CURRENT_UP = 0x400000,
        CURRENT_DOWN = 0x800000,

        ORIGIN = 0x1000000,

        MONSTER = 0x2000000,
        DEBRIS = 0x4000000,
        DETAIL = 0x8000000,
        TRANSLUCENT = 0x10000000,
        LADDER = 0x20000000,
        HITBOX = 0x40000000
    };

    [Flags]
    public enum EMask : uint
    {
        ALL = 0xffffffff,
        SOLID = (EContents.SOLID | EContents.MOVEABLE | EContents.WINDOW | EContents.MONSTER | EContents.GRATE),

        PLAYERSOLID = (EContents.SOLID | EContents.MOVEABLE | EContents.PLAYERCLIP | EContents.WINDOW |
                       EContents.MONSTER | EContents.GRATE),

        NPCSOLID = (EContents.SOLID | EContents.MOVEABLE | EContents.MONSTERCLIP | EContents.WINDOW |
                    EContents.MONSTER | EContents.GRATE),

        NPCFLUID =
            (EContents.SOLID | EContents.MOVEABLE | EContents.MONSTERCLIP | EContents.WINDOW | EContents.MONSTER),
        WATER = (EContents.WATER | EContents.MOVEABLE | EContents.SLIME),
        OPAQUE = (EContents.SOLID | EContents.MOVEABLE | EContents.OPAQUE),
        OPAQUE_AND_NPCS = (OPAQUE | EContents.MONSTER),
        BLOCKLOS = (EContents.SOLID | EContents.MOVEABLE | EContents.BLOCKLOS),
        BLOCKLOS_AND_NPCS = (BLOCKLOS | EContents.MONSTER),
        VISIBLE = (OPAQUE | EContents.IGNORE_NODRAW_OPAQUE),
        VISIBLE_AND_NPCS = (OPAQUE_AND_NPCS | EContents.IGNORE_NODRAW_OPAQUE),

        SHOT = (EContents.SOLID | EContents.MOVEABLE | EContents.MONSTER | EContents.WINDOW | EContents.DEBRIS |
                EContents.HITBOX),
        SHOT_BRUSHONLY = (EContents.SOLID | EContents.MOVEABLE | EContents.WINDOW | EContents.DEBRIS),

        SHOT_HULL = (EContents.SOLID | EContents.MOVEABLE | EContents.MONSTER | EContents.WINDOW | EContents.DEBRIS |
                     EContents.GRATE),
        SHOT_PORTAL = (EContents.SOLID | EContents.MOVEABLE | EContents.WINDOW | EContents.MONSTER),
        SOLID_BRUSHONLY = (EContents.SOLID | EContents.MOVEABLE | EContents.WINDOW | EContents.GRATE),

        PLAYERSOLID_BRUSHONLY = (EContents.SOLID | EContents.MOVEABLE | EContents.WINDOW | EContents.PLAYERCLIP |
                                 EContents.GRATE),

        NPCSOLID_BRUSHONLY = (EContents.SOLID | EContents.MOVEABLE | EContents.WINDOW | EContents.MONSTERCLIP |
                              EContents.GRATE),
        NPCWORLDSTATIC = (EContents.SOLID | EContents.WINDOW | EContents.MONSTERCLIP | EContents.GRATE),
        NPCWORLDSTATIC_FLUID = (EContents.SOLID | EContents.WINDOW | EContents.MONSTERCLIP),
        SPLITAREAPORTAL = (EContents.WATER | EContents.SLIME),

        CURRENT = (EContents.CURRENT_0 | EContents.CURRENT_90 | EContents.CURRENT_180 | EContents.CURRENT_270 |
                   EContents.CURRENT_UP | EContents.CURRENT_DOWN),
        DEADSOLID = (EContents.SOLID | EContents.PLAYERCLIP | EContents.WINDOW | EContents.GRATE),
    };

    public enum EOverrideType
    {
        Normal = 0,
        BuildShadows,
        DepthWrite,
        CustomMaterial, // weapon skins
        SsaoDepthWrite
    };

    public enum EFrameStage
    {
        UNDEFINED = -1,
        START,
        NET_UPDATE_START,
        NET_UPDATE_POSTDATAUPDATE_START,
        NET_UPDATE_POSTDATAUPDATE_END,
        NET_UPDATE_END,
        RENDER_START,
        RENDER_END
    };

    public enum EStickerAttribute
    {
        Index,
        Wear,
        Scale,
        Rotation
    }
}