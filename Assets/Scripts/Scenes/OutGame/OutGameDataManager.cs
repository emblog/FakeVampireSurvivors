using System.Collections.Generic;
using UnityEngine;
using FVS.Defines;

// 인벤토리, 캐릭터 랩업 등 관리
public class OutGameDataManager : MonoBehaviour
{
	#region SINGLETON

	static OutGameDataManager _instance = null;

	public static OutGameDataManager Ins
	{
		get
		{
			if (_instance == null)
			{
				_instance = FindObjectOfType(typeof(OutGameDataManager)) as OutGameDataManager;

				if (_instance == null)
				{
					_instance = new GameObject("OutGameDataManager", typeof(OutGameDataManager)).GetComponent<OutGameDataManager>();
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

	#region TABLE_DATA

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

	#endregion


	// OutGameDataManager만 참조하도록 만들 예정
	DataSaver m_cDataSaver = new DataSaver();

	// 실데이터
	UserData m_stUserData;

	long[] m_liEquipedSlot = new long[(int)EEquipSlot.Max];
	Dictionary<long, EquipmentData> m_mapOwnEquipList = new Dictionary<long, EquipmentData>();
	
	public void LoadingSavedData()
	{
		// 저장 데이터 로드
		m_cDataSaver.LoadData();

		// 유저 정보 세팅
		m_cDataSaver.FillUserData(out m_stUserData);

		// 이큅먼트 세팅
		m_cDataSaver.FillEquipmentData(m_liEquipedSlot, m_mapOwnEquipList);

		Debug.Assert(m_liEquipedSlot[(int)EEquipSlot.Weapon] > 0 && m_mapOwnEquipList.Count > 0);
	}
}
