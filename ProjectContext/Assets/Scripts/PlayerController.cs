using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
	[SerializeField] private float lookSensitivityX = 5f;
	[SerializeField] private float lookSensitivityY = 5f;
	private bool inputSelection = true;

	private PlayerMotor playerMotor;
	private float yRot, xRot, yConRot, xConRot;

	private void Start()
    {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		playerMotor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        //ControllerInput();
        MouseInput();
	}

	
	private void MouseInput()
	{
		//Player Horizontal Rotation
		yRot = Input.GetAxisRaw("Mouse X");

		Vector3 _rotation = new Vector3(0, yRot, 0) * lookSensitivityX;

		playerMotor.Rotate(_rotation);

		//Cam Vertical Rotation
		xRot = Input.GetAxisRaw("Mouse Y");

		Vector3 _camRotation = new Vector3(xRot, 0, 0) * lookSensitivityY;

		playerMotor.RotateCamera(_camRotation);
	}
	
    /*
	private void ControllerInput()
	{
		//Player Horizontal Rotation
		yConRot = Input.GetAxisRaw("HorizontalController");

		Vector3 _Conrotation = new Vector3(0, yConRot, 0) * lookSensitivityX;

		playerMotor.Rotate(_Conrotation);

		//Cam Vertical Rotation
		xConRot = Input.GetAxisRaw("VerticalController");

		Vector3 _camConRotation = new Vector3(xConRot, 0, 0) * lookSensitivityY;

		playerMotor.RotateCamera(_camConRotation);
	}
	*/
}
