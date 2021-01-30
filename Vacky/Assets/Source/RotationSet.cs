using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Rigidbody2D>().rotation = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
