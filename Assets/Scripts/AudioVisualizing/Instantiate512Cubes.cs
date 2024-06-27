using System.Collections.Generic;
using UnityEngine;

public class Instantiate512Cubes : MonoBehaviour
{
    [SerializeField]
    private GameObject _sampleCubePrefab;

    [SerializeField]
    private float _maxScale;

    private List<GameObject> _sampleCubes = new List<GameObject>(512);

    void Start()
    {
        for (int i = 0; i < 512; i++)
        {
            GameObject _instanceSampleCube = Instantiate(_sampleCubePrefab, transform);
            _instanceSampleCube.name = "SampleCube" + i;
            _instanceSampleCube.transform.position = transform.position + Quaternion.Euler(0, 0.703125f * i, 0) * Vector3.forward * 100;
            _sampleCubes.Add(_instanceSampleCube);
        }
    }

    void Update()
    {
        for (int i = 0; i < _sampleCubes.Count; i++)
        {
            if (_sampleCubes[i] != null)
            {
                float scaleY = (AudioVisualizer._samples[i] * _maxScale) + 2;
                _sampleCubes[i].transform.localScale = new Vector3(1, scaleY, 1);
            }
        }
    }
}