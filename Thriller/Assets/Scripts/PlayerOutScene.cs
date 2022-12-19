using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerOutScene : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("SceneIdx", SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

/*    // Update is called once per frame
    void Update()
    {
        
    }*/
}
