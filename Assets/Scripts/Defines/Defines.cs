using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.ComponentModel;

// Fake Vampire Survivors 네임 스페이스정리
namespace FVS { }
namespace FVS.Defines { }
namespace FVS.InGameDefines { } // todo : 사이즈 봐서 없앨수도 있음

// naming convention
// ~~ DBData : 데이터 저장시 사용하는 타입 ( from server or from save file )
// ~~ TableData : 테이블에있는 데이터와 1:1 매칭되는 타입
// FVS : Fake Vampire Survivors 이 프로젝트를 말 함
// 
//
// 멤버변수 m_
// 아규먼트 a_
// 전역변수 g_
// 로컬변수는 안붙임

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

	public enum OutGame
	{
		// MaxEquipmentSlot = (int)EEquipSlot.Max,
	}

	public enum EScene
	{
		Lobby,
		Game
	}

	public enum ESkillID
	{
		None = 0,
		NoSkill = -1,

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

		__FromWeapon_MainSkill__, // 아웃게임에서 장비한 무기로 부터 적용되는 메인스킬

		Shuriken,
		Rebolber,
		Bat,
		Shotgun,
		Katana,
		LihgtChaser,
		PowerOfDestruction,

		__FromWeapon_UpgardeSkill__,

		__EquipmentSkill__, // 무기가 아닌 장비로부터의 스킬


		__InGame_ItemSkill__, // 인게임에서 아이템을 얻었을 경우의 스킬


		__FusionSkill__, // 인게임에서 아이템과, 특정 메인스킬 둘 다 보유시 업그레이드 되는 스킬

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

	public class EquipmentData
	{
		public long lUuid;
		public EEquipmentType eType;
		public EGrade eGrade;
		public StatTable.Data stStat;
		public int nLevel;
		
		// public void SetStat(int a_nGrade, int a_nLevel)
		// {
		// 	Debug.Assert(eType.GetStatTable(a_nGrade, a_nLevel, out stStat), "stat table not exist - check index");
		// }
	}

	/* 아직 필요할 지 잘 모르겠음
	enum EGlobalTableValueType
	{
		Integer,
		Float,
		String,
	}

	struct GlobalValueTableData
	{
		public int nID;
		public int nType; // EValueType
		public string sValue;
		public string sDescription;
	}
	*/

	public static class FVSGameExt
	{
		// 테이블
		public static int GetStatTableIndex(this EEquipmentType type, int a_nGrade, int a_nLevel)
		{
			return (int)type * 10000 + a_nGrade * 100 + a_nLevel;
		}

		public static bool GetStatTable(this EEquipmentType type, int a_nGrade, int a_nLevel, out StatTable.Data data)
		{
			int nStatTableID = GetStatTableIndex(type, a_nGrade, a_nLevel);

			return FVSTableManager.Ins.GetStatTable().TryGetData(nStatTableID, out data);
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
