using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

using FVS.Defines;

public class PlayerController : MonoBehaviour
{
	#region INSPECTOR

	public Sprite Image;

    #endregion

    PlayerData Data = new PlayerData();

	private void Start()
	{
		Data = FVSGameManager.Ins.GetPlayerData();
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

        moveX *= Data.Speed;
        moveY *= Data.Speed;

        var pos = transform.position;

        pos.x += moveX * Time.deltaTime;
        pos.y += moveY * Time.deltaTime;

        transform.position = pos;
    }
}
