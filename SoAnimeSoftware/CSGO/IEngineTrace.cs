using SoAnimeSoftware.CSGO.Structs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SoAnimeSoftware.GUI.Elements;

namespace SoAnimeSoftware.CSGO
{
    public unsafe class IEngineTrace : InterfaceBase
    {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate int GetPointContentsDlg(IntPtr ptr, ref Vector vecAbsPosition, int contentsMask,
            Entity** ppEntity);

        public GetPointContentsDlg _GetPointContents;


        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void ClipRayToEntityDlg(IntPtr ptr, ref Ray ray, uint mask, Entity* entity,
            ref CBaseTrace trace);

        public ClipRayToEntityDlg _ClipRayToEntity;


        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void TraceRayDlg(IntPtr ptr, ref Ray ray, uint mask, ref CTraceFilter filter,
            ref CBaseTrace trace);

        public TraceRayDlg _TraceRay;

        public IEngineTrace(IntPtr Address) : base(Address)
        {
            _GetPointContents = GetInterfaceFunction<GetPointContentsDlg>(0);
            _ClipRayToEntity = GetInterfaceFunction<ClipRayToEntityDlg>(3);
            _TraceRay = GetInterfaceFunction<TraceRayDlg>(5);
        }

        public int GetPointContents(ref Vector vecAbsPosition, int contentsMask)
        {
            return _GetPointContents(Address, ref vecAbsPosition, contentsMask, (Entity**) IntPtr.Zero);
        }

        public int GetPointContents(ref Vector vecAbsPosition, int contentsMask, Entity** ppEntity)
        {
            return _GetPointContents(Address, ref vecAbsPosition, contentsMask, ppEntity);
        }

        public void TraceRay(ref Ray ray, uint mask, ref CTraceFilter filter, ref CBaseTrace trace)
        {
            _TraceRay(Address, ref ray, mask, ref filter, ref trace);
            if (Settings.tracerDebug)
            {
                var color = trace.DidHit() ? new ByteColor(Color.Green) : new ByteColor(Color.Red);
                Hack.Visuals.Perception.tracers.AddLast(
                    new GameLine(DateTime.Now.AddSeconds(2), color, trace.start, trace.end));
            }
        }

        public void ClipRayToEntity(ref Ray ray, uint mask, Entity* entity, ref CBaseTrace trace)
        {
            _ClipRayToEntity(Address, ref ray, (uint) mask, entity, ref trace);
            if (Settings.tracerDebug)
            {
                var color = trace.DidHitEntity(entity) ? new ByteColor(Color.Green) : new ByteColor(Color.Red);
                Hack.Visuals.Perception.tracers.AddLast(
                    new GameLine(DateTime.Now.AddSeconds(2), color, trace.start, trace.end));
            }
        }

        public CBaseTrace ClipRayToEntity(Vector start, Vector end, Entity* entity, uint mask)
        {
            CBaseTrace trace = new CBaseTrace();
            Ray ray = new Ray(start, end);

            ClipRayToEntity(ref ray, (uint) mask, entity, ref trace);

            return trace;
        }

        public CBaseTrace TraceRay(Vector start, Vector end, EMask mask)
        {
            CBaseTrace trace = new CBaseTrace();
            CTraceFilter filter = new CTraceFilter(SDK.g_LocalPlayer());
            Ray ray = new Ray(start, end);

            TraceRay(ref ray, (uint) mask, ref filter, ref trace);

            return trace;
        }

        public CBaseTrace TraceRay(Vector start, Vector end, EMask mask, Entity* eSkip)
        {
            CBaseTrace trace = new CBaseTrace();
            CTraceFilter filter = new CTraceFilter(eSkip);
            Ray ray = new Ray(start, end);

            TraceRay(ref ray, (uint) mask, ref filter, ref trace);

            return trace;
        }

        public CBaseTrace TraceRay(Vector start, Vector end, uint mask)
        {
            CBaseTrace trace = new CBaseTrace();
            CTraceFilter filter = new CTraceFilter(SDK.g_LocalPlayer());
            Ray ray = new Ray(start, end);

            TraceRay(ref ray, (uint) mask, ref filter, ref trace);

            return trace;
        }

