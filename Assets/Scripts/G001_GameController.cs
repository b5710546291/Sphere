using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//using PlayFab;
//using PlayFab.ClientModels;

public class G001_GameController : MonoBehaviour
{
    public static float speed = 4;
    public float score;
    float speed_increase;
    public bool isOver;
    public GameObject deadPref;
    

    public Text scoreText;
    public GameObject OverPanel;
    public Animator textAnim;
    public InputField nameToSave;
    public string nameSave;

    // Use this for initialization
    void Start()
    {
        score = 0;
        speed = 4;
        speed_increase = 0;
        isOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOver)
        {
            score += speed * Time.deltaTime * 10;
            speed_increase += Time.deltaTime;
            if (speed_increase > 4)
            {
                speed += 0.1f;
                speed_increase = 0;
            }
            scoreText.text = "Score: " + (int)score;
        }
    }

    public void GameOver(GameObject go)
    {
        isOver = true;
        Instantiate(deadPref, go.transform.position, Quaternion.identity);
        Destroy(go);

        scoreText.transform.parent.gameObject.SetActive(false);
        OverPanel.gameObject.SetActive(true);
        OverPanel.transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<Text>().text = "Your score: " + (int)score;

    }

    public void GetPickUp()
    {
        score += 50;
        scoreText.text = "Score: " + (int)score;
        textAnim.Play("ScorePickUp");
    }

    public void ReplayButton()
    {
        saveScore();
        SceneManager.LoadScene(1);
    }

    public void ExitButton()
    {
        saveScore();
        SceneManager.LoadScene(0);
    }

    public void saveScore()
    {
        if (nameToSave.text == "")
        {
            nameSave = "Player";
        } else
        {
            nameSave = nameToSave.text;
        }


        int placeToSave = -1;
        for(int i = 10; i >= 1 ; i--)
        {
            if(PlayerPrefs.GetInt("G001S" + i, 0) <= score)
            {
                placeToSave = i;
            } else
            {
                break;
            }
        }

        if(placeToSave > 0)
        {

            int scoreTemp = PlayerPrefs.GetInt("G001S" + placeToSave, 0);
            string nameTemp = PlayerPrefs.GetString("G001N" + placeToSave, "Player");
            PlayerPrefs.SetInt("G001S" + placeToSave, (int)score);
            PlayerPrefs.SetString("G001N" + placeToSave, nameSave);

            int scoreTemp2;
            string nameTemp2;

            for (int i = placeToSave + 1; i <= 10; i++)
            {
                scoreTemp2 = PlayerPrefs.GetInt("G001S" + i, 0);
                nameTemp2 = PlayerPrefs.GetString("G001N" + i, "Player");
                PlayerPrefs.SetInt("G001S" + i, scoreTemp);
                PlayerPrefs.SetString("G001N" + i, nameTemp);
                scoreTemp = scoreTemp2;
                nameTemp = nameTemp2;
            }
        }
        

        //Sumitting();
        
    }



    /**private void Sumitting()
    {

        PlayFabSettings.TitleId = "B0E0";



        LoginWithCustomIDRequest request = new LoginWithCustomIDRequest { CustomId = nameSave, CreateAccount = true };

        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);

    }



    private void OnLoginSuccess(LoginResult result)

    {

        UpdateUserTitleDisplayNameRequest request = new UpdateUserTitleDisplayNameRequest();

        request.DisplayName = nameSave;

        PlayFabClientAPI.UpdateUserTitleDisplayName(request, null, null);



        UpdatePlayerStatisticsRequest statRequest = new UpdatePlayerStatisticsRequest();

        statRequest.Statistics = new List<StatisticUpdate>();

        statRequest.Statistics.Add(new StatisticUpdate { StatisticName = "score", Version = 0, Value = score });



        PlayFabClientAPI.UpdatePlayerStatistics(statRequest, null, OnSummitError);

    }



    private void OnLoginFailure(PlayFabError error)

    {

        Debug.Log("Fail to loggin: message: " + error.GenerateErrorReport());

    }



    private void OnSummitError(PlayFabError error)
    {

        Debug.Log("Fail to submit score: " + error.GenerateErrorReport());

    }*/

}
