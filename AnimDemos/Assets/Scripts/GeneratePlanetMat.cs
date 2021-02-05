using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlanetMat : MonoBehaviour
{
    private MeshRenderer mesh;
    public int size = 512;
    public float zoom = 20;

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        MakeTexture();
    }
    void MakeTexture()
    {
        // Load a new 2d texture on a specific size
        Texture2D texture = new Texture2D(size, size);

        // Generate a 1 dimensional array
        Color[] pixels = texture.GetPixels();
        // create for loops for textureX and textureY
        for (int y = 0; y < size; y++)
        {
            for(int x = 0; x < size; x++)
            {
                int i = x + y * size;

                float a = Mathf.PerlinNoise(x/zoom, y/zoom);

                if (a < .5f)
                {
                    pixels[i] = new Color(0, 0, 255); // Set to random by perlin noise
                }
                else
                {
                    pixels[i] = new Color(0, 255, 0); // Set to random by perlin noise

                }


            }
        }
        texture.SetPixels(pixels); // Call the texture produced by the array
        texture.Apply(); // Apply that texture

        // Set the texture of the mesh material
        mesh.material.SetTexture("_MainTex", texture);
    }
}
