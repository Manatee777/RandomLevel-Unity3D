using UnityEngine;
using System.Collections;

public class GameLoader : MonoBehaviour {

	public GameObject gamaManager;

	void Awake () 
	{
		if (BoardEngine.instanceBoardEngine == null)
		{
			Instantiate(gamaManager);
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
