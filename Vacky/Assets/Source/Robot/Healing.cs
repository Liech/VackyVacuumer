using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ammo))]
[RequireComponent(typeof(Life))]
public class Healing : MonoBehaviour
{
    public int heal_points = 1;     // how man health points are added per heal tick
    public int ammo_cost = 1;       // how much ammo is needed for one heal tick
    public float healing_time = 1;  // time between two ticks in seconds
    private float time_counter = 0;        // count how long contact persists to healing station
    private bool in_heal_zone = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (in_heal_zone)
        {
            if (time_counter >= healing_time)
            {
                int ammo = GetComponent<Ammo>().getAmmo();
                int life = GetComponent<Life>().getLife();
                Debug.Log("oldlife: " + life);
                if (ammo >= ammo_cost && life < GetComponent<Life>().maxlife)
                {
                    GetComponent<Ammo>().setAmmo(ammo - ammo_cost);
                    int new_life = Mathf.Min(life + heal_points, GetComponent<Life>().maxlife);
                    GetComponent<Life>().setLife(new_life);
                    Debug.Log("new life: " + new_life);
                }
                time_counter = 0;
            }
            time_counter += Time.deltaTime;
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.tag == "HealingStation")
    //    {
    //        //Debug.Log("wait");
    //        if (time_counter >= healing_time)
    //        {
    //            int ammo = GetComponent<Ammo>().getAmmo();
    //            int life = GetComponent<Life>().getLife();
    //            Debug.Log("oldlife: " + life);
    //            if (ammo >= ammo_cost && life < GetComponent<Life>().maxlife)
    //            {
    //                GetComponent<Ammo>().setAmmo(ammo - ammo_cost);
    //                int new_life = Mathf.Min(life + heal_points, GetComponent<Life>().maxlife);
    //                GetComponent<Life>().setLife(new_life);
    //                Debug.Log("new life: " + new_life);
    //            }
    //            time_counter = 0;
    //        }
    //        time_counter += Time.deltaTime;
    //        Debug.Log(time_counter);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "HealingStation")
        {
            in_heal_zone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        time_counter = 0;   // resetting time counter when leaving healing station
        in_heal_zone = false;
    }
}
