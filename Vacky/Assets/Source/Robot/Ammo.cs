using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public int max_ammo = 100;
    public int ammo = 0;
    
    // Start is called before the first frame update
    void Start()
    {    
    }

  // Update is called once per frame
  private void FixedUpdate()
  {
    if(Singleton.instance.dreckbar)
    Singleton.instance.dreckbar.setAmmo((float)ammo / (float)max_ammo);
  }

  public void setAmmo(int new_ammo)
  {
    ammo = new_ammo;

    Singleton.instance.dreckbar.setAmmo((float)ammo / (float)max_ammo);
  }

  public int getAmmo() { return ammo; }

  public float getAmmoPercentage() { return (float) ammo / (float) max_ammo; }

  public void incAmmo()
  {
    if (ammo < max_ammo)
      ammo++;
    Singleton.instance.dreckbar.setAmmo((float)ammo / (float)max_ammo);
  }

  public void decAmmo( int amount)
  {
    ammo -= amount;
    if (ammo < 0) ammo = 0;
    Singleton.instance.dreckbar.setAmmo((float)ammo / (float)max_ammo);
  }
}
