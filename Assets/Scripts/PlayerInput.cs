using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {
	private CharacterController _characterController;
	public float speed = 30.0f;
	public float gravity = -9.8f;
	public float rotationalSpeed = 1.0f;
	// Use this for initialization
	void Start () {
		_characterController = GetComponent<CharacterController> ();
	}
		
	// Update is called once per frame
	void Update () {
		float deltaX = Input.GetAxis ("Horizontal") * speed;
		float deltaZ = Input.GetAxis ("Vertical") * speed;
		Vector3 movement = new Vector3 (deltaZ, 0, -deltaX);
		movement = Vector3.ClampMagnitude (movement, speed);


		Quaternion direction = Quaternion.LookRotation (movement);
		transform.rotation = Quaternion.Lerp (transform.rotation, direction, rotationalSpeed * Time.deltaTime);

		movement.y = gravity;
		movement *= Time.deltaTime;
		movement = transform.TransformDirection (movement);
		_characterController.Move (movement);
	}
}
