using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void FixedUpdate()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      GetComponent<IFireable>().fire();
    }
  }
}
