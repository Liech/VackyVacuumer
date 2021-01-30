using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ammo))]
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
    //int dirt_count = GetComponent<Dreck>().GetDirtCount();
    if (pressed && !fired &&  GetComponent<Ammo>().getAmmo() > 0 && GetComponentInChildren<IFireable>())
    {
      GetComponentInChildren<IFireable>().fire();
      fired = true;
      GetComponent<Ammo>().decAmmo();
    }
    else if (!pressed)
      fired = false;
  }
}
