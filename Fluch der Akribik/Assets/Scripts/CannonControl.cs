using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonControl : MonoBehaviour {

	public Transform head;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButton (0)) 
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			Physics.Raycast (ray, out hit);

			head.transform.LookAt (hit.point);

			Vector3 distanceVector = hit.point - transform.position;
			float distance = Vector3.Magnitude (distanceVector);

			if (Input.GetMouseButtonDown(0))
				Debug.Log ("ObjectName: " + hit.transform.name + " | Distance: " + distance);


			Debug.DrawLine (transform.position, hit.point, Color.red);

		}


	}
}
