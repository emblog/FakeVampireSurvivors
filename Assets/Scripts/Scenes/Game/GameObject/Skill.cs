using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FVS.GameDefines;

public class Skill : MonoBehaviour
{
	SkillData m_stData;

	public float fNowDuration;
	public float fNowSpeed;

	public void SetSkillData(ref SkillData a_stData)
	{
		m_stData = a_stData;

		fNowDuration = a_stData.fDuration;
		fNowSpeed = a_stData.fSpeed;
	}

	public void SkillTick(float a_fDelta)
	{
		
	}
}
