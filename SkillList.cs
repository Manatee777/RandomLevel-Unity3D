using UnityEngine;
using System.Collections;

public class SkillList : SkillController {

	//list of prefabs to instantiate
	public GameObject stone_throw_efect;




	public Transform offensive_spawn;
	public Transform defensive_spawn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.F2))
		{
			StoneAttackSkill();
		}
	}

	public override void OffensiveSkill(float distance, float damage, float heal, float skill_points_cost, float cast_time, float skill_level, bool unlock)
	{
		base.OffensiveSkill(distance,damage,heal,skill_points_cost, cast_time,skill_level, unlock);
	}

	void StoneAttackSkill()
	{
		OffensiveSkill(15,5,0,1,0.5f,1,true);

		if (efectRelease == true)
		{
			Instantiate(stone_throw_efect, offensive_spawn.position, offensive_spawn.rotation);

		}
	}


}
