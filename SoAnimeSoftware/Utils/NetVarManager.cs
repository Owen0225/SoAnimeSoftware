using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoAnimeSoftware.CSGO.Structs;
using SoAnimeSoftware.CSGO;
using System.Security.Policy;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Windows.Markup;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices;

namespace SoAnimeSoftware.Utils
{
    public unsafe static class NetVarManager
    {
        #region Hashtables

        public static Dictionary<string, Hashtable> NetVars = new Dictionary<string, Hashtable>();

        #endregion

        public static string tablename = "";
        public static string oldtablename = "1";
        public static Dictionary<string, bool> ready = new Dictionary<string, bool>();

        public unsafe static void Init()
        {
            for (ClientClass* i = CSGO.SDK.Client.GetAllClasses(); i != null; i = i->m_pNext)
            {
                tablename = i->m_pRecvTable->m_pNetTableName->ToString();
                var table = DumpTable(i->m_pRecvTable);
                NetVars.Add(tablename, table);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate int ViewModelSequenceDlg(CRecvProxyData* pDataConst, IntPtr pStruct, IntPtr pOut);

        public unsafe static Hashtable DumpTable(RecvTable* table, int offset = 0)
        {
            Hashtable hashtable = new Hashtable();
            for (int i = 0; i < table->m_nProps; i++)
            {
                RecvProp* prop = (RecvProp*) ((IntPtr) table->m_pProps + i * sizeof(RecvProp));

                if (prop == null)
                    continue;
                if (prop->m_pVarName->Contains("baseclass") || prop->m_pVarName->ToString().StartsWith("0") ||
                    prop->m_pVarName->ToString().StartsWith("1") || prop->m_pVarName->ToString().StartsWith("2"))
                    continue;

                if (!hashtable.ContainsKey(prop->m_pVarName->ToString()))
                {
                    hashtable.Add(prop->m_pVarName->ToString(), prop->m_Offset + offset);

                    string[] manualDump =
                    {
                        //"DT_BaseEntity", "DT_BasePlayer", "DT_CSPlayer", "DT_BaseViewModel",
                        //"DT_BaseAttributableItem",
                        //"DT_EnvTonemapController",
                        //"DT_BaseCombatCharacter",
                        //"DT_BaseCombatWeapon",
                    };

                    if (manualDump.Contains(tablename))
                    {
                        var propName = prop->m_pVarName->ToString();
                        var sharpPropName = propName[propName.Length - 1] == ']'
                            ? propName.Substring(0, propName.Length - 3) + '_' + propName[propName.Length - 2]
                            : propName;
                        sharpPropName = sharpPropName.Replace('.', '_');


                        var newtable = oldtablename != tablename;

                        var typename = ((RecvType) prop->m_RecvType).ToString("G");
                        if (prop->m_RecvType > 3)
                            typename = "int";

                        if (Char.IsDigit(sharpPropName[0]))
                            sharpPropName = '_' + sharpPropName;


                        typename = typename.ToLower().Replace("DPT_".ToLower(), "").Replace("XY".ToLower(), "");
                        if (typename[0] == 'v')
                            typename = typename.Replace('v', 'V');

                        //if (newtable)
                        //    Console.WriteLine($"}}");
                        //
                        //if (newtable)
                        //    Console.WriteLine($"public static class {tablename} {{");

                        //Console.WriteLine($"public static int {sharpPropName} = NetVarManager.GetOffset(\"{tablename}\", \"{propName}\");");

                        if (newtable)
                            Console.WriteLine("#endregion");

                        if (newtable)
                            Console.WriteLine($"#region {tablename}");


                        if (prop->m_pVarName->ToString().StartsWith("m_b"))
                        {
                            Console.WriteLine(
                                $"public bool {sharpPropName} {{ get {{ return (*(byte*)(Ptr() + Offsets.{tablename}.{sharpPropName})) != 0; }} set {{ *(byte*)(Ptr() + Offsets.{tablename}.{sharpPropName}) = value ? (byte)1 : (byte)0; }} }}");
                        }
                        else
                        {
                            Console.WriteLine(
                                $"public {typename} {sharpPropName} {{ get{{ return *({typename}*)(Ptr() + Offsets.{tablename}.{sharpPropName}); }} set {{ *({typename}*)(Ptr() + Offsets.{tablename}.{sharpPropName}) = value; }} }}");
                        }

                        oldtablename = tablename;
                    }
                }

                if (prop->m_pDataTable != null)
                {
                    foreach (DictionaryEntry entry in DumpTable(prop->m_pDataTable, offset: prop->m_Offset + offset))
                    {
                        if (!hashtable.ContainsKey(entry.Key))
                        {
                            hashtable.Add(entry.Key, entry.Value);
                        }
                    }
                }
            }

            return hashtable;
        }

        public static int GetOffset(string table, string propName)
        {
            for (ClientClass* i = CSGO.SDK.Client.GetAllClasses(); i != null; i = i->m_pNext)
            {
                tablename = i->m_pRecvTable->m_pNetTableName->ToString();
                if (tablename == table)
                {
                    var offset = GetOffset(i->m_pRecvTable, propName, 0);
                    if (offset == -1) Log.Error($"Bad offset for {tablename} {propName}.");
                    return offset;
                }
            }

            Log.Error($"Bad offset for {tablename} {propName}.");
            return -1;
        }

        public static int GetOffset(RecvTable* table, string propName, int offset)
        {
            for (int i = 0; i < table->m_nProps; i++)
            {
                RecvProp* prop = (RecvProp*) ((IntPtr) table->m_pProps + i * sizeof(RecvProp));

                if (prop == null)
                    continue;
                if (prop->m_pVarName->Contains("baseclass") || prop->m_pVarName->ToString().StartsWith("0") ||
                    prop->m_pVarName->ToString().StartsWith("1") || prop->m_pVarName->ToString().StartsWith("2"))
                    continue;

                if (prop->m_pVarName->ToString() == propName)
                    return prop->m_Offset + offset;

                if (prop->m_pDataTable != null)
                {
                    var result = GetOffset(prop->m_pDataTable, propName, prop->m_Offset + offset);
                    if (result != -1)
                        return result;
                }
            }

            return -1;
        }

        public static RecvProp* GetProp(string tableName, string propName)
        {
            for (ClientClass* i = SDK.Client.GetAllClasses(); i != null; i = i->m_pNext)
            {
                var table = i->m_pRecvTable;
                if (table->m_pNetTableName->ToString() == tableName)
                {
                    for (int j = 0; j < table->m_nProps; j++)
                    {
                        RecvProp* prop = (RecvProp*) ((IntPtr) table->m_pProps + j * sizeof(RecvProp));

                        if (prop == null)
                            continue;
                        if (prop->m_pVarName->Contains("baseclass") ||
                            prop->m_pVarName->ToString().StartsWith("0") ||
                            prop->m_pVarName->ToString().StartsWith("1") ||
                            prop->m_pVarName->ToString().StartsWith("2"))
                            continue;

                        if (prop->m_pVarName->ToString() == propName)
                        {
                            return prop;
                        }
                    }
                }
            }

            return null;
        }


        public enum RecvType
        {
            DPT_Int = 0,
            DPT_Float,
            DPT_Vector,
            DPT_VectorXY, // Only encodes the XY of a vector, ignores Z
            DPT_String,
            DPT_Array, // An array of the base types (can't be of datatables).
            DPT_DataTable,
            DPT_Quaternion,
            DPT_Int64,
            DPT_NUMSendPropTypes
        }

        #region DebugDumper

        public unsafe static void DebugDumpFull()
        {
            for (ClientClass* i = CSGO.SDK.Client.GetAllClasses(); i != null; i = i->m_pNext)
            {
                Console.WriteLine(i->m_pNetworkName->ToString());
                Console.WriteLine("__" + i->m_pRecvTable->m_pNetTableName->ToString());
                DumpTable(i->m_pRecvTable, 2, 0);
            }
        }

        public unsafe static void DumpTable(RecvTable* table, int depth, int offset = 0)
        {
            for (int i = 0; i < table->m_nProps; i++)
            {
                RecvProp* prop = (RecvProp*) ((IntPtr) table->m_pProps + i * sizeof(RecvProp));

                try
                {
                    if (prop == null)
                        continue;
                    if (prop->m_pVarName->Contains("baseclass") || prop->m_pVarName->ToString().StartsWith("0") ||
                        prop->m_pVarName->ToString().StartsWith("1") || prop->m_pVarName->ToString().StartsWith("2"))
                        continue;

                    Console.WriteLine(new string(' ', depth * 2) + prop->m_pVarName->ToString() + "  0x" +
                                      (prop->m_Offset + offset).ToString("X"));

                    if (prop->m_pDataTable != null)
                    {
                        DumpTable(prop->m_pDataTable, depth + 1, (prop->m_Offset + offset));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(((IntPtr) prop).ToString("X"));
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        #endregion
    }

    public unsafe struct CRecvProxyData
    {
        RecvProp* m_pRecvProp;
        public DVariant m_Value;
        int m_iElement;
        int m_ObjectID;
    }

    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct DVariant
    {
        [FieldOffset(0)] float m_Float;
        [FieldOffset(0)] public int m_Int;
        [FieldOffset(0)] char* m_pString;
        [FieldOffset(0)] void* m_pData;
        [FieldOffset(0)] Vector m_Vector;
        [FieldOffset(0)] long m_Int64;
        [FieldOffset(0)] int m_Type;
    }
}