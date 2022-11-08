using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Board : MonoBehaviour
{
	#region INSPECTOR

    public List<GameObject> m_liImage;

    #endregion

    // todo : 나중에 좀 더 제대로 된 맵 관련 보드 이미지 수정. 
    // 러프하게 하고 후루룩 넘어가는 것으로
    // 9장 이미지 기준으로 세팅
    const int boardSize = 512;
    const int w = 3;
    const int h = 3;

	private void Start()
	{
        Debug.Assert(m_liImage.Count == 9); // 임시로 9장

        for (int j = 0; j < h; ++j)
		{
            for (int i = 0; i < w; ++i)
			{
                var sprObj = m_liImage[j * w + i];

                sprObj.transform.localPosition = new Vector3(i * 512, j * 512, 0);
            }
		}
	}

	void Update()
    {
        
    }
}
