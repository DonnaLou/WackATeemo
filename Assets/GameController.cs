using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public Transform Teemo;
	public Transform Shroom;
	
	int shroomPosition;
	int teemoPosition;
	
	List<Vector3> PositionList;
	
	void Start () 
	{
		Initialize ();
		InvokeRepeating ("ChangePositions", 2, 2);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(HitObject ())
		{
			ChangePositions();
			CancelInvoke();
			InvokeRepeating ("ChangePositions", 2, 2);
		}
	}	

	void Initialize ()
	{
		ScoreCounter.currentHealth = ScoreCounter.maxHealth;
		Vector3 position1 = new Vector3 (-3.2434f, 3.75022f, 0f);
		Vector3 position2 = new Vector3 (0.17787f, 3.64654f, 0f);
		Vector3 position3 = new Vector3 (3.18452f, 3.50830f, 0f);
		Vector3 position4 = new Vector3 (-3.7618f, 0.95092f, 0f);
		Vector3 position5 = new Vector3 (-0.2022f, 1.15827f, 0f);
		Vector3 position6 = new Vector3 (3.66835f, 1.22739f, 0f);
		Vector3 position7 = new Vector3 (-4.4530f, -1.9520f, 0f);
		Vector3 position8 = new Vector3 (-.012f, -2.31f, 0f);
		Vector3 position9 = new Vector3 (3.99255f, -2.1372f, 0f);
		PositionList = new List<Vector3> () {
			position1,
			position2,
			position3,
			position4,
			position5,
			position6,
			position7,
			position8,
			position9
		};
	}

	void ChangePositions()
	{
		teemoPosition = Random.Range (1,9);
		shroomPosition = Random.Range(1,9);
		
		while(teemoPosition == shroomPosition)
		{
			shroomPosition = Random.Range (1,9);
		}		
		
		Teemo.position = PositionList[teemoPosition-1];
		Shroom.position = PositionList[shroomPosition-1];
	}
	
	bool HitObject()
	{
		if(Input.GetMouseButtonDown (0))
		{
			Vector3 mousePos = Input.mousePosition;
			mousePos.z = 10;
			Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePos);
			
			RaycastHit2D hitInfo = Physics2D.Raycast (mouseWorldPosition, Vector2.zero);		
			
			if(hitInfo != null && hitInfo.rigidbody != null)
			{
				ScoreCounter.hit(hitInfo.rigidbody.name);
				return true;
			}
		}
		return false;
	}
}
