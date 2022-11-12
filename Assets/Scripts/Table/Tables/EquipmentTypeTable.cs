using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentTypeTable : BaseTable<EquipmentTypeTable.Data>
{
	public struct Data
	{
		public readonly int		nID;
		public readonly string	sName;
		public readonly string	sInfo;
		public readonly string	sImageName;

		public readonly int		nGradeMaxLevel_01;
		public readonly int		nGradeMaxLevel_02;
		public readonly int		nGradeMaxLevel_03;
		public readonly int		nGradeMaxLevel_04;
		public readonly int		nGradeMaxLevel_05;
		public readonly int		nGradeMaxLevel_06;
		public readonly int		nGradeMaxLevel_07;
		public readonly int		nGradeMaxLevel_08;
		public readonly int		nGradeMaxLevel_09;
		public readonly int		nGradeMaxLevel_10;
	}
}
