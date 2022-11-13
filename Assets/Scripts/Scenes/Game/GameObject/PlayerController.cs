using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

using FVS.Defines;
using FVS.GameDefines;

public class PlayerController : MonoBehaviour, ITick
{
	#region INSPECTOR

	public Sprite m_Image;
    public Camera m_Camera;

	

	#endregion

	private void Start()
	{
        // todo data set
        
        FVSGameManager.Ins.AddTickObject(this);
    }

    public void Tick(float a_fDelta)
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
            // moveX *= m_Data.Speed;
            // moveY *= m_Data.Speed;

            Vector3 move = new Vector3(moveX * a_fDelta, moveY * a_fDelta, 0);
            transform.position += move;

            if (m_Camera != null)
            {
                m_Camera.transform.position += move;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            // FVSSkillManager.Ins.ShootSkill(m_stSkillData);
        }
    }
}
