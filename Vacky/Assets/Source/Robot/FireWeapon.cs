using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ammo))]
public class FireWeapon : IController
{
  bool onCoolDown = false;
  // Start is called before the first frame update
  void Start()
  {

  }

  IEnumerator CoolDown(float seconds)
  {
    yield return new WaitForSeconds(seconds);

    onCoolDown = false;
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    if (Singleton.instance.blockInput)
      return;

    bool pressed = Input.GetKey(KeyCode.Space);
    if (!pressed) return;

    IFireable Weapon = GetComponentInChildren<IFireable>();

    if (!Weapon)  return;

    if (!onCoolDown)
    {
      onCoolDown = true;
      StartCoroutine(CoolDown(Weapon.coolDownTime));

      if (GetComponent<Ammo>().getAmmo() >= Weapon.ammoNeeded)
      {
        Debug.Log("Firing!");
        GetComponentInChildren<IFireable>().fire();
        GetComponent<Ammo>().decAmmo(Weapon.ammoNeeded);
      } else {
        Debug.Log("Ammo too low");
        SoundSingleton.instance.playClick();
      }
    }
  }
}
