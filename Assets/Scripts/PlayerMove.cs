using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] float speed = 5f;


    public event Action OnMove;
    public event Action OnStop;

    // Update is called once per frame
    void Update()
    {
        Move(); 
    }

    public void Move()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (Mathf.Approximately(horizontal, 0) && Mathf.Approximately(vertical, 0)) {
            OnStop?.Invoke();
            return;
        }

        Vector3 Movement = new Vector3(horizontal, 0, vertical);
        transform.rotation = Quaternion.LookRotation(Movement);
        transform.position += Movement * speed * Time.deltaTime;
        OnMove?.Invoke();

    }
}
