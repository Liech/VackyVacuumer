using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachComponentUpgrade : Upgrader
{
  public Component AttachOnUpgrade;

  private GameObject targetInstance;

  //public override void addUpgrade(Upgradeable target)
  //{
  //  if (targetInstance)
  //    uninstall();
  //  targetInstance = Instantiate(AttachOnUpgrade, target.gameObject.transform);
  //}
  //public override void uninstall()
  //{
  //  if (targetInstance)
  //    Destroy(targetInstance);
  //  targetInstance = null;
  //}
}
