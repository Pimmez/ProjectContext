using UnityEngine;
using System;
using System.Collections;
using Random = UnityEngine.Random;

public class EnemyBehaviour : MonoBehaviour
{
	public static Action EnemyDeadEvent;

	private bool isVulnerable = false;
	[SerializeField] private Animator anim;


	private void Update()
	{
		InvokeRepeating("TriggerGrab", Random.Range(3, 10), Random.Range(3, 10));
		isVulnerable = true;
	}

	private void TriggerGrab()
	{
		StartCoroutine("Grab");
	}

	private IEnumerator Grab()
	{
		anim.SetBool("Pickup", true);

		yield return new WaitForSeconds(.5f);

		anim.SetBool("Pickup", false);
	}

	private void OnCollisionEnter(Collision col)
	{
		if(isVulnerable)
		{
			if (col.gameObject.tag == Tags.Bear)
			{
				Destroy(this.gameObject);
				Destroy(col.gameObject);

				if (EnemyDeadEvent != null)
				{
					EnemyDeadEvent();
				}
			}
		}
	}
}