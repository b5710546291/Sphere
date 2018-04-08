using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G001_GameController : MonoBehaviour
{
    public static float speed = 4;
    public float score;
    float speed_increase;
    public bool isOver;
    public GameObject deadPref;

    // Use this for initialization
    void Start()
    {
        score = 0;
        speed_increase = 0;
        isOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOver)
        {
            score += speed * Time.deltaTime * 10;
            speed_increase += speed * Time.deltaTime * 10;
            if (speed_increase > 200)
            {
                speed += 0.1f;
                speed_increase = 0;
            }
            print(score);
        }
    }

    public void GameOver(GameObject go)
    {
        isOver = true;
        Instantiate(deadPref, go.transform.position, Quaternion.identity);
        Destroy(go);
    }
}
