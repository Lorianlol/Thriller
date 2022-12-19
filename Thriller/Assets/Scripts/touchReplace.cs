using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class touchReplace : MonoBehaviour
{

    public GameObject replaceTo;
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            replaceTo.SetActive(true);
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


}
