using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    [SerializeField] AudioClip clip;
    // Start is called before the first frame update
    void Awake()
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }

}
