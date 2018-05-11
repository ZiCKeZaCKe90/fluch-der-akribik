using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RenderBallisticPath : MonoBehaviour {

    public float velocity = 10.0f;
    public float timeResolution = 0.02f;
    public float maxTime = 10.0f;
    public LayerMask layerMask;

    private LineRenderer lineRenderer;

	// Use this for initialization
	void Start ()
    {
        lineRenderer = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 velocityVector = transform.forward * velocity;

        lineRenderer.positionCount = (int)(maxTime/timeResolution);

        int index = 0;

        Vector3 currentPosition = transform.position;

        for (float t = 0.0f; t < maxTime; t += timeResolution)
        {
            lineRenderer.SetPosition(index, currentPosition);

            RaycastHit hit;

            if (Physics.Raycast(currentPosition, velocityVector, out hit, velocityVector.magnitude * timeResolution, layerMask))
            {
                lineRenderer.positionCount = index + 2;
                lineRenderer.SetPosition(index + 1, hit.point);
                break;
            }

            currentPosition += velocityVector * timeResolution;
            velocityVector += Physics.gravity;
            index++;
        }
	}
}
