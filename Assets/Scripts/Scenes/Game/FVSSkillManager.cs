using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FVS.InGameDefines;

public class FVSSkillManager : MonoBehaviour
{
    // singleton // 임시
    static FVSSkillManager instance = null;

    static public FVSSkillManager Ins => instance;

    private FVSSkillManager() { }

    List<Skill> m_liActiveSkills = new List<Skill>();
    List<Skill> m_liSkillPool = new List<Skill>();


    void Awake()
    {
        instance = this;
    }

    void ShootSkill(ref SkillData a_stData)
	{

    }

    private void Update()
	{
		
	}

}


