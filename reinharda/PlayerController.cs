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
 * Usage: This code deals with the camera movement as well as the player jumping, rotating, and being able to move.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour 
{

	[SerializeField]
	private float speed = 5f;

	[SerializeField]
	private float lookSensitivity = 3f;

	[SerializeField]
	private float thrusterForce = 1000f;

	private PlayerMotor motor;

	void Start()
	{
		motor = GetComponent<PlayerMotor>();
	}

	void Update()
	{
		//Calculate movement velocity
		float _xMov = Input.GetAxisRaw("Horizontal");
		float _zMov = Input.GetAxisRaw ("Vertical");

		Vector3 _movHorizontal = transform.right * _xMov;
		Vector3 _movVertical = transform.forward * _zMov;

		Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

		//Apply movement
		motor.Move(_velocity);

		//Calculate rotation vector (turning around)
		float _yRot = Input.GetAxisRaw("Mouse X");

		Vector3 _rotation = new Vector3 (0f, _yRot, 0f) * lookSensitivity;

		//Apply rotation
		motor.Rotate(_rotation);

		//Calculate rotation vector (looking up and down)
		float _xRot = Input.GetAxisRaw("Mouse Y");

		Vector3 _cameraRotation = new Vector3 (_xRot, 0f, 0f) * lookSensitivity;

		//Apply rotation
		motor.RotateCamera(_cameraRotation);

		Vector3 _thrusterforce = Vector3.zero;

		//calulcate and apply thruster. This all only works for objects with a Configurable Joint Behavior.
		if (Input.GetButton("Jump"))
		{
			_thrusterforce = Vector3.up * thrusterForce;
		}

		//Uses the method from the PlayerMotor script which is attached to the same object
		motor.ApplyThruster (_thrusterforce);
	}
}