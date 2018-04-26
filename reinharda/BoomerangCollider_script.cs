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
using UnityEngine.Networking;

public class BoomerangCollider_script : NetworkBehaviour 
{
	//INFO: The following two lines didn't work
	//public BoomerangScript boomerangScript;
	//public GameObject boomerangScript;

	public GameObject player;
	public Player_Stats stats;

	void Start()
	{
		Player_Stats stats = player.GetComponent<Player_Stats> ();
	}

	void OnTriggerEnter(Collider other)
	{
		//if wall, destroy this object
		if(other.CompareTag("wall") || other.CompareTag("ground"))
		{
			Destroy (gameObject);
		}

		else if (other.CompareTag ("5 point target")) 
		{
			Destroy (other.gameObject);
			stats.ChangePoints (5);
			Debug.Log ("5 points have been added");
		}

		//if target, destroy the target
		else if (other.CompareTag("10 point target"))
		{
			Destroy (other.gameObject);
			stats.ChangePoints (10);
			//stats.points = stats.points + 10;
			Debug.Log ("Detected 10 point target and destroyed");
		}

		//if target, destroy the target
		else if (other.CompareTag("20 point target"))
		{
			Destroy (other.gameObject);
			stats.ChangePoints (20);
			//stats.points = stats.points + 10;
			Debug.Log ("Detected 20 point target and destroyed");
		}

		else if (other.CompareTag("30 point target"))
		{
			Destroy (other.gameObject);
			stats.ChangePoints (30);
			//stats.points = stats.points + 10;
			Debug.Log ("Detected 30 point target and destroyed");
		}

		else if (other.CompareTag("50 point target"))
		{
			Destroy (other.gameObject);
			stats.ChangePoints (50);
			//stats.points = stats.points + 10;
			Debug.Log ("Detected 50 point target and destroyed");
		}

		else if (other.CompareTag("100 point target"))
		{
			Destroy (other.gameObject);
			stats.ChangePoints (100);
			//stats.points = stats.points + 10;
			Debug.Log ("Detected 100 point target and destroyed");
		}

		else if (other.CompareTag ("Player")) 
		{
			//TODO: Figure out how to make health decrease
			//other.gameObject.Player_Stats.health -= 30;
			Debug.Log("Player was hit");
		}
	}
}
