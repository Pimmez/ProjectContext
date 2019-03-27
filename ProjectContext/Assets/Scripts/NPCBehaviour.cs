using System;
using UnityEngine;
using System.Collections;


public class NPCBehaviour : MonoBehaviour
{
	public static Action NPCHitEvent;
	[SerializeField] private Animator anim;

	private SoundManager sound;
	private ParticleInstantiater particles;
	

	private void Start()
	{
		anim = GetComponent<Animator>();
		sound = FindObjectOfType<SoundManager>();
		particles = FindObjectOfType<ParticleInstantiater>();
	}

	private void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == Tags.Bear)
		{
			col.gameObject.tag = Tags.Untagged;
			sound.PlayAudio(1);
			anim.SetBool("IsHit", true);
			particles.InstanciateParticle(0, this.transform);
			Debug.Log(anim);
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