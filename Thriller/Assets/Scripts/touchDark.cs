using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchDark : MonoBehaviour
{
    public float darkTime = 2.5f;
    GameObject[] lights;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            lights = GameObject.FindGameObjectsWithTag("light1-1");
            Debug.Log(lights.Length);
            StartCoroutine(LightAndOff());
        }
    }

    public IEnumerator LightAndOff()
    {
        foreach(var light in lights)
        {
            Debug.Log(light.GetComponent<Light>().enabled);
            light.GetComponent<Light>().enabled = !(light.GetComponent<Light>().enabled);
        }
        yield return new WaitForSeconds(1);
        Debug.Log("ohyes");
        foreach (var light in lights)
        {
            Debug.Log(light.GetComponent<Light>().enabled);
            light.GetComponent<Light>().enabled = !(light.GetComponent<Light>().enabled);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        
    }

}
