using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{

    [SerializeField] private FireColour FireColour;


    private void OnTriggerEnter(Collider other)
    {
        Fireball fb = other.gameObject.GetComponent<Fireball>();
        if (fb == null)
        {
            return;
        }

        if (fb.FireColour != FireColour)
        {
            return;
        }

        Destroy(fb.gameObject);
    }
    
}
