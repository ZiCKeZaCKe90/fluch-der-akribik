using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaunchArcRenderer : MonoBehaviour {

    LineRenderer lineRenderer;

    public float velocity;
    public float angle;
    public int resolution = 10;

    float gravity;
    float radianAngle;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        gravity = Mathf.Abs(Physics.gravity.y);
    }

    private void OnValidate()
    {
        if (lineRenderer != null & Application.isPlaying)
        {
            RenderArc();
        }
    }

    void Start ()
    {
        RenderArc();
	}

    void RenderArc()
    {
        lineRenderer.SetVertexCount(resolution + 1);
        lineRenderer.SetPositions(CalculateArcArray());
    }

    Vector3[] CalculateArcArray()
    {
        Vector3[] arcArray = new Vector3[resolution + 1];

        radianAngle = Mathf.Deg2Rad * angle;
        float maxDistance = (velocity * velocity * Mathf.Sin(2 * radianAngle)) / gravity;

        for (int i = 0; i <= resolution; i++)
        {
            float t = (float)i / (float)resolution;
            arcArray[i] = CalculateArcPoint(t, maxDistance);
        }

        return arcArray;
    }

    Vector3 CalculateArcPoint(float t, float maxDistance)
    {
        float x = t * maxDistance;
        float y = x * Mathf.Tan(radianAngle) - ((gravity * x * x) / (2 * velocity * velocity * Mathf.Cos(radianAngle) * Mathf.Cos(radianAngle)));
        return new Vector3(x, y);
    }


	

}
