using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChuckGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject _chunk;

    [SerializeField]
    private GameObject _blackChunk;

    private Camera _camera;

    private List<Tuple<GameObject, GameObject>> _chunks;

    private int _offset = 0;
    
    void Start()
    {
        _camera = Camera.main;

        _chunks = new List<Tuple<GameObject, GameObject>>();

        for (int i = 0; i < 8; i++)
        {
            _chunks.Add(new Tuple<GameObject, GameObject> (
                Instantiate(_chunk, new Vector3(_offset, 0, 0), Quaternion.identity),
                Instantiate(_blackChunk, new Vector3(_offset, 0, 0), Quaternion.identity)
                ));
            _offset += 127;
        }
    }
    
    void Update()
    {
        if (_camera.transform.position.x > _chunks[0].Item1.transform.position.x + 130)
        {
            Destroy(_chunks[0].Item1);
            Destroy(_chunks[0].Item2);
            _chunks.RemoveAt(0);
            _chunks.Add(new Tuple<GameObject, GameObject> (
                Instantiate(_chunk, new Vector3(_offset, 0, 0), Quaternion.identity),
                Instantiate(_blackChunk, new Vector3(_offset, 0, 0), Quaternion.identity)
                ));
            _offset += 127;
        }
    }
}
