﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collision)
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().incScore();
		this.gameObject.SetActive (false);
    }
}
