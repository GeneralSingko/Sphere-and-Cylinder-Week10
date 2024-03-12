using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shape", menuName = "Shape")]
public class Shape : ScriptableObject
{
    [SerializeField]private Vector3[] points;
    public Vector3 transformPosition;
    public float rotationAngle;

    public Vector3[] actualPoints
    {
        get
        {
            var newPoint = new Vector3[points.Length];
            for (int i = 0; i < newPoint.Length; i++)
            {
                // Apply rotation around z-axis
                Quaternion rotation = Quaternion.Euler(0f, 0f, rotationAngle);
                newPoint[i] = rotation * (transformPosition - points[i]);
            }

            return newPoint;
        }
    }
}
