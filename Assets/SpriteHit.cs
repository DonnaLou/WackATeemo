using UnityEngine;
using System.Collections;

public class SpriteHit : MonoBehaviour {

	void OnTriggerEnter2D( Collider2D hitTarget)
	{
		Debug.Log("" + hitTarget.name);
	}
}
