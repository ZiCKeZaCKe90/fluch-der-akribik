using UnityEngine;
using UnityEngine.AI;

public class ShipNavigation : MonoBehaviour {

	public Camera cam;

	public NavMeshAgent agent;

	// Use this for initialization
	void Start () 
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			Ray ray = cam.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				agent.SetDestination (hit.point);
				Debug.Log ("Hit!");
			}
		}	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
