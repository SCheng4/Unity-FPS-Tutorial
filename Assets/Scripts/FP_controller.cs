using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
public class FP_controller : MonoBehaviour {
	CharacterController characterController;
	public float movementSpeed = 5.0f;
	public float mouseSensitivity = 5.0f;

	float verticalVelocity = 0;
	float verticalRotation = 0;
	public float updownRange = 60.0f;
	float jumpSpeed = 7;

	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		characterController = GetComponent<CharacterController> ();
	}

	// Update is called once per frame
	void Update () {
		// Rotation
		float rotLeftRight = Input.GetAxis ("Mouse X") * mouseSensitivity;
		transform.Rotate (0, rotLeftRight, 0);
		
		verticalRotation -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
		verticalRotation = Mathf.Clamp (verticalRotation, -updownRange, updownRange);
		Camera.main.transform.localRotation = Quaternion.Euler (verticalRotation, 0, 0);
		
		// Movement
		if (characterController.isGrounded) {
			if (Input.GetButtonDown ("Jump")) {
					verticalVelocity = jumpSpeed;
			}
		}

		float forwardSpeed = Input.GetAxis ("Vertical") * movementSpeed;
		float sideSpeed = Input.GetAxis ("Horizontal") * movementSpeed;



		verticalVelocity += Physics.gravity.y * Time.deltaTime;
		Vector3 speed = new Vector3 (sideSpeed, verticalVelocity, forwardSpeed);
		speed = transform.rotation * speed;

		characterController.Move (speed * Time.deltaTime);
	}
}
