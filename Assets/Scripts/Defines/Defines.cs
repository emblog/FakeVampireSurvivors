using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.ComponentModel;
using System.IO;
using System.Text;

#if UNITY_EDITOR

using System.Runtime.CompilerServices;

#endif

// Fake Vampire Survivors 네임 스페이스정리
namespace FVS { }
namespace FVS.Defines { }
namespace FVS.GameDefines { } // todo : 사이즈 봐서 없앨수도 있음

// naming convention
// FVS : Fake Vampire Survivors 이 프로젝트를 말 함
// ~~ DBData : 데이터 저장시 사용하는 타입 ( from server or from save file )
// ~~ TableData : 테이블에있는 데이터와 1:1 매칭되는 타입
// 
// prefix ------------------------------------
// 멤버변수 m_
// 아규먼트 a_
// 전역변수 g_
// 로컬변수는 안붙임

// 써드파티
// LitJson - 커밋넘버 4df8ec7 - https://github.com/LitJSON/litjson
// 

namespace FVS.Defines
{
	static public class Path
	{
		public readonly static string PREFAB_PATH = "Prefab\\";
		public readonly static string PREFAB_PATH_ADD = "Prefab\\{0}";
	}

	static public class EXTMethod
	{
		// GameObject
		public static GameObject Instantiate_asChild(this GameObject a_objParent, string a_strPrefabName)
		{
			if (string.IsNullOrEmpty(a_strPrefabName) == true)
			{
				Debug.LogError("arg error");
				return null;
			}

			string FileName_withPath = string.Format(Path.PREFAB_PATH_ADD, a_strPrefabName);

			GameObject objPrefab = Resources.Load(FileName_withPath) as GameObject;

			if (objPrefab == null)
			{
				Debug.LogError("logic error");
				return null;
			}

			return a_objParent.Instantiate_asChild(objPrefab);
		}

		public static GameObject Instantiate_asChild(this GameObject a_objParent, GameObject a_objPrefab)
		{
			GameObject objChild = GameObject.Instantiate(a_objPrefab) as GameObject;

			if (objChild != null)
			{
				objChild.transform.parent = a_objParent.transform;
				objChild.transform.localPosition = Vector3.zero;
				objChild.transform.localRotation = Quaternion.identity;
				objChild.transform.localScale = Vector3.one;
				objChild.layer = a_objParent.layer;
			}

			return objChild;
		}

		// enum
		public static string ToDesc(this System.Enum a_eEnumVal)
		{
			var da = (DescriptionAttribute[])(a_eEnumVal.GetType().GetField(a_eEnumVal.ToString())).GetCustomAttributes(typeof(DescriptionAttribute), false);
			return da.Length > 0 ? da[0].Description : a_eEnumVal.ToString();
		}
	}

	public enum eLog
	{
		Log,
		Warning,
		Error,
	}

	static class FVS
	{
		// Log
		[System.Diagnostics.Conditional("UNITY_EDITOR")]
		public static void Log(string a_strLog, eLog a_eLogType = eLog.Error,
								[CallerFilePath] string a_sFilePath = "",
								[CallerLineNumber] int a_nLineNum = 0) // 로그성 데이터
		{
			_Log(a_strLog, a_eLogType, a_sFilePath, a_nLineNum);
		}

		public static void LogError(string a_strLog,
								[CallerFilePath] string a_sFilePath = "",
								[CallerLineNumber] int a_nLineNum = 0) // 에러는 무조건 출력하는게 맞음
		{
			_Log(a_strLog, eLog.Error, a_sFilePath, a_nLineNum);
		}

		static void _Log(string a_strLog, eLog a_eLogType = eLog.Error,
								string a_sFilePath = "",
								int a_nLineNum = 0)
		{
			StringBuilder s = new StringBuilder("[<color=red>");
			s.Append(System.IO.Path.GetFileName(a_sFilePath));
			s.Append("</color>][<color=red>");
			s.Append(a_nLineNum);
			s.Append("</color>] ");
			s.Append(a_strLog);

			switch (a_eLogType)
			{
				case eLog.Log:
					{
						Debug.Log(s.ToString());
					}
					break;
				case eLog.Warning:
					{
						Debug.LogWarning(s.ToString());
					}
					break;
				case eLog.Error:
					{
						Debug.LogError(s.ToString());
					}
					break;
			}
		}
	}

