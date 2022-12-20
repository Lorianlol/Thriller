using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInto : MonoBehaviour
{
    public Transform m_CameraPosition;

    public AudioSource audioSource;
    public AudioSource lastAudioSource;
    public AudioClip audioClip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Camera.main.transform.position = m_CameraPosition.position;
            Debug.Log(Camera.main.transform.position);
            Debug.Log("传入坐标:" + m_CameraPosition.position);

            if(lastAudioSource != null) lastAudioSource.Stop();

            if (audioSource != null && audioSource.isPlaying == false)
            {
                audioSource.PlayOneShot(audioClip);
            }
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
