using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;

    public bool _active;


    public void triggerDialog()
    { 
        if (_active)
        {
            //entfernen falls man sich nicht im Dialog bewegen soll

            //FindObjectOfType<WASD>().dialogStart();

            FindObjectOfType<DialogManager>().StarteDialog(dialog);
        }
    }

    public void activateDialogTrigger()
    {
        _active = true;
    }
    public void deactivateDialogTrigger()
    {
        _active = false;
    }

    public void triggerObject()
    {
        triggerDialog();
    }
}
