using UnityEngine;
using System;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour
{
	public static Action EnemyDeadEvent;

	[SerializeField] private Avatar grabAvatar;
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
		if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
		{

			StartCoroutine(WaitFewSeconds());
		}

		//InvokeRepeating("GrabNPC", 2.0f, UnityEngine.Random.Range(3f, 10f));
	}

	IEnumerator WaitFewSeconds()
	{
		yield return new WaitForSeconds(UnityEngine.Random.Range(2f, 10f));
		anim.SetTrigger("Grab");
		anim.avatar = grabAvatar;

	}

	private void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == Tags.Bear)
		{
			Destroy(col.gameObject);
			sound.PlayAudio(2);
			particles.InstanciateParticle(1, this.transform);

			anim.gameObject.GetComponent<Animator>().enabled = false;

			if (EnemyDeadEvent != null)
			{
				EnemyDeadEvent();
			}

			StartCoroutine(TimeTillDeath());
		}
	}

	IEnumerator TimeTillDeath()
	{
		yield return new WaitForSeconds(1f);

		Destroy(this.gameObject);
	}
}