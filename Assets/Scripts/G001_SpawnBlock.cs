using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G001_SpawnBlock : MonoBehaviour
{
    public GameObject BoxPref;
    public List<GameObject> T1ObsPrefab;
    public List<GameObject> T2ObsPrefab;
    float count = 0;
    int nextGen = 0;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Instantiate(BoxPref, transform.transform.position, Quaternion.identity);
        count += Time.deltaTime * G001_GameController.speed;
    }

    private void Awake()
    {
        StartCoroutine("Spawning");
    }

    IEnumerator Spawning()
    {
        if(nextGen <= 0)
        {
            float rand = Random.Range(0f,1f)*100;
            if (rand < 75)
            {
                Instantiate(BoxPref, transform.position, Quaternion.identity);
                nextGen = 1;
            } else if (rand < 90) 
            {
                int randI = Random.Range(0, T1ObsPrefab.Count);
                Instantiate(T1ObsPrefab[randI], transform.position, Quaternion.identity);
                nextGen = 4;
            } else
            {
                int randI = Random.Range(0, T2ObsPrefab.Count);
                Instantiate(T2ObsPrefab[randI], transform.position, Quaternion.identity);
                nextGen = 8;
            }
        }
        yield return new WaitUntil(() => count >= 0.99);
        nextGen--;
        count = 0;
        StartCoroutine("Spawning");
    }
}
