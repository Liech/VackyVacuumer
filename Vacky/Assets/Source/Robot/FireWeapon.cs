using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ammo))]
public class FireWeapon : IController
{
  bool fired = false;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void FixedUpdate()
  {
    if (Singleton.instance.blockInput)
      return;

    bool pressed = Input.GetKey(KeyCode.Space);

    int ammoNeeded = 0;
    if (GetComponentInChildren<IFireable>())
      ammoNeeded = GetComponentInChildren<IFireable>().ammoNeeded;
    if (pressed && !fired &&  GetComponent<Ammo>().getAmmo() >= ammoNeeded && GetComponentInChildren<IFireable>())
    {
      GetComponentInChildren<IFireable>().fire();
      fired = true;
      GetComponent<Ammo>().decAmmo(ammoNeeded);
    }
    else if (!pressed)
      fired = false;
  }
}
