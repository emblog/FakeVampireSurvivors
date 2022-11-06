using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FVS.Defines;

public class LobbyUI : MonoBehaviour
{
	// EventHandler
	public void OnClick_QuitButton()
	{
		
	}

	public void OnClick_OptionButton()
	{
	}

	public void OnClick_StartButton()
	{
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
