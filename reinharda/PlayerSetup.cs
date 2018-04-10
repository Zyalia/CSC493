/* Acknowledgement: This sniplet of code is from Brackey's "Making a Multiplayer FPS in Unity" tutorial
 * 					and I modified it to my content.
 * 
 * The link to the github of all of his code is here:
 * https://github.com/Brackeys/MutliplayerFPS-Tutorial/tree/master/MultiplayerFPS/Assets/Scripts
 * 
 * I didn't change the title of the scripts used so they can easily be looked up within his scripts folder
 * and compared. He has a lot of more things added onto his version than there is to mine so things won't
 * entire match.
 * 
 * Usage: Sets up the player for networking so that Behaviors and several cameras aren't in the scene
 * 			at the same time.
*/

using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour {

	[SerializeField]
	Behaviour[] componentsToDisable;

	Camera sceneCamera;

	void Start()
	{
		//If the player isn't local, then disable the components
		if (!isLocalPlayer) {
			for (int i = 0; i < componentsToDisable.Length; i++) {
				componentsToDisable [i].enabled = false;
			}
		} else 
		{
			//sets the main Camera (the one looking over the whole map to inactive
			sceneCamera = Camera.main;
			if (sceneCamera != null) 
			{
				sceneCamera.gameObject.SetActive (false);
			}
		}
	}

	void OnDisable()
	{
		//If the sceneCamera is set to null, then set the camera on the player to active.
		//This way, there aren't two or more cameras in the scene in the same time.
		if (sceneCamera != null) 
		{
			sceneCamera.gameObject.SetActive (true);
		}
	}

}
