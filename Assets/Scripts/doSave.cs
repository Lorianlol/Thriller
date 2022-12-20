using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doSave : MonoBehaviour
{
    public Sprite m_saveSuccess;
    SpriteRenderer m_spriteRenderer;
    
    private void Awake()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void save()
    {
        PlayerPrefs.SetFloat("PlayerPosX", transform.position.x);
        PlayerPrefs.SetFloat("PlayerPosY", transform.position.y);
        PlayerPrefs.SetFloat("PlayerPosZ", transform.position.z);

        PlayerPrefs.SetFloat("CameraPosX", Camera.main.transform.position.x);
        PlayerPrefs.SetFloat("CameraPosY", Camera.main.transform.position.y);
        PlayerPrefs.SetFloat("CameraPosZ", Camera.main.transform.position.z);
        Debug.Log("saveOk");
        Debug.Log(m_spriteRenderer.sprite);
        m_spriteRenderer.sprite = m_saveSuccess;
        Debug.Log(m_spriteRenderer.sprite);
    }
}
