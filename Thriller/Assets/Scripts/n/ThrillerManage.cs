using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrillerManage : MonoBehaviour
{
    public int level;
    public GameObject audio;

    private float pic_time;
    private float mons_time;
    private float mus_time;

    private float pic_timer;
    private float mons_timer;
    private float mus_timer;

    private Transform[] pics;
    private Transform[] monsts;

    // Start is called before the first frame update
    void Start()
    {
        level = 0;

        pic_time = (100 - level) / 10.0f + 3.0f;
        mons_time = (100 - level) / 10.0f + 5.0f;
        mus_time = (100 - level) / 10.0f + 3.0f;

        pic_timer = Random.Range(pic_time - 3.0f, pic_time + 3.0f);
        mons_timer = Random.Range(mons_time - 5.0f, mons_time + 5.0f);
        mus_timer = Random.Range(mus_time - 3.0f, mus_time + 3.0f);

        pics = GameObject.Find("pics").GetComponentsInChildren<Transform>(true);
        monsts = GameObject.Find("monsters").GetComponentsInChildren<Transform>(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(pic_timer > 0)
        {
            pic_timer -= Time.deltaTime;
        }
        else
        {
            int idx = Random.Range(1, pics.Length);
            StartCoroutine(jumpPic(idx));
            pic_timer = Random.Range(pic_time - 3.0f, pic_time + 3.0f);
        }

        if(mons_timer > 0)
        {
            mons_timer -= Time.deltaTime;
        }
        else
        {
            int idx = Random.Range(1, monsts.Length);
            if (!monsts[idx].gameObject.activeSelf)
            {
                monsts[idx].gameObject.SetActive(true);
                Vector2 v = new Vector2(Random.Range(-15f, 15f), Random.Range(10f, -8f));
                monsts[idx].gameObject.transform.position = v;
            }

            mons_timer = Random.Range(mons_time - 3.0f, mons_time + 3.0f);
        }

        if(mus_timer > 0)
        {
            mus_timer -= Time.deltaTime;

        }
        else
        {
            Debug.Log("called");
            audio.SendMessage("randomPlay", SendMessageOptions.DontRequireReceiver);
            mus_timer = Random.Range(mus_time - 3.0f, mus_time + 3.0f);
        }
    }

    IEnumerator jumpPic(int idx)
    {
        pics[idx].gameObject.SetActive(true);
        
        yield return new WaitForSeconds(0.16f);

        pics[idx].gameObject.SetActive(false);

    }

    void levelUp()
    {
        if (level >= 100) return;
        level++;
        Debug.Log("level = " + level);

        pic_time =(100 - level)/ 10.0f + 3.0f;
        mons_time = (100 - level) / 10.0f + 5.0f;
        mus_time = (100 - level) / 10.0f + 3.0f;

    }
}
