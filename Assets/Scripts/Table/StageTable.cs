using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTable : BaseTable<StatTable.Data>
{
	public struct Data
	{
		public int nId;
		public int snName;

		// 던전 리워드는 드랍테이블에 종속해서 만들어질 수 있음.
		public int tnDropTableID;
		public int nGoldReward;
		public int nExpReward;

		// 입장시 필요한 재화
		public int nEnterDungeonPriceType;
		public int nEnterDungeonPrice;
	}
}