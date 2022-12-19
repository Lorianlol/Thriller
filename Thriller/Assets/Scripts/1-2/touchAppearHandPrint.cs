using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchAppearHandPrint : MonoBehaviour
{

    public GameObject handprint1;
    public GameObject handprint2;
    public GameObject handprint3;
    public GameObject handprint4;
    public GameObject handprint5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(show());
        }
    }

    public IEnumerator show()
    {
        handprint1.SetActive(true);
        yield return new WaitForSeconds(0.5f);

        handprint2.SetActive(true);
        yield return new WaitForSeconds(0.4f);

        handprint3.SetActive(true);
        yield return new WaitForSeconds(0.4f);

        handprint4.SetActive(true);
        yield return new WaitForSeconds(0.3f);

        handprint5.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
