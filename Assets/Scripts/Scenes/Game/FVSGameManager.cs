using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FVS.Defines;
using FVS.GameDefines;

public class FVSGameManager : MonoBehaviour
{
	#region SINGLETON_LIKE

	static FVSGameManager instance = null;

    static public FVSGameManager Ins => instance;

    private FVSGameManager() { }

    void Awake()
    {
		// 게임씬이 로딩되면, 하이어라키에 있기 때문에 그 때 세팅됨.
        instance = this;
    }

	#endregion // 유사 싱글톤으로 제작

	List<ITick> m_liTickObjects = new List<ITick>();

	public void AddTickObject(ITick a_cTick)
	{
		Debug.Assert(a_cTick != null, "arg error");

		m_liTickObjects.Add(a_cTick);
	}

	public void RemoveTickObject(ITick a_cTick)
	{
		Debug.Assert(a_cTick != null, "arg error");

		m_liTickObjects.Remove(a_cTick);
	}

	private void Update()
	{
		float fDelta = Time.deltaTime;

		foreach(var obj in m_liTickObjects)
		{
			obj.Tick(fDelta);
		}
	}
}
