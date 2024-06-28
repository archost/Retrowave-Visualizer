using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour
{
    [SerializeField]
    private Material _targetMaterial;

    void Start()
    {
        if (_targetMaterial == null)
            Debug.LogError("Material is not assigned");
    }

    
    void Update()
    {
        _targetMaterial.SetColor("_EmissionColor", _targetMaterial.color * AudioVisualizer._bandBuffer[7] * 0.125f);
        // _targetMaterial.SetColor("_EmissionColor", new Color(AudioVisualizer._bandBuffer[5], 0, 211));
    }
}
