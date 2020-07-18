using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] float speed = 5f;


    // Update is called once per frame
    void Update()
    {
        Move(); 
    }

    public void Move()
    {

        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.position += Movement * speed * Time.deltaTime;

    }
}
