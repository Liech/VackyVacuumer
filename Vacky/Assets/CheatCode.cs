using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatCode : MonoBehaviour
{
  bool first = false;
  bool second = false;
  bool third = false;
  int current = 0;
  // Start is called before the first frame update
  void Start()
  {
      
  }
  bool pressed = false;
  // Update is called once per frame
  void Update()
  {
    if (Singleton.instance.cheats.Count == 0)
      return;
    if (third)
    {
      if (Input.GetKey(KeyCode.L) && !pressed)
      {
        pressed = true;
        current++;
        if (current >= Singleton.instance.cheats.Count)
          current = 0;
        if (current < 0)
          current = Singleton.instance.cheats.Count - 1;
        GameObject cheat = Singleton.instance.cheats[current];
        //Destroy(Singleton.instance.protagonist);
        //var prota = Instantiate(Singleton.instance.roboPrefab,cheat.transform.position,Quaternion.identity);
        Singleton.instance.protagonist.transform.position = cheat.transform.position;
        foreach (var comp in cheat.GetComponents<Upgrade>())
          comp.doUpgrade(Singleton.instance.protagonist);
      }
      else if (Input.GetKey(KeyCode.K)&&!pressed)
      {
        pressed = true;
        current--;
        if (current >= Singleton.instance.cheats.Count)
          current = 0;
        if (current < 0)
          current = Singleton.instance.cheats.Count - 1;
        GameObject cheat = Singleton.instance.cheats[current];
        //Destroy(Singleton.instance.protagonist);
        //var prota = Instantiate(Singleton.instance.roboPrefab,cheat.transform.position,Quaternion.identity);
        Singleton.instance.protagonist.transform.position = cheat.transform.position;
        foreach (var comp in cheat.GetComponents<Upgrade>())
          comp.doUpgrade(Singleton.instance.protagonist);
      }
      if (!Input.GetKey(KeyCode.K) && !Input.GetKey(KeyCode.L) && pressed)
        pressed = false;
    }


    if (second) if (Input.GetKey(KeyCode.N)) {
        third = true; SoundSingleton.instance.playClick(); 
      }
    if (first) if (Input.GetKey(KeyCode.O)) {
        second = true; SoundSingleton.instance.playClick();
      }
    if (Input.GetKey(KeyCode.B)) { 
      first = true; SoundSingleton.instance.playClick();
    }
  }
}
