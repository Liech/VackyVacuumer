using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IFireable : MonoBehaviour
{

  public int ammoNeeded = 1;
  public float coolDownTime = 0.5f;
  public virtual void fire() { }

}
