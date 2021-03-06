/* Acknowledgement: This sniplet of code is from Brackey's "Making a Multiplayer FPS in Unity" tutorial
 * 					and I modified it to my content.
 * 
 * The link to the github of all of his code is here:
 * https://github.com/Brackeys/MutliplayerFPS-Tutorial/tree/master/MultiplayerFPS/Assets/Scripts
 * 
 * I didn't change the title of the scripts used so they can easily be looked up within his scripts folder
 * and compared. He has a lot of more things added onto his version than there is to mine so things won't
 * entirely match.
 * 
 * Usage: Interacts with the PlayerController script on the same object in performing the player movement
 * 			and rotation.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

	[SerializeField]
	private Camera cam;

	private Vector3 velocity = Vector3.zero;
	private Vector3 rotation = Vector3.zero;
	private Vector3 cameraRotation = Vector3.zero;
	private Vector3 thrusterForce = Vector3.zero;

	private Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
	}

	//Gets movement vector, rotation Vector, etc
	public void Move (Vector3 _velocity)
	{
		velocity = _velocity;
	}

	public void Rotate (Vector3 _rotation)
	{
		rotation = _rotation;
	}

	public void RotateCamera (Vector3 _cameraRotation)
	{
		cameraRotation = _cameraRotation;
	}

	public void ApplyThruster (Vector3 _thrusterForce)
	{
		thrusterForce = _thrusterForce;
	}

	void FixedUpdate()
	{
		PerformMovement ();
		PerformRotation ();
	}

	//Performs Movement based on velocity variable
	void PerformMovement()
	{
		//Always check to make sure things aren't zero/null
		if (velocity != Vector3.zero) 
		{
			rb.MovePosition (transform.position + velocity * Time.fixedDeltaTime);
		}

		if (thrusterForce != Vector3.zero) 
		{
			rb.AddForce (thrusterForce * Time.fixedDeltaTime, ForceMode.Acceleration);
		}
	}

	//Perform rotation
	void PerformRotation()
	{
		rb.MoveRotation (rb.rotation * Quaternion.Euler(rotation));

		cam.transform.Rotate(-cameraRotation);

		/////If you want camera to be optional:
		//if (cam != null) 
		//{
			
		//}
	}
}
