using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkillTable : BaseTable<StatTable.Data>
{
	public struct Data
	{
		public int			nId;
		public int			snName;
		public int			tnStat;
		public int			nDamage;
		public float		fDuration;
		public float		fSpeed;
	}
}
