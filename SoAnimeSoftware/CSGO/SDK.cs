using SoAnimeSoftware.CSGO.Structs;
using SoAnimeSoftware.Utils;
using SoAnimeSoftware.Objects;
using System;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Reflection;
using SoAnimeSoftware.GUI;
using SoAnimeSoftware.Hack;

namespace SoAnimeSoftware.CSGO
{
    public delegate IntPtr CreateInterface(string name, int ptr);

    public unsafe static class SDK
    {
        public static IClient Client;
        public static IEntityList EntityList;
        public static IClientMode ClientMode;
        public static IEngine Engine;
        public static IGameEventManager GameEventManager;
        public static IPanel Panel;
        public static IMaterialSystem MaterialSystem;
        public static ISurface Surface;
        public static ICVar CVar;
        public static IModelRender ModelRender;
        public static IStudioRender StudioRender;
        public static IGlowObjManager GlowObjManager;
        public static IInputSystem InputSystem;
        public static IMoveHelper MoveHelper;
        public static IPrediction Prediction;
        public static IGameMovement GameMovement;
        public static IEngineTrace EngineTrace;
        public static IModelInfo ModelInfo;
        public static ISound Sound;
        public static IDebugOverlay DebugOverlay;
        public static ILocalize Localize;
        public static IPhysicsSurfaceProps PhysicsSurfaceProps;
        public static IRenderView RenderView;
        public static IRenderToRTHelper RenderToRtHelper;

        private static CreateInterface ClientInterface;
        private static CreateInterface EngineInterface;
        private static CreateInterface VGUI2Interface;
        private static CreateInterface VGUISurfaceInterface;
        private static CreateInterface MaterialInterface;
        private static CreateInterface PhysicsInterface;
        private static CreateInterface StdInterface;
        private static CreateInterface StudioRenderInterface;
        private static CreateInterface InputSystemInterface;
        private static CreateInterface LocalizeInterface;

        public static CGlobalVars* GlobalVars;
        public static CHud* Hud;
        public static CHudWeapon* HudWeapon;
        public static CHudChat* HudChat;
        public static CMoveData* MoveData;
        public static int* m_pPredictionRandomSeed;
        public static CInput* Input;
        public static CClientState* ClientState;
        public static INetChannel* NetChannel;

        public static CConVar* game_mode;
        public static CConVar* game_type;

