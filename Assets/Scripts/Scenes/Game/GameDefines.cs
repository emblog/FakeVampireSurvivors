using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FVS.Defines;

namespace FVS.GameDefines
{
	public struct IngameDeliveryData
	{
		public List<SkillData> liSkillData;
		public IngameStat stTotalStat;

		public void Clear()
		{
			liSkillData.Clear();
			stTotalStat.Clear();
		}
	}

	public enum InGame
	{

	}

	public struct SkillData
	{
		public ESkillID eId;
		public ESkillType eType;

		public float fDuration;
		public int nDamage;
		public float fSpeed;
		public IngameStat stStat;

		public bool IsValid()
		{
			return ((int)eId) > 0;
		}
	}

	public struct IngameStat
	{
		public int nAttack;
		public int nHP;
		public int nDefence;
		public float fSpeed;

		public void Clear()
		{
			nAttack = 0;
			nHP = 0;
			nDefence = 0;
			fSpeed = 0.0f;
		}

		public bool IsValid()
		{
			return true;
		}
	}

	public interface ITick
	{
		void Tick(float a_fDelta);
	}
}
