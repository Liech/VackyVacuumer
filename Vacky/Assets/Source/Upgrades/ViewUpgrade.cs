using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewUpgrade : Upgrade
{
  public override void doUpgrade(GameObject target)
  {
    if (target.GetComponent<VisRenderer>())
      target.GetComponent<VisRenderer>().upgrade();
      SoundSingleton.instance.playCollect();
  }
}
