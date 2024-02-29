using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    Vector3 _pivotPoint;

    bool _isDoorOpem = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !_isDoorOpem)
        {
            transform.RotateAround(_pivotPoint, Vector3.up, -90);
            _isDoorOpem = true;
        }
    }
}
