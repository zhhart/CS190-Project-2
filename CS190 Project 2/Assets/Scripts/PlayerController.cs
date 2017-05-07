using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public float speed;
	private float walksoundCooldown = 0.7f;
	private float timeStamp;

	private GameObject humanSnoringGameObject;
    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
		humanSnoringGameObject = GameObject.Find ("HumanSnoring");
	}
	
	// Update is called once per frame
	void Update () {
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

		transform.Rotate(0, x, 0);
		transform.Translate(0, 0, z);

		//Add a Timer to check when to play foodstep sounds again

		if (timeStamp <= Time.time && z!=0) { 
			{
				timeStamp = Time.time + walksoundCooldown;	
				AkSoundEngine.PostEvent ("HouseFootStep", gameObject);
				Debug.Log ("Walk");
			}
			
		}
		

		
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
		if (other.gameObject.name == "FoodFrying") {
			AkSoundEngine.PostEvent ("FoodFrying", gameObject);
		}
		if (other.gameObject.name == "DoorShower") {
			AkSoundEngine.PostEvent ("DoorShower", gameObject);
		}
			
		if (other.gameObject.name == "PuttingOnClothes") {
			AkSoundEngine.PostEvent ("PuttingOnClothes", gameObject);
		}

		if (other.gameObject.name == "Zipper") {
			AkSoundEngine.PostEvent ("PuttingOnClothes", gameObject);
		}
		if (other.gameObject.name == "Brushing") {
			AkSoundEngine.PostEvent ("Brushing", gameObject);
		}
		if (other.gameObject.name == "CarCrash") {
			AkSoundEngine.PostEvent ("CarCrash", gameObject);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "DestroyOnExit") {
			Destroy (other.gameObject);
		}
		if (other.gameObject.tag == "StopOnExit") {
			AkSoundEngine.PostEvent ("StopHumanSnoring", humanSnoringGameObject); 
			//AkSoundEngine.StopPlayingID (2213787648); //HumanSnoring Event ID found in Wwise - Does not turn off..
			Debug.Log("Turned off Snoring");
		}


	}



}
