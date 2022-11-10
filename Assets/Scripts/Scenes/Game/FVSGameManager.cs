using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FVS.Defines;
using FVS.GameDefines;


public class FVSGameManager : MonoBehaviour
{
    // singleton // 임시
    static FVSGameManager instance = null;

    static public FVSGameManager Ins => instance;

    private FVSGameManager() { }


    IngameData data;

    void Awake()
    {
        instance = this;

        data = FVSSceneManager.Ins.GetInGameData();

        // todo : 어느정도 작업 되면 삭제 필수
        // 게임 씬에서 바로 시작할 때 사용할 더미 데이터
        if (data.IsValid() == false)
		{
            PlayerData temp;

            temp.Speed = 5;
            temp.HP = 10;
            temp.AttakSpeed = 1.5f;
            temp.AttackDamage = 1;

            data.stPlayerData = temp;

            EquipmentData temp2;

            temp2.eSkillID = ESkillID.Sword;
            temp2.nBaseDamage = 1;

            data.stEquipmentData = temp2;
        }
    }

    public PlayerData GetPlayerData()
	{
		return data.stPlayerData;
	}

    public EquipmentData GetEquipmentData()
    {
        return data.stEquipmentData;
    }
}
