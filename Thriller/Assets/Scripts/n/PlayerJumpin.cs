using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpin : MonoBehaviour
{
    public Transform m_playerPosition;
    public GameObject m_player;
    // Start is called before the first frame update
    
    void OnEnable()
    {
        m_player.transform.position = m_playerPosition.position;
        PlayerPrefs.SetFloat("PlayerPosX", m_playerPosition.position.x);
        PlayerPrefs.SetFloat("PlayerPosY", m_playerPosition.position.y);
        PlayerPrefs.SetFloat("PlayerPosZ", m_playerPosition.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
