using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FVS.Defines;
using FVS.GameDefines;


public class FVSGameManager : MonoBehaviour
{
    // singleton // �ӽ�
    static FVSGameManager instance = null;

    static public FVSGameManager Ins => instance;

    private FVSGameManager() { }


    IngameData data;

    void Awake()
    {
        instance = this;

        data = FVSSceneManager.Ins.GetInGameData();

        // todo : ������� �۾� �Ǹ� ���� �ʼ�
        // ���� ������ ������ �� ����� ���� ������
        if (data.IsValid() == false)
		{
            PlayerData temp;

            temp.Speed = 5;
            temp.HP = 10;
            temp.AttakSpeed = 1.5f;
            temp.AttackDamage = 1;

            data.playerData = temp;
        }
    }

    public PlayerData GetPlayerData()
	{
		return data.playerData;
	}
}
