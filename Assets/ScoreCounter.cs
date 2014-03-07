using UnityEngine;
using System.Collections;

public class ScoreCounter : MonoBehaviour {

	public static int maxHealth = 3;
	public static int currentHealth;	
	public GUISkin ScoreSkin;
	
	public static void hit(string objName)
	{
		if(objName != "Teemo")
			currentHealth--;
	
	}
	
	public void OnGUI()
	{
		GUI.skin = ScoreSkin;
		GUI.Label(new Rect(Screen.width/2 - 100, 40, 250, 100), "CurrentHealth = " + currentHealth);
	}
}
