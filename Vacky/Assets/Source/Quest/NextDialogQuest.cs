using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDialogQuest : Quest
{
  public override void questDone(string ID)
  {
    Destroy(gameObject.GetComponent<CanTalk>());

  }
}
