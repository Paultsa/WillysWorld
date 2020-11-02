using UnityEngine;
using System.Collections;

public class LiikkuvaPlatform : MonoBehaviour
{
    /// <summary>The objects initial position.</summary>
    private Vector3 startPosition;
    /// <summary>The objects updated position for the next frame.</summary>
    private Vector3 newPosition;
    public float maxDistanceX = 0.0f;
    public float maxDistanceY = 0.0f;
    public float maxDistanceZ = 0.0f;

    /// <summary>The speed at which the object moves.</summary>
    [SerializeField] private float speed = 3.0f;
    /// <summary>The maximum distance the object may move in either y direction.</summary>
  // [SerializeField] private int maxDistance = 1;

    void Start()
    {
        startPosition = transform.position;
        newPosition = transform.position;
    }

    void Update()
    {
        newPosition.x = startPosition.x + (maxDistanceX * Mathf.Sin(Time.time * speed));
        newPosition.y = startPosition.y + (maxDistanceY * Mathf.Sin(Time.time * speed));
        newPosition.z = startPosition.z + (maxDistanceZ * Mathf.Sin(Time.time * speed));
        transform.position = newPosition;
    }
}