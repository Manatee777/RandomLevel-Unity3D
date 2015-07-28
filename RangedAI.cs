using UnityEngine;
using System.Collections;


public class RangedAI : MonoBehaviour, IAI{



	// Use this for initialization
	public GameObject player;
	
	public Vector3 velocity;
	
	public float walkSpeed;
	public float runSpeed;
	public float directionChange;
	public float maxAngleRange = 360;
	public float intervalDirectionChange;
	public float angleRange;
	Vector3 targetRotation;
	
	
	public CharacterController characterController;
	public AnimationClip run;


	//variables pro utok na dalku
	public float nextposspeell;
	public float timebetweenspells;
	public float castperminute;
	
	public float spelldamage;
	
	
	public bool efect_release;

	public Transform spellSpawn;
	public GameObject efectFireball;
	//variblas pro utoky na dalku

	
	
	void Awake () //lepsi nez start diky inicializace promennych a metod pred behem scriptu
	{

		characterController = GetComponent<CharacterController>();
		angleRange = Random.Range (0,360);
		transform.eulerAngles = new Vector3(0, angleRange, 0);
		StartCoroutine(newDirection());
	}

	
	
	
	// Update is called once per frame
	void Update () {

		
		
		transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation,Time.deltaTime * intervalDirectionChange);
		var targetPosition = transform.TransformDirection(Vector3.forward);
		characterController.SimpleMove(targetPosition * runSpeed);
		animation.CrossFade(run.name);

		
		
		
		if (Vector3.Distance(transform.position, player.transform.position) < 6)
		{
			transform.LookAt(player.transform.position);
			Fireball();
		}

	
	}

	
	public IEnumerator newDirection()
	{
		while(true)
		{
			DirectionChange();
			yield return new WaitForSeconds(intervalDirectionChange);
		}
	}

	public void DirectionChange()
	{
		var minChange = Mathf.Clamp(angleRange - maxAngleRange, 0,360);
		var maxChange = Mathf.Clamp(angleRange + maxAngleRange, 0,360);
		angleRange = Random.Range (minChange, maxChange);
		targetRotation = new Vector3(0, angleRange, 0);
	}


	public void RangedAttack(float distance, float casttime)
	{
		
		
		if (player != null) 
		{
			timebetweenspells = casttime;
			
			if(Vector3.Distance(transform.position, player.transform.position) < distance)
			{

					if (AttackTime())
					{
						nextposspeell = Time.time + timebetweenspells;
						efect_release = true;

						Debug.Log("utocne kouzlo!");
					}
					
					else efect_release = false;
			}
		}
	}


	
	public  bool AttackTime()
	{
		bool attackTime = true;
		efect_release = true;
		
		
		if (Time.time < nextposspeell) 
		{
			attackTime = false;
			efect_release = false;
		}
		return attackTime; 
	}



	//skill list ranged

	void Fireball()
	{
		RangedAttack(15,2);
		if (efect_release == true)
		{
			Instantiate(efectFireball, spellSpawn.position, spellSpawn.rotation);
			
		}
	}



	

}
