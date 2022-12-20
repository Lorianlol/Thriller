using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killByghost : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public int times = 1;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && times > 0)
        {

            if (audioSource != null && audioSource.isPlaying == false)
            {
                audioSource.PlayOneShot(audioClip);
            }
            times--;

        }
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
