using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class callGhost : MonoBehaviour
{

    public int times = 1;
    public GameObject ghost;
    public GameObject doorTile;

    public AudioSource audioSource;
    public AudioClip audioClip;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && times > 0)
        {
            ghost.SetActive(true);
            doorTile.SetActive(true);
            times--;

            if (audioSource != null && audioSource.isPlaying == false)
            {
                audioSource.clip = audioClip;
                audioSource.Play();
            }
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
