using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


[RequireComponent(typeof(Ammo))]
public class Dreck : MonoBehaviour
{
    private int dirt_count = 0;
    private int num_points = 180;
    public GameObject Aufsaugesound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  private void OnTriggerStay2D(Collider2D collision)
  {
    if (collision.tag == "Dreck")
    {
      //Debug.Log("Dreck Count: " + dirt_count);

      float radius = GetComponent<CircleCollider2D>().radius;
      Vector3 pos = gameObject.transform.position;

      foreach (var tilemap in Singleton.instance.DirtTileMaps)
      {
        for (int i = 0; i < num_points; i++)
        {
          float angle = 2f * Mathf.PI / (float)num_points * i;
          Vector3 contour_point = new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0) + pos;
          if (tilemap.GetTile(tilemap.WorldToCell(contour_point)) != null)
          {
            tilemap.SetTile(tilemap.WorldToCell(contour_point), null);
            if (Aufsaugesound) Instantiate(Aufsaugesound);
            dirt_count += 1;
          }
        }
        if (tilemap.GetTile(tilemap.WorldToCell(pos)))
        {
          tilemap.SetTile(tilemap.WorldToCell(pos), null);
          if (Aufsaugesound) Instantiate(Aufsaugesound);
          dirt_count += 1;
          GetComponent<Ammo>().incAmmo();
        }
      }

    }
  }

    public int GetDirtCount()
    {
        return dirt_count;
    }

    public void SetDirtCount(int new_count)
    {
        dirt_count = new_count;
    }
}
