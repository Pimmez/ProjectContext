using UnityEngine;
using System;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour
{
	public static Action EnemyDeadEvent;

	private SoundManager sound;
	private ParticleInstantiater particles;

	[SerializeField] private Animator anim;

	private void Start()
	{
		sound = FindObjectOfType<SoundManager>();
		particles = FindObjectOfType<ParticleInstantiater>();
	}

	private void Update()
	{
		StartCoroutine("Grab");
	}

	private IEnumerator Grab()
	{
		anim.SetBool("Pickup", true);

		yield return new WaitForSeconds(3f);

		anim.SetBool("Pickup", false);
	}

	private void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == Tags.Bear)
		{
			Destroy(col.gameObject);
			sound.PlayAudio(2);
			particles.InstanciateParticle(1, this.transform);

			if (EnemyDeadEvent != null)
			{
				EnemyDeadEvent();
			}
		}
	}
}