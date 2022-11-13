using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// table key 값은 int 고정
public abstract class BaseTable<T> where T : struct
{
	public Dictionary<int, T> m_mapData = new Dictionary<int, T>();

	public void Add(int a_nKey, ref T a_stValue)
	{
		m_mapData.Add(a_nKey, a_stValue);
	}

	public bool TryGetData(int a_nKey, out T a_refGet)
	{
		return m_mapData.TryGetValue(a_nKey, out a_refGet);
	}
}
