using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject RedFireballPrefab;
    [SerializeField] private GameObject BlueFireballPrefab;
    [SerializeField] private Material RedMat;
    [SerializeField] private Material BlueMat;
    [SerializeField] private float WaitTime = 1f;
    private Level Level;
    private List<Tile> Tiles;
    private HashSet<Tile> TargetedTiles;



    // Create a Random object  
    private System.Random rand = new System.Random();
    // Generate a random index less than the size of the array.  
 

    // Start is called before the first frame update
    void Start()
    {
        TargetedTiles = new HashSet<Tile>();
        Level = FindObjectOfType<Level>();
        Tiles = Level.GetAllTiles();
        StartCoroutine(SpawnFireballs());
    }


    IEnumerator SpawnFireballs() {
        while (Tiles.Count > 0) {
            Tile TargetTile = GetRandomTargetableTile();
            if (TargetTile == null) {
                break;
            }
            TargetedTiles.Add(TargetTile);
            Vector3 TargetPosition = TargetTile.transform.position;

            Fireball fb;
            if (rand.Next(2) == 0)
            {
                GameObject go = Instantiate(RedFireballPrefab, new Vector3(TargetPosition.x, TargetPosition.y + 10, TargetPosition.z), Quaternion.identity);
                fb = go.GetComponentInChildren<Fireball>();
                fb.FireColour = FireColour.RED;
                fb.gameObject.layer = 9; // red
                TargetTile.Fireball = fb;

            }
            else {
                GameObject go = Instantiate(BlueFireballPrefab, new Vector3(TargetPosition.x, TargetPosition.y + 10, TargetPosition.z), Quaternion.identity);
                fb = go.GetComponentInChildren<Fireball>();
                fb.FireColour = FireColour.BLUE;
                fb.gameObject.layer = 8; // blue
                TargetTile.Fireball = fb;

            }


            fb.OnDestruction += () =>
            {
                TargetedTiles.Remove(TargetTile);
            };
            yield return new WaitForSeconds(WaitTime);
        }
    }

    private Tile GetRandomTargetableTile() {
        List<Tile> TargetableTiles = Tiles.Where(t => !TargetedTiles.Contains(t)).ToList();
        int index = rand.Next(TargetableTiles.Count);

        if (index >= TargetableTiles.Count) {
            return null;
        }
        return TargetableTiles[index];
    }




    public void UnRegisterTile(Tile tile)
    {
        if (!Tiles.Contains(tile)) {
            Debug.Log("Tried to unregister tile: "+ tile.name + " but it was not in Tiles!");
            return;
        }
        Tiles.Remove(tile);
    }
}
