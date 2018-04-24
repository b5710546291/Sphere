using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
            if (speed_increase > 5)
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
        OverPanel.transform.GetChild(1).GetComponent<Text>().text = "Your score: " + (int)score;

    }

    public void GetPickUp()
    {
        score += 50;
        scoreText.text = "Score: " + (int)score;
        textAnim.Play("ScorePickUp");
    }

    public void ReplayButton()
    {
        print(nameToSave.text);
        SceneManager.LoadScene(1);
    }

    public void ExitButton()
    {
        print(nameToSave.text);
        SceneManager.LoadScene(0);
    }

    /**public void saveScore()
    {

        if (isWorthy)
        {

            InputField field = happyText.gameObject.transform.GetChild(0).gameObject.GetComponent<InputField>(); ;

            nameSave = "Player";

            if (field.text == "")
            {



            }
            else
            {

                nameSave = field.text;

            }



            string nameTemp1 = PlayerPrefs.GetString("name" + saveTo, "Player");

            int scoreTemp1 = PlayerPrefs.GetInt("score" + saveTo, 0);

            string nameTemp2;

            int scoreTemp2;



            for (int i = saveTo - 1; i >= 1; i--)
            {

                nameTemp2 = PlayerPrefs.GetString("name" + i, "Player");

                scoreTemp2 = PlayerPrefs.GetInt("score" + i, 0);

                PlayerPrefs.SetString("name" + i, nameTemp1);

                PlayerPrefs.SetInt("score" + i, scoreTemp1);

                nameTemp1 = nameTemp2;

                scoreTemp1 = scoreTemp2;



            }



            PlayerPrefs.SetInt("score" + saveTo, score);

            PlayerPrefs.SetString("name" + saveTo, nameSave);

        }

        Sumitting();

    }



    private void Sumitting()
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
