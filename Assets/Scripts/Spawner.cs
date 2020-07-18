using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject RedFireballPrefab;
    [SerializeField] private GameObject BlueFireballPrefab;
    [SerializeField] private float WaitTime = 1f;
    [SerializeField] private float SpeedUpTime = 0.1f;
    [SerializeField] private int SpeedUpEvery = 10;

    public event Action OnGameEnd;

    private float ActiveWaitTime;
    private Level Level;
    private List<Tile> Tiles;
    private HashSet<Tile> TargetedTiles;

    


    private System.Random rand = new System.Random();

    void Start()
    {
        TargetedTiles = new HashSet<Tile>();
        Level = FindObjectOfType<Level>();
        Tiles = Level.GetAllTiles();
        ActiveWaitTime = WaitTime;
        StartCoroutine(SpawnFireballs());

    }



    IEnumerator SpawnFireballs() {
        int count = 0;
        while (Tiles.Count > 0) {
            Tile TargetTile = GetRandomTargetableTile();
            if (TargetTile == null) {

                FindObjectOfType<GameEnder>().EndGame();
                break;

            }
            TargetedTiles.Add(TargetTile);
            Vector3 TargetPosition = TargetTile.transform.position;

            Fireball fb;
            if (rand.Next(2) == 0)
            {
                GameObject go = Instantiate(RedFireballPrefab, new Vector3(TargetPosition.x, TargetPosition.y + 20, TargetPosition.z), Quaternion.identity);
                fb = go.GetComponentInChildren<Fireball>();
                fb.FireColour = FireColour.RED;
                fb.gameObject.layer = 9; // red
                TargetTile.Fireball = fb;

            }
            else {
                GameObject go = Instantiate(BlueFireballPrefab, new Vector3(TargetPosition.x, TargetPosition.y + 20, TargetPosition.z), Quaternion.identity);
                fb = go.GetComponentInChildren<Fireball>();
                fb.FireColour = FireColour.BLUE;
                fb.gameObject.layer = 8; // blue
                TargetTile.Fireball = fb;
            }

            fb.OnDestruction += () =>
            {
                TargetedTiles.Remove(TargetTile);
            };
            count++;
            if (count % SpeedUpEvery == 0) {
                ActiveWaitTime -=SpeedUpTime;
                ActiveWaitTime = Mathf.Max(ActiveWaitTime, 0.5f);
                SpeedUpEvery *= 2;
            }
            yield return new WaitForSeconds(ActiveWaitTime);
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
