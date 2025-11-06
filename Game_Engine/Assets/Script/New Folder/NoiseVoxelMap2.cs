using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseVoxelMap2 : MonoBehaviour
{
    public GameObject dirtPrefab;
    public GameObject grassPrefab;
    public GameObject waterPrefab;
    public GameObject mineral;

    public int width = 20;
    public int depth = 20;
    public int maxHeight = 16;
    [SerializeField] float noiseScale = 20f;
    [SerializeField] int waterHeight = 4; // 물 높이 기준선

    void Start()
    {
        float offsetX = Random.Range(-9999f, 9999f);
        float offsetZ = Random.Range(-9999f, 9999f);

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < depth; z++)
            {
                float nx = (x + offsetX) / noiseScale;
                float nz = (z + offsetZ) / noiseScale;

                float noise = Mathf.PerlinNoise(nx, nz);
                int h = Mathf.FloorToInt(noise * maxHeight);

                // 땅 생성
                for (int y = 0; y < h; y++)
                {
                    // 최상단 블록이면 Grass, 아니면 Dirt
                    if (y == h - 1)
                        Place(grassPrefab, x, y, z);
                    else
                        Place(dirtPrefab, x, y, z);
                }

                // 물 채우기: 일정 높이 이하에 블록이 없으면 물 배치
                for (int y = h; y < waterHeight; y++)
                {
                    Place(waterPrefab, x, y, z);
                }
            }
        }
    }

    private void Place(GameObject prefab, int x, int y, int z)
    {
        var go = Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity, transform);
        go.name = $"{prefab.name}_{x}_{y}_{z}";
    }
}
