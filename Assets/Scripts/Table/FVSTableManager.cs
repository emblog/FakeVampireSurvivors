using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FVSTableManager : MonoBehaviour
{
	#region SINGLETON

	static FVSTableManager _instance = null;

	public static FVSTableManager Ins
	{
		get
		{
			if (_instance == null)
			{
				_instance = FindObjectOfType(typeof(FVSTableManager)) as FVSTableManager;

				if (_instance == null)
				{
					_instance = new GameObject("FVSTableManager", typeof(FVSTableManager)).GetComponent<FVSTableManager>();
				}
			}

			return _instance;
		}
	}

	void Awake()
	{
		DontDestroyOnLoad(this);
	}

	#endregion

	// todo : 관리를 어떻게 할 지 고민 + table getter API
	// static class로 만들지도 고민, 아마 사라질 수도있음.
	// 어차피 테이블의 접근은 확장메소드로밖에 안할 예정

	SkillTable skill = new SkillTable();
	StatTable stat = new StatTable();
	EquipmentTypeTable eqType = new EquipmentTypeTable();

	public SkillTable GetSkillTable()
	{
		return skill;
	}

	public StatTable GetStatTable()
	{
		return stat;
	}

	public EquipmentTypeTable GetEquipmentTypeTable()
	{
		return eqType;
	}
}
