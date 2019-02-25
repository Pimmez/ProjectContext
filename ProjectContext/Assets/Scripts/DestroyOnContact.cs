using UnityEngine;
using System;

public class DestroyOnContact : MonoBehaviour
{
	public static Action EnemyDeadEvent;

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == Tags.Enemy)
		{
			Destroy(gameObject);
			Destroy(collision.gameObject);
			if(EnemyDeadEvent != null)
			{
				EnemyDeadEvent();
			}
		}
	}
}
