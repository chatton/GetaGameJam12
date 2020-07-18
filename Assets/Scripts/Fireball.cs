using System;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    private Spawner Spawner;
    public FireColour FireColour;

    public Action OnDestruction { get; internal set; }

    // Start is called before the first frame update
    void Start()
    {
        Spawner = FindObjectOfType<Spawner>();
    }

    private void OnCollisionEnter(Collision collision)
    {

        Tile tile = collision.gameObject.GetComponent<Tile>();

        if (tile == null) {
            return;
        }

        Spawner.UnRegisterTile(tile);
        Destroy(collision.gameObject);
    }

    private void OnDestroy()
    {
        OnDestruction?.Invoke();
    }
}
