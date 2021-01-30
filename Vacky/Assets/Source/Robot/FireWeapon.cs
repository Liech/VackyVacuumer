using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
  bool fired = false;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void FixedUpdate()
  {
    bool pressed = Input.GetKey(KeyCode.Space);
    if (pressed && !fired)
    {
      GetComponent<IFireable>().fire();
      fired = true;
    }
    else if (!pressed)
      fired = false;
  }
}
