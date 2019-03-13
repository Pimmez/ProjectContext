using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class EnemyBehaviour : MonoBehaviour
{
	public static Action EnemyDeadEvent;

	[SerializeField] private float duration = 3f;
	private float time = 0;
	private new Renderer renderer;
	private bool isVulnerable = false;

	private void Start()
	{
		renderer = GetComponent<Renderer>();
	}

	private void Update()
	{
		Invoke("ColorChanger", Random.Range(3, 10));
	}

	private void ColorChanger()
	{
		renderer.material.color = Color.Lerp(Color.cyan, Color.red, time);
		IsTargetHit();

		if (time < 1)
		{
			time += Time.deltaTime / duration;
		}
	}

	private void IsTargetHit()
	{
		if(renderer.material.color != Color.red)
		{
			//Debug.Log("Can be hit");
			isVulnerable = true;
		}
		else
		{
			//Debug.Log("RAPING IN PROGRESS");
			isVulnerable = false;
		}
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