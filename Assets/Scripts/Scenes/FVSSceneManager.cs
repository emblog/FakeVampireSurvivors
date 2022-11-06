using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FVS.Defines;

public class FVSSceneManager : MonoBehaviour
{
	// singleton // 임시
    static FVSSceneManager instance = new FVSSceneManager();

    static public FVSSceneManager Ins => instance;

	private FVSSceneManager() { }

	void Awake()
	{
		DontDestroyOnLoad(this);
	}

	// Scene 관리
	public void ChangeScene(EScene a_Scene)
	{
		SceneManager.LoadScene(a_Scene.ToString());
	}




}
