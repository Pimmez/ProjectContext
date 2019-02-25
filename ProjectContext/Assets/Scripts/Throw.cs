using UnityEngine;

public class Throw : MonoBehaviour
{
	[SerializeField] private GameObject prefab;
	[SerializeField] private float fireRate = 1;
	[SerializeField] private float nextFire = 0.0F;
	[SerializeField] private float throwSrength = 100;
	[SerializeField] private GameObject ArmPosition;

	private void Start()
	{
		prefab = Resources.Load("projectile") as GameObject;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			GameObject projectile = Instantiate(prefab, ArmPosition.transform, false) as GameObject;
			Rigidbody rb = projectile.GetComponent<Rigidbody>();
			projectile.transform.parent = null;
			rb.velocity = Camera.main.transform.forward * (throwSrength * 10) * Time.deltaTime;
		}
	}
}