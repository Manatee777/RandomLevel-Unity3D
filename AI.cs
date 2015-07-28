using UnityEngine;
using System.Collections;

public class AI : BasicCharacterProp {

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
	
	}


	IEnumerator newDirection()
	{
		while(true)
		{
			DirectionChange();
			yield return new WaitForSeconds(intervalDirectionChange);
			
		}
	}

	void TestInft(){}


	void DirectionChange()
	{
		var minChange = Mathf.Clamp(angleRange - maxAngleRange, 0,360);
		var maxChange = Mathf.Clamp(angleRange + maxAngleRange, 0,360);
		angleRange = Random.Range (minChange, maxChange);
		targetRotation = new Vector3(0, angleRange, 0);
	}
}
