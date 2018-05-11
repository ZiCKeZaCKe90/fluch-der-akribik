using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShooting : MonoBehaviour {

//	public int playerNumber = 1;
	public Rigidbody pirate;
	public Transform fireTransform;

	public float minLaunchForce;
	public float maxLaunchForce;

//	private string fireButton;
	public float currentLaunchForce;
	private float chargeSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonUp (0)) 
		{
			Fire ();
		}
	}

	void Fire() 
	{
		Rigidbody pirateInstance = Instantiate (pirate, fireTransform.position, fireTransform.rotation) as Rigidbody;

		pirateInstance.velocity = currentLaunchForce * fireTransform.forward;
	}


}
