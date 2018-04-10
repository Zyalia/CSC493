/*Code written by Angela Reinhard
 * 
 * Usage: This code deals with when the object this script is
 * 			attached to, enters another object's collider and 
 * 			will act accordingly. (make sure its set as a trigger)
 * 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Networking;

public class BoomerangCollider_script : MonoBehaviour 
{
	//INFO: The following two lines didn't work
	//public BoomerangScript boomerangScript;
	//public GameObject boomerangScript;

	void OnTriggerEnter(Collider other)
	{
		//if wall, destroy this object
		if(other.CompareTag("wall") || other.CompareTag("ground"))
		{
			Destroy (gameObject);
		}

		//if target, destroy the target
		if (other.CompareTag("10 point target"))
		{
			Destroy (other.gameObject);
			Debug.Log ("Detected 10 point target and destroyed");
		}
			
		if (other.CompareTag ("Player")) 
		{
			//TODO: Figure out how to make health decrease
			//other.gameObject.Player_Stats.health -= 30;
			Debug.Log("Player was hit");
		}
	}
}
