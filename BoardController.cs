using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic; //pro dynamické kolekce
using Random = UnityEngine.Random;

public class BoardController : MonoBehaviour {


	[Serializable]
	public class Count
	{
		public int minimum;	
		public int maximum;

		public Count(int min, int max) //konstruktor
		{
			minimum = min;
			maximum =max;
		}
	}


	public int horizontalField = 20;
	public int verticalField = 20;

	public Count treasureCount = new Count(3,6);
	public Count obstacleCount = new Count(3,6);

	public GameObject endGamer;
	public GameObject[] voidGrid;
	public GameObject[] treasureGrid;
	public GameObject[] obstacleGrid;
	public GameObject[] starGrid;
	public GameObject[] borderGrid;



	public GameObject[] planetaryGrid;

	private Transform boardHolder;
	private List<Vector3> gridPositions = new List<Vector3>();

	void InitializePositionsList()
	{

		gridPositions.Clear ();

		for (int x = 1; x < verticalField -1; x++)
		{
			for (int y = 1; y < horizontalField -1; y++)
			{
				gridPositions.Add (new Vector3(x,0.8f, y));
			}

		}
	}

	void BoardInitialize()
	{
		boardHolder = new GameObject("Board").transform;
		for (int x = -1; x < verticalField +1; x++)
		{
			for (int y = -1; y < horizontalField +1; y++)
			{

				GameObject toInstantiate = voidGrid[Random.Range (0, voidGrid.Length)];
				if (x == -1 || x == verticalField || y == -1 || y == horizontalField)
				{
					 toInstantiate = borderGrid[Random.Range(0, borderGrid.Length)];


				}

				GameObject StartInstatiate = Instantiate(toInstantiate, new Vector3(x, 1f,y), Quaternion.identity) as GameObject;
				StartInstatiate.transform.SetParent(boardHolder);

			}
		}
	}

	Vector3 RandomPosition()
	{
		int randomIndex = Random.Range (0, gridPositions.Count);
		Vector3 randomPosition = gridPositions[randomIndex];
		gridPositions.RemoveAt(randomIndex);
		return randomPosition;
	}

	void Randomize(GameObject[] objectField, int minimum, int maximum)
	{
		int objectCount = Random.Range (minimum, maximum +1);
		for (int i = 0; i < objectCount; i++)
		{
			Vector3 randomPosition = RandomPosition();
			GameObject selectionObject = objectField[Random.Range (0, objectField.Length)];
			Instantiate(selectionObject, randomPosition, Quaternion.identity);
		}

	}

	public void boardCreator(int level)
	{
		BoardInitialize();
		InitializePositionsList();
		Randomize(obstacleGrid, obstacleCount.minimum, obstacleCount.maximum);
		Randomize(treasureGrid, treasureCount.minimum, treasureCount.maximum);
		//int enemyCount = (int)Mathf.Log(level, 2f);
		Instantiate(endGamer, new Vector3(verticalField -1, 0.8f, horizontalField-1), Quaternion.identity);
	}






	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
