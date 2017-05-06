using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    /// <summary>
    /// An integer that represents the score
    /// </summary>
	/// 
	public GameObject player;

	private int score = 0;
    public int Score
    {
        get { return score;  }
        set { score = value; }
    }

	// Use this for initialization
	void Start () {
        score = 0;
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {

	}

    /// <summary>
    /// Increments the score by one.
    /// </summary>
    public void incScore()
    {
        Score = Score + 1;
        Debug.Log("Player Health: " + Score);
		AkSoundEngine.PostEvent ("Pickup", player);

    }
}
