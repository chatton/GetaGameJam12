using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldActivator : MonoBehaviour
{

    [SerializeField] GameObject RedForceField;
    [SerializeField] GameObject BlueForceField;

    // Update is called once per frame
    void Update()
    {

        bool BlueActive = Input.GetMouseButton(0);
        bool RedActive = Input.GetMouseButton(1);


        if (BlueActive) {
            BlueForceField.SetActive(true);
            RedForceField.SetActive(false);
            return;
        }

        
        if (RedActive)
        {
            BlueForceField.SetActive(false);
            RedForceField.SetActive(true);
            return;
        }


        BlueForceField.SetActive(false);
        RedForceField.SetActive(false);
    }
}
