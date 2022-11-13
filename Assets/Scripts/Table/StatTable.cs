using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatTable : BaseTable<StatTable.Data>
{
	public struct Data
	{
		public readonly int nID;
		public readonly int nAttack;
		public readonly int nHP;
		public readonly int nDefence;
		public readonly int nSkillID01;
		public readonly int nSkillID02;
		public readonly int nSkillID03;
		public readonly int nSkillID04;
		public readonly int nSkillID05;
	}
}
