using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBar : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).gameObject.GetComponent<Image>().enabled = true;
        for (int i = 1; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setAmmo(float ammo_percentage)
    {

        int imgNr = (int)(ammo_percentage * (transform.childCount - 1));

        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.GetComponent<Image>().enabled = imgNr == i;
    }
}
