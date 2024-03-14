using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cube", menuName = "Cube")]
public class Cube : ScriptableObject
{
    public float length;
    public float height;
    public float width;

    public Vector3 transformPosition;
    public float rotationAngle;

    public Vector3[] frontSide
    {
        get
        {
            Vector3[] points = new Vector3[]
            {
                new Vector3(width/2, height/2, length/2),
                new Vector3(width/2, -height/2, length/2),
                new Vector3(-width/2, -height/2, length/2),
                new Vector3(-width/2, height/2, length/2)
            };

            return ApplyRotation(points);

        }
    }

    public Vector3[] backSide
    {
        get
        {
            Vector3[] points = new Vector3[]
            {
                new Vector3(width/2, height/2, -length/2),
                new Vector3(width/2, -height/2, -length/2),
                new Vector3(-width/2, -height/2, -length/2),
                new Vector3(-width/2, height/2, -length/2)
            };

            return ApplyRotation(points);
        }
    }

    public Vector3[] leftSide
    {
        get
        {
            Vector3[] points = new Vector3[]
            {
                frontSide[0], frontSide[1], backSide[1], backSide[0]
            };

            return ApplyRotation(points);
        }
    }

    public Vector3[] rightSide
    {
        get
        {
            Vector3[] points = new Vector3[]
            {
                frontSide[2], frontSide[3], backSide[3], backSide[2]
            };

            return ApplyRotation(points);
        }
    }

    private Vector3[] ApplyRotation(Vector3[] points)
    {
        Quaternion rotation = Quaternion.Euler(0f, 0f, rotationAngle);

        for (int i = 0; i < points.Length; i++)
        {
            // Apply rotation around local axis
            points[i] = transformPosition + (rotation * points[i]);
        }

        return points;
    }
}
