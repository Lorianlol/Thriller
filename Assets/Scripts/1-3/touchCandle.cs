using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchCandle : MonoBehaviour
{
    public float darkTime = 1.5f;
    public GameObject lightOff;
    public GameObject lightOn;
    public GameObject word;
    public int times = 1;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && times > 0)
        {
            StartCoroutine(LightAndOff());
            times--;
        }
    }

    public IEnumerator LightAndOff()
    {
        lightOff.GetComponent<Light>().enabled = false;

        yield return new WaitForSeconds(darkTime);

        lightOn.GetComponent<Light>().enabled = true;
        word.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
/*    void Update()
    {
        
    }*/
}
