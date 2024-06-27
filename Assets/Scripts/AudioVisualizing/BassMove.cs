using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BassMove : MonoBehaviour
{
    public float _speed;

    void Start()
    {
        
    }

    
    void Update()
    {
        Move();
    }

    private void Move()
    {
        _speed = AudioVisualizer._audioBandBuffer[1] * 10;
        transform.Translate(_speed * Time.deltaTime * Vector3.right);
    }
}
