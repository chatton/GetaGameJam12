﻿using UnityEngine;

public class Shredder : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}