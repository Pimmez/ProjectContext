using System;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{
	public static Action NPCHitEvent;
	private SoundManager sound;
	private ParticleInstantiater particles;

	private void Start()
	{
		sound = FindObjectOfType<SoundManager>();
		particles = FindObjectOfType<ParticleInstantiater>();
	}

	private void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == Tags.Bear)
		{
			//Destroy(col.gameObject);
			sound.PlayAudio(1);
			particles.InstanciateParticle(0, this.transform);

			if (NPCHitEvent != null)
			{
				NPCHitEvent();
			}
		}
	}
}