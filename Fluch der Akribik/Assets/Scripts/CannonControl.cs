using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonControl : MonoBehaviour {

	public Transform head;

	public float maxDistance = 10.0f;
	public float minDistance = 1.0f;

	public float xAngleMax = 90.0f;
	public float xAngleMin = 0.0f;

	public float yAngleRight = 45.0f;
	public float yAngleLeft = 45.0f;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButton (0)) 
		{
			// Detect mousePosition in game world
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			Physics.Raycast (ray, out hit);

			// Calculating distance between transform.position and mousePosition
			Vector3 direction = hit.point - transform.position;
			float distance = Vector3.Magnitude (direction);

			// Calculate distance percentage
			float distancePercentage = Mathf.Clamp (distance / maxDistance, 0.0f, 1.0f);

			float xRotation = Mathf.Lerp (xAngleMin, xAngleMax, distancePercentage);

			//Vector3 newRotation = new Vector3 (xRotation, head.transform.rotation.y, head.transform.rotation.z);

			Quaternion lookRotation = Quaternion.LookRotation (direction);

			float yRotation = lookRotation.eulerAngles.y;


			head.transform.rotation = Quaternion.Euler (xRotation, yRotation, 0.0f);


			if (Input.GetMouseButtonDown(0))
				Debug.Log ("Distance: " + distance + " distancePercentage: " + distancePercentage);



		}
	}
}
