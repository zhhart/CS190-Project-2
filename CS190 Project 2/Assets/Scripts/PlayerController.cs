using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public float speed;
	private float walksoundCooldown = 0.7f;
	private float timeStamp;

    private bool isOnRegularFloor = true;

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
                if (isOnRegularFloor)
                {
                    AkSoundEngine.PostEvent("HouseFootStep", gameObject);
                }
                else
                {
                    AkSoundEngine.PostEvent("ConcreteStep", gameObject);
                }
			}
			
		}

        if (Input.GetKeyDown(KeyCode.E))
        {
            AkSoundEngine.PostEvent("Sigh", gameObject);
            Debug.Log("Sigh");
        }
		

		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Regular Floor")
        {
            isOnRegularFloor = true;
        }
        if (collision.gameObject.tag == "Concrete Floor")
        {
            Debug.Log("On Concrete");
            isOnRegularFloor = false;
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

        if (other.gameObject.name == "Alarm Zone")
        {
            AkSoundEngine.PostEvent("AlarmRing", gameObject);
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
			AkSoundEngine.PostEvent ("Zipper", gameObject);
		}
		if (other.gameObject.name == "Brushing") {
			AkSoundEngine.PostEvent ("Brushing", gameObject);
		}
		if (other.gameObject.name == "CarCrash") {
			AkSoundEngine.PostEvent ("CarCrash", gameObject);
		}

        if (other.gameObject.name == "TakeShower")
        {
            AkSoundEngine.PostEvent("StartShower", gameObject);
        }

        if (other.gameObject.name == "CarDoor")
        {
            AkSoundEngine.PostEvent("CarDoor", gameObject);
        }

        if (other.gameObject.name == "CarEngine")
        {
            AkSoundEngine.PostEvent("CarEngine", gameObject);
        }

        if (other.gameObject.name == "CarAlarm")
        {
            AkSoundEngine.PostEvent("CarAlarm", gameObject);
        }

        if (other.gameObject.name == "CarGearShift")
        {
            AkSoundEngine.PostEvent("CarGearShift", gameObject);
        }

        if (other.gameObject.name == "Sink")
        {
            AkSoundEngine.PostEvent("Sink", gameObject);
        }

        if (other.gameObject.name == "Door")
        {
            AkSoundEngine.PostEvent("Door", gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Alarm Zone" && Input.GetKeyDown(KeyCode.Q))
        {
            AkSoundEngine.PostEvent("TurnOffAlarm", gameObject);
            AkSoundEngine.PostEvent("StopAlarm", gameObject);
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

        if (other.gameObject.name == "TakeShower")
        {
            AkSoundEngine.PostEvent("StopShower", gameObject);
        }

        if (other.gameObject.name == "Brushing")
        {
            AkSoundEngine.PostEvent("StopBrush", gameObject);
        }
    }



}
