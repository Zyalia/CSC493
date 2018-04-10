/*Code by Angela Reinhard
 * 
 * Usage: This code is for spawning the Boomerang prefab,
 * 			adding force onto it so that it moves forward,
 * 			then will add force onto it once more in the
 * 			opposite direction after 2 seconds based on the Transform Vector.
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangScript : MonoBehaviour {

	public Rigidbody boomerang;

	//This is an empty Transform object in front of the
	// player object (a child object under player within the hierarchy).
	public Transform boomerangStart;

	public int damage;
	public int Speed;

	//The length of the shot before it changes directions
	public float TimeOfShot = 2f;
	//Float isn't needed anymore. TimeOfShot takes care of this.
	//public float AvailabilityTime = 3f;

	public bool boomerangAvailable = true;
	private bool movingForward = false;

	private Rigidbody boomerangInstance;

	void Update () {
		
		//checks if mouse was pressed and if boomerang is available
		if (Input.GetMouseButtonDown(0) && boomerangAvailable == true) 
		{
			//shooting the boomerang
			boomerangAvailable = false;

			//Instantiates the boomerang prefab
			Rigidbody boomerangInstance;
			boomerangInstance = Instantiate (boomerang, boomerangStart.position, boomerangStart.rotation) as Rigidbody;

			//adds force in forward direction of where the player is facing
			boomerangInstance.AddForce (boomerangStart.forward * Speed);
			movingForward = true;

			//starts the coroutine (countdown) for the boomerang changing direction
			StartCoroutine (ShootBoomerang (boomerangInstance, movingForward));

		}
	}

	//IEnumerator functions are countdown functions if you want to use timers
	IEnumerator ShootBoomerang(Rigidbody boomerangInstance, bool movingForward)
	{
		
		yield return new WaitForSeconds (TimeOfShot);

		//In case boomerang is destroyed before it starts to return
		if (boomerangInstance != null) 
		{
			movingForward = false;
			Debug.Log ("Time of shot has counted down");
			//Adds force into opposite direction of where the player is facing
			boomerangInstance.AddForce (-boomerangStart.forward * Speed * 2);
		}

		boomerangAvailable = true;

	}
}


/*INFO: THIS WAS ORIGINALLY USED TO MAKE THE BOOMERANG AVAILABLE AFTER A GIVEN TIME,
	 * BUT IT TURNS OUT IT CAN BE EASILY DONE BY SIMPLY PLACING THE LAST STATEMENT IN THE ShootBoomerang Enumerator.
	 * Though, if I want to make the Availablility a different time from when the boomerang switches directions,
	 * then I might use this part again.
	 * 
	 * StartCoroutine (MakeBoomerangAvailable (boomerangAvailable));
	 * 
	 * IEnumerator MakeBoomerangAvailable(bool boomerangAvailable)
	{
		//This is to make the Boomerang available 
		yield return new WaitForSeconds (AvailabilityTime);
		Debug.Log ("Boomerang now available");
		boomerangAvailable = true;
	}*/
