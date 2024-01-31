using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    public Vector3 offset;
    public float speed;
    private void LateUpdate()
    {
        transform.position = target.transform.position+ offset;
    }
}
