using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    void Update()
    {
        transform.position += new Vector3(_speed * Time.deltaTime + AudioVisualizer._audioBandBuffer[0] * 0.5f, 0, 0);
    }
}