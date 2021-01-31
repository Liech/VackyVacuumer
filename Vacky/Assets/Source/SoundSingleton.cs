using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSingleton : MonoBehaviour
{
  public static SoundSingleton instance;

  public GameObject Click;
  public GameObject Bonk;
  public GameObject Collect;
  public GameObject EnemyDeath;

  public void playEnemyDeath()
  {
    if (EnemyDeath) Instantiate(EnemyDeath);
  }
  public void playCollect()
  {
    if (Collect) Instantiate(Collect);
  }
  public void playClick()
  {
    if (Click) Instantiate(Click);
  }
  public void playBonk(Transform t)
  {
    if (Bonk) Instantiate(Bonk,t);
  }

  public SoundSingleton()
  {
    instance = this;
  }

  // Update is called once per frame
  void Update()
  {

  }
}
