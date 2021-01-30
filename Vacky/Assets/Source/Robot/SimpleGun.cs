using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGun : IFireable
{
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public override void fire()
  {
    Debug.Log("Peng!");
  }
}