        public CBaseTrace TraceRay(Vector start, Vector end, uint mask, Entity* eSkip)
        {
            CBaseTrace trace = new CBaseTrace();
            CTraceFilter filter = new CTraceFilter(eSkip);
            Ray ray = new Ray(start, end);

            TraceRay(ref ray, (uint) mask, ref filter, ref trace);

            return trace;
        }
    }

    public unsafe struct Ray
    {
        public VectorAligned m_Start;
        public VectorAligned m_Delta;
        public VectorAligned m_StartOffset;
        public VectorAligned m_Extents;
        public Matrix3x4* m_pWorldAxisTransform;
        public byte m_IsRay;
        public byte m_IsSwept;

        public Ray(Vector start, Vector end)
        {
            m_Delta = end - start;

            m_IsSwept = (m_Delta.X != 0 || m_Delta.Y != 0 || m_Delta.Z != 0) ? (byte) 1 : (byte) 0;

            m_Extents = new Vector();

            m_pWorldAxisTransform = (Matrix3x4*) IntPtr.Zero;
            m_IsRay = (byte) 1;

            m_StartOffset = new Vector();
            m_Start = start;
        }
    }

    public unsafe struct CTraceFilter // CTraceFilter : ITraceFilter
    {
        public CTraceFilterVfTable* pTable;
        public Entity* skip;
        public CTraceFilterVfTable table;

        public CTraceFilter(Entity* e)
        {
            skip = e;
            table = new CTraceFilterVfTable();
            table.pShouldHitEntity = ShouldHitEntityPtr;
            table.pGetTraceType = GetTraceTypePtr;
            fixed (CTraceFilterVfTable* ptr = &table)
                pTable = ptr;
        }


        public static byte ShouldHitEntity(CTraceFilter* address, Entity* e, uint mask)
        {
            return e != address->skip ? (byte) 1 : (byte) 0;
        }

        public static int GetTraceType(CTraceFilter* address)
        {
            return 0;
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate byte ShouldHitEntityDlg(CTraceFilter* ptr, Entity* entity, uint mask);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate int GetTraceTypeDlg(CTraceFilter* ptr);

        public static ShouldHitEntityDlg ShouldHitEntityStaticDlg = ShouldHitEntity;
        public static GetTraceTypeDlg GetTraceTypeStaticDlg = GetTraceType;

        public static IntPtr ShouldHitEntityPtr = Marshal.GetFunctionPointerForDelegate(ShouldHitEntityStaticDlg);
        public static IntPtr GetTraceTypePtr = Marshal.GetFunctionPointerForDelegate(GetTraceTypeStaticDlg);
    }


    public unsafe struct CTraceFilterVfTable
    {
        public IntPtr pShouldHitEntity;
        public IntPtr pGetTraceType;
    }


    public unsafe struct CBaseTrace
    {
        public Vector start;
        public Vector end;
        public CPlane plane;
        public float fraction;
        public int contents;
        public short dispFlags;
        public byte allSolid;
        public byte startSolid;

        public float fractionLeftSolid;
        public CSurface surface;
        public int hitgroup;
        public short physicsBone;
        public short worldSurfaceIndex;
        public Entity* hit_entity;
        public int hitbox; //0x50

        public bool DidHit()
        {
            return (fraction < 1) || (allSolid != 0) || (startSolid != 0);
        }

        public bool DidHitWorld()
        {
            return hit_entity != null && hit_entity->GetIndex() == 0;
        }

        public bool DidHitEntity(Entity* e)
        {
            return hit_entity != null && hit_entity == e;
        }
    }

    public unsafe struct CPlane
    {
        public Vector normal;
        public float dist;
        public byte type;
        public byte signbits;
        public byte pad1;
        public byte pad2;
    }

    public unsafe struct CSurface
    {
        public Char_t* name;
        public short surfaceProps;
        public short flags;
    }
}