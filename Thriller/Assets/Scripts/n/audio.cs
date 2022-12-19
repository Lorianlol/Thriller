using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;

    void randomPlay()
    {
        Debug.Log("played");
        int rand = Random.Range(1, 4);
        if(rand >= 1 && rand < 2)
        {
            audioSource.PlayOneShot(clip1);
        }
        else if(rand >= 2 && rand < 3)
        {
            audioSource.PlayOneShot(clip2);
        }
        else
        {
            audioSource.PlayOneShot(clip3);
        }

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
