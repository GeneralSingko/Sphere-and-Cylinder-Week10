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
            Vector3[] points = new Vector3[4];
            Quaternion rotation = Quaternion.Euler(0f, 0f, rotationAngle);

            points[0] = rotation * (transformPosition + new Vector3(width / 2, height / 2, length / 2));
            points[1] = rotation * (transformPosition + new Vector3(width / 2, -height / 2, length / 2));
            points[2] = rotation * (transformPosition + new Vector3(-width / 2, -height / 2, length / 2));
            points[3] = rotation * (transformPosition + new Vector3(-width / 2, height / 2, length / 2));

            return points;

        }
    }

    public Vector3[] backSide
    {
        get
        {
            Vector3[] points = new Vector3[4];
            Quaternion rotation = Quaternion.Euler(0f, 0f, rotationAngle);

            points[0] = rotation * (transformPosition + new Vector3(width / 2, height / 2, -length / 2));
            points[1] = rotation * (transformPosition + new Vector3(width / 2, -height / 2, -length / 2));
            points[2] = rotation * (transformPosition + new Vector3(-width / 2, -height / 2, -length / 2));
            points[3] = rotation * (transformPosition + new Vector3(-width / 2, height / 2, -length / 2));

            return points;
        }
    }

    public Vector3[] leftSide
    {
        get
        {
            return new Vector3[]
            {
                frontSide[0], frontSide[1], backSide[1], backSide[0]
            };
        }
    }

    public Vector3[] rightSide
    {
        get
        {
            return new Vector3[]
            {
                frontSide[2], frontSide[3], backSide[3], backSide[2]
            };
        }
    }
}
