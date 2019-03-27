using System.Collections.Generic;
using UnityEngine;

public class ParticleInstantiater : MonoBehaviour
{ 
	[SerializeField] private List<GameObject> particles = new List<GameObject>();

	private void Awake()
    {
		particles.Add(Resources.Load("particle_clouds") as GameObject);
		particles.Add(Resources.Load("particle_hearts") as GameObject);
	}

	public void InstanciateParticle(int particleID, Transform other)
	{
		Instantiate(particles[particleID], other.transform, false);
	}
}
