using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Level : MonoBehaviour
{

    [SerializeField] Tile TilePrefab;
    [SerializeField] int LevelSize;
    private List<Tile> Tiles;
    // Start is called before the first frame update
    void Awake()
    {
        Tiles = new List<Tile>();
        foreach (Transform child in transform) {
            Tile t = child.gameObject.GetComponent<Tile>();
            if(t != null) {
                Tiles.Add(t);
            }
        }
    }

    public void GenerateLevel(int LevelSize) {
        for (int i = 0; i < LevelSize; i++)
        {
            for (int j = 0; j < LevelSize; j++)
            {
                Tile go = Instantiate(TilePrefab);
                go.transform.position = new Vector3(i, 0, j);
                go.transform.parent = transform;
                go.name = "tile_" + i + "_" + j;
            }
        }
    }

    public List<Tile> GetAllTiles()
    {
        return new List<Tile>(Tiles);
    }


}
