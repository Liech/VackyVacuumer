using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fetchObject : MonoBehaviour
{

    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.GetComponent<Upgradeable>())
            return;
        Debug.Log("Medizin taken");
        Destroy(door);

        Destroy(gameObject); // destroy self
    }
}
