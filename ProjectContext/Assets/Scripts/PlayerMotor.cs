using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
	[SerializeField] private Camera cam;

	private Vector3 velocity = Vector3.zero;
	private Vector3 rotation = Vector3.zero;
	private Vector3 camRotation = Vector3.zero;

	private Rigidbody rb;

	private void Start()
    {
		rb = GetComponent<Rigidbody>();
    }

	public void Rotate(Vector3 _rotation)
	{
		rotation = _rotation;
	}

	public void RotateCamera(Vector3 _camRotation)
	{
		camRotation = _camRotation;
	}

	private void FixedUpdate()
	{
		PerformRotation();
	}

	private void PerformRotation()
	{
		rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
		if(cam != null)
		{
			cam.transform.Rotate(-camRotation);
		}
	}
}