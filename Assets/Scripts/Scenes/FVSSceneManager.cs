using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FVS.Defines;
using FVS.InGameDefines;

public class FVSSceneManager : MonoBehaviour
{
	#region SINGLETON

	static FVSSceneManager _instance = null;

	public static FVSSceneManager Ins
	{
		get
		{
			if (_instance == null)
			{
				_instance = FindObjectOfType(typeof(FVSSceneManager)) as FVSSceneManager;

				if (_instance == null)
				{
					_instance = new GameObject("FVSSceneManager", typeof(FVSSceneManager)).GetComponent<FVSSceneManager>();
				}
			}

			return _instance;
		}
	}

	void Awake()
	{
		DontDestroyOnLoad(this);
	}

	#endregion


	IngameData m_passingData;

	public void SetInGameData(ref PlayerData a_stPlayerData, ref EquipmentData a_stEquipmentData)
	{
		m_passingData.stPlayerData = a_stPlayerData;
		m_passingData.stEquipmentData = a_stEquipmentData;

		Debug.Assert(m_passingData.IsValid(), "not valid stage passing data");
	}

	public IngameData GetInGameData()
	{
		return m_passingData;
	}

	// Scene 관리
	public void ChangeScene(EScene a_Scene)
	{
		SceneManager.LoadScene(a_Scene.ToString());
	}
}
