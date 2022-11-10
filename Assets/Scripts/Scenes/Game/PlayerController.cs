using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

using FVS.Defines;
using FVS.GameDefines;

public class PlayerController : MonoBehaviour
{
	#region INSPECTOR

	public Sprite m_Image;
    public Camera m_Camera;

    #endregion

    PlayerData m_Data = new PlayerData();
    SkillData m_stSkillData = new SkillData();

	private void Start()
	{
        m_Data = FVSGameManager.Ins.GetPlayerData();

        var data = FVSGameManager.Ins.GetEquipmentData();

        m_stSkillData.eID = data.eSkillID;
        m_stSkillData.nDamage = data.nBaseDamage;
        m_stSkillData.fDuration = 1.0f; // todo 테이블 매니져 곧 제작 할 예정
        m_stSkillData.fSpeed = 3.0f;
    }

	void Update()
    {
        float moveX = 0;
        float moveY = 0;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveY += 1;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveY -= 1;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveX += 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveX -= 1;
        }

        if (moveX != 0 || moveY != 0)
		{
            moveX *= m_Data.Speed;
            moveY *= m_Data.Speed;

            Vector3 move = new Vector3(moveX* Time.deltaTime, moveY* Time.deltaTime, 0);
            transform.position += move;

            if (m_Camera != null)
			{
                m_Camera.transform.position += move;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
		{
            FVSSkillManager.Ins.ShootSkill(m_stSkillData);
		}
    }
}
