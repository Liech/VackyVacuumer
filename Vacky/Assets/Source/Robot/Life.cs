using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum DamageCategory : int
{
  BonkDamage = 1,
  ReinigungsDamage = 2
}

public class Life : MonoBehaviour
{
  public int life = 100;
  public int maxlife = 100;
  public bool lifebar = false;
  private bool alive = true;
  public int team;
  public DamageCategory vulnerability = DamageCategory.BonkDamage;

  public GameObject gotDamageSound;

  // Start is called before the first frame update
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {
    float perc = (float)life / (float)maxlife;
    if (lifebar)
    {
      LifeBar img = Singleton.instance.lifebar;
      img.setLife(perc);
    }
    transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.5f + perc/2, 0.5f + perc/2);
  }

  public void addDamage(int dmg, DamageCategory category = DamageCategory.BonkDamage)
  {
    if (vulnerability > category)
      return;
    if (gotDamageSound) Instantiate(gotDamageSound);
    life -= dmg;
    if (life < 0)
    {
      life = 0;
      if (alive)
      {
        alive = false;
        foreach (var comp in GetComponents<IController>())
          comp.enabled = false;
        if (GetComponent<DangerousThing>())
          GetComponent<DangerousThing>().On = false;
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0.3f,0.3f,0.3f);
        Debug.Log("Death: " + gameObject.name);
      }
    }
  }

  public int getLife() { return life; }

  public void setLife(int new_life)
  {
      life = new_life;
  }
}
