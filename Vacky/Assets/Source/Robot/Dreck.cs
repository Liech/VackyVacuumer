using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class Dreck : MonoBehaviour
{
    public Tilemap tilemap;
    private int dirt_count = 0;
    private int num_points = 180;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //tilemap.SetTile(tilemap.WorldToCell(gameObject.transform.position), null);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Dreck")
    //    {
    //        dirt_count += 1;
    //        Debug.Log("Dreck Count: " + dirt_count);

    //        float radius = GetComponent<CircleCollider2D>().radius;
    //        Vector3 pos = gameObject.transform.position;

    //        for (int i = 0; i<num_points; i++)
    //        {
    //            float angle = 2f * Mathf.PI / (float) num_points * i;
    //            Vector3 contour_point = new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0) + pos;
    //            tilemap.SetTile(tilemap.WorldToCell(contour_point), null);
    //            //Debug.Log(contour_point);
    //        }
    //        tilemap.SetTile(tilemap.WorldToCell(pos), null);
    //        //Debug.Log(radius);
    //    }
    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Dreck")
        {
            dirt_count += 1;
            Debug.Log("Dreck Count: " + dirt_count);

            float radius = GetComponent<CircleCollider2D>().radius;
            Vector3 pos = gameObject.transform.position;

            for (int i = 0; i < num_points; i++)
            {
                float angle = 2f * Mathf.PI / (float)num_points * i;
                Vector3 contour_point = new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0) + pos;
                tilemap.SetTile(tilemap.WorldToCell(contour_point), null);
                //Debug.Log(contour_point);
            }
            tilemap.SetTile(tilemap.WorldToCell(pos), null);
            //Debug.Log(radius);
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
