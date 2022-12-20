using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject m_player;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 vec = Vector3.zero;

        vec.x = PlayerPrefs.GetFloat("CameraPosX", 0.5f);
        vec.y = PlayerPrefs.GetFloat("CameraPosY", 0.5f);
        vec.z = PlayerPrefs.GetFloat("CameraPosZ", -10);
        Camera.main.transform.position = vec;

        vec.x = PlayerPrefs.GetFloat("PlayerPosX", -7.91f);
        vec.y = PlayerPrefs.GetFloat("PlayerPosY", -2.06f);
        vec.z = PlayerPrefs.GetFloat("PlayerPosZ", 0);
        m_player.transform.position = vec;

        int sceneIdx = PlayerPrefs.GetInt("SceneIdx", 1);
        if(sceneIdx != SceneManager.GetActiveScene().buildIndex)
        {
            SceneManager.LoadScene(sceneIdx);
/*
 在PlayOutScene中删除上一个Scene的角色位置和照相机位置存档
此处删除则会出现：
    存档在scene 1, 此时在scece 0, load 1的时候将档删了，load 1 start的时候档没了取0， 又load回0 的错误情况
 */
            //PlayerPrefs.DeleteAll();

            Debug.Log(sceneIdx + "!!!!!!!!!s");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Restart"))
        {
            Debug.Log("restart");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(PlayerPrefs.GetInt("SceneIdx", 1));
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
