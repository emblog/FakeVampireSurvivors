using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FVS.Defines;

namespace FVS.InGameDefines
{
	public struct IngameData
	{
		public PlayerData stPlayerData;

		// todo : 시간이 모자라서 바깥에서 쓰는 데이터를 그대로 가져왔는데, 인게임 데이터화 필요
		public EquipmentData stEquipmentData;

		public bool IsValid()
		{
			return stPlayerData.IsValid() && stEquipmentData.IsValid();
		}
	}

	public struct SkillData
	{
		public ESkillID		eID;
		public float		fDuration;
		public int			nDamage;
		public float		fSpeed;
	}
}
