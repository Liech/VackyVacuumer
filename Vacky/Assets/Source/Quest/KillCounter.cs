using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
  public float extendX = 2;
  public float extendY = 2;
  public List<GameObject> quests;
  string ID;
  
  void checkSuccess()
  {
    int counter = 0;
    foreach(var op in Singleton.instance.Enemys)
    {
      Vector2 pos = op.transform.position;
      bool left  = pos.x > transform.position.x - extendX / 2;
      bool right = pos.x < transform.position.x + extendX / 2;
      bool up    = pos.y > transform.position.y - extendY / 2;
      bool down  = pos.y < transform.position.y + extendY / 2;

      if (left && right && up && down)
        if (op.GetComponent<Life>().getLife() > 0)
          counter++;
    }
    if (counter == 0)
    {
      Debug.Log("QUEST DONE: Kill -- " + ID);
      foreach (var quest in quests)
        quest.GetComponent<Quest>().questDone(ID);
      Destroy(gameObject);
      SoundSingleton.instance.playCollect();

    }
    else
      Debug.Log("Kill quest remain: " + counter.ToString());
  }

  void Start()
  {
    StartCoroutine("lazyUpdate");
  }

  private IEnumerator lazyUpdate()
  {
    while (true)
    {
      yield return new WaitForSeconds(1);
      checkSuccess();
    }
  }
  private void OnDrawGizmos()
  {
    Gizmos.color = new Color(0.1f, 0.1f, 0.1f, 0.1f);
    Gizmos.DrawCube(transform.position, new Vector3(extendX, extendY, 1));
  }
}
