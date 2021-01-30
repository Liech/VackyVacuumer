using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    private Queue<string> dialogStuecke;
    void Start()
    {
        dialogStuecke = new Queue<string>();
    }

    public Text name;
    public Text dialogText;

  bool schonmalgefuellt = false;

    public void StarteDialog (Dialog dialog)
    {
        if (dialog != null )
        {
            Debug.Log(dialogStuecke.Count);
            if (dialogStuecke.Count == 0 && !schonmalgefuellt)
            {
                 schonmalgefuellt = true;
                Debug.Log("2");

                name.text = dialog.name;

                Debug.Log(dialog.name);
                
                dialogStuecke.Clear();

                foreach (string dialogStueck in dialog.dialogStuecke)
                {
                    dialogStuecke.Enqueue(dialogStueck);
                }
            }

            ZeigeNaechstenDialogstueck();
        }
    }

    public void ZeigeNaechstenDialogstueck()
    {
        if (dialogStuecke.Count == 0)
        {
            DialogEnde();
            return;
        }

        string dialogStueck = dialogStuecke.Dequeue();
        dialogText.text = dialogStueck;

        Debug.Log(dialogStueck);
    }

    public void DialogEnde()
    {
        Debug.Log("Ende");
    Destroy(name);
        //FindObjectOfType<WASD>().dialogEscape();
    }
}
