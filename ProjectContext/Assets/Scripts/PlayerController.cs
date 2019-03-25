using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
	[SerializeField] private float lookSensitivityX = 5f;
	[SerializeField] private float lookSensitivityY = 5f;

	private PlayerMotor playerMotor;

	private void Start()
    {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		playerMotor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
		//Player Horizontal Rotation
		float _yRot = Input.GetAxisRaw("Mouse X");

		Vector3 _rotation = new Vector3(0, _yRot, 0) * lookSensitivityX;

		playerMotor.Rotate(_rotation);

		//Cam Vertical Rotation
		float _xRot = Input.GetAxisRaw("Mouse Y");

		Vector3 _camRotation = new Vector3(_xRot, 0, 0) * lookSensitivityY;

		playerMotor.RotateCamera(_camRotation);
	}
}
