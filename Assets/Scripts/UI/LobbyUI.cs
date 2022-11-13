using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FVS.Defines;

// 임시로 최초 씬에 대한 책임을 전부 가짐

public class LobbyUI : MonoBehaviour
{

	private void Awake()
	{
		GameStart();
	}

	void GameStart()
	{
		OutGameDataManager.Ins.LoadingSavedData();
	}


	// EventHandler
	public void OnClick_QuitButton()
	{
		
	}

	public void OnClick_OptionButton()
	{
	}

	public void OnClick_StartButton()
	{
		FVSSceneManager.Ins.SetInGameData();
		
		FVSSceneManager.Ins.ChangeScene(EScene.Game);
	}

	public void OnClick_CollectionButton()
	{
	}

	public void OnClick_PowerUpButton()
	{
	}

	public void OnClick_UnlocksButton()
	{
	}

	public void OnClick_CreditsButton()
	{
	}
}
