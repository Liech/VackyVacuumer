using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public GameObject AmmoBar;
    public int max_ammo = 100;
    public int ammo = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (AmmoBar)
        //    AmmoBar.GetComponent<AmmoBar>().setAmmo(ammo);
    }

    public void setAmmo(int new_ammo)
    {
        ammo = new_ammo;
        AmmoBar.GetComponent<AmmoBar>().setAmmo(ammo);
    }

    public int getAmmo() { return ammo; }

    public void incAmmo()
    {
        ammo++;
        AmmoBar.GetComponent<AmmoBar>().setAmmo(ammo);
    }

    public void decAmmo()
    {
        ammo--;
        AmmoBar.GetComponent<AmmoBar>().setAmmo(ammo);
    }
}
