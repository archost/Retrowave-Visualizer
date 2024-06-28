using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightmapLoader : MonoBehaviour
{
    [SerializeField]
    private Texture2D _heightmapTexture;

    private float[,] _heightmapData;

    void Start()
    {
        LoadHeightmap();
    }

    void LoadHeightmap()
    {
        if (_heightmapTexture == null)
        {
            Debug.LogError("Heightmap texture is not assigned.");
            return;
        }

        int width = _heightmapTexture.width;
        int height = _heightmapTexture.height;
        Debug.Log(width + " " + height);
        _heightmapData = new float[width, height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Color pixelColor = _heightmapTexture.GetPixel(x, y);
                _heightmapData[x, y] = pixelColor.grayscale;
            }
        }
    }

    public float GetHeightAt(int x, int y)
    {
        if (x < 0 || x >= _heightmapData.GetLength(0) || y < 0 || y >= _heightmapData.GetLength(1))
        {
            Debug.LogError("Coordinates out of bounds.");
            return 0;
        }

        return _heightmapData[x, y];
    }
}