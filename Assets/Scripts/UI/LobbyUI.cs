using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FVS.Defines;

// 임시로 최초 씬에 대한 책임을 전부 가짐


// save데이터는 임시로 플레이어 프렙스에 저장할 예정
// save데이터에 대한 모든 내용은 DataSaver를 통해 진행

public class LobbyUI : MonoBehaviour
{

	private void Awake()
	{
		GameStart();
	}

	void GameStart()
	{
		
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
		
		FVSSceneManager.Ins.SetInGameData(ref temp, ref temp2);
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
