using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsCheat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
  {
    Singleton.instance.cheats.Add(gameObject);

  }

    // Update is called once per frame
    void Update()
    {
        
    }
}
