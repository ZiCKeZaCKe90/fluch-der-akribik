using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateBehaviour : MonoBehaviour {



    void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag("Ocean")) 
		{
			Destroy (gameObject);
		}

		if (other.CompareTag("Ship")) 
		{
			Destroy (gameObject);
			Destroy (other.gameObject);
		}
	}
}
