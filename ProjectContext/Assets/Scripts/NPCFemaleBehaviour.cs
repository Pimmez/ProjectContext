using System.Collections;
using System;
using UnityEngine;

public class NPCFemaleBehaviour : MonoBehaviour
{
	[SerializeField] private Avatar cryAvatar;
	[SerializeField] private Avatar reactionAvatar;

	public static Action FemaleHitEvent;
	[SerializeField] private Animator anim;

	private SoundManager sound;

	private void Start()
	{
		anim = GetComponent<Animator>();
		sound = FindObjectOfType<SoundManager>();
	}

	private void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == Tags.Bear)
		{
			col.gameObject.tag = Tags.Untagged;
			sound.PlayAudio(1);

			anim.avatar = reactionAvatar;
			anim.SetTrigger("femaleHit");

			StartCoroutine(ChangeAvatar());

			if (FemaleHitEvent != null)
			{
				FemaleHitEvent();
			}
		}
	}

	
	IEnumerator ChangeAvatar()
	{
		yield return new WaitForSeconds(2.1f);
		anim.avatar = cryAvatar;
		anim.Play("Cry");
	}
	



}