        public static void Init()
        {
            ClientInterface = GetCreateInterfaceFunction("client.dll");
            EngineInterface = GetCreateInterfaceFunction("engine.dll");
            VGUI2Interface = GetCreateInterfaceFunction("vgui2.dll");
            VGUISurfaceInterface = GetCreateInterfaceFunction("vguimatsurface.dll");
            MaterialInterface = GetCreateInterfaceFunction("materialsystem.dll");
            PhysicsInterface = GetCreateInterfaceFunction("vphysics.dll");
            StdInterface = GetCreateInterfaceFunction("vstdlib.dll");
            StudioRenderInterface = GetCreateInterfaceFunction("studiorender.dll");
            InputSystemInterface = GetCreateInterfaceFunction("inputsystem.dll");
            LocalizeInterface = GetCreateInterfaceFunction("localize.dll");

            Client = new IClient(GetInterfacePointer("VClient", ClientInterface));
            ClientMode =
                new IClientMode(Memory.ReadPointer(
                    Memory.ReadPointer(Memory.ReadPointer(Memory.ReadPointer(Client.Address) + 10 * 4) + 0x5)));
            Input = (CInput*) Memory.ReadPointer(Memory.ReadPointer(Memory.ReadPointer(Client.Address) + 16 * 4) + 0x1);
            EntityList = new IEntityList(GetInterfacePointer("VClientEntityList", ClientInterface));
            Engine = new IEngine(GetInterfacePointer("VEngineClient", EngineInterface));
            Engine._SetClanTag =
                Marshal.GetDelegateForFunctionPointer<IEngine.SetClanTagDlg>(Memory.FindPattern("engine.dll",
                    "53 56 57 8B DA 8B F9 FF 15"));
            GameEventManager =
                new IGameEventManager(GetInterfacePointer("GAMEEVENTSMANAGER002", EngineInterface, true));
            Panel = new IPanel(GetInterfacePointer("VGUI_Panel", VGUI2Interface));
            MaterialSystem = new IMaterialSystem(GetInterfacePointer("VMaterialSystem", MaterialInterface));
            Surface = new ISurface(GetInterfacePointer("VGUI_Surface", VGUISurfaceInterface));
            CVar = new ICVar(GetInterfacePointer("VEngineCvar", StdInterface));
            ModelRender = new IModelRender(GetInterfacePointer("VEngineModel", EngineInterface));
            StudioRender = new IStudioRender(GetInterfacePointer("VStudioRender", StudioRenderInterface));
            InputSystem = new IInputSystem(GetInterfacePointer("InputSystemVersion", InputSystemInterface));
            Prediction = new IPrediction(GetInterfacePointer("VClientPrediction", ClientInterface));
            Hud = *(CHud**) (Memory.FindPattern("client.dll", "B9 ? ? ? ? 68 ? ? ? ? E8 ? ? ? ? 89 46 24") + 1);
            HudChat = (CHudChat*) Hud->FindHudElement("CHudChat");
            HudWeapon = (CHudWeapon*) (Hud->FindHudElement("CCSGO_HudWeaponSelection") - 0x28 * 4);
            MoveHelper = new IMoveHelper(Memory.ReadPointer(
                Memory.ReadPointer(Memory.FindPattern("client.dll", "8B 0D ? ? ? ? 8B 45 ? 51 8B D4 89 02 8B 01") +
                                   2)));
            MoveData = **(CMoveData***) (Memory.FindPattern("client.dll", "A1 ? ? ? ? F3 0F 59 CD") + 1);
            GlowObjManager = new IGlowObjManager(Memory.FindPattern("client.dll", "0F 11 05 ? ? ? ? 83 C8 01") + 3);
            GlobalVars = **(CGlobalVars***) (Memory.FindPattern("client.dll", "A1 ? ? ? ? 5E 8B 40 10") + 1);
            GameMovement = new IGameMovement(GetInterfacePointer("GameMovement", ClientInterface));
            EngineTrace = new IEngineTrace(GetInterfacePointer("EngineTraceClient", EngineInterface));

            ModelInfo = new IModelInfo(GetInterfacePointer("VModelInfoClient", EngineInterface));
            ClientState =
                **(CClientState***) (Memory.FindPattern("engine.dll", "A1 ? ? ? ? 33 D2 6A 00 6A 00 33 C9 89 B0") + 1);
            //DebugOverlay = new IDebugOverlay(GetInterfacePtr("VDebugOverlay004", EngineInterface, true));
            Sound = new ISound(GetInterfacePointer("IEngineSoundClient", EngineInterface));
            Localize = new ILocalize(GetInterfacePointer("Localize_001", LocalizeInterface, true));
            PhysicsSurfaceProps =
                new IPhysicsSurfaceProps(GetInterfacePointer("VPhysicsSurfaceProps001", PhysicsInterface, true));
            RenderView = new IRenderView(GetInterfacePointer("VEngineRenderView", EngineInterface));
            RenderToRtHelper = new IRenderToRTHelper(GetInterfacePointer("RenderToRTHelper001", ClientInterface, true));

            m_pPredictionRandomSeed =
                *(int**) (Memory.FindPattern("client.dll", "8B 0D ? ? ? ? BA ? ? ? ? E8 ? ? ? ? 83 C4 04") + 2);

            Tier.Init();
            NetVarManager.Init();

            game_mode = CVar.FindVar("game_mode");
            game_type = CVar.FindVar("game_type");
        }

        public static Entity* g_LocalPlayer() => *(Entity**) Offsets.LocalPlayer;

        private static CreateInterface GetCreateInterfaceFunction(string moduleName)
        {
            return Memory.GetFunctionFromModule<CreateInterface>(moduleName, "CreateInterface");
        }

        private static IntPtr GetInterfacePointer(string interfaceName, CreateInterface cInterface,
            bool absoulute = false)
        {
            string interfaceVersion = "0";

            if (absoulute)
                return cInterface(interfaceName, 0);
            for (int i = 0; i <= 99; i++)
            {
                var tempInterface = interfaceName + interfaceVersion + i;
                var funcPtr = cInterface(tempInterface, 0);
                if (funcPtr != IntPtr.Zero)
                {
                    return funcPtr;
                }

                if (i >= 99 && interfaceVersion == "0")
                {
                    interfaceVersion = "00";
                    i = 0;
                }
            }

            return IntPtr.Zero;
        }
    }
}