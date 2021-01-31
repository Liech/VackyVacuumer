using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyQuest : Quest
{
  public override void questDone(string ID)
  {
    Debug.Log("Now I will open");
    //Instantiate(toSpawn, transform.position, Quaternion.identity);
    Destroy(gameObject);
    SoundSingleton.instance.playQuestComplete();
  }
}
