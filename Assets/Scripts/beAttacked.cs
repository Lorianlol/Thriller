using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beAttacked : MonoBehaviour
{
    public GameObject replaceTo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void attackReact()
    {
        replaceTo.SetActive(true);
        Destroy(gameObject);
    }
}
