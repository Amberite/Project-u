using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrivalDetector : MonoBehaviour {

	void OnTriggerEnter(Collider other) 
	{
		if (other.CompareTag("Player"))
		{
			gameObject.SendMessageUpwards("PlayerEntered", this, SendMessageOptions.RequireReceiver);
			Debug.Log(this.name + ": Player is all up in my personal space");
		}
		else {
			Debug.Log("Collider entered: " + other.name);
		}

	}
}
