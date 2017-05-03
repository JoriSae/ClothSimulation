using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restraints : MonoBehaviour
{
    public List<GameObject> objs;

    public float distance;
    public float compensate1;
    public float compensate2;

    void FixedDistanceConstraint(ref Vector3 pos1,ref Vector3 pos2, float desired_dist, float compensate1, float compensate2)
    {
        Vector3 delta = pos2 - pos1;

        float deltalength = delta.magnitude;

        if (deltalength > desired_dist)
        {
            float diff = (deltalength - desired_dist) / deltalength;

            pos1 += delta * compensate1 * diff;

            pos2 -= delta * compensate2 * diff;
        }
    }
	
	// Update is called once per frame
	void FixedUpdate()
    {
        foreach (GameObject obj in objs)
        {
                Vector3 p1 = transform.position;
                Vector3 p2 = obj.transform.position;
                FixedDistanceConstraint(ref p1, ref p2, distance, compensate1, compensate2);
                transform.position = p1;
                obj.transform.position = p2;
                Debug.DrawLine(p1, p2, Color.red);
        }
	}
}
