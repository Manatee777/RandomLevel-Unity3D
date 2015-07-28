using UnityEngine;
using System.Collections;

public class SkillController : MonoBehaviour {



	public GameObject target;

	public float nextPossibleSkill;
	public float timeBetweenSkills;
	public float skillsPerMinute;



	public Transform playerTarget;

	public bool efectRelease;

	// Use this for initialization
	void Start () {

		timeBetweenSkills = 60 / skillsPerMinute;
	
	}
	
	// Update is called once per frame


	public virtual bool SkillTimeReseter()
	{
		bool skillTime = true;
		efectRelease = true;

		if (Time.time < nextPossibleSkill)
		{
			skillTime = false;
			efectRelease = false;
		}

		return skillTime;
	}


	public virtual void OffensiveSkill(float distance, float damage, float heal, float skill_points_cost, float cast_time, float skill_level, bool unlock)
	{
		if (unlock)
		{
		if (playerTarget.GetComponent<PlayerEngine>().skill_points >= skill_points_cost)
		{
			timeBetweenSkills = cast_time;

			if (SkillTimeReseter())
			{
				nextPossibleSkill = Time.time + timeBetweenSkills;
				efectRelease = true;
				Debug.Log ("utocny skill");
				playerTarget.GetComponent<PlayerEngine>().skill_points -= skill_points_cost;


			}
			else efectRelease = false;
		}
		else efectRelease = false;
		}
	}




	void Update () {
	
	}
}
