using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FVS.Defines;
using FVS.GameDefines;

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


	IngameDeliveryData m_stDeliveryData;

	

	public void SetDeliveryData_forIngame()
	{
		// stage 데이터

		m_stDeliveryData.Clear();

		Debug.Assert(m_stDeliveryData.IsValid(), "not valid stage passing data");
	}

	public IngameDeliveryData GetInGameDeliveryData()
	{
		return m_stDeliveryData;
	}

	// Scene 관리
	public void ChangeScene(EScene a_Scene)
	{

		SceneManager.LoadScene(a_Scene.ToString());
	}
}
