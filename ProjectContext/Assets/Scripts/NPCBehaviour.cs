using System;
using UnityEngine;
using System.Collections;


public class NPCBehaviour : MonoBehaviour
{
	public static Action NPCHitEvent;
	[SerializeField] private Animator anim;

	private SoundManager sound;	

	private void Start()
	{
		anim = GetComponent<Animator>();
		sound = FindObjectOfType<SoundManager>();
	}

	private void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == Tags.Bear)
		{
			col.gameObject.tag = Tags.Untagged;
			sound.PlayAudio(1);
			anim.SetBool("IsHit", true);

			if (NPCHitEvent != null)
			{
				NPCHitEvent();
			}

			StartCoroutine("CancelAnimation");
		}
	}

	private IEnumerator CancelAnimation()
	{ 
		yield return new WaitForSeconds(1f);
		anim.SetBool("IsHit", false);
	}
}