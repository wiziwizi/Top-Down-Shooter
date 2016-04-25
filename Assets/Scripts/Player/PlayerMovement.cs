using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {


	public float speed;
	private Rigidbody _rigidbody;
	private float xInput;
	private float yInput;
	private Vector3 movement;


	void Awake()
	{
		// make reference with Rigidbody component
		_rigidbody = GetComponent<Rigidbody>(); 
	}

	void Update()
	{
		// FetchInput needed for movement
		xInput = Input.GetAxis("Horizontal");
		yInput = Input.GetAxis ("Vertical");

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		Plane plane = new Plane (Vector3.up, Vector3.zero);
		float distance;
		if (plane.Raycast (ray, out distance))
		{
			Vector3 point = ray.GetPoint (distance);
			Vector3 adjustedHeightPoint = new Vector3 (point.x, transform.position.y, point.z);
			transform.LookAt(adjustedHeightPoint);
		}
	}

	void FixedUpdate()
	{
		if (TimeControl.TIME == false)
		{
			//move rigidbody using MovePosition()
			Vector3 direction = new Vector3 (xInput, 0f, yInput);
			Vector3 velocity = direction.normalized * speed * Time.fixedDeltaTime;
			_rigidbody.MovePosition (_rigidbody.position + velocity);
		}
	}

	void OnTriggerStay(Collider other)
	{
		if(other.CompareTag ("Car"))
		{
			Debug.Log ("yup");
			if(Input.GetKey ("e"))
			{
				SceneManager.LoadScene ("EndScene");
			}
		}
	}
		
}
