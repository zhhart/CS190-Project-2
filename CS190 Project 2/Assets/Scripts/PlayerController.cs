using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public float speed;

    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

		transform.Rotate(0, x, 0);
		transform.Translate(0, 0, z);

		/*if (z != 0) {
			AkSoundEngine.PostEvent ("HouseFootStep", gameObject);
		}*/

		
	}


	private void OnTriggerEnter(Collider other)
	{
		//HOW TO: AkSoundEngine.PostEvent("EventID from Wwise", gameObject to Play sound from);

		if (other.gameObject.name == "OutOfBed") {
			AkSoundEngine.PostEvent ("GettingOutOfBed", gameObject);
		}

		if (other.gameObject.name == "Yawning") {
			AkSoundEngine.PostEvent ("Yawning", gameObject);
		}

		if (other.gameObject.name == "TurnOffAlarm") {
			AkSoundEngine.PostEvent ("TurnOffAlarm", gameObject);
		}

	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "DestroyOnExit") {
			Destroy (other.gameObject);
		}
	}



}
