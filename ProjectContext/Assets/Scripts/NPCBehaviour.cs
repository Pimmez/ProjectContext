using System;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{
	public static Action NPCHitEvent;

	private void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == Tags.Bear)
		{
			Debug.Log("Hit Target NPC");

			if (NPCHitEvent != null)
			{
				NPCHitEvent();
			}
		}
	}
}