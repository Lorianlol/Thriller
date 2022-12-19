using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeave : MonoBehaviour
{
    GameObject[] maps;

    private GameObject thrillerManage;

    private Transform[] monsts;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            maps = GameObject.FindGameObjectsWithTag("mapN");
            int len = maps.Length;
            int chose = Random.Range(0, len);
            Debug.Log(chose);

            for(int i = 0; i < len; i++)
            {
                Transform[] targetObjects = maps[i].GetComponentsInChildren<Transform>(true);

                targetObjects[1].gameObject.SetActive(false);

                if (i == chose)
                {
                    targetObjects[1].gameObject.SetActive(true);
                }
            }

            for(int i = 1; i < monsts.Length; i++)
            {
                monsts[i].gameObject.SetActive(false);
            }

            thrillerManage.SendMessage("levelUp", SendMessageOptions.DontRequireReceiver);



        }
    }
    // Start is called before the first frame update
    void Start()
    {
        thrillerManage = GameObject.Find("ThrillerManage");
        monsts = GameObject.Find("monsters").GetComponentsInChildren<Transform>(true);

    }

    // Update is called once per frame
    /*    void Update()
        {

        }*/
}
