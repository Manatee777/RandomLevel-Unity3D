using UnityEngine;
using System.Collections;

public class FlyingProjectile : GameObjectController {

	public float projectileSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		rigidbody.velocity = transform.forward * projectileSpeed;

	
	}
}
