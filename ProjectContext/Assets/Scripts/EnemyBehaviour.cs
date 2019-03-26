using UnityEngine;
using System;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour
{
	public static Action EnemyDeadEvent;

	private SoundManager sound;

	private bool isVulnerable = false;
	[SerializeField] private Animator anim;

    private GameObject particle;

	private void Start()
	{
		sound = FindObjectOfType<SoundManager>();
        particle = Resources.Load("particle_clouds") as GameObject;
    }

	private void Update()
	{
		StartCoroutine("Grab");
		isVulnerable = true;
	}

	private IEnumerator Grab()
	{
		anim.SetBool("Pickup", true);

		yield return new WaitForSeconds(3f);

		anim.SetBool("Pickup", false);
	}

	private void OnTriggerEnter(Collider col)
	{
		if(isVulnerable)
		{
			if (col.gameObject.tag == Tags.Bear)
			{
                Instantiate(particle, this.transform, false);
				sound.PlayAudio(2);

				if (EnemyDeadEvent != null)
				{
					EnemyDeadEvent();
				}
			}
		}
	}
}