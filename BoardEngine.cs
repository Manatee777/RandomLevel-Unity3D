using UnityEngine;
using System.Collections;

public class BoardEngine : MonoBehaviour {


	public BoardController boardControllerInstance;
	private int level = 1;
	// Use this for initialization
	public static  BoardEngine instanceBoardEngine = null;



	void Awake()
	{
		if (instanceBoardEngine == null)
		{
			instanceBoardEngine = this;
		}

		else if (instanceBoardEngine != this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
		boardControllerInstance = GetComponent<BoardController>();
		InitGame();

	}

	void InitGame()
	{
		boardControllerInstance.boardCreator(level);
	}


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
