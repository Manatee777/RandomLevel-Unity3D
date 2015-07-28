using UnityEngine;
using System.Collections;

public class ShipControlScript : PlayerEngine {

	private Quaternion target_rotation;
	private float rotation_speed = 5;
	private Vector3 velocity_mode;
	private float acceleration = 5;

	public AnimationClip walk;
	public AnimationClip run;
	public AnimationClip attack;
	public AnimationClip attack2;
	public AnimationClip idle;

	private bool idle_state = true;




	private CharacterController characterController;



	// Use this for initialization
	void Start () {

		characterController = GetComponent<CharacterController>();
	
	}
	
	// Update is called once per frame
	void Update () {

		keyboardControllPlayer1();

		if (Input.GetButtonDown ("Attack"))
		{
			Attack();
		}

		if (Input.GetButtonDown("Throw"))
		{
			Throw();
		}
	
	}

	void keyboardControllPlayer1()
	{
		Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")); // pohyb vynechava axis osy Y

		if (input != Vector3.zero) //pokud není vstup prázdný
		{
			target_rotation = Quaternion.LookRotation(input); //zacílení rotace  dle vektoru vstupniho
			transform.rotation = Quaternion.Lerp(transform.rotation, target_rotation, Time.deltaTime *4); //střední doba mezi současnou a cílovou rotací
			transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, target_rotation.eulerAngles.y, rotation_speed * Time.deltaTime);
			animation.CrossFade(walk.name);
		}

		else if (idle_state == true) { animation.CrossFade(idle.name);}

		velocity_mode = Vector3.MoveTowards(velocity_mode, input, acceleration * Time.deltaTime); //pohyb nezávislý na framerate diky Time.deltatime
		Vector3 motion = velocity_mode;

		motion *= (Mathf.Abs(input.x) == 1 && Mathf.Abs(input.z) == 1)?.7f:1;
		motion *= (Input.GetButton("Walk"))?defaultSpeed:engineSpeed;//ternární operátor, pokud je na inputu Fly, provede se defaultSpeed, pokud ne, tak engineSpeed

		motion += Vector3.up * -8;

		characterController.Move (motion * Time.deltaTime);  //move na pozici nezávisle na framerate



	}

	void Throw()
	{
		idle_state = false;
		animation.CrossFade(attack.name);
		StartCoroutine(AnimationReseter());
	}

	void Attack()
	{
		idle_state = false;
		animation.CrossFade(attack2.name);
		StartCoroutine(AnimationReseter());
		
	}

	IEnumerator AnimationReseter()
	{
		yield return new WaitForSeconds(0.47f); //počka půl vteřiny a přehodí bool idle state na true a tím umožní idle animaci
		idle_state = true;
	}


}
