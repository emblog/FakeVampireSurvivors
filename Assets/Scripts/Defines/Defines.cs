using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Fake Vampire Survivors 네임 스페이스정리
namespace FVS { }
namespace FVS.Defines { }
namespace FVS.GameDefines { } // todo : 사이즈 봐서 없앨수도 있음


namespace FVS.Defines
{
    public enum EScene
	{
		Lobby,
		Game
	}

	public enum ESkillID
	{
		None,
		NoSkill,	// 스킬 없음
		Sword,		// 직선으로 날아가는 비도
	}

	public struct PlayerData
	{
		public int HP;
		public int Speed;
		public int AttackDamage;
		public float AttakSpeed;

		public bool IsValid()
		{
			return (HP > 0) && (Speed > 0) &&(AttackDamage > 0) && (AttakSpeed > 0);
		}
	}

	public struct EquipmentData
	{
		public ESkillID	eSkillID;
		public int		nBaseDamage;

		public bool IsValid()
		{
			return eSkillID != ESkillID.None && nBaseDamage > 0;
		}
	}
}
