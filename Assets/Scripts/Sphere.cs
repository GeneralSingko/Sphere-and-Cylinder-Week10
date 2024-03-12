using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sphere", menuName = "Sphere")]
public class Sphere : ScriptableObject
{
    public float radius;
    public Vector3 transformPosition;
    public int longitudeSegments;
    public int latitudeSegments;
    public Vector3 localRotation;

    public Vector3[] GeneratePoints(int longitudeSegments, int latitudeSegments)
    {
        Vector3[] points = new Vector3[(longitudeSegments + 1) * (latitudeSegments + 1)];
        float phiStep = 2 * Mathf.PI / longitudeSegments;
        float thetaStep = Mathf.PI / latitudeSegments;
        int index = 0;

        Quaternion rotation = Quaternion.Euler(localRotation);

        for (int lat = 0; lat <= latitudeSegments; lat++)
        {
            float theta = lat * thetaStep;
            float sinTheta = Mathf.Sin(theta);
            float cosTheta = Mathf.Cos(theta);

            for (int lon = 0; lon <= longitudeSegments; lon++)
            {
                float phi = lon * phiStep;
                float sinPhi = Mathf.Sin(phi);
                float cosPhi = Mathf.Cos(phi);

                float x = cosPhi * sinTheta;
                float y = cosTheta;
                float z = sinPhi * sinTheta;

                points[index] = rotation * (new Vector3(x * radius, y * radius, z * radius) + transformPosition);
                index++;
            }
        }

        return points;
    }
}
