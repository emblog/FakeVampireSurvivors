using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FVS.Defines;

namespace FVS.GameDefines
{
	public struct IngameData
	{
		public PlayerData stPlayerData;

		// todo : �ð��� ���ڶ� �ٱ����� ���� �����͸� �״�� �����Դµ�, �ΰ��� ������ȭ �ʿ�
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
