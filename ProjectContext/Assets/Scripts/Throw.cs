using UnityEngine;

public class Throw : MonoBehaviour
{
	private SoundManager sound;

	public float FireRate { get { return fireRate; } }
	public float NextFire { get { return nextFire; } }

	private GameObject prefab;
	[SerializeField] private float throwStrength = 20;
	[SerializeField] private GameObject ArmPosition;
	[SerializeField] public float fireRate = 1;
	private float nextFire = 0.0F;

	private Vector3 offset = new Vector3(0, 0.5f, 0);
	private Vector3 muzzlePosition;

	private void Start()
	{
		sound = FindObjectOfType<SoundManager>();
		prefab = Resources.Load("projectile") as GameObject;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && Time.time > nextFire || Input.GetButtonDown("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			FirerateUI.Instance.CoolDown = true;
			sound.PlayAudio(0);

			muzzlePosition = ArmPosition.transform.position - offset;
			GameObject projectile = Instantiate(prefab, muzzlePosition, Quaternion.identity) as GameObject;
			Rigidbody rb = projectile.GetComponent<Rigidbody>();
			projectile.transform.parent = null;
			rb.velocity = Camera.main.transform.forward * throwStrength;
		}
	}
}