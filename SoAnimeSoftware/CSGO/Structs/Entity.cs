using SoAnimeSoftware.Hack.Combat;
using SoAnimeSoftware.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SoAnimeSoftware.Hack;
using static SoAnimeSoftware.CSGO.EItemDefinitionIndex;

namespace SoAnimeSoftware.CSGO.Structs
{
    public unsafe struct Entity
    {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate ClientClass* GetClientClassDlg(Entity* ptr);

        public ClientClass* GetClientClass()
        {
            fixed (Entity* ptr = &this)
            {
                return Memory.GetVTableFunction<GetClientClassDlg>((IntPtr) ptr + 8, 2)(ptr + 8);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void OnDataChangedDlg(Entity* ptr, int updateType);

        public void OnDataChanged(int updateType = 0)
        {
            fixed (Entity* ptr = &this)
            {
                Memory.GetVTableFunction<OnDataChangedDlg>((IntPtr) ptr + 8, 5)(ptr + 8, updateType);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void PostDataUpdateDlg(Entity* ptr, int updateType);

        public void PostDataUpdate(int updateType = 0)
        {
            fixed (Entity* ptr = &this)
            {
                Memory.GetVTableFunction<PostDataUpdateDlg>((IntPtr) ptr + 8, 7)(ptr + 8, updateType);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void PreDataUpdateDlg(Entity* ptr, int updateType);

        public void PreDataUpdate(int updateType = 0)
        {
            fixed (Entity* ptr = &this)
            {
                Memory.GetVTableFunction<PreDataUpdateDlg>((IntPtr) ptr + 8, 6)(ptr + 8, updateType);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void ClearCustomMaterialsDlg(Entity* ptr, byte purge);

        public void ClearCustomMaterials(bool purge = false)
        {
            fixed (Entity* ptr = &this)
            {
                Marshal.GetDelegateForFunctionPointer<ClearCustomMaterialsDlg>(Offsets.ClearCustomMaterialsPointer)(ptr,
                    purge ? (byte) 1 : (byte) 0);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void SetModelIndexDlg(Entity* ptr, int index);

        public void SetModelIndex(int index)
        {
            fixed (Entity* ptr = &this)
            {
                Memory.GetVTableFunction<SetModelIndexDlg>((IntPtr) ptr, 75)(ptr, index);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate int GetIndexDlg(Entity* ptr);

        public int GetIndex()
        {
            fixed (Entity* ptr = &this)
            {
                return Memory.GetVTableFunction<GetIndexDlg>((IntPtr) ptr + 8, 10)(ptr + 8);
            }
        }

        public PlayerAnimState* GetPlayerAnimState()
        {
            return *(PlayerAnimState**) (Ptr() + 0x3914);
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate byte IsDormantDlg(Entity* ptr);

        public bool IsDormant()
        {
            fixed (Entity* ptr = &this)
            {
                return Memory.GetVTableFunction<IsDormantDlg>((IntPtr) ptr + 8, 9)(ptr + 8) != 0;
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate MStudioModel* GetModelDlg(Entity* ptr);

        public MStudioModel* GetModel()
        {
            fixed (Entity* ptr = &this)
            {
                return Memory.GetVTableFunction<GetModelDlg>((IntPtr) ptr + 4, 8)(ptr + 4);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void SetAngleDlg(Entity* ptr, Vector angle);

        public void SetAngle(Vector angle)
        {
            Marshal.GetDelegateForFunctionPointer<SetAngleDlg>(Offsets.SetAnglePointer)(Ptr(), angle);
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate int DrawModelDlg(Entity* ptr, int flags, int instance);

        public int DrawModel(int flags, int instance)
        {
            fixed (Entity* ptr = &this)
            {
                return Memory.GetVTableFunction<DrawModelDlg>((IntPtr) ptr + 4, 9)(ptr + 4, flags, instance);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate byte SetupBonesDlg(Entity* ptr, ref Matrix3x4 bones, int maxBones, int boneMask,
            float currentTime);

        public bool SetupBones(ref Matrix3x4 bones, int maxBones, int boneMask, float currentTime)
        {
            fixed (Entity* ptr = &this)
            {
                var origin = m_vecOrigin;

                int* render = (int*) (ptr + 0x274);
                int backup = *render;
                var absOrigin = *GetAbsOrigin();
                *render = 0;

                SetAbsOrigin(ref origin);
                var result =
                    Memory.GetVTableFunction<SetupBonesDlg>((IntPtr) ptr + 4, 13)(ptr + 4, ref bones, maxBones, boneMask,
                        currentTime) != 0;
                SetAbsOrigin(ref absOrigin);
                *render = backup;
                return result;
            }
        }

        public string GetIcon()
        {
            var id = m_iItemDefinitionIndex;
            switch (id)
            {
                case (int) KNIFE:
                case 500:
                case 505:
                case 506:
                case 507:
                case 508:
                case 509:
                case 512:
                case 514:
                case 515:
                case 516:
                    return "]";
                case (int) DEAGLE:
                    return "A";
                case (int) ELITE:
                    return "B";
                case (int) FIVESEVEN:
                    return "C";
                case (int) GLOCK:
                    return "D";
                case (int) HKP2000:
                    return "E";
                case (int) P250:
                    return "F";
                case (int) USP_SILENCER:
                    return "G";
                case (int) TEC9:
                    return "H";
                case (int) CZ75A:
                    return "I";
                case (int) REVOLVER:
                    return "J";
                case (int) MAC10:
                    return "K";
                case (int) UMP45:
                    return "L";
                case (int) BIZON:
                    return "M";
                case (int) MP7:
                    return "N";
                case (int) MP9:
                    return "O";
                case (int) P90:
                    return "P";
                case (int) GALILAR:
                    return "Q";
                case (int) FAMAS:
                    return "R";
                case (int) M4A1_SILENCER:
                    return "S";
                case (int) M4A1:
                    return "T";
                case (int) AUG:
                    return "U";
                case (int) SG553:
                    return "V";
                case (int) AK47:
                    return "W";
                case (int) G3SG1:
                    return "X";
                case (int) SCAR20:
                    return "Y";
                case (int) AWP:
                    return "Z";
                case (int) SSG08:
                    return "a";
                case (int) XM1014:
                    return "b";
                case (int) SAWEDOFF:
                    return "c";
                case (int) MAG7:
                    return "d";
                case (int) NOVA:
                    return "e";
                case (int) NEGEV:
                    return "f";
                case (int) M249:
                    return "g";
                case (int) TASER:
                    return "h";
                case (int) FLASHBANG:
                    return "i";
                case (int) HEGRENADE:
                    return "j";
                case (int) SMOKEGRENADE:
                    return "k";
                case (int) MOLOTOV:
                    return "l";
                case (int) DECOY:
                    return "m";
                case (int) INCGRENADE:
                    return "n";
                case (int) C4:
                    return "o";
                default:
                    return " ";
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate Entity* GetObserverTargetDlg(Entity* ptr);

        public Entity* GetObserverTarget()
        {
            fixed (Entity* ptr = &this)
            {
                return Memory.GetVTableFunction<GetObserverTargetDlg>((IntPtr) ptr, 294)(ptr);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate Entity* GetActiveWeaponDlg(Entity* ptr);

        public Entity* GetActiveWeapon()
        {
            fixed (Entity* ptr = &this)
            {
                return Memory.GetVTableFunction<GetActiveWeaponDlg>((IntPtr) ptr, 267)(ptr);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate byte IsWeaponDlg(Entity* ptr);

        public bool IsWeapon()
        {
            fixed (Entity* ptr = &this)
            {
                return Memory.GetVTableFunction<IsWeaponDlg>((IntPtr) ptr, 165)(ptr) != 0;
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void SetAbsOriginDlg(Entity* ptr, ref Vector vec);

        public void SetAbsOrigin(ref Vector vec)
        {
            fixed (Entity* ptr = &this)
            {
                Marshal.GetDelegateForFunctionPointer<SetAbsOriginDlg>(Offsets.SetAbsOriginPointer)(ptr, ref vec);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate IntPtr GetEconItemViewDlg(Entity* ptr);

        public IntPtr GetEconItemView()
        {
            fixed (Entity* ptr = &this)
            {
                return Marshal.GetDelegateForFunctionPointer<GetEconItemViewDlg>(Offsets.GetEconItemViewPointer)(ptr);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate IntPtr GetItemSchemaDlg();

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate IntPtr GetPaintKitDefinitionDlg(IntPtr ptr, int paintkitid);

        public IntPtr GetPaintKitDefinition()
        {
            return
                Marshal.GetDelegateForFunctionPointer<GetPaintKitDefinitionDlg>(Offsets.GetPaintKitDefinitionPointer)(
                    Marshal.GetDelegateForFunctionPointer<GetItemSchemaDlg>(Offsets.GetItemSchemaPointer)() + 4,
                    m_nFallbackPaintKit);
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void SetAbsAnglesDlg(Entity* ptr, ref Vector vec);

        public void SetAbsAngles(ref Vector vec)
        {
            fixed (Entity* ptr = &this)
            {
                Marshal.GetDelegateForFunctionPointer<SetAbsAnglesDlg>(Offsets.SetAbsAnglesPointer)(ptr, ref vec);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate Vector* GetAbsOriginDlg(Entity* ptr);

        public Vector* GetAbsOrigin()
        {
            fixed (Entity* ptr = &this)
            {
                return Memory.GetVTableFunction<GetAbsOriginDlg>((IntPtr) ptr, 10)(ptr);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate Vector* GetAbsAnglesDlg(Entity* ptr);

        public Vector* GetAbsAngles()
        {
            fixed (Entity* ptr = &this)
            {
                return Memory.GetVTableFunction<GetAbsAnglesDlg>((IntPtr) ptr, 11)(ptr);
            }
        }

        public bool IsReloading()
        {
            return *(byte*) (Ptr() + (int) Offsets.InReload) != 0;
        }

        public void InvalidateBoneCache()
        {
            var model_bone_counter = **((uint**) (Offsets.InvalidateBoneCachePointer));

            *(uint*) (Ptr() + 0x2924) = 0xFF7FFFFF;
            *(uint*) (Ptr() + 0x2690) = model_bone_counter - 1;
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate CWeaponInfo* GetWeaponDataDlg(Entity* ptr);

        public CWeaponInfo* GetWeaponData()
        {
            fixed (Entity* ptr = &this)
            {
                return Memory.GetVTableFunction<GetWeaponDataDlg>((IntPtr) ptr, 460)(ptr);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void UpdateAccuracyPenaltyDlg(Entity* ptr);

        public void UpdateAccuracyPenalty()
        {
            fixed (Entity* ptr = &this)
            {
                Memory.GetVTableFunction<UpdateAccuracyPenaltyDlg>((IntPtr) ptr, 483)(ptr);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate float GetInaccuracyDlg(Entity* ptr);

        public float GetInaccuracy()
        {
            fixed (Entity* ptr = &this)
            {
                return Memory.GetVTableFunction<GetInaccuracyDlg>((IntPtr) ptr, 482)(ptr);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate float GetSpreadDlg(Entity* ptr);

        public float GetSpread()
        {
            fixed (Entity* ptr = &this)
            {
                return Memory.GetVTableFunction<GetSpreadDlg>((IntPtr) ptr, 452)(ptr);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate int GetSequenceActivityDlg(Entity* ptr, int sequence);

        public int GetSequenceActivity(int sequence)
        {
            return Marshal.GetDelegateForFunctionPointer<GetSequenceActivityDlg>(Offsets.GetSequenceActivityFnPointer)(
                Ptr(), sequence);
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void SendViewModelMatchingSequenceDlg(Entity* ptr, int sequence);

        public void SendViewModelMatchingSequence(int sequence)
        {
            Memory.GetVTableFunction<SendViewModelMatchingSequenceDlg>((IntPtr) Ptr(), 246)(Ptr(), sequence);
        }

        public bool IsGun()
        {
            var info = GetWeaponData();
            EWeaponType type = (EWeaponType) info->WeaponType;
            return type != EWeaponType.Grenade && type != EWeaponType.C4 && type != EWeaponType.Knife &&
                   type != EWeaponType.Fists && info->iBullets > 0;
        }

        public bool IsKnife()
        {
            var info = GetWeaponData();
            EWeaponType type = (EWeaponType) info->WeaponType;
            return type == EWeaponType.Knife;
        }

        public bool CanShoot()
        {
            fixed (Entity* ptr = &this)
            {
                if (ptr == null)
                    return false;

                if (ptr->IsReloading())
                    return false;

                if (ptr->m_flNextPrimaryAttack > SDK.GlobalVars->ServerTime(null))
                    return false;

                if (ptr->m_iClip1 <= 0)
                    return false;

                var weaponData = ptr->GetWeaponData();

                if (weaponData->iBullets <= 0)
                    return false;

                if (SDK.g_LocalPlayer()->m_iShotsFired > 0 && weaponData->bFullAuto == 0)
                    return false;
            }

            return true;
        }

        public Vector GetBonePosition(int index)
        {
            fixed (Entity* ptr = &this)
            {
                Matrix3x4[] bone_matrices = new Matrix3x4[128];
                if (SetupBones(ref bone_matrices[0], 128, 256, 0f))
                {
                    return new Vector(bone_matrices[index]._14, bone_matrices[index]._24, bone_matrices[index]._34);
                }

                return new Vector();
            }
        }

        public Vector GetBonePosition(Matrix3x4[] bone_matrices, int index)
        {
            return new Vector(bone_matrices[index]._14, bone_matrices[index]._24, bone_matrices[index]._34);
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate Vector GetAimPunchDlg(Entity* ptr, ref Vector pos);

        public Vector GetAimPunch()
        {
            fixed (Entity* ptr = &this)
            {
                Vector pos = new Vector();
                Memory.GetVTableFunction<GetAimPunchDlg>((IntPtr) ptr, 345)(ptr, ref pos);
                return pos;
            }
        }

        public bool Exist()
        {
            fixed (Entity* ptr = &this)
                return ptr != null;
        }

        public bool IsVisible()
        {
            if (SDK.g_LocalPlayer() == null)
                return false;

            var res = SDK.EngineTrace.TraceRay(SDK.g_LocalPlayer()->GetEyePosition(), this.GetBonePosition(8),
                (EMask) 0x46004009);
            return res.hit_entity == Ptr() || res.fraction > 0.97f;
        }

        public bool IsVisible(int boneIndex)
        {
            if (SDK.g_LocalPlayer() == null)
                return false;

            var res = SDK.EngineTrace.TraceRay(SDK.g_LocalPlayer()->GetEyePosition(), this.GetBonePosition(boneIndex),
                (EMask) 0x46004009);
            return res.hit_entity == Ptr() || res.fraction > 0.97f;
        }

        public bool IsVisible(Vector point)
        {
            if (SDK.g_LocalPlayer() == null)
                return false;

            var res = SDK.EngineTrace.TraceRay(SDK.g_LocalPlayer()->GetEyePosition(), point,
                (EMask) 0x46004009);
            return res.hit_entity == Ptr() || res.fraction > 0.97f;
        }

        public Vector GetEyePosition()
        {
            return m_vecOrigin + m_vecViewOffset;
        }

        public bool IsEnemy()
        {
            return m_iTeamNum != SDK.g_LocalPlayer()->m_iTeamNum;
        }

        public Matrix3x4* m_pBones
        {
            get { return *(Matrix3x4**) (Ptr() + 0x2698); }
            set { *(Matrix3x4**) (Ptr() + 0x2698) = value; }
        }

        public IntPtr BoneAccessor()
        {
            return (IntPtr) ((IntPtr) Ptr() + (int) Offsets.BoneAccessorPointer);
        }

        public void SetMatrix(Matrix3x4[] matrix)
        {
            Memory.Write((IntPtr) (*(Matrix3x4**) (Ptr() + 0x2698)), matrix);
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void SetCollisionBoundsDlg(IntPtr thisPtr, ref Vector mins, ref Vector maxs);

        public void SetCollisionBounds(ref Vector mins, ref Vector maxs)
        {
            Marshal.GetDelegateForFunctionPointer<SetCollisionBoundsDlg>(Offsets.SetCollisionBoundPointer)(m_Collision,
                ref mins, ref maxs);
        }

        public void SetCustomMatrix(ref Matrix3x4[] matrix)
        {
            fixed (Matrix3x4* ptr = &matrix[0])
                *(int*) (Ptr() + 0x26A8) = (int) ptr;
        }

        public void SetCustomMatrixPtr(IntPtr matrix)
        {
            *(int*) (Ptr() + 0x26A8) = (int) matrix;
        }

        public Matrix3x4* m_rgflCoordinateFrame
        {
            get { return (Matrix3x4*) (Ptr() + Offsets.DT_BaseEntity.m_CollisionGroup - 0x30); }
        }

        public int m_nMoveType
        {
            get { return *(int*) (Ptr() + 0x25C); }
            set { *(int*) (Ptr() + 0x25C) = value; }
        }

        public bool IsAlive()
        {
            return m_iHealth > 0;
        }

        public PlayerInfo PlayerInfo()
        {
            fixed (Entity* ptr = &this)
            {
                PlayerInfo pInfo = new PlayerInfo();
                SDK.Engine.GetPlayerInfo(ptr->GetIndex(), ref pInfo);
                return pInfo;
            }
        }

        public bool IsPlayer()
        {
            return GetClientClass()->m_ClassID == (int) EClassId.CCSPlayer;
        }

        public bool OnGround()
        {
            return (m_fFlags & (int) EEntityFlags.FL_ONGROUND) != 0;
        }

        public Entity* Ptr()
        {
            fixed (Entity* ptr = &this)
                return ptr;
        }

        public int UserID()
        {
            return PlayerInfo().userid;
        }

        public T Get<T>(string table, string netvar) where T : unmanaged
        {
            return *(T*) (Ptr() + (int) NetVarManager.GetOffset(table, netvar));
        }

        public T Get<T>(int offset) where T : unmanaged
        {
            return *(T*) (Ptr() + offset);
        }

        //public int m_iPrimaryReserveAmmoCount { get { return *(int*)(Ptr() + (int)NetVarManager.DT_BaseCombatWeapon["m_iPrimaryReserveAmmoCount"]); } set { *(int*)(Ptr() + (int)NetVarManager.DT_BaseCombatWeapon["m_iPrimaryReserveAmmoCount"]) = value; } }
        //public int m_hWeaponWorldModel { get { return *(int*)(Ptr() + (int)NetVarManager.DT_BaseCombatWeapon["m_hWeaponWorldModel"]); } set { *(int*)(Ptr() + (int)NetVarManager.DT_BaseCombatWeapon["m_hWeaponWorldModel"]) = value; } }
        //public IntPtr* m_hMyWeapons { get { return (IntPtr*)(Ptr() + (int)NetVarManager.DT_BaseCombatCharacter["m_hMyWeapons"]); } }
        //public int m_hMyWearables { get { return *(int*)(Ptr() + (int)NetVarManager.DT_BaseCombatCharacter["m_hMyWearables"]); } set { *(int*)(Ptr() + (int)NetVarManager.DT_BaseCombatCharacter["m_hMyWearables"]) = value; } }

        //public float m_flNextPrimaryAttack { get { return *(float*)(Ptr() + (int)NetVarManager.DT_BaseCombatWeapon["m_flNextPrimaryAttack"]); } set { *(float*)(Ptr() + (int)NetVarManager.DT_BaseCombatWeapon["m_flNextPrimaryAttack"]) = value; } }


        #region DT_BaseAttributableItem

        public int m_AttributeManager
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.m_AttributeManager); }
            set { *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.m_AttributeManager) = value; }
        }

        public int m_hOuter
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.m_hOuter); }
            set { *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.m_hOuter) = value; }
        }

        public int m_ProviderType
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.m_ProviderType); }
            set { *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.m_ProviderType) = value; }
        }

        public int m_iReapplyProvisionParity
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.m_iReapplyProvisionParity); }
            set { *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.m_iReapplyProvisionParity) = value; }
        }

        public int m_Item
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.m_Item); }
            set { *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.m_Item) = value; }
        }

        public int m_iItemDefinitionIndex
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.m_iItemDefinitionIndex); }
            set { *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.m_iItemDefinitionIndex) = value; }
        }

        public int m_iEntityLevel
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.m_iEntityLevel); }
            set { *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.m_iEntityLevel) = value; }
        }

        public int m_iItemIDHigh
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.m_iItemIDHigh); }
            set { *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.m_iItemIDHigh) = value; }
        }

        public int m_iItemIDLow
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.m_iItemIDLow); }
            set { *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.m_iItemIDLow) = value; }
        }

        public int m_iAccountID
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.m_iAccountID); }
            set { *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.m_iAccountID) = value; }
        }

        public int m_iEntityQuality
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.m_iEntityQuality); }
            set { *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.m_iEntityQuality) = value; }
        }

        public bool m_bInitialized
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_BaseAttributableItem.m_bInitialized)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_BaseAttributableItem.m_bInitialized) = value ? (byte) 1 : (byte) 0; }
        }

        public int m_szCustomName
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.m_szCustomName); }
            set { *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.m_szCustomName) = value; }
        }

        public int m_NetworkedDynamicAttributesForDemos
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.m_NetworkedDynamicAttributesForDemos); }
            set { *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.m_NetworkedDynamicAttributesForDemos) = value; }
        }

        public int m_Attributes
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.m_Attributes); }
            set { *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.m_Attributes) = value; }
        }

        public int lengthproxy
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.lengthproxy); }
            set { *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.lengthproxy) = value; }
        }

        public int lengthprop32
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.lengthprop32); }
            set { *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.lengthprop32) = value; }
        }

        public int m_OriginalOwnerXuidLow
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.m_OriginalOwnerXuidLow); }
            set { *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.m_OriginalOwnerXuidLow) = value; }
        }

        public int m_OriginalOwnerXuidHigh
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.m_OriginalOwnerXuidHigh); }
            set { *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.m_OriginalOwnerXuidHigh) = value; }
        }

        public int m_nFallbackPaintKit
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.m_nFallbackPaintKit); }
            set { *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.m_nFallbackPaintKit) = value; }
        }

        public int m_nFallbackSeed
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.m_nFallbackSeed); }
            set { *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.m_nFallbackSeed) = value; }
        }

        public float m_flFallbackWear
        {
            get { return *(float*) (Ptr() + Offsets.DT_BaseAttributableItem.m_flFallbackWear); }
            set { *(float*) (Ptr() + Offsets.DT_BaseAttributableItem.m_flFallbackWear) = value; }
        }

        public int m_nFallbackStatTrak
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.m_nFallbackStatTrak); }
            set { *(int*) (Ptr() + Offsets.DT_BaseAttributableItem.m_nFallbackStatTrak) = value; }
        }

        #endregion

        #region DT_CSPlayer

        public int cslocaldata
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.cslocaldata); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.cslocaldata) = value; }
        }

        public Vector m_vecOrigin
        {
            get { return *(Vector*) (Ptr() + Offsets.DT_CSPlayer.m_vecOrigin); }
            set { *(Vector*) (Ptr() + Offsets.DT_CSPlayer.m_vecOrigin) = value; }
        }

        public float m_vecOrigin_2
        {
            get { return *(float*) (Ptr() + Offsets.DT_CSPlayer.m_vecOrigin_2); }
            set { *(float*) (Ptr() + Offsets.DT_CSPlayer.m_vecOrigin_2) = value; }
        }

        public float m_flStamina
        {
            get { return *(float*) (Ptr() + Offsets.DT_CSPlayer.m_flStamina); }
            set { *(float*) (Ptr() + Offsets.DT_CSPlayer.m_flStamina) = value; }
        }

        public int m_iDirection
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iDirection); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iDirection) = value; }
        }

        public int m_iShotsFired
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iShotsFired); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iShotsFired) = value; }
        }

        public int m_nNumFastDucks
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_nNumFastDucks); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_nNumFastDucks) = value; }
        }

        public bool m_bDuckOverride
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bDuckOverride)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bDuckOverride) = value ? (byte) 1 : (byte) 0; }
        }

        public float m_flVelocityModifier
        {
            get { return *(float*) (Ptr() + Offsets.DT_CSPlayer.m_flVelocityModifier); }
            set { *(float*) (Ptr() + Offsets.DT_CSPlayer.m_flVelocityModifier) = value; }
        }

        public bool m_bPlayerDominated
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bPlayerDominated)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bPlayerDominated) = value ? (byte) 1 : (byte) 0; }
        }

        public bool m_bPlayerDominatingMe
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bPlayerDominatingMe)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bPlayerDominatingMe) = value ? (byte) 1 : (byte) 0; }
        }

        public int m_iWeaponPurchasesThisRound
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iWeaponPurchasesThisRound); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iWeaponPurchasesThisRound) = value; }
        }

        public int m_unActiveQuestId
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_unActiveQuestId); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_unActiveQuestId) = value; }
        }

        public int m_nQuestProgressReason
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_nQuestProgressReason); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_nQuestProgressReason) = value; }
        }

        public int csnonlocaldata
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.csnonlocaldata); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.csnonlocaldata) = value; }
        }

        public int csteamdata
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.csteamdata); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.csteamdata) = value; }
        }

        public int m_iWeaponPurchasesThisMatch
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iWeaponPurchasesThisMatch); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iWeaponPurchasesThisMatch) = value; }
        }

        public int m_EquippedLoadoutItemDefIndices
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_EquippedLoadoutItemDefIndices); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_EquippedLoadoutItemDefIndices) = value; }
        }

        public float m_angEyeAngles_0
        {
            get { return *(float*) (Ptr() + Offsets.DT_CSPlayer.m_angEyeAngles_0); }
            set { *(float*) (Ptr() + Offsets.DT_CSPlayer.m_angEyeAngles_0) = value; }
        }

        public float m_angEyeAngles_1
        {
            get { return *(float*) (Ptr() + Offsets.DT_CSPlayer.m_angEyeAngles_1); }
            set { *(float*) (Ptr() + Offsets.DT_CSPlayer.m_angEyeAngles_1) = value; }
        }

        public int m_iAddonBits
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iAddonBits); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iAddonBits) = value; }
        }

        public int m_iPrimaryAddon
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iPrimaryAddon); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iPrimaryAddon) = value; }
        }

        public int m_iSecondaryAddon
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iSecondaryAddon); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iSecondaryAddon) = value; }
        }

        public int m_iThrowGrenadeCounter
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iThrowGrenadeCounter); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iThrowGrenadeCounter) = value; }
        }

        public bool m_bWaitForNoAttack
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bWaitForNoAttack)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bWaitForNoAttack) = value ? (byte) 1 : (byte) 0; }
        }

        public bool m_bIsRespawningForDMBonus
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bIsRespawningForDMBonus)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bIsRespawningForDMBonus) = value ? (byte) 1 : (byte) 0; }
        }

        public int m_iPlayerState
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iPlayerState); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iPlayerState) = value; }
        }

        public int m_iAccount
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iAccount); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iAccount) = value; }
        }

        public int m_iStartAccount
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iStartAccount); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iStartAccount) = value; }
        }

        public int m_totalHitsOnServer
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_totalHitsOnServer); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_totalHitsOnServer) = value; }
        }

        public bool m_bInBombZone
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bInBombZone)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bInBombZone) = value ? (byte) 1 : (byte) 0; }
        }

        public bool m_bInBuyZone
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bInBuyZone)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bInBuyZone) = value ? (byte) 1 : (byte) 0; }
        }

        public bool m_bInNoDefuseArea
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bInNoDefuseArea)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bInNoDefuseArea) = value ? (byte) 1 : (byte) 0; }
        }

        public bool m_bKilledByTaser
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bKilledByTaser)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bKilledByTaser) = value ? (byte) 1 : (byte) 0; }
        }

        public int m_iMoveState
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iMoveState); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iMoveState) = value; }
        }

        public int m_iClass
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iClass); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iClass) = value; }
        }

        public int m_ArmorValue
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_ArmorValue); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_ArmorValue) = value; }
        }

        public Vector m_angEyeAngles
        {
            get { return *(Vector*) (Ptr() + Offsets.DT_CSPlayer.m_angEyeAngles); }
            set { *(Vector*) (Ptr() + Offsets.DT_CSPlayer.m_angEyeAngles) = value; }
        }

        public bool m_bHasDefuser
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bHasDefuser)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bHasDefuser) = value ? (byte) 1 : (byte) 0; }
        }

        public bool m_bNightVisionOn
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bNightVisionOn)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bNightVisionOn) = value ? (byte) 1 : (byte) 0; }
        }

        public bool m_bHasNightVision
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bHasNightVision)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bHasNightVision) = value ? (byte) 1 : (byte) 0; }
        }

        public bool m_bInHostageRescueZone
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bInHostageRescueZone)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bInHostageRescueZone) = value ? (byte) 1 : (byte) 0; }
        }

        public bool m_bIsDefusing
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bIsDefusing)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bIsDefusing) = value ? (byte) 1 : (byte) 0; }
        }

        public bool m_bIsGrabbingHostage
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bIsGrabbingHostage)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bIsGrabbingHostage) = value ? (byte) 1 : (byte) 0; }
        }

        public int m_iBlockingUseActionInProgress
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iBlockingUseActionInProgress); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iBlockingUseActionInProgress) = value; }
        }

        public bool m_bIsScoped
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bIsScoped)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bIsScoped) = value ? (byte) 1 : (byte) 0; }
        }

        public bool m_bIsWalking
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bIsWalking)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bIsWalking) = value ? (byte) 1 : (byte) 0; }
        }

        public int m_nIsAutoMounting
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_nIsAutoMounting); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_nIsAutoMounting) = value; }
        }

        public bool m_bResumeZoom
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bResumeZoom)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bResumeZoom) = value ? (byte) 1 : (byte) 0; }
        }

        public float m_fImmuneToGunGameDamageTime
        {
            get { return *(float*) (Ptr() + Offsets.DT_CSPlayer.m_fImmuneToGunGameDamageTime); }
            set { *(float*) (Ptr() + Offsets.DT_CSPlayer.m_fImmuneToGunGameDamageTime) = value; }
        }

        public bool m_bGunGameImmunity
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bGunGameImmunity)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bGunGameImmunity) = value ? (byte) 1 : (byte) 0; }
        }

        public bool m_bHasMovedSinceSpawn
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bHasMovedSinceSpawn)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bHasMovedSinceSpawn) = value ? (byte) 1 : (byte) 0; }
        }

        public bool m_bMadeFinalGunGameProgressiveKill
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bMadeFinalGunGameProgressiveKill)) != 0; }
            set
            {
                *(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bMadeFinalGunGameProgressiveKill) = value ? (byte) 1 : (byte) 0;
            }
        }

        public int m_iGunGameProgressiveWeaponIndex
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iGunGameProgressiveWeaponIndex); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iGunGameProgressiveWeaponIndex) = value; }
        }

        public int m_iNumGunGameTRKillPoints
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iNumGunGameTRKillPoints); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iNumGunGameTRKillPoints) = value; }
        }

        public int m_iNumGunGameKillsWithCurrentWeapon
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iNumGunGameKillsWithCurrentWeapon); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iNumGunGameKillsWithCurrentWeapon) = value; }
        }

        public int m_iNumRoundKills
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iNumRoundKills); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iNumRoundKills) = value; }
        }

        public float m_fMolotovUseTime
        {
            get { return *(float*) (Ptr() + Offsets.DT_CSPlayer.m_fMolotovUseTime); }
            set { *(float*) (Ptr() + Offsets.DT_CSPlayer.m_fMolotovUseTime) = value; }
        }

        public float m_fMolotovDamageTime
        {
            get { return *(float*) (Ptr() + Offsets.DT_CSPlayer.m_fMolotovDamageTime); }
            set { *(float*) (Ptr() + Offsets.DT_CSPlayer.m_fMolotovDamageTime) = value; }
        }

        public int m_szArmsModel
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_szArmsModel); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_szArmsModel) = value; }
        }

        public int m_hCarriedHostage
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_hCarriedHostage); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_hCarriedHostage) = value; }
        }

        public int m_hCarriedHostageProp
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_hCarriedHostageProp); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_hCarriedHostageProp) = value; }
        }

        public bool m_bIsRescuing
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bIsRescuing)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bIsRescuing) = value ? (byte) 1 : (byte) 0; }
        }

        public float m_flGroundAccelLinearFracLastTime
        {
            get { return *(float*) (Ptr() + Offsets.DT_CSPlayer.m_flGroundAccelLinearFracLastTime); }
            set { *(float*) (Ptr() + Offsets.DT_CSPlayer.m_flGroundAccelLinearFracLastTime) = value; }
        }

        public bool m_bCanMoveDuringFreezePeriod
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bCanMoveDuringFreezePeriod)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bCanMoveDuringFreezePeriod) = value ? (byte) 1 : (byte) 0; }
        }

        public int m_isCurrentGunGameLeader
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_isCurrentGunGameLeader); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_isCurrentGunGameLeader) = value; }
        }

        public int m_isCurrentGunGameTeamLeader
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_isCurrentGunGameTeamLeader); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_isCurrentGunGameTeamLeader) = value; }
        }

        public float m_flGuardianTooFarDistFrac
        {
            get { return *(float*) (Ptr() + Offsets.DT_CSPlayer.m_flGuardianTooFarDistFrac); }
            set { *(float*) (Ptr() + Offsets.DT_CSPlayer.m_flGuardianTooFarDistFrac) = value; }
        }

        public float m_flDetectedByEnemySensorTime
        {
            get { return *(float*) (Ptr() + Offsets.DT_CSPlayer.m_flDetectedByEnemySensorTime); }
            set { *(float*) (Ptr() + Offsets.DT_CSPlayer.m_flDetectedByEnemySensorTime) = value; }
        }

        public bool m_bIsPlayerGhost
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bIsPlayerGhost)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bIsPlayerGhost) = value ? (byte) 1 : (byte) 0; }
        }

        public int m_iMatchStats_Kills
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iMatchStats_Kills); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iMatchStats_Kills) = value; }
        }

        public int m_iMatchStats_Damage
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iMatchStats_Damage); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iMatchStats_Damage) = value; }
        }

        public int m_iMatchStats_EquipmentValue
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iMatchStats_EquipmentValue); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iMatchStats_EquipmentValue) = value; }
        }

        public int m_iMatchStats_MoneySaved
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iMatchStats_MoneySaved); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iMatchStats_MoneySaved) = value; }
        }

        public int m_iMatchStats_KillReward
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iMatchStats_KillReward); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iMatchStats_KillReward) = value; }
        }

        public int m_iMatchStats_LiveTime
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iMatchStats_LiveTime); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iMatchStats_LiveTime) = value; }
        }

        public int m_iMatchStats_Deaths
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iMatchStats_Deaths); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iMatchStats_Deaths) = value; }
        }

        public int m_iMatchStats_Assists
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iMatchStats_Assists); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iMatchStats_Assists) = value; }
        }

        public int m_iMatchStats_HeadShotKills
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iMatchStats_HeadShotKills); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iMatchStats_HeadShotKills) = value; }
        }

        public int m_iMatchStats_Objective
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iMatchStats_Objective); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iMatchStats_Objective) = value; }
        }

        public int m_iMatchStats_CashEarned
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iMatchStats_CashEarned); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iMatchStats_CashEarned) = value; }
        }

        public int m_iMatchStats_UtilityDamage
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iMatchStats_UtilityDamage); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iMatchStats_UtilityDamage) = value; }
        }

        public int m_iMatchStats_EnemiesFlashed
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iMatchStats_EnemiesFlashed); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iMatchStats_EnemiesFlashed) = value; }
        }

        public int m_rank
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_rank); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_rank) = value; }
        }

        public int m_passiveItems
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_passiveItems); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_passiveItems) = value; }
        }

        public bool m_bHasParachute
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bHasParachute)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bHasParachute) = value ? (byte) 1 : (byte) 0; }
        }

        public int m_unMusicID
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_unMusicID); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_unMusicID) = value; }
        }

        public bool m_bHasHelmet
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bHasHelmet)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bHasHelmet) = value ? (byte) 1 : (byte) 0; }
        }

        public bool m_bHasHeavyArmor
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bHasHeavyArmor)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bHasHeavyArmor) = value ? (byte) 1 : (byte) 0; }
        }

        public int m_nHeavyAssaultSuitCooldownRemaining
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_nHeavyAssaultSuitCooldownRemaining); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_nHeavyAssaultSuitCooldownRemaining) = value; }
        }

        public float m_flFlashDuration
        {
            get { return *(float*) (Ptr() + Offsets.DT_CSPlayer.m_flFlashDuration); }
            set { *(float*) (Ptr() + Offsets.DT_CSPlayer.m_flFlashDuration) = value; }
        }

        public float m_flFlashMaxAlpha
        {
            get { return *(float*) (Ptr() + Offsets.DT_CSPlayer.m_flFlashMaxAlpha); }
            set { *(float*) (Ptr() + Offsets.DT_CSPlayer.m_flFlashMaxAlpha) = value; }
        }

        public int m_iProgressBarDuration
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iProgressBarDuration); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iProgressBarDuration) = value; }
        }

        public float m_flProgressBarStartTime
        {
            get { return *(float*) (Ptr() + Offsets.DT_CSPlayer.m_flProgressBarStartTime); }
            set { *(float*) (Ptr() + Offsets.DT_CSPlayer.m_flProgressBarStartTime) = value; }
        }

        public int m_hRagdoll
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_hRagdoll); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_hRagdoll) = value; }
        }

        public int m_hPlayerPing
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_hPlayerPing); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_hPlayerPing) = value; }
        }

        public int m_cycleLatch
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_cycleLatch); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_cycleLatch) = value; }
        }

        public int m_unCurrentEquipmentValue
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_unCurrentEquipmentValue); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_unCurrentEquipmentValue) = value; }
        }

        public int m_unRoundStartEquipmentValue
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_unRoundStartEquipmentValue); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_unRoundStartEquipmentValue) = value; }
        }

        public int m_unFreezetimeEndEquipmentValue
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_unFreezetimeEndEquipmentValue); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_unFreezetimeEndEquipmentValue) = value; }
        }

        public bool m_bIsControllingBot
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bIsControllingBot)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bIsControllingBot) = value ? (byte) 1 : (byte) 0; }
        }

        public bool m_bHasControlledBotThisRound
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bHasControlledBotThisRound)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bHasControlledBotThisRound) = value ? (byte) 1 : (byte) 0; }
        }

        public bool m_bCanControlObservedBot
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bCanControlObservedBot)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bCanControlObservedBot) = value ? (byte) 1 : (byte) 0; }
        }

        public int m_iControlledBotEntIndex
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iControlledBotEntIndex); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iControlledBotEntIndex) = value; }
        }

        public Vector m_vecAutomoveTargetEnd
        {
            get { return *(Vector*) (Ptr() + Offsets.DT_CSPlayer.m_vecAutomoveTargetEnd); }
            set { *(Vector*) (Ptr() + Offsets.DT_CSPlayer.m_vecAutomoveTargetEnd) = value; }
        }

        public float m_flAutoMoveStartTime
        {
            get { return *(float*) (Ptr() + Offsets.DT_CSPlayer.m_flAutoMoveStartTime); }
            set { *(float*) (Ptr() + Offsets.DT_CSPlayer.m_flAutoMoveStartTime) = value; }
        }

        public float m_flAutoMoveTargetTime
        {
            get { return *(float*) (Ptr() + Offsets.DT_CSPlayer.m_flAutoMoveTargetTime); }
            set { *(float*) (Ptr() + Offsets.DT_CSPlayer.m_flAutoMoveTargetTime) = value; }
        }

        public bool m_bIsAssassinationTarget
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bIsAssassinationTarget)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bIsAssassinationTarget) = value ? (byte) 1 : (byte) 0; }
        }

        public bool m_bHud_MiniScoreHidden
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bHud_MiniScoreHidden)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bHud_MiniScoreHidden) = value ? (byte) 1 : (byte) 0; }
        }

        public bool m_bHud_RadarHidden
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bHud_RadarHidden)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bHud_RadarHidden) = value ? (byte) 1 : (byte) 0; }
        }

        public int m_nLastKillerIndex
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_nLastKillerIndex); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_nLastKillerIndex) = value; }
        }

        public int m_nLastConcurrentKilled
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_nLastConcurrentKilled); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_nLastConcurrentKilled) = value; }
        }

        public int m_nDeathCamMusic
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_nDeathCamMusic); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_nDeathCamMusic) = value; }
        }

        public bool m_bIsHoldingLookAtWeapon
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bIsHoldingLookAtWeapon)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bIsHoldingLookAtWeapon) = value ? (byte) 1 : (byte) 0; }
        }

        public bool m_bIsLookingAtWeapon
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bIsLookingAtWeapon)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bIsLookingAtWeapon) = value ? (byte) 1 : (byte) 0; }
        }

        public int m_iNumRoundKillsHeadshots
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iNumRoundKillsHeadshots); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_iNumRoundKillsHeadshots) = value; }
        }

        public int m_unTotalRoundDamageDealt
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_unTotalRoundDamageDealt); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_unTotalRoundDamageDealt) = value; }
        }

        public float m_flLowerBodyYawTarget
        {
            get { return *(float*) (Ptr() + Offsets.DT_CSPlayer.m_flLowerBodyYawTarget); }
            set { *(float*) (Ptr() + Offsets.DT_CSPlayer.m_flLowerBodyYawTarget) = value; }
        }

        public bool m_bStrafing
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bStrafing)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bStrafing) = value ? (byte) 1 : (byte) 0; }
        }

        public float m_flThirdpersonRecoil
        {
            get { return *(float*) (Ptr() + Offsets.DT_CSPlayer.m_flThirdpersonRecoil); }
            set { *(float*) (Ptr() + Offsets.DT_CSPlayer.m_flThirdpersonRecoil) = value; }
        }

        public bool m_bHideTargetID
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bHideTargetID)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bHideTargetID) = value ? (byte) 1 : (byte) 0; }
        }

        public bool m_bIsSpawnRappelling
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bIsSpawnRappelling)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_CSPlayer.m_bIsSpawnRappelling) = value ? (byte) 1 : (byte) 0; }
        }

        public Vector m_vecSpawnRappellingRopeOrigin
        {
            get { return *(Vector*) (Ptr() + Offsets.DT_CSPlayer.m_vecSpawnRappellingRopeOrigin); }
            set { *(Vector*) (Ptr() + Offsets.DT_CSPlayer.m_vecSpawnRappellingRopeOrigin) = value; }
        }

        public int m_nSurvivalTeam
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_nSurvivalTeam); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_nSurvivalTeam) = value; }
        }

        public int m_hSurvivalAssassinationTarget
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_hSurvivalAssassinationTarget); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_hSurvivalAssassinationTarget) = value; }
        }

        public float m_flHealthShotBoostExpirationTime
        {
            get { return *(float*) (Ptr() + Offsets.DT_CSPlayer.m_flHealthShotBoostExpirationTime); }
            set { *(float*) (Ptr() + Offsets.DT_CSPlayer.m_flHealthShotBoostExpirationTime) = value; }
        }

        public float m_flLastExoJumpTime
        {
            get { return *(float*) (Ptr() + Offsets.DT_CSPlayer.m_flLastExoJumpTime); }
            set { *(float*) (Ptr() + Offsets.DT_CSPlayer.m_flLastExoJumpTime) = value; }
        }

        public int m_vecPlayerPatchEconIndices
        {
            get { return *(int*) (Ptr() + Offsets.DT_CSPlayer.m_vecPlayerPatchEconIndices); }
            set { *(int*) (Ptr() + Offsets.DT_CSPlayer.m_vecPlayerPatchEconIndices) = value; }
        }

        #endregion

        #region DT_EnvTonemapController

        public bool m_bUseCustomAutoExposureMin
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_EnvTonemapController.m_bUseCustomAutoExposureMin)) != 0; }
            set
            {
                *(byte*) (Ptr() + Offsets.DT_EnvTonemapController.m_bUseCustomAutoExposureMin) =
                    value ? (byte) 1 : (byte) 0;
            }
        }

        public bool m_bUseCustomAutoExposureMax
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_EnvTonemapController.m_bUseCustomAutoExposureMax)) != 0; }
            set
            {
                *(byte*) (Ptr() + Offsets.DT_EnvTonemapController.m_bUseCustomAutoExposureMax) =
                    value ? (byte) 1 : (byte) 0;
            }
        }

        public bool m_bUseCustomBloomScale
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_EnvTonemapController.m_bUseCustomBloomScale)) != 0; }
            set
            {
                *(byte*) (Ptr() + Offsets.DT_EnvTonemapController.m_bUseCustomBloomScale) = value ? (byte) 1 : (byte) 0;
            }
        }

        public float m_flCustomAutoExposureMin
        {
            get { return *(float*) (Ptr() + Offsets.DT_EnvTonemapController.m_flCustomAutoExposureMin); }
            set { *(float*) (Ptr() + Offsets.DT_EnvTonemapController.m_flCustomAutoExposureMin) = value; }
        }

        public float m_flCustomAutoExposureMax
        {
            get { return *(float*) (Ptr() + Offsets.DT_EnvTonemapController.m_flCustomAutoExposureMax); }
            set { *(float*) (Ptr() + Offsets.DT_EnvTonemapController.m_flCustomAutoExposureMax) = value; }
        }

        public float m_flCustomBloomScale
        {
            get { return *(float*) (Ptr() + Offsets.DT_EnvTonemapController.m_flCustomBloomScale); }
            set { *(float*) (Ptr() + Offsets.DT_EnvTonemapController.m_flCustomBloomScale) = value; }
        }

        public float m_flCustomBloomScaleMinimum
        {
            get { return *(float*) (Ptr() + Offsets.DT_EnvTonemapController.m_flCustomBloomScaleMinimum); }
            set { *(float*) (Ptr() + Offsets.DT_EnvTonemapController.m_flCustomBloomScaleMinimum) = value; }
        }

        public float m_flBloomExponent
        {
            get { return *(float*) (Ptr() + Offsets.DT_EnvTonemapController.m_flBloomExponent); }
            set { *(float*) (Ptr() + Offsets.DT_EnvTonemapController.m_flBloomExponent) = value; }
        }

        public float m_flBloomSaturation
        {
            get { return *(float*) (Ptr() + Offsets.DT_EnvTonemapController.m_flBloomSaturation); }
            set { *(float*) (Ptr() + Offsets.DT_EnvTonemapController.m_flBloomSaturation) = value; }
        }

        public float m_flTonemapPercentTarget
        {
            get { return *(float*) (Ptr() + Offsets.DT_EnvTonemapController.m_flTonemapPercentTarget); }
            set { *(float*) (Ptr() + Offsets.DT_EnvTonemapController.m_flTonemapPercentTarget) = value; }
        }

        public float m_flTonemapPercentBrightPixels
        {
            get { return *(float*) (Ptr() + Offsets.DT_EnvTonemapController.m_flTonemapPercentBrightPixels); }
            set { *(float*) (Ptr() + Offsets.DT_EnvTonemapController.m_flTonemapPercentBrightPixels) = value; }
        }

        public float m_flTonemapMinAvgLum
        {
            get { return *(float*) (Ptr() + Offsets.DT_EnvTonemapController.m_flTonemapMinAvgLum); }
            set { *(float*) (Ptr() + Offsets.DT_EnvTonemapController.m_flTonemapMinAvgLum) = value; }
        }

        public float m_flTonemapRate
        {
            get { return *(float*) (Ptr() + Offsets.DT_EnvTonemapController.m_flTonemapRate); }
            set { *(float*) (Ptr() + Offsets.DT_EnvTonemapController.m_flTonemapRate) = value; }
        }

        #endregion

        #region DT_BasePlayer

        public int localdata
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.localdata); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.localdata) = value; }
        }

        public int m_Local
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_Local); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_Local) = value; }
        }

        public int m_chAreaBits
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_chAreaBits); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_chAreaBits) = value; }
        }

        public int m_chAreaPortalBits
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_chAreaPortalBits); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_chAreaPortalBits) = value; }
        }

        public int m_iHideHUD
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_iHideHUD); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_iHideHUD) = value; }
        }

        public float m_flFOVRate
        {
            get { return *(float*) (Ptr() + Offsets.DT_BasePlayer.m_flFOVRate); }
            set { *(float*) (Ptr() + Offsets.DT_BasePlayer.m_flFOVRate) = value; }
        }

        public bool m_bDucked
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_BasePlayer.m_bDucked)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_BasePlayer.m_bDucked) = value ? (byte) 1 : (byte) 0; }
        }

        public bool m_bDucking
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_BasePlayer.m_bDucking)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_BasePlayer.m_bDucking) = value ? (byte) 1 : (byte) 0; }
        }

        public float m_flLastDuckTime
        {
            get { return *(float*) (Ptr() + Offsets.DT_BasePlayer.m_flLastDuckTime); }
            set { *(float*) (Ptr() + Offsets.DT_BasePlayer.m_flLastDuckTime) = value; }
        }

        public bool m_bInDuckJump
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_BasePlayer.m_bInDuckJump)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_BasePlayer.m_bInDuckJump) = value ? (byte) 1 : (byte) 0; }
        }

        public int m_nDuckTimeMsecs
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_nDuckTimeMsecs); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_nDuckTimeMsecs) = value; }
        }

        public int m_nDuckJumpTimeMsecs
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_nDuckJumpTimeMsecs); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_nDuckJumpTimeMsecs) = value; }
        }

        public int m_nJumpTimeMsecs
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_nJumpTimeMsecs); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_nJumpTimeMsecs) = value; }
        }

        public float m_flFallVelocity
        {
            get { return *(float*) (Ptr() + Offsets.DT_BasePlayer.m_flFallVelocity); }
            set { *(float*) (Ptr() + Offsets.DT_BasePlayer.m_flFallVelocity) = value; }
        }

        public Vector m_viewPunchAngle
        {
            get { return *(Vector*) (Ptr() + Offsets.DT_BasePlayer.m_viewPunchAngle); }
            set { *(Vector*) (Ptr() + Offsets.DT_BasePlayer.m_viewPunchAngle) = value; }
        }

        public Vector m_aimPunchAngle
        {
            get { return *(Vector*) (Ptr() + Offsets.DT_BasePlayer.m_aimPunchAngle); }
            set { *(Vector*) (Ptr() + Offsets.DT_BasePlayer.m_aimPunchAngle) = value; }
        }

        public Vector m_aimPunchAngleVel
        {
            get { return *(Vector*) (Ptr() + Offsets.DT_BasePlayer.m_aimPunchAngleVel); }
            set { *(Vector*) (Ptr() + Offsets.DT_BasePlayer.m_aimPunchAngleVel) = value; }
        }

        public bool m_bDrawViewmodel
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_BasePlayer.m_bDrawViewmodel)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_BasePlayer.m_bDrawViewmodel) = value ? (byte) 1 : (byte) 0; }
        }

        public bool m_bWearingSuit
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_BasePlayer.m_bWearingSuit)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_BasePlayer.m_bWearingSuit) = value ? (byte) 1 : (byte) 0; }
        }

        public bool m_bPoisoned
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_BasePlayer.m_bPoisoned)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_BasePlayer.m_bPoisoned) = value ? (byte) 1 : (byte) 0; }
        }

        public float m_flStepSize
        {
            get { return *(float*) (Ptr() + Offsets.DT_BasePlayer.m_flStepSize); }
            set { *(float*) (Ptr() + Offsets.DT_BasePlayer.m_flStepSize) = value; }
        }

        public bool m_bAllowAutoMovement
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_BasePlayer.m_bAllowAutoMovement)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_BasePlayer.m_bAllowAutoMovement) = value ? (byte) 1 : (byte) 0; }
        }

        public int m_skybox3d_scale
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_skybox3d_scale); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_skybox3d_scale) = value; }
        }

        public Vector m_skybox3d_origin
        {
            get { return *(Vector*) (Ptr() + Offsets.DT_BasePlayer.m_skybox3d_origin); }
            set { *(Vector*) (Ptr() + Offsets.DT_BasePlayer.m_skybox3d_origin) = value; }
        }

        public int m_skybox3d_area
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_skybox3d_area); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_skybox3d_area) = value; }
        }

        public int m_skybox3d_fog_enable
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_skybox3d_fog_enable); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_skybox3d_fog_enable) = value; }
        }

        public int m_skybox3d_fog_blend
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_skybox3d_fog_blend); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_skybox3d_fog_blend) = value; }
        }

        public Vector m_skybox3d_fog_dirPrimary
        {
            get { return *(Vector*) (Ptr() + Offsets.DT_BasePlayer.m_skybox3d_fog_dirPrimary); }
            set { *(Vector*) (Ptr() + Offsets.DT_BasePlayer.m_skybox3d_fog_dirPrimary) = value; }
        }

        public int m_skybox3d_fog_colorPrimary
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_skybox3d_fog_colorPrimary); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_skybox3d_fog_colorPrimary) = value; }
        }

        public int m_skybox3d_fog_colorSecondary
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_skybox3d_fog_colorSecondary); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_skybox3d_fog_colorSecondary) = value; }
        }

        public float m_skybox3d_fog_start
        {
            get { return *(float*) (Ptr() + Offsets.DT_BasePlayer.m_skybox3d_fog_start); }
            set { *(float*) (Ptr() + Offsets.DT_BasePlayer.m_skybox3d_fog_start) = value; }
        }

        public float m_skybox3d_fog_end
        {
            get { return *(float*) (Ptr() + Offsets.DT_BasePlayer.m_skybox3d_fog_end); }
            set { *(float*) (Ptr() + Offsets.DT_BasePlayer.m_skybox3d_fog_end) = value; }
        }

        public float m_skybox3d_fog_maxdensity
        {
            get { return *(float*) (Ptr() + Offsets.DT_BasePlayer.m_skybox3d_fog_maxdensity); }
            set { *(float*) (Ptr() + Offsets.DT_BasePlayer.m_skybox3d_fog_maxdensity) = value; }
        }

        public float m_skybox3d_fog_HDRColorScale
        {
            get { return *(float*) (Ptr() + Offsets.DT_BasePlayer.m_skybox3d_fog_HDRColorScale); }
            set { *(float*) (Ptr() + Offsets.DT_BasePlayer.m_skybox3d_fog_HDRColorScale) = value; }
        }

        public Vector m_audio_localSound_0
        {
            get { return *(Vector*) (Ptr() + Offsets.DT_BasePlayer.m_audio_localSound_0); }
            set { *(Vector*) (Ptr() + Offsets.DT_BasePlayer.m_audio_localSound_0) = value; }
        }

        public Vector m_audio_localSound_1
        {
            get { return *(Vector*) (Ptr() + Offsets.DT_BasePlayer.m_audio_localSound_1); }
            set { *(Vector*) (Ptr() + Offsets.DT_BasePlayer.m_audio_localSound_1) = value; }
        }

        public Vector m_audio_localSound_2
        {
            get { return *(Vector*) (Ptr() + Offsets.DT_BasePlayer.m_audio_localSound_2); }
            set { *(Vector*) (Ptr() + Offsets.DT_BasePlayer.m_audio_localSound_2) = value; }
        }

        public Vector m_audio_localSound_3
        {
            get { return *(Vector*) (Ptr() + Offsets.DT_BasePlayer.m_audio_localSound_3); }
            set { *(Vector*) (Ptr() + Offsets.DT_BasePlayer.m_audio_localSound_3) = value; }
        }

        public Vector m_audio_localSound_4
        {
            get { return *(Vector*) (Ptr() + Offsets.DT_BasePlayer.m_audio_localSound_4); }
            set { *(Vector*) (Ptr() + Offsets.DT_BasePlayer.m_audio_localSound_4) = value; }
        }

        public Vector m_audio_localSound_5
        {
            get { return *(Vector*) (Ptr() + Offsets.DT_BasePlayer.m_audio_localSound_5); }
            set { *(Vector*) (Ptr() + Offsets.DT_BasePlayer.m_audio_localSound_5) = value; }
        }

        public Vector m_audio_localSound_6
        {
            get { return *(Vector*) (Ptr() + Offsets.DT_BasePlayer.m_audio_localSound_6); }
            set { *(Vector*) (Ptr() + Offsets.DT_BasePlayer.m_audio_localSound_6) = value; }
        }

        public Vector m_audio_localSound_7
        {
            get { return *(Vector*) (Ptr() + Offsets.DT_BasePlayer.m_audio_localSound_7); }
            set { *(Vector*) (Ptr() + Offsets.DT_BasePlayer.m_audio_localSound_7) = value; }
        }

        public int m_audio_soundscapeIndex
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_audio_soundscapeIndex); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_audio_soundscapeIndex) = value; }
        }

        public int m_audio_localBits
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_audio_localBits); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_audio_localBits) = value; }
        }

        public int m_audio_entIndex
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_audio_entIndex); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_audio_entIndex) = value; }
        }

        public Vector m_vecViewOffset
        {
            get { return *(Vector*) (Ptr() + Offsets.DT_BasePlayer.m_vecViewOffset_0); }
            set { *(Vector*) (Ptr() + Offsets.DT_BasePlayer.m_vecViewOffset_0) = value; }
        }

        public float m_vecViewOffset_1
        {
            get { return *(float*) (Ptr() + Offsets.DT_BasePlayer.m_vecViewOffset_1); }
            set { *(float*) (Ptr() + Offsets.DT_BasePlayer.m_vecViewOffset_1) = value; }
        }

        public float m_vecViewOffset_2
        {
            get { return *(float*) (Ptr() + Offsets.DT_BasePlayer.m_vecViewOffset_2); }
            set { *(float*) (Ptr() + Offsets.DT_BasePlayer.m_vecViewOffset_2) = value; }
        }

        public float m_flFriction
        {
            get { return *(float*) (Ptr() + Offsets.DT_BasePlayer.m_flFriction); }
            set { *(float*) (Ptr() + Offsets.DT_BasePlayer.m_flFriction) = value; }
        }

        public int m_fOnTarget
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_fOnTarget); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_fOnTarget) = value; }
        }

        public int m_nTickBase
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_nTickBase); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_nTickBase) = value; }
        }

        public int m_nNextThinkTick
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_nNextThinkTick); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_nNextThinkTick) = value; }
        }

        public int m_hLastWeapon
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_hLastWeapon); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_hLastWeapon) = value; }
        }

        public Vector m_vecVelocity
        {
            get { return *(Vector*) (Ptr() + Offsets.DT_BasePlayer.m_vecVelocity_0); }
            set { *(Vector*) (Ptr() + Offsets.DT_BasePlayer.m_vecVelocity_0) = value; }
        }

        public float m_vecVelocity_1
        {
            get { return *(float*) (Ptr() + Offsets.DT_BasePlayer.m_vecVelocity_1); }
            set { *(float*) (Ptr() + Offsets.DT_BasePlayer.m_vecVelocity_1) = value; }
        }

        public float m_vecVelocity_2
        {
            get { return *(float*) (Ptr() + Offsets.DT_BasePlayer.m_vecVelocity_2); }
            set { *(float*) (Ptr() + Offsets.DT_BasePlayer.m_vecVelocity_2) = value; }
        }

        public Vector m_vecBaseVelocity
        {
            get { return *(Vector*) (Ptr() + Offsets.DT_BasePlayer.m_vecBaseVelocity); }
            set { *(Vector*) (Ptr() + Offsets.DT_BasePlayer.m_vecBaseVelocity) = value; }
        }

        public int m_hConstraintEntity
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_hConstraintEntity); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_hConstraintEntity) = value; }
        }

        public Vector m_vecConstraintCenter
        {
            get { return *(Vector*) (Ptr() + Offsets.DT_BasePlayer.m_vecConstraintCenter); }
            set { *(Vector*) (Ptr() + Offsets.DT_BasePlayer.m_vecConstraintCenter) = value; }
        }

        public float m_flConstraintRadius
        {
            get { return *(float*) (Ptr() + Offsets.DT_BasePlayer.m_flConstraintRadius); }
            set { *(float*) (Ptr() + Offsets.DT_BasePlayer.m_flConstraintRadius) = value; }
        }

        public float m_flConstraintWidth
        {
            get { return *(float*) (Ptr() + Offsets.DT_BasePlayer.m_flConstraintWidth); }
            set { *(float*) (Ptr() + Offsets.DT_BasePlayer.m_flConstraintWidth) = value; }
        }

        public float m_flConstraintSpeedFactor
        {
            get { return *(float*) (Ptr() + Offsets.DT_BasePlayer.m_flConstraintSpeedFactor); }
            set { *(float*) (Ptr() + Offsets.DT_BasePlayer.m_flConstraintSpeedFactor) = value; }
        }

        public bool m_bConstraintPastRadius
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_BasePlayer.m_bConstraintPastRadius)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_BasePlayer.m_bConstraintPastRadius) = value ? (byte) 1 : (byte) 0; }
        }

        public float m_flDeathTime
        {
            get { return *(float*) (Ptr() + Offsets.DT_BasePlayer.m_flDeathTime); }
            set { *(float*) (Ptr() + Offsets.DT_BasePlayer.m_flDeathTime) = value; }
        }

        public float m_flNextDecalTime
        {
            get { return *(float*) (Ptr() + Offsets.DT_BasePlayer.m_flNextDecalTime); }
            set { *(float*) (Ptr() + Offsets.DT_BasePlayer.m_flNextDecalTime) = value; }
        }

        public float m_fForceTeam
        {
            get { return *(float*) (Ptr() + Offsets.DT_BasePlayer.m_fForceTeam); }
            set { *(float*) (Ptr() + Offsets.DT_BasePlayer.m_fForceTeam) = value; }
        }

        public float m_flLaggedMovementValue
        {
            get { return *(float*) (Ptr() + Offsets.DT_BasePlayer.m_flLaggedMovementValue); }
            set { *(float*) (Ptr() + Offsets.DT_BasePlayer.m_flLaggedMovementValue) = value; }
        }

        public int m_hTonemapController
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_hTonemapController); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_hTonemapController) = value; }
        }

        public int pl
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.pl); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.pl) = value; }
        }

        public int deadflag
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.deadflag); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.deadflag) = value; }
        }

        public int m_iFOV
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_iFOV); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_iFOV) = value; }
        }

        public int m_iFOVStart
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_iFOVStart); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_iFOVStart) = value; }
        }

        public float m_flFOVTime
        {
            get { return *(float*) (Ptr() + Offsets.DT_BasePlayer.m_flFOVTime); }
            set { *(float*) (Ptr() + Offsets.DT_BasePlayer.m_flFOVTime) = value; }
        }

        public int m_iDefaultFOV
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_iDefaultFOV); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_iDefaultFOV) = value; }
        }

        public int m_hZoomOwner
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_hZoomOwner); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_hZoomOwner) = value; }
        }

        public int m_afPhysicsFlags
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_afPhysicsFlags); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_afPhysicsFlags) = value; }
        }

        public int m_hVehicle
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_hVehicle); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_hVehicle) = value; }
        }

        public int m_hUseEntity
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_hUseEntity); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_hUseEntity) = value; }
        }

        public int m_hGroundEntity
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_hGroundEntity); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_hGroundEntity) = value; }
        }

        public int m_iHealth
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_iHealth); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_iHealth) = value; }
        }

        public int m_lifeState
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_lifeState); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_lifeState) = value; }
        }

        public int m_iAmmo
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_iAmmo); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_iAmmo) = value; }
        }

        public int m_iBonusProgress
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_iBonusProgress); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_iBonusProgress) = value; }
        }

        public int m_iBonusChallenge
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_iBonusChallenge); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_iBonusChallenge) = value; }
        }

        public float m_flMaxspeed
        {
            get { return *(float*) (Ptr() + Offsets.DT_BasePlayer.m_flMaxspeed); }
            set { *(float*) (Ptr() + Offsets.DT_BasePlayer.m_flMaxspeed) = value; }
        }

        public int m_fFlags
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_fFlags); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_fFlags) = value; }
        }

        public int m_iObserverMode
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_iObserverMode); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_iObserverMode) = value; }
        }

        public bool m_bActiveCameraMan
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_BasePlayer.m_bActiveCameraMan)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_BasePlayer.m_bActiveCameraMan) = value ? (byte) 1 : (byte) 0; }
        }

        public bool m_bCameraManXRay
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_BasePlayer.m_bCameraManXRay)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_BasePlayer.m_bCameraManXRay) = value ? (byte) 1 : (byte) 0; }
        }

        public bool m_bCameraManOverview
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_BasePlayer.m_bCameraManOverview)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_BasePlayer.m_bCameraManOverview) = value ? (byte) 1 : (byte) 0; }
        }

        public bool m_bCameraManScoreBoard
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_BasePlayer.m_bCameraManScoreBoard)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_BasePlayer.m_bCameraManScoreBoard) = value ? (byte) 1 : (byte) 0; }
        }

        public int m_uCameraManGraphs
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_uCameraManGraphs); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_uCameraManGraphs) = value; }
        }

        public int m_iDeathPostEffect
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_iDeathPostEffect); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_iDeathPostEffect) = value; }
        }

        public int m_hObserverTarget
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_hObserverTarget); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_hObserverTarget) = value; }
        }

        public int m_hViewModel
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_hViewModel_0); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_hViewModel_0) = value; }
        }

        public int m_hViewModel_
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_hViewModel); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_hViewModel) = value; }
        }

        public int m_iCoachingTeam
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_iCoachingTeam); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_iCoachingTeam) = value; }
        }

        public int m_szLastPlaceName
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_szLastPlaceName); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_szLastPlaceName) = value; }
        }

        public Vector m_vecLadderNormal
        {
            get { return *(Vector*) (Ptr() + Offsets.DT_BasePlayer.m_vecLadderNormal); }
            set { *(Vector*) (Ptr() + Offsets.DT_BasePlayer.m_vecLadderNormal) = value; }
        }

        public int m_ladderSurfaceProps
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_ladderSurfaceProps); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_ladderSurfaceProps) = value; }
        }

        public int m_ubEFNoInterpParity
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_ubEFNoInterpParity); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_ubEFNoInterpParity) = value; }
        }

        public int m_hPostProcessCtrl
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_hPostProcessCtrl); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_hPostProcessCtrl) = value; }
        }

        public int m_hColorCorrectionCtrl
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_hColorCorrectionCtrl); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_hColorCorrectionCtrl) = value; }
        }

        public int m_PlayerFog_m_hCtrl
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_PlayerFog_m_hCtrl); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_PlayerFog_m_hCtrl) = value; }
        }

        public int m_vphysicsCollisionState
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_vphysicsCollisionState); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_vphysicsCollisionState) = value; }
        }

        public int m_hViewEntity
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_hViewEntity); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_hViewEntity) = value; }
        }

        public bool m_bShouldDrawPlayerWhileUsingViewEntity
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_BasePlayer.m_bShouldDrawPlayerWhileUsingViewEntity)) != 0; }
            set
            {
                *(byte*) (Ptr() + Offsets.DT_BasePlayer.m_bShouldDrawPlayerWhileUsingViewEntity) =
                    value ? (byte) 1 : (byte) 0;
            }
        }

        public float m_flDuckAmount
        {
            get { return *(float*) (Ptr() + Offsets.DT_BasePlayer.m_flDuckAmount); }
            set { *(float*) (Ptr() + Offsets.DT_BasePlayer.m_flDuckAmount) = value; }
        }

        public float m_flDuckSpeed
        {
            get { return *(float*) (Ptr() + Offsets.DT_BasePlayer.m_flDuckSpeed); }
            set { *(float*) (Ptr() + Offsets.DT_BasePlayer.m_flDuckSpeed) = value; }
        }

        public int m_nWaterLevel
        {
            get { return *(int*) (Ptr() + Offsets.DT_BasePlayer.m_nWaterLevel); }
            set { *(int*) (Ptr() + Offsets.DT_BasePlayer.m_nWaterLevel) = value; }
        }

        #endregion

        #region DT_BaseEntity

        public int AnimTimeMustBeFirst
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseEntity.AnimTimeMustBeFirst); }
            set { *(int*) (Ptr() + Offsets.DT_BaseEntity.AnimTimeMustBeFirst) = value; }
        }

        public int m_flAnimTime
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseEntity.m_flAnimTime); }
            set { *(int*) (Ptr() + Offsets.DT_BaseEntity.m_flAnimTime) = value; }
        }

        public float m_flSimulationTime
        {
            get { return *(float*) (Ptr() + Offsets.DT_BaseEntity.m_flSimulationTime); }
            set { *(float*) (Ptr() + Offsets.DT_BaseEntity.m_flSimulationTime) = value; }
        }

        public int m_cellbits
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseEntity.m_cellbits); }
            set { *(int*) (Ptr() + Offsets.DT_BaseEntity.m_cellbits) = value; }
        }

        public int m_cellX
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseEntity.m_cellX); }
            set { *(int*) (Ptr() + Offsets.DT_BaseEntity.m_cellX) = value; }
        }

        public int m_cellY
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseEntity.m_cellY); }
            set { *(int*) (Ptr() + Offsets.DT_BaseEntity.m_cellY) = value; }
        }

        public int m_cellZ
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseEntity.m_cellZ); }
            set { *(int*) (Ptr() + Offsets.DT_BaseEntity.m_cellZ) = value; }
        }

        public Vector m_angRotation
        {
            get { return *(Vector*) (Ptr() + Offsets.DT_BaseEntity.m_angRotation); }
            set { *(Vector*) (Ptr() + Offsets.DT_BaseEntity.m_angRotation) = value; }
        }

        public int m_nModelIndex
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseEntity.m_nModelIndex); }
            set { *(int*) (Ptr() + Offsets.DT_BaseEntity.m_nModelIndex) = value; }
        }

        public int m_fEffects
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseEntity.m_fEffects); }
            set { *(int*) (Ptr() + Offsets.DT_BaseEntity.m_fEffects) = value; }
        }

        public int m_nRenderMode
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseEntity.m_nRenderMode); }
            set { *(int*) (Ptr() + Offsets.DT_BaseEntity.m_nRenderMode) = value; }
        }

        public int m_nRenderFX
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseEntity.m_nRenderFX); }
            set { *(int*) (Ptr() + Offsets.DT_BaseEntity.m_nRenderFX) = value; }
        }

        public int m_clrRender
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseEntity.m_clrRender); }
            set { *(int*) (Ptr() + Offsets.DT_BaseEntity.m_clrRender) = value; }
        }

        public int m_iTeamNum
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseEntity.m_iTeamNum); }
            set { *(int*) (Ptr() + Offsets.DT_BaseEntity.m_iTeamNum) = value; }
        }

        public int m_iPendingTeamNum
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseEntity.m_iPendingTeamNum); }
            set { *(int*) (Ptr() + Offsets.DT_BaseEntity.m_iPendingTeamNum) = value; }
        }

        public int m_CollisionGroup
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseEntity.m_CollisionGroup); }
            set { *(int*) (Ptr() + Offsets.DT_BaseEntity.m_CollisionGroup) = value; }
        }

        public float m_flElasticity
        {
            get { return *(float*) (Ptr() + Offsets.DT_BaseEntity.m_flElasticity); }
            set { *(float*) (Ptr() + Offsets.DT_BaseEntity.m_flElasticity) = value; }
        }

        public float m_flShadowCastDistance
        {
            get { return *(float*) (Ptr() + Offsets.DT_BaseEntity.m_flShadowCastDistance); }
            set { *(float*) (Ptr() + Offsets.DT_BaseEntity.m_flShadowCastDistance) = value; }
        }

        public int m_hOwnerEntity
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseEntity.m_hOwnerEntity); }
            set { *(int*) (Ptr() + Offsets.DT_BaseEntity.m_hOwnerEntity) = value; }
        }

        public int m_hEffectEntity
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseEntity.m_hEffectEntity); }
            set { *(int*) (Ptr() + Offsets.DT_BaseEntity.m_hEffectEntity) = value; }
        }

        public int moveparent
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseEntity.moveparent); }
            set { *(int*) (Ptr() + Offsets.DT_BaseEntity.moveparent) = value; }
        }

        public int m_iParentAttachment
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseEntity.m_iParentAttachment); }
            set { *(int*) (Ptr() + Offsets.DT_BaseEntity.m_iParentAttachment) = value; }
        }

        public int m_iName
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseEntity.m_iName); }
            set { *(int*) (Ptr() + Offsets.DT_BaseEntity.m_iName) = value; }
        }

        public int movetype
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseEntity.movetype); }
            set { *(int*) (Ptr() + Offsets.DT_BaseEntity.movetype) = value; }
        }

        public int movecollide
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseEntity.movecollide); }
            set { *(int*) (Ptr() + Offsets.DT_BaseEntity.movecollide) = value; }
        }

        public IntPtr m_Collision
        {
            get { return (IntPtr) (Ptr() + Offsets.DT_BaseEntity.m_Collision); }
            set { *(IntPtr*) (Ptr() + Offsets.DT_BaseEntity.m_Collision) = value; }
        }

        //public Vector m_vecMins { get { return *(Vector*)(Ptr() + Offsets.DT_BaseEntity.m_vecMins); } set { *(Vector*)(Ptr() + Offsets.DT_BaseEntity.m_vecMins) = value; } }
        //public Vector m_vecMaxs { get { return *(Vector*)(Ptr() + Offsets.DT_BaseEntity.m_vecMaxs); } set { *(Vector*)(Ptr() + Offsets.DT_BaseEntity.m_vecMaxs) = value; } }
        public Vector* m_vecMins
        {
            get { return (Vector*) (Ptr() + Offsets.DT_BaseEntity.m_vecMins); }
        }

        public Vector* m_vecMaxs
        {
            get { return (Vector*) (Ptr() + Offsets.DT_BaseEntity.m_vecMaxs); }
        }

        public int m_nSolidType
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseEntity.m_nSolidType); }
            set { *(int*) (Ptr() + Offsets.DT_BaseEntity.m_nSolidType) = value; }
        }

        public int m_usSolidFlags
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseEntity.m_usSolidFlags); }
            set { *(int*) (Ptr() + Offsets.DT_BaseEntity.m_usSolidFlags) = value; }
        }

        public int m_nSurroundType
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseEntity.m_nSurroundType); }
            set { *(int*) (Ptr() + Offsets.DT_BaseEntity.m_nSurroundType) = value; }
        }

        public int m_triggerBloat
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseEntity.m_triggerBloat); }
            set { *(int*) (Ptr() + Offsets.DT_BaseEntity.m_triggerBloat) = value; }
        }

        public Vector m_vecSpecifiedSurroundingMins
        {
            get { return *(Vector*) (Ptr() + Offsets.DT_BaseEntity.m_vecSpecifiedSurroundingMins); }
            set { *(Vector*) (Ptr() + Offsets.DT_BaseEntity.m_vecSpecifiedSurroundingMins) = value; }
        }

        public Vector m_vecSpecifiedSurroundingMaxs
        {
            get { return *(Vector*) (Ptr() + Offsets.DT_BaseEntity.m_vecSpecifiedSurroundingMaxs); }
            set { *(Vector*) (Ptr() + Offsets.DT_BaseEntity.m_vecSpecifiedSurroundingMaxs) = value; }
        }

        public int m_iTextureFrameIndex
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseEntity.m_iTextureFrameIndex); }
            set { *(int*) (Ptr() + Offsets.DT_BaseEntity.m_iTextureFrameIndex) = value; }
        }

        public bool m_bSimulatedEveryTick
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_BaseEntity.m_bSimulatedEveryTick)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_BaseEntity.m_bSimulatedEveryTick) = value ? (byte) 1 : (byte) 0; }
        }

        public bool m_bAnimatedEveryTick
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_BaseEntity.m_bAnimatedEveryTick)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_BaseEntity.m_bAnimatedEveryTick) = value ? (byte) 1 : (byte) 0; }
        }

        public bool m_bAlternateSorting
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_BaseEntity.m_bAlternateSorting)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_BaseEntity.m_bAlternateSorting) = value ? (byte) 1 : (byte) 0; }
        }

        public bool m_bSpotted
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_BaseEntity.m_bSpotted)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_BaseEntity.m_bSpotted) = value ? (byte) 1 : (byte) 0; }
        }

        public bool m_bSpottedBy
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_BaseEntity.m_bSpottedBy)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_BaseEntity.m_bSpottedBy) = value ? (byte) 1 : (byte) 0; }
        }

        public bool m_bSpottedByMask
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_BaseEntity.m_bSpottedByMask)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_BaseEntity.m_bSpottedByMask) = value ? (byte) 1 : (byte) 0; }
        }

        public bool m_bIsAutoaimTarget
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_BaseEntity.m_bIsAutoaimTarget)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_BaseEntity.m_bIsAutoaimTarget) = value ? (byte) 1 : (byte) 0; }
        }

        public float m_fadeMinDist
        {
            get { return *(float*) (Ptr() + Offsets.DT_BaseEntity.m_fadeMinDist); }
            set { *(float*) (Ptr() + Offsets.DT_BaseEntity.m_fadeMinDist) = value; }
        }

        public float m_fadeMaxDist
        {
            get { return *(float*) (Ptr() + Offsets.DT_BaseEntity.m_fadeMaxDist); }
            set { *(float*) (Ptr() + Offsets.DT_BaseEntity.m_fadeMaxDist) = value; }
        }

        public float m_flFadeScale
        {
            get { return *(float*) (Ptr() + Offsets.DT_BaseEntity.m_flFadeScale); }
            set { *(float*) (Ptr() + Offsets.DT_BaseEntity.m_flFadeScale) = value; }
        }

        public int m_nMinCPULevel
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseEntity.m_nMinCPULevel); }
            set { *(int*) (Ptr() + Offsets.DT_BaseEntity.m_nMinCPULevel) = value; }
        }

        public int m_nMaxCPULevel
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseEntity.m_nMaxCPULevel); }
            set { *(int*) (Ptr() + Offsets.DT_BaseEntity.m_nMaxCPULevel) = value; }
        }

        public int m_nMinGPULevel
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseEntity.m_nMinGPULevel); }
            set { *(int*) (Ptr() + Offsets.DT_BaseEntity.m_nMinGPULevel) = value; }
        }

        public int m_nMaxGPULevel
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseEntity.m_nMaxGPULevel); }
            set { *(int*) (Ptr() + Offsets.DT_BaseEntity.m_nMaxGPULevel) = value; }
        }

        public float m_flUseLookAtAngle
        {
            get { return *(float*) (Ptr() + Offsets.DT_BaseEntity.m_flUseLookAtAngle); }
            set { *(float*) (Ptr() + Offsets.DT_BaseEntity.m_flUseLookAtAngle) = value; }
        }

        public float m_flLastMadeNoiseTime
        {
            get { return *(float*) (Ptr() + Offsets.DT_BaseEntity.m_flLastMadeNoiseTime); }
            set { *(float*) (Ptr() + Offsets.DT_BaseEntity.m_flLastMadeNoiseTime) = value; }
        }

        public float m_flMaxFallVelocity
        {
            get { return *(float*) (Ptr() + Offsets.DT_BaseEntity.m_flMaxFallVelocity); }
            set { *(float*) (Ptr() + Offsets.DT_BaseEntity.m_flMaxFallVelocity) = value; }
        }

        public bool m_bEligibleForScreenHighlight
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_BaseEntity.m_bEligibleForScreenHighlight)) != 0; }
            set
            {
                *(byte*) (Ptr() + Offsets.DT_BaseEntity.m_bEligibleForScreenHighlight) = value ? (byte) 1 : (byte) 0;
            }
        }

        #endregion

        #region DT_BaseCombatCharacter

        public int bcc_localdata
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseCombatCharacter.bcc_localdata); }
            set { *(int*) (Ptr() + Offsets.DT_BaseCombatCharacter.bcc_localdata) = value; }
        }

        public float m_flNextAttack
        {
            get { return *(float*) (Ptr() + Offsets.DT_BaseCombatCharacter.m_flNextAttack); }
            set { *(float*) (Ptr() + Offsets.DT_BaseCombatCharacter.m_flNextAttack) = value; }
        }

        public int bcc_nonlocaldata
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseCombatCharacter.bcc_nonlocaldata); }
            set { *(int*) (Ptr() + Offsets.DT_BaseCombatCharacter.bcc_nonlocaldata) = value; }
        }

        public IntPtr* m_hMyWeapons
        {
            get { return (IntPtr*) (Ptr() + Offsets.DT_BaseCombatCharacter.m_hMyWeapons); }
        }

        public int m_LastHitGroup
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseCombatCharacter.m_LastHitGroup); }
            set { *(int*) (Ptr() + Offsets.DT_BaseCombatCharacter.m_LastHitGroup) = value; }
        }

        public int m_hActiveWeapon
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseCombatCharacter.m_hActiveWeapon); }
            set { *(int*) (Ptr() + Offsets.DT_BaseCombatCharacter.m_hActiveWeapon) = value; }
        }

        public float m_flTimeOfLastInjury
        {
            get { return *(float*) (Ptr() + Offsets.DT_BaseCombatCharacter.m_flTimeOfLastInjury); }
            set { *(float*) (Ptr() + Offsets.DT_BaseCombatCharacter.m_flTimeOfLastInjury) = value; }
        }

        public int m_nRelativeDirectionOfLastInjury
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseCombatCharacter.m_nRelativeDirectionOfLastInjury); }
            set { *(int*) (Ptr() + Offsets.DT_BaseCombatCharacter.m_nRelativeDirectionOfLastInjury) = value; }
        }

        public int m_hMyWearables
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseCombatCharacter.m_hMyWearables); }
            set { *(int*) (Ptr() + Offsets.DT_BaseCombatCharacter.m_hMyWearables) = value; }
        }

        #endregion

        #region DT_BaseViewModel

        //public int m_nModelIndex { get { return *(int*)(Ptr() + Offsets.DT_BaseViewModel.m_nModelIndex); } set { *(int*)(Ptr() + Offsets.DT_BaseViewModel.m_nModelIndex) = value; } }
        public int m_hWeapon
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseViewModel.m_hWeapon); }
            set { *(int*) (Ptr() + Offsets.DT_BaseViewModel.m_hWeapon) = value; }
        }

        public int m_nSkin
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseViewModel.m_nSkin); }
            set { *(int*) (Ptr() + Offsets.DT_BaseViewModel.m_nSkin) = value; }
        }

        public int m_nBody
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseViewModel.m_nBody); }
            set { *(int*) (Ptr() + Offsets.DT_BaseViewModel.m_nBody) = value; }
        }

        public int m_nSequence
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseViewModel.m_nSequence); }
            set { *(int*) (Ptr() + Offsets.DT_BaseViewModel.m_nSequence) = value; }
        }

        public int m_nViewModelIndex
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseViewModel.m_nViewModelIndex); }
            set { *(int*) (Ptr() + Offsets.DT_BaseViewModel.m_nViewModelIndex) = value; }
        }

        public float m_flPlaybackRate
        {
            get { return *(float*) (Ptr() + Offsets.DT_BaseViewModel.m_flPlaybackRate); }
            set { *(float*) (Ptr() + Offsets.DT_BaseViewModel.m_flPlaybackRate) = value; }
        }

        public int m_nAnimationParity
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseViewModel.m_nAnimationParity); }
            set { *(int*) (Ptr() + Offsets.DT_BaseViewModel.m_nAnimationParity) = value; }
        }

        public int m_hOwner
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseViewModel.m_hOwner); }
            set { *(int*) (Ptr() + Offsets.DT_BaseViewModel.m_hOwner) = value; }
        }

        public int m_nNewSequenceParity
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseViewModel.m_nNewSequenceParity); }
            set { *(int*) (Ptr() + Offsets.DT_BaseViewModel.m_nNewSequenceParity) = value; }
        }

        public int m_nResetEventsParity
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseViewModel.m_nResetEventsParity); }
            set { *(int*) (Ptr() + Offsets.DT_BaseViewModel.m_nResetEventsParity) = value; }
        }

        public int m_nMuzzleFlashParity
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseViewModel.m_nMuzzleFlashParity); }
            set { *(int*) (Ptr() + Offsets.DT_BaseViewModel.m_nMuzzleFlashParity) = value; }
        }

        public bool m_bShouldIgnoreOffsetAndAccuracy
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_BaseViewModel.m_bShouldIgnoreOffsetAndAccuracy)) != 0; }
            set
            {
                *(byte*) (Ptr() + Offsets.DT_BaseViewModel.m_bShouldIgnoreOffsetAndAccuracy) =
                    value ? (byte) 1 : (byte) 0;
            }
        }

        #endregion

        #region DT_BaseCombatWeapon

        public int LocalWeaponData
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseCombatWeapon.LocalWeaponData); }
            set { *(int*) (Ptr() + Offsets.DT_BaseCombatWeapon.LocalWeaponData) = value; }
        }

        public int m_iPrimaryAmmoType
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseCombatWeapon.m_iPrimaryAmmoType); }
            set { *(int*) (Ptr() + Offsets.DT_BaseCombatWeapon.m_iPrimaryAmmoType) = value; }
        }

        public int m_iSecondaryAmmoType
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseCombatWeapon.m_iSecondaryAmmoType); }
            set { *(int*) (Ptr() + Offsets.DT_BaseCombatWeapon.m_iSecondaryAmmoType) = value; }
        }

        //public int m_nViewModelIndex { get { return *(int*)(Ptr() + Offsets.DT_BaseCombatWeapon.m_nViewModelIndex); } set { *(int*)(Ptr() + Offsets.DT_BaseCombatWeapon.m_nViewModelIndex) = value; } }
        public bool m_bFlipViewModel
        {
            get { return (*(byte*) (Ptr() + Offsets.DT_BaseCombatWeapon.m_bFlipViewModel)) != 0; }
            set { *(byte*) (Ptr() + Offsets.DT_BaseCombatWeapon.m_bFlipViewModel) = value ? (byte) 1 : (byte) 0; }
        }

        public int m_iWeaponOrigin
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseCombatWeapon.m_iWeaponOrigin); }
            set { *(int*) (Ptr() + Offsets.DT_BaseCombatWeapon.m_iWeaponOrigin) = value; }
        }

        public int m_iWeaponModule
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseCombatWeapon.m_iWeaponModule); }
            set { *(int*) (Ptr() + Offsets.DT_BaseCombatWeapon.m_iWeaponModule) = value; }
        }

        public int LocalActiveWeaponData
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseCombatWeapon.LocalActiveWeaponData); }
            set { *(int*) (Ptr() + Offsets.DT_BaseCombatWeapon.LocalActiveWeaponData) = value; }
        }

        public float m_flNextPrimaryAttack
        {
            get { return *(float*) (Ptr() + Offsets.DT_BaseCombatWeapon.m_flNextPrimaryAttack); }
            set { *(float*) (Ptr() + Offsets.DT_BaseCombatWeapon.m_flNextPrimaryAttack) = value; }
        }

        public float m_flNextSecondaryAttack
        {
            get { return *(float*) (Ptr() + Offsets.DT_BaseCombatWeapon.m_flNextSecondaryAttack); }
            set { *(float*) (Ptr() + Offsets.DT_BaseCombatWeapon.m_flNextSecondaryAttack) = value; }
        }

        //public int m_nNextThinkTick { get { return *(int*)(Ptr() + Offsets.DT_BaseCombatWeapon.m_nNextThinkTick); } set { *(int*)(Ptr() + Offsets.DT_BaseCombatWeapon.m_nNextThinkTick) = value; } }
        public float m_flTimeWeaponIdle
        {
            get { return *(float*) (Ptr() + Offsets.DT_BaseCombatWeapon.m_flTimeWeaponIdle); }
            set { *(float*) (Ptr() + Offsets.DT_BaseCombatWeapon.m_flTimeWeaponIdle) = value; }
        }

        public int m_iViewModelIndex
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseCombatWeapon.m_iViewModelIndex); }
            set { *(int*) (Ptr() + Offsets.DT_BaseCombatWeapon.m_iViewModelIndex) = value; }
        }

        public int m_iWorldModelIndex
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseCombatWeapon.m_iWorldModelIndex); }
            set { *(int*) (Ptr() + Offsets.DT_BaseCombatWeapon.m_iWorldModelIndex) = value; }
        }

        public int m_iWorldDroppedModelIndex
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseCombatWeapon.m_iWorldDroppedModelIndex); }
            set { *(int*) (Ptr() + Offsets.DT_BaseCombatWeapon.m_iWorldDroppedModelIndex) = value; }
        }

        public int m_iState
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseCombatWeapon.m_iState); }
            set { *(int*) (Ptr() + Offsets.DT_BaseCombatWeapon.m_iState) = value; }
        }

        //public int m_hOwner { get { return *(int*)(Ptr() + Offsets.DT_BaseCombatWeapon.m_hOwner); } set { *(int*)(Ptr() + Offsets.DT_BaseCombatWeapon.m_hOwner) = value; } }
        public int m_iClip1
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseCombatWeapon.m_iClip1); }
            set { *(int*) (Ptr() + Offsets.DT_BaseCombatWeapon.m_iClip1) = value; }
        }

        public int m_iClip2
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseCombatWeapon.m_iClip2); }
            set { *(int*) (Ptr() + Offsets.DT_BaseCombatWeapon.m_iClip2) = value; }
        }

        public int m_iPrimaryReserveAmmoCount
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseCombatWeapon.m_iPrimaryReserveAmmoCount); }
            set { *(int*) (Ptr() + Offsets.DT_BaseCombatWeapon.m_iPrimaryReserveAmmoCount) = value; }
        }

        public int m_iSecondaryReserveAmmoCount
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseCombatWeapon.m_iSecondaryReserveAmmoCount); }
            set { *(int*) (Ptr() + Offsets.DT_BaseCombatWeapon.m_iSecondaryReserveAmmoCount) = value; }
        }

        public int m_hWeaponWorldModel
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseCombatWeapon.m_hWeaponWorldModel); }
            set { *(int*) (Ptr() + Offsets.DT_BaseCombatWeapon.m_hWeaponWorldModel) = value; }
        }

        public int m_iNumEmptyAttacks
        {
            get { return *(int*) (Ptr() + Offsets.DT_BaseCombatWeapon.m_iNumEmptyAttacks); }
            set { *(int*) (Ptr() + Offsets.DT_BaseCombatWeapon.m_iNumEmptyAttacks) = value; }
        }

        #endregion
    }
}