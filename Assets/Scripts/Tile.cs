using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    public Fireball Fireball; // the Fireball coming towards us!

    private Light Light;

    void Start()
    {
        Light = GetComponentInChildren<Light>();
    }

    void Update()
    {
        Light.enabled = Fireball != null;

        if (Fireball != null) {
            if (Fireball.FireColour == FireColour.BLUE)
            {
                Light.color = Color.blue;
            }
            else {
                Light.color = Color.red;
            }
            Light.intensity = 1 / Vector3.Distance(Light.transform.position, Fireball.transform.position) * 100;
            Light.range = 1;
        }
    }
}
