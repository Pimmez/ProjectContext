using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

	private float mouseInput;
	private Vector3 lookAround;
	[SerializeField] private float sensitivity = 100;

	private void Start()
	{
		Cursor.visible = false;
	}

	void Update()
    {
		mouseInput = Input.GetAxis("Mouse X");
		lookAround = new Vector3(0, mouseInput, 0) * sensitivity * Time.deltaTime;
		transform.Rotate(lookAround);
	}
}
