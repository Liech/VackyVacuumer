using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgradeable : IController
{
  private List<Upgrader> upgrader;
  private Upgrader currentUpgrader;
  bool pressed = false;
  public void FixedUpdate()
  {
    if (Singleton.instance.blockInput)
      return;

    bool forward   = Input.GetKey(KeyCode.Q);
    bool backwards = Input.GetKey(KeyCode.E);
    
    if ((forward||backwards) && currentUpgrader && !pressed)
    {
      pressed = true;
      int currentID = 0;
      for (int i = 0; i < upgrader.Count; i++)
        if (upgrader[i] == currentUpgrader)
          currentID = i;
      if (forward)
        currentID++;
      if (backwards)
        currentID--;
      if (currentID < 0)
        currentID += upgrader.Count;
      if (currentID >= upgrader.Count)
        currentID -= upgrader.Count;
      currentID = currentID % upgrader.Count;
      setUpgrade(upgrader[currentID]);
    }
    if (!forward && !backwards)
      pressed = false;
  }

  public Upgradeable()
  {
    upgrader = new List<Upgrader>();
  }

  public void setUpgrade(Upgrader u)
  {
    if (currentUpgrader)
    {
      currentUpgrader.uninstall();
    }
    currentUpgrader = u;
    u.addUpgrade(this);
  }
  public void addUpgrade(Upgrader u)
  {
    upgrader.Add(u);
    setUpgrade(u);
  }
}
