using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnQuest : Quest
{
  public GameObject toSpawn;
  public override void questDone(string ID)
  {
    Debug.Log("Danke. Hier die Belohnung: " + toSpawn.name);
    Instantiate(toSpawn,transform.position,Quaternion.identity);
    Destroy(gameObject);    
  }
}
