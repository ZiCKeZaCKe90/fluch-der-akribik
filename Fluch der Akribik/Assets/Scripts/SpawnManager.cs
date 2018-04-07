using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	public GameObject ship;

	[Range(1.0f,10.0f)]
	public float maxTimeBetweenSpawns;

	public Transform[] spawnPoints;
	public Transform[] targetPoints;

	private bool coroutineIsRunning;
	private Transform currentSpawnPoint;
	public GameObject currentShip;


	void Update () 
	{
		if (!coroutineIsRunning)
			StartCoroutine (Spawn ());
	}

	void SetNewSpawnPoint()
	{
		currentSpawnPoint = spawnPoints [Random.Range (0, spawnPoints.Length)];
	}

	float SetNewWaitForSeconds ()
	{
		float randomWaitForSeconds = Random.Range (1, maxTimeBetweenSpawns);
		return randomWaitForSeconds;
	}

	IEnumerator Spawn()
	{
		coroutineIsRunning = true;
		SetNewSpawnPoint ();
		currentShip = Instantiate (ship, currentSpawnPoint.position, Quaternion.identity);
		currentShip.GetComponent<ShipNavigation> ().targets = targetPoints;
		yield return new WaitForSeconds (SetNewWaitForSeconds ());
		coroutineIsRunning = false;
	}
}
