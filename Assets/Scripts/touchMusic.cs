using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchMusic : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip audioClip;
    public int times = 1;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && times > 0)
        {
            if (audioSource.isPlaying == false)
            {
                audioSource.PlayOneShot(audioClip);
                times--;
            }
        }
    }
}
