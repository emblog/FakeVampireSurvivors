using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FVS { }

namespace FVS.Defines
{
    public enum EScene
	{
		Lobby,
		Game
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
}
