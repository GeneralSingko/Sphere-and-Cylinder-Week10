using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cylinder", menuName = "Cylinder")]
public class Cylinder : ScriptableObject
{
    public float radius;
    public float height;
    public Vector3 transformPosition;
    public int segments;
    public float rotationAngle;

    public Vector3[] points
    {
        get
        {
            int numPoints = segments * 2;
            Vector3[] cylinderPoints = new Vector3[numPoints];

            float segmentAngle = 360f / segments;

            // Apply rotation around z-axis
            Quaternion rotation = Quaternion.Euler(0f, 0f, rotationAngle);

            // Top circle
            for (int i = 0; i < segments; i++)
            {
                float angle = Mathf.Deg2Rad * (i * segmentAngle);
                float x = Mathf.Cos(angle) * radius;
                float z = Mathf.Sin(angle) * radius;
                cylinderPoints[i] = rotation * (transformPosition + new Vector3(x, height / 2, z));
            }
            // Bottom circle
            for (int i = 0; i < segments; i++)
            {
                float angle = Mathf.Deg2Rad * (i * segmentAngle);
                float x = Mathf.Cos(angle) * radius;
                float z = Mathf.Sin(angle) * radius;
                cylinderPoints[i + segments] = rotation * (transformPosition + new Vector3(x, -height / 2, z));
            }
            return cylinderPoints;
        }
    }
}
