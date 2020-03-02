using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Camera Position")]
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 offset;

    [Header("Camera Boundaries")]
    [SerializeField]
    private float min = 0;
    [SerializeField]
    private float max = 0;

    void Start()
    {
        offset = this.transform.position - target.position;
    }

    void Update()
    {
        if (target != null)
        {
            this.transform.position = offset + target.position;

            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
