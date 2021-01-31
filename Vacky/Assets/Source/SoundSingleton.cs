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
  public GameObject QuestComplete;
  public GameObject Heal;

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

  public void playQuestComplete()
  {
    if (QuestComplete) Instantiate(QuestComplete);
  }
  
  public void playHeal()
  {
    if (Heal) Instantiate(Heal);
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
