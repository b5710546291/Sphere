using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G001_SpawnBlock : MonoBehaviour
{
    public GameObject BoxPref;
    public GameObject CoinPref;
    public GameObject TopObsPref;
    public GameObject BotObsPref;
    int nextGen = 0;
    GameObject PrevBox;
    int prevCoinI = 0;
    int prevCoinJ = 1;
    List<Vector2> idList = new List<Vector2>();

	public int maxBlock;
	public GameObject blockColls;



    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		
    }

    private void Awake()
    {
        PrevBox = Instantiate(BoxPref, Vector3.zero, Quaternion.identity);
        for (int i = 0; i< 5; i++)
        {
            Vector3 pos = new Vector3(PrevBox.transform.position.x, PrevBox.transform.position.y, PrevBox.transform.position.z+2);
            PrevBox = Instantiate(BoxPref, pos, Quaternion.identity);
        }
        StartCoroutine("Spawning");
        
    }

    IEnumerator Spawning()
    {
        
        Vector3 pos = new Vector3(PrevBox.transform.position.x, PrevBox.transform.position.y, PrevBox.transform.position.z + 2 );
        PrevBox = Instantiate(BoxPref, pos, Quaternion.identity);
        nextGen = 1;
        idList.Clear();
        for (int i = 0; i < 3; i++)
        {

            for (int j = 0; j < 2; j++)
            {
                idList.Add(new Vector2(i,j));
            }
        }
        idList.Remove(new Vector2(prevCoinI + 1, prevCoinJ - 1));
        GameObject Coin = Instantiate(CoinPref, PrevBox.transform);
        Coin.transform.Translate(new Vector3(prevCoinI,prevCoinJ -1 ,0),Space.World);

        
        float horiRand = Random.Range(0f, 100f);
        float vertiRand = Random.Range(0f, 100f);
        int tempI = prevCoinI;
        int tempJ = prevCoinJ;
        if (prevCoinI < 0)
        {
            if(horiRand <= 30)
            {
                prevCoinI++; 
            }
        } else if (prevCoinI == 0)
        {
            if(horiRand <= 15)
            {
                prevCoinI--;
            } else if(horiRand <= 30)
            {
                prevCoinI++;
            }
        } else if (prevCoinI > 0)
        {
            if (horiRand <= 30)
            {
                prevCoinI--;
            }
        }
        if (tempI == prevCoinI)
        {
            if (prevCoinJ == 1)
            {
                if (vertiRand <= 30)
                {
                    prevCoinJ++;
                }
            }
            else if (prevCoinJ == 2)
            {
                if (vertiRand <= 30)
                {
                    prevCoinJ--;
                }
            }
        }
        if (tempI != prevCoinI || tempJ != prevCoinJ)
        {

            idList.Remove(new Vector2(prevCoinI + 1, prevCoinJ - 1));
            //Coin = Instantiate(CoinPref, PrevBox.transform);
            //Coin.transform.Translate(new Vector3(prevCoinI, prevCoinJ - 1, 0), Space.World);
        }

        float obsRand = Random.Range(0f, 100f);
        int currentCon = 80;

        List<int> iList = new List<int>();
        List<int> jList = new List<int>();

        if ( obsRand <= currentCon)
        {
            bool spawnobs = true;
            while (spawnobs)
            {
                if (idList.Count <= 0)
                {
                    break;
                }
                int spaRand = Random.Range(0, idList.Count);
                if (idList[spaRand].y == 0)
                {
                    GameObject obs = Instantiate(BotObsPref, PrevBox.transform);
                    obs.transform.Translate(new Vector3(idList[spaRand].x - 1, 0, 0), Space.World);
                } else
                {
                    GameObject obs = Instantiate(TopObsPref, PrevBox.transform);
                    obs.transform.Translate(new Vector3(idList[spaRand].x - 1, 1, 0), Space.World);
                }
                idList.RemoveAt(spaRand);
                currentCon -= 20;
                if (obsRand >= currentCon)
                {
                    spawnobs = false;
                }
                
            }
        }
		PrevBox.transform.SetParent (blockColls.transform);

        
                
        
		yield return new WaitUntil(() => blockColls.transform.childCount < maxBlock);
        StartCoroutine("Spawning");
    }
}
