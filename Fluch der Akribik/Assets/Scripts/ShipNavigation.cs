using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ShipNavigation : MonoBehaviour {

	public Camera cam;

	public NavMeshAgent agent;
	public Transform[] targets;

	[Range(1.0f,5.0f)]
	public float maxTimeBetweenNewTarget;

	private Transform currentTarget;
	private bool coroutineIsRunning;

	void Awake () 
	{
		agent = GetComponent<NavMeshAgent> ();
	}

	void Update () 
	{
		if (!coroutineIsRunning)
			StartCoroutine (RandomNavigation ());

		// Destroy Condition
		if (transform.position.x == currentTarget.position.x) 
		{
			Destroy (gameObject);
		}
			
	}

	void FindNewTarget ()
	{
		currentTarget = targets[Random.Range(0,targets.Length)];
	}

	float SetNewWaitForSeconds ()
	{
		float randomWaitForSeconds = Random.Range (1, maxTimeBetweenNewTarget);
		return randomWaitForSeconds;
	}

	IEnumerator RandomNavigation ()
	{
		
		coroutineIsRunning = true;
		FindNewTarget ();
		agent.SetDestination (currentTarget.position);
		yield return new WaitForSeconds (SetNewWaitForSeconds());
		coroutineIsRunning = false;
	}
}
