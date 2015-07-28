using UnityEngine;
using System.Collections;

public class GameObjectController : MonoBehaviour {

	public float timeToDestroy = 2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Destroy(gameObject, timeToDestroy);
	
	}
}
