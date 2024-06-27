using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    private Mesh _mesh;

    private Vector3[] _verticies;
    private int[] _triangles;

    [SerializeField]
    int _xSize;

    [SerializeField]
    int _zSize;

    void Start()
    {
        _mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = _mesh;
        CreateShape();
        UpdateMesh();
    }

    private void CreateShape()
    {
        _verticies = new Vector3[(_xSize + 1) * (_zSize + 1)];

        for (int z = 0, i = 0; z <= _zSize; z++)
        {
            for (int x = 0; x <= _xSize; x++)
            {
                float y = Mathf.PerlinNoise(z * .3f, x * .3f) * 2f;

                Debug.Log(y);

                y = y < 0.5 ? 0 : y * 3;

                _verticies[i] = new Vector3(x, y, z);
                i++;
            }
        }

        _triangles = new int[_zSize * _xSize * 6];

        int vert = 0, tris = 0;

        for (int z = 0; z < _zSize; z++)
        {
            for (int x = 0; x < _xSize; x++, vert++, tris += 6)
            {
                _triangles[tris + 0] = vert + 0;
                _triangles[tris + 1] = vert + _xSize + 1;
                _triangles[tris + 2] = vert + 1;
                _triangles[tris + 3] = vert + 1;
                _triangles[tris + 4] = vert + _xSize + 1;
                _triangles[tris + 5] = vert + _xSize + 2;
            }
            vert++;
        }

        


    }

    private void UpdateMesh()
    {
        _mesh.Clear();
        _mesh.vertices = _verticies;
        _mesh.triangles = _triangles;
        _mesh.RecalculateNormals();
    }

    private void OnDrawGizmos()
    {
        if (_verticies == null)
            return;

        for (int i = 0; i < _verticies.Length; i++)
        {
            Gizmos.DrawSphere(_verticies[i], .1f);
        }
    }
}
