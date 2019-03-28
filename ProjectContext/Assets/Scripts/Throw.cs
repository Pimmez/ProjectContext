using UnityEngine;
using UnityEngine.UI;

public class Throw : MonoBehaviour
{
    public static bool gameStarted = false;
	private SoundManager sound;

	[SerializeField] private GameObject startUI;

	[SerializeField] private GameObject UI;

	public float FireRate { get { return fireRate; } }
	public float NextFire { get { return nextFire; } }

	private GameObject prefab;
	[SerializeField] private float throwStrength = 20;
	[SerializeField] private GameObject ArmPosition;

	private float fireRate = 1;
	private float nextFire = 0.0F;

	private Vector3 offset = new Vector3(0, 0.5f, 0);
	private Vector3 muzzlePosition;

	private void Start()
	{
		gameStarted = false;
		sound = FindObjectOfType<SoundManager>();
		prefab = Resources.Load("projectile") as GameObject;
	}

	private void Update()
	{
        if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Fire1"))
        {
            if (gameStarted && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                FirerateUI.Instance.CoolDown = true;
                sound.PlayAudio(0);

                muzzlePosition = ArmPosition.transform.position - offset;
                GameObject projectile = Instantiate(prefab, muzzlePosition, Quaternion.identity) as GameObject;
                Rigidbody rb = projectile.GetComponent<Rigidbody>();
                projectile.transform.parent = null;
                rb.velocity = Camera.main.transform.forward * throwStrength;
            } else if (!gameStarted)
            {
                UI.gameObject.SetActive(true);
				startUI.gameObject.SetActive(false);
				gameStarted = true;
            }
        }
	}
}