	public enum ETable
	{
		[Description("")]
		None = -1,

		[Description("0")]
		Config,

		[Description("755314011")]
		String,

		[Description("862757383")]
		EquipmentType,
		
		[Description("406417124")]
		Skill,

		[Description("1146574653")]
		Stat,

		[Description("1022096175")]
		Stage,

		Max,
	}

	public enum OutGame
	{
		// MaxEquipmentSlot = (int)EEquipSlot.Max,
	}

	public enum EScene
	{
		Lobby,
		Game
	}

	public enum ESkillType
	{
		None = 0,

		Trigger,	// 기본적으로 모든 공격은 전부 트리거 스킬
		Passive,	// 그 외 스탯
		Active,		// 혹시 나~~중에 만들지도 모르는 액티브스킬
	}

	public enum ESkillID
	{
		None = 0,
		NoSkill = 0,
		
		__MainSkill__ = 0, // 인게임 메인 스킬

		LightningCoil,
		Boomerang,
		FireBottle,
		Saver,
		Shield,
		Stone,
		Ball,
		Rocket,
		AtypeDrone, // black
		BtypeDrone, // white
		Doorian,
		DrillShot,
		Laser,
		ModularMine,

		__EquipmentSkill__, // 아웃게임에서 장비한 무기로 부터 적용되는 메인스킬

		Shuriken,
		Rebolber,
		Bat,
		Shotgun,
		Katana,
		LihgtChaser,
		PowerOfDestruction,

		__InGame_ItemSkill__, // 인게임에서 아이템을 얻었을 경우의 스킬

		__InGame_FusionSkill__, // 인게임에서 아이템과, 특정 메인스킬 등의 조합으로 생성되는 스킬

		__Equipment_PassiveSkill__, // 무기포함 모든 장비에서 얻는 패시브 스킬

		__InGame_ItemPassiveSkill__, // 인게임 아이템에서 얻는 패시브 스킬

		__InGame_FusionPassiveSkill__, // 인게임에서 조합으로 생기는 패시브 스킬

		__Equipment_ActiveSkill__, // 무기포함 모든 장비에서 얻는 액티브 스킬

		__InGame_ItemActiveSkill__, // 인게임 아이템에서 얻는 액티브 스킬

		__InGame_FusionActiveSkill__, // 인게임에서 조합으로 생기는 액티브 스킬

	}

	public enum EEquipSlot
	{
		None = 0,

		Weapon = 1,
		Accessary = 2,
		Glove = 3,
		BodyArmor = 4,
		Belt = 5,
		Shoes = 6,

		Max,
	}

	public enum EStatObtainSource
	{
		None = 0,

		UserLevel = 0, // 스탯의 경우 user level 에 따라서 얻어옴, 스킬은 없음
		Weapon = 1,
		Accessary = 2,
		Glove = 3,
		BodyArmor = 4,
		Belt = 5,
		Shoes = 6,

		InGameSkill = 10,
		InGameItem = 11,
		InGameFusion = 12,

		UserEvolution = 20,
		UserSpecialEvolution = 21,
		UserOthers = 22,

		Character = 30, // 캐릭터 단위의 무언가가 생긴다면
	}

	public enum EGrade // 최대 9단계만 쓸 예정 ( 1 ~ 9 사이 )
	{
		None = 0,

		Normal, // 흰템
		Magic,	// 녹템
		Rare,   // 파템
		Epic,	// 보라
		Unique,	// 노랑
		Legend,	// 빨강
	}

	// 이 타입에 따라 아이템창에 그려지는게 달라서 여기다 텍스트를 박아도 될거같긴한데...
	public enum EEquipmentType // 최대 9999 ( 1 ~ 9999 )
	{
		None = 0,

