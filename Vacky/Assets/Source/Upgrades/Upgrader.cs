using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrader : MonoBehaviour
{
  public virtual void addUpgrade(Upgradeable target) { }
  public virtual void uninstall() { }
}
