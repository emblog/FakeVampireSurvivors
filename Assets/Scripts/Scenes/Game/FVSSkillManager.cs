using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FVS.GameDefines;

public class FVSSkillManager : MonoBehaviour, ITick
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

    void Start()
    {
        FVSGameManager.Ins.AddTickObject(this);
    }

	public void Tick(float a_fDelta)
	{
		foreach(var skill in m_liActiveSkills)
		{
            skill.SkillTick(a_fDelta);
		}
	}
}
