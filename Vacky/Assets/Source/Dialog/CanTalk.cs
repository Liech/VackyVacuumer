using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanTalk : MonoBehaviour
{
  public List<string> titles;
  public List<string> textes;
  public List<Sprite> sprites;
  int currentPosition = 0;

  bool dialogActive = false;
  public virtual void talk()
  {
    if (titles.Count != textes.Count || textes.Count != sprites.Count)
      throw new System.Exception("List unequal long in cantalk");
    Singleton.instance.Dialog.SetActive(true);
    Singleton.instance.blockInput = true;
    pressed = true;
    dialogActive = true;
    currentPosition = -1;
    nextSlide();
  }

  void nextSlide()
  {
    if(currentPosition == textes.Count-1)
    {
      Singleton.instance.Dialog.SetActive(false);
      Singleton.instance.blockInput = false;
      dialogActive = false;
      currentPosition = -1;
    }
    else
    {
      currentPosition++;
      UnityEngine.UI.Image avatar = Singleton.instance.Dialog.transform.GetChild(0).GetChild(0).GetComponent<UnityEngine.UI.Image>();
      UnityEngine.UI.Text title   = Singleton.instance.Dialog.transform.GetChild(1).GetChild(1).GetComponent<UnityEngine.UI.Text>();
      UnityEngine.UI.Text text    = Singleton.instance.Dialog.transform.GetChild(1).GetChild(0).GetComponent<UnityEngine.UI.Text>();

      text.text = titles[currentPosition];
      title.text = textes[currentPosition];
      avatar.sprite = sprites[currentPosition];
    }
  }

  bool pressed = false;
  private void FixedUpdate()
  {
    if (dialogActive)
    {
      bool next = Input.GetKey(KeyCode.E);
      if (next && !pressed)
      {
        Debug.Log("Pressed");
        pressed = true;
        nextSlide();
      }
      else if (pressed && !next)
      {
        pressed = false;
        Debug.Log("Pressreset");

      }
    }
  }
}