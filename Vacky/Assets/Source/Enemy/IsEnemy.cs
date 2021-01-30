using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsEnemy : MonoBehaviour
{
  void Start()
  {
    Singleton.instance.Enemys.Add(this);
  }

  void OnDestroy()
  {
    Singleton.instance.Enemys.Remove(this);
  }
}
