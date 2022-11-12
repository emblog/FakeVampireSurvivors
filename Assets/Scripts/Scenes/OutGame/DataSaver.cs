using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FVS.Defines;

// 플레이어 프랩스 or 서버 와의 가교 or 구글 드라이브에 저장
// 서버랑 통신을 하든, 로컬에서 계속 갱신을 하든 가변할 데이터 이기 때문에 일단 클래스로 제작.
public class DataSaver : MonoBehaviour
{
	class EquipmentDBData
	{
		public long lUuid;

		public int nType;
		public int nGrade;
		public int nLevel;
	}

	class UserDBData
	{
		public long lUserUUID;

		public int nLevel;
		public int nNowExp;

		public int nEolutionData;
		public int nSpecialEvolutionData;

		// 재화
		public int nStamina;
		public int nGem;
		public int nGold;
		public int nSiverKey;
		public int nGoldKey;
	}

	class ShopDBData
	{
		// 현재 파는 상품에 대한 정보. 이거는 거의 구현 안될 수 있음
		// 4주치까지의 목표는 무료 상품 + 광고 상품정도에 대한 구현
	}

	class ShopDailyDBData
	{
		// 광고 최대 볼 수 있는 횟수에대한 카운트
		public List<int> nShopIndexADCount = new List<int>();

		// 비슷하게, 클릭하면 받는 상품에 대한 카운팅도 관리 해야함. ( 기본적으로 1회 )
	}

	UserDBData				temp01 = new UserDBData();
	ShopDBData				temp02 = new ShopDBData();
	ShopDailyDBData			temp03 = new ShopDailyDBData();

	List<EquipmentDBData>	m_liEquipment = new List<EquipmentDBData>();
	List<long>				m_liEquipedList = new List<long>();

	// 서버가 없다면, uuid를 스스로 발급해서 관리해야함
	// public static long GetUUID()
	// {
	// 	return 0;
	// }

	public void LoadData()
	{
		// todo - 어딘가로부터 잘 로딩했다고 가정
		EquipmentDBData shuriken = new EquipmentDBData();

		shuriken.lUuid = 10;
		shuriken.nType = (int)EEquipmentType.Shuriken;
		shuriken.nGrade = 1;
		shuriken.nLevel = 1;

		EquipmentDBData body = new EquipmentDBData();

		body.lUuid = 11;
		body.nType = (int)EEquipmentType.ClothBody;
		body.nGrade = 1;
		body.nLevel = 1;

		m_liEquipedList.Add(10);
		m_liEquipedList.Add(11);
	}

	static EquipmentData CreateDataFromDBData(EquipmentDBData a_stData)
	{
		EquipmentData data = new EquipmentData();

		data.lUuid = a_stData.lUuid;
		data.eType = (EEquipmentType)a_stData.nType;
		data.eGrade = (EGrade)a_stData.nGrade;
		data.nLevel = a_stData.nLevel;

		Debug.Assert(data.eType.GetStatTable(a_stData.nGrade, a_stData.nLevel, out var statData), "stat setting error");
		data.stStat = statData;

		return data;
	}

	public void FillEquipmentData(long[] a_arSlot, Dictionary<long, EquipmentData> a_map)
	{
		a_map.Clear();

		foreach( var equip in m_liEquipment)
		{
			EquipmentData data = CreateDataFromDBData(equip);

			a_map.Add(equip.lUuid, data);

			foreach ( long uuid in m_liEquipedList)
			{
				if( uuid == equip.lUuid )
				{

					data.eType.GetSlotIndex();



				}
			}
		}
	}
}
