/*Code made by Angela Reinhard
 * 
 * Usage: This is a simple script for player statistics only.
 * 			This is meant to make things cleaner and easier to use.
 * 			This script is attached to the player object.
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Stats : MonoBehaviour {

	//These stats are varied to change within the coming weeks.
	//It's not certain if I'll use all of these statistics.
	//points is the most likely to be used.
	public int health = 100;
	public int points = 0;
	//Not using this variable:
	//public int attack_damage = 30;

	//public Text txt_point;
	//public Text txt_EndGame;
	public Text txt_point;

	void Start()
	{
		points = 0;
		txt_point.text = "Points: 0";
		Debug.Log ("In Start function of Player_Stats");
		//txt_EndGame.text = "";
	}

	public void ChangePoints(int value)
	{
		
		points = points + value;
		Debug.Log ("We are in ChangePoints");
		txt_point.text = "Points: " + points;

		if (points >= 500) 
		{
			Debug.Log ("Game won!");
			//txt_EndGame.text = "You Win!";
		}
	}

}
