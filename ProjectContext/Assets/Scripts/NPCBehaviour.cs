using System;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{
	public static Action NPCHitEvent;
	private SoundManager sound;

	private void Start()
	{
		sound = FindObjectOfType<SoundManager>();
	}

	private void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == Tags.Bear)
		{
			Debug.Log("Hit Target NPC");
			Destroy(col.gameObject);
			sound.PlayAudio(1);

			if (NPCHitEvent != null)
			{
				NPCHitEvent();
			}
		}
	}
}