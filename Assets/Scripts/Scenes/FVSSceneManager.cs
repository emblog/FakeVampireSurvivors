using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FVS.Defines;
using FVS.GameDefines;

public class FVSSceneManager : MonoBehaviour
{
	// singleton // 임시
    static FVSSceneManager instance = new FVSSceneManager();

    static public FVSSceneManager Ins => instance;

	private FVSSceneManager() { }

	IngameData m_passingData;

	void Awake()
	{
		DontDestroyOnLoad(this);
	}

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
