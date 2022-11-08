using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Board : MonoBehaviour
{
	#region INSPECTOR

    public List<GameObject> m_liImage;

    #endregion

    // todo : ���߿� �� �� ����� �� �� ���� ���� �̹��� ����. 
    // �����ϰ� �ϰ� �ķ�� �Ѿ�� ������
    // 9�� �̹��� �������� ����
    const int boardSize = 512;
    const int w = 3;
    const int h = 3;

	private void Start()
	{
        Debug.Assert(m_liImage.Count == 9); // �ӽ÷� 9��

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
