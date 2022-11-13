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
		public long lUuid;

		public int nLevel;
		public int nNowExp;

		public int nEvolutionStep;
		public int nSpecialEvolutionStep;

		// 재화
		public int nStamina;
		public int nGem;
		public int nGold;
		public int nSiverKey;
		public int nGoldKey;
	}

	class User_DailyUpdateDBData
	{
		public List<int> liDuengeonKey;

		public List<int> liShopFreeToken;
		public List<int> liShopADToken;
		public List<float> liShopADTerm;
	}

	class ShopDBData
	{
		// 현재 파는 상품에 대한 정보. 이거는 거의 구현 안될 수 있음
		// 4주치까지의 목표는 무료 상품 + 광고 상품정도에 대한 구현
	}
	
	ShopDBData				temp02 = new ShopDBData();
	User_DailyUpdateDBData	temp03 = new User_DailyUpdateDBData();

	UserDBData				m_cUser = new UserDBData();
	List<EquipmentDBData>	m_liEquipment = new List<EquipmentDBData>();
	List<long>				m_liEquipedList = new List<long>();

	public void LoadData()
	{
		// todo - 어딘가로부터 잘 로딩했다고 가정
		UserDBData user = new UserDBData();
		
		user.nLevel = 1;
		user.nNowExp = 0;
		user.nEvolutionStep = 0;
		user.nSpecialEvolutionStep = 0;

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

	EquipmentData CreateDataFromDBData(EquipmentDBData a_stData)
	{
		EquipmentData data = new EquipmentData();

		data.lUuid = a_stData.lUuid;
		data.eType = (EEquipmentType)a_stData.nType;
		data.eGrade = (EGrade)a_stData.nGrade;
		data.nLevel = a_stData.nLevel;

		Debug.Assert(data.eType.TryGetStatTable(a_stData.nGrade, a_stData.nLevel, out var statData), "stat setting error");

		data.stStat.Apply(ref statData);
		return data;
	}

	public bool FillUserData(out UserData a_refUserData)
	{
		a_refUserData.lUuid = m_cUser.lUuid;
		a_refUserData.stLevel = new UserLevelData();

		a_refUserData.stLevel.nLevel				= m_cUser.nLevel;
		a_refUserData.stLevel.nExp					= m_cUser.nNowExp;
		a_refUserData.stLevel.nEvolutionStep		= m_cUser.nEvolutionStep;
		a_refUserData.stLevel.nSpecialEvolutionStep	= m_cUser.nSpecialEvolutionStep;
		a_refUserData.stLevel.stUserLevelStat.Clear();

		Debug.Assert(EStatObtainSource.UserLevel.TryGetStatTable(a_refUserData.stLevel.nLevel, out var stat), "index error");
		a_refUserData.stLevel.stUserLevelStat.Apply(ref stat);

		a_refUserData.stLevel.stSpecialEvolutionStat.Clear();
		a_refUserData.stLevel.stEvolutionStat.Clear();

		a_refUserData.stGoods = new UserGoodsData();

		a_refUserData.stGoods.nStamina	= m_cUser.nStamina;
		a_refUserData.stGoods.nGem		= m_cUser.nGem;
		a_refUserData.stGoods.nGold		= m_cUser.nGold;
		a_refUserData.stGoods.nSiverKey	= m_cUser.nSiverKey;
		a_refUserData.stGoods.nGoldKey	= m_cUser.nGoldKey;

		return true;
	}

	public void FillEquipmentData(long[] a_arSlot, Dictionary<long, EquipmentData> a_map)
	{
		a_map.Clear();

		for( int i=0 ;i<a_arSlot.Length; ++i )
		{
			a_arSlot[i] = 0;
		}

		foreach( var equip in m_liEquipment)
		{
			EquipmentData data = CreateDataFromDBData(equip);

			a_map.Add(equip.lUuid, data);

			foreach ( long uuid in m_liEquipedList)
			{
				if( uuid == equip.lUuid )
				{
					int n = data.eType.GetSlotIndex();

					Debug.Assert(a_arSlot[n] == 0, "received value error");

					a_arSlot[n] = uuid;
				}
			}
		}
	}
}
