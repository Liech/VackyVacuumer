using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DirtCounter : MonoBehaviour
{
  public float extendX = 2;
  public float extendY = 2;
  public int successAt = 4;
  public List<GameObject> quests;
  public string ID = "CLEAN";

  void checkSuccess()
  {
    int counter = 0;
        
    HashSet<Tilemap> maps;
    maps = Singleton.instance.DirtTileMaps;

    foreach (var map in maps)
    {
      Vector3Int from = map.WorldToCell(transform.position - new Vector3(extendX/2, extendY/2, 0));
      Vector3Int to = map.WorldToCell(transform.position + new Vector3(extendX/2, extendY/2, 0));
      Vector3Int center = map.WorldToCell(transform.position);

      for (int x = from[0]; x < to[0]; x++)
        for (int y = from[1]; y < to[1]; y++)
        {
          TileBase current = map.GetTile(new Vector3Int(x, y, 0));
          if (current != null)
            counter++;
        }
    }
    if (counter <= successAt)
    {
      Debug.Log("QUEST DONE: Dirt -- " + ID);
      foreach(var quest in quests) 
        quest.GetComponent<Quest>().questDone(ID);
      Destroy(gameObject);
      SoundSingleton.instance.playCollect();

    }
    else
      Debug.Log("DIRT REMAINING: " + counter.ToString());
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
