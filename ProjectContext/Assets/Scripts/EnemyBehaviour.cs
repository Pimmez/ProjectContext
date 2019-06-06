using UnityEngine;
using System;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour
{
	public static Action EnemyDeadEvent;

	[SerializeField] private Avatar grabAvatar;
	[SerializeField] private Avatar danceAvatar;
	[SerializeField] private Avatar loveAvatar;

	private SoundManager sound;
	private ParticleInstantiater particles;

	private Animator anim;

	private float timer;
	private float maxTimer = 8f;
	private bool isHit;

	private void Start()
	{
		sound = FindObjectOfType<SoundManager>();
		particles = FindObjectOfType<ParticleInstantiater>();
		anim = GetComponent<Animator>();
	}

	private void Update()
	{
		if(!isHit)
		{
			timer += Time.deltaTime;

			if (timer < maxTimer)
			{
				anim.SetTrigger("Dance");
				anim.avatar = danceAvatar;
			}

			if (timer >= maxTimer)
			{
				anim.SetTrigger("Grab");
				anim.avatar = grabAvatar;
			}
		}

		if(isHit)
		{
			anim.SetTrigger("Bear");
			anim.avatar = loveAvatar;
		}
	}

	public void EndOfGrab()
	{
		timer = 0;
	}

	private void EnemyAnimationIndex(int i, Avatar avatar)
	{
		anim.SetInteger("EnemySequence", i);
		anim.avatar = avatar;
	}

	private void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == Tags.Bear && anim.GetCurrentAnimatorStateInfo(0).IsName("Grab"))
		{
			isHit = true;
			Destroy(col.gameObject);
			sound.PlayAudio(2);
			particles.InstanciateParticle(1, this.transform);

			//Adds Points to UI
			if (EnemyDeadEvent != null)
			{
				EnemyDeadEvent();
			}
		}
	}
}