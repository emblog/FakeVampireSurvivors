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
        // ���� ������ �ٷ� ������ �� ����� ���� ������
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
