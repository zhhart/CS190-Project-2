using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().incScore();
        Destroy(this.gameObject);
    }
}
