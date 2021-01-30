using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Dreck : MonoBehaviour
{
    public Tilemap tilemap;
    private int dirt_count;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tilemap.SetTile(tilemap.WorldToCell(gameObject.transform.position), null);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Dreck")
        {
            dirt_count += 1;
            Debug.Log("Dreck Count: " + dirt_count);
            
            tilemap.SetTile(tilemap.WorldToCell(gameObject.transform.position),null);

        }
    }
}
