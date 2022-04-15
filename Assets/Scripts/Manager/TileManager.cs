using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Manager
{
    public class TileManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> tilePrefabs;
        [SerializeField] private float zSpawn = 0;
        [SerializeField] private float tileLength = 30;
        [SerializeField] private int maxNumOfTiles;
        [SerializeField] private Transform playerTransform;

        private List<GameObject> activeTiles = new List<GameObject>();
        

        private void Start()
        {
            for (int i = 0; i < maxNumOfTiles; i++)
            {
                if (i == 0)
                {
                    SpawnTile(0);
                }
                else
                {
                    SpawnTile(Random.Range(1, tilePrefabs.Count));
                }
            }
        }

        private void Update()
        {
            if (playerTransform.position.z - tileLength + 5 > zSpawn - (maxNumOfTiles * tileLength))
            {
                SpawnTile(Random.Range(1, tilePrefabs.Count));
                DeleteTile();
            }
        }

        private void SpawnTile(int tileIndex)
        {
            GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
            activeTiles.Add(go);
            zSpawn += tileLength;
        }

        private void DeleteTile()
        {
            Destroy(activeTiles[0]);
            activeTiles.RemoveAt(0);
        }
        
    }
}
