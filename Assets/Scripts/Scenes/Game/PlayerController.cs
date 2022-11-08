using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

using FVS.Defines;

public class PlayerController : MonoBehaviour
{
	#region INSPECTOR

	public Sprite m_Image;
    public Camera m_Camera;

    #endregion

    PlayerData m_Data = new PlayerData();

	private void Start()
	{
        m_Data = FVSGameManager.Ins.GetPlayerData();
	}

	// Update is called once per frame
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
    }
}
