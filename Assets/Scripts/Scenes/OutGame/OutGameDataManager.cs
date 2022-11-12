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

	DataSaver m_cDataSaver = new DataSaver();
	long[] m_liEquipedSlot = new long[(int)EEquipSlot.Max];
	Dictionary<long, EquipmentData> m_mapOwnEquipList = new Dictionary<long, EquipmentData>();
	
	void GameStart()
	{
		m_cDataSaver.LoadData();
		m_cDataSaver.FillEquipmentData(m_liEquipedSlot, m_mapOwnEquipList);

		Debug.Assert(m_liEquipedSlot[(int)EEquipSlot.Weapon] > 0 && m_mapOwnEquipList.Count > 0);
	}
}
