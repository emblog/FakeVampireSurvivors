using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FVS.Defines;
using FVS.GameDefines;


public class FVSGameManager : MonoBehaviour
{
    // singleton // юс╫ц
    static FVSGameManager instance = null;

    static public FVSGameManager Ins => instance;

    private FVSGameManager() { }


    IngameData data;

    void Awake()
    {
        instance = this;

        data = FVSSceneManager.Ins.GetInGameData();
    }

    public PlayerData GetPlayerData()
	{
		return data.playerData;
	}
}
