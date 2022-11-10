using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Fake Vampire Survivors ���� �����̽�����
namespace FVS { }
namespace FVS.Defines { }
namespace FVS.GameDefines { } // todo : ������ ���� ���ټ��� ����


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
		NoSkill,	// ��ų ����
		Sword,		// �������� ���ư��� ��
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