		__Weapon__ = 1000,
		Shuriken,
		Rebolber,
		Bat,
		Shotgun,
		Katana,
		LihgtChaser,
		PowerOfDestruction,

		__Accessary__ = 2000,
		Necklace,
		Ring,

		__Glove__ = 3000,
		ClothGlove,
		ChainMailGlove,

		__BodyArmor__ = 4000,
		ClothBody,
		ChainMailBody,

		__Belt__ = 5000,
		ClothBelt,
		ChainMailBelt,

		__Shoes__= 6000,
		ClothShoes,
		ChainMailShoes,
	}

	public struct UserData
	{
		public long lUuid;
		public UserLevelData stLevel;
		public UserGoodsData stGoods;
	}

	public struct UserLevelData
	{
		public int nLevel;
		public int nExp;

		public int nEvolutionStep;
		public int nSpecialEvolutionStep;

		public Stat stUserLevelStat;
		public Stat stEvolutionStat;
		public Stat stSpecialEvolutionStat;

		// todo : Evolution 스킬 추가해야하는데 일단 패스, ui작업시 추가해서 작업할 예정
	}

	// 재화 데이터
	public struct UserGoodsData
	{
		public int nStamina;
		public int nGem;
		public int nGold;
		public int nSiverKey;
		public int nGoldKey;
	}
	
	public struct Stat
	{
		public int nAttack;
		public int nHP;
		public int nDefence;

		public void Clear()
		{
			nAttack = 0;
			nHP = 0;
			nDefence = 0;
		}

		public void Apply(ref StatTable.Data stData)
		{
			nAttack = stData.nAttack;
			nHP = stData.nHP;
			nDefence = stData.nDefence;
		}
	}

	public class EquipmentData
	{
		public long lUuid;
		public EEquipmentType eType;
		public EGrade eGrade;
		public Stat stStat;
		public int nLevel;
		
		// public void SetStat(int a_nGrade, int a_nLevel)
		// {
		// 	Debug.Assert(eType.GetStatTable(a_nGrade, a_nLevel, out stStat), "stat table not exist - check index");
		// }
	}


	public enum StageType
	{
		Normal,
		SpecialDuengeon,
		DailyDungeon,
		EventDungeon,
	}

	public enum EventDungeon
	{
		Gold,
		Material,
	}

	public static class FVSGameExt
	{
		// 테이블
		public static int GetStatTableIndex(this EEquipmentType type, int a_nGrade, int a_nLevel)
		{
			return (int)type * 10000 + a_nGrade * 100 + a_nLevel;
		}

		public static int GetStatTableIndex(this EStatObtainSource type, int nPostfix)
		{
			return (int)type * 10000 + nPostfix;
		}

		public static int GetSkillTableIndex(this EStatObtainSource type, int nPostfix)
		{
			return (int)type * 10000 + nPostfix;
		}

		public static bool TryGetStatTable(this EEquipmentType type, int a_nGrade, int a_nLevel, out StatTable.Data data)
		{
			int nStatTableID = GetStatTableIndex(type, a_nGrade, a_nLevel);

			return OutGameDataManager.Ins.GetStatTable().TryGetData(nStatTableID, out data);
		}

		public static bool TryGetStatTable(this EStatObtainSource type, int nPostfix, out StatTable.Data data)
		{
			int nStatTableID = GetStatTableIndex(type, nPostfix);

			return OutGameDataManager.Ins.GetStatTable().TryGetData(nStatTableID, out data);
		}

		public static int GetSlotIndex(this EEquipmentType a_eType)
		{
			int n = (int)a_eType;

			n /= 1000;
			--n;

			Debug.Assert(n>=0, "type value errro");

			return n;
		}

		public static EEquipSlot GetSlotType(this EEquipmentType a_eType)
		{
			return (EEquipSlot)GetSlotIndex(a_eType);
		}
	}
}
