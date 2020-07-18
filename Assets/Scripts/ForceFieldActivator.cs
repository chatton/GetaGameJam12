using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ForceFieldActivator : MonoBehaviour
{

    [SerializeField] GameObject RedForceField;
    [SerializeField] GameObject BlueForceField;

    public event Action OnCast;
    public event Action OnStopCast;

    // Update is called once per frame
    void Update()
    {

        bool BlueActive = Input.GetMouseButton(0);
        bool RedActive = Input.GetMouseButton(1);


        if (BlueActive) {
            BlueForceField.SetActive(true);
            RedForceField.SetActive(false);
            OnCast?.Invoke();
            return;
        }

        
        if (RedActive)
        {
            BlueForceField.SetActive(false);
            RedForceField.SetActive(true);
            OnCast?.Invoke();
            return;
        }


        OnStopCast?.Invoke();
        BlueForceField.SetActive(false);
        RedForceField.SetActive(false);
    }
}
