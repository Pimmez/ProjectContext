using UnityEngine;

public class Throw : MonoBehaviour
{
	public float FireRate { get{ return fireRate; } }
	public float NextFire { get { return nextFire; } }

	[SerializeField] private GameObject prefab;
	[SerializeField] private float throwSrength = 100;
	[SerializeField] private GameObject ArmPosition;

	private float fireRate = 1;
	private float nextFire = 0.0F;

	private void Start()
	{
		prefab = Resources.Load("projectile") as GameObject;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
		{
			FirerateUI.Instance.CoolDown = true;
			nextFire = Time.time + fireRate;
			GameObject projectile = Instantiate(prefab, ArmPosition.transform, false) as GameObject;
			Rigidbody rb = projectile.GetComponent<Rigidbody>();
			projectile.transform.parent = null;
			rb.velocity = Camera.main.transform.forward * (throwSrength * 10) * Time.deltaTime;
		}
	}
}