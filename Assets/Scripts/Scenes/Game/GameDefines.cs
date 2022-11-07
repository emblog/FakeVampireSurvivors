using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FVS.Defines;

namespace FVS.GameDefines
{
	public struct IngameData
	{
		public PlayerData playerData;

		public bool IsValid()
		{
			return playerData.IsValid();
		}
	}
}
