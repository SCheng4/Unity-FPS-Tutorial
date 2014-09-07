using UnityEngine;
using System.Collections;

public class FP_controller : MonoBehaviour {

	public float movementSpeed = 5.0f;
	public float mouseSensitivity = 5.0f;
	public float updownRange = 60.0f;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		// Rotation
		float rotUpDown = Input.GetAxis ("Mouse Y") * mouseSensitivity;
		transform.Rotate (-rotUpDown, 0, 0);

		float currentUpDown = Camera.main.transform.rotation.eulerAngles.x;
		float desiredUpDown = currentUpDown - rotUpDown;
		//desiredUpDown = Mathf.Clamp (desiredUpDown, -updownRange, updownRange);

		Camera.main.transform.rotation = Quaternion.Euler (desiredUpDown, 0, 0);

		float rotLeftRight = Input.GetAxis ("Mouse X") * mouseSensitivity;
		transform.Rotate (0, rotLeftRight, 0);

		// Movement
		float forwardSpeed = Input.GetAxis ("Vertical") * movementSpeed;
		float sideSpeed = Input.GetAxis ("Horizontal") * movementSpeed;

		Vector3 speed = new Vector3 (sideSpeed, 0, forwardSpeed);
		speed = transform.rotation * speed;

		CharacterController cc = GetComponent<CharacterController> ();
		cc.SimpleMove (speed);
	}
}
