using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//using PlayFab;
//using PlayFab.ClientModels;

public class G001_MainMenu : MonoBehaviour {

    public GameObject mainPanel;
    public GameObject LeaderboardPanel;

    private bool isLocal = true;

    //public List<PlayerLeaderboardEntry> leaderboard;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Awake()
    {
        LeaderboardPanel.transform.GetChild(0).GetChild(0);
        for(int i = 1;i<= 10; i++)
        {
            LeaderboardPanel.transform.GetChild(0).GetChild(0).GetChild(i).GetComponent<Text>().text = PlayerPrefs.GetString("G001N" + i, "Player");
            LeaderboardPanel.transform.GetChild(0).GetChild(0).GetChild(i+11).GetComponent<Text>().text = PlayerPrefs.GetInt("G001S" + i, 0).ToString();
        }


        //LoadOnlineBoard();


    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void LeaderboardButton()
    {
        mainPanel.SetActive(false);
        LeaderboardPanel.SetActive(true);
    }

    public void BackFromLeaderboard()
    {

        mainPanel.SetActive(true);
        LeaderboardPanel.SetActive(false);
    }

    public void ChangeLeaderboard()
    {
        LeaderboardPanel.transform.GetChild(0).gameObject.SetActive(!isLocal);
        LeaderboardPanel.transform.GetChild(1).gameObject.SetActive(isLocal);
        isLocal = !isLocal;
    }
    /**

    public void LoadOnlineBoard()
    {
        PlayFabSettings.TitleId = "B0E0";



        LoginWithCustomIDRequest request = new LoginWithCustomIDRequest { CustomId = "Guess", CreateAccount = true };

        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
    }

    private void OnLoginSuccess(LoginResult result)

    {

        TryGetLeaderBoard();



    }

    private void OnLoginFailure(PlayFabError error)

    {
        LeaderboardPanel.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text = error.GenerateErrorReport();
    }

    private void TryGetLeaderBoard()
    {

        PlayFabClientAPI.GetLeaderboard(new GetLeaderboardRequest { StatisticName = "score", StartPosition = 0, MaxResultsCount = 10 },

            (GetLeaderboardResult r) => {

                leaderboard = r.Leaderboard;

                int i = 1;

                foreach (PlayerLeaderboardEntry entry in leaderboard)
                {

                    LeaderboardPanel.transform.GetChild(1).GetChild(0).GetChild(i).GetComponent<Text>().text = entry.DisplayName;
                    LeaderboardPanel.transform.GetChild(1).GetChild(0).GetChild(i + 11).GetComponent<Text>().text = entry.StatValue.ToString();
                    

                    i++;

                }

            },

            OnLoginFailure

        );



    }*/
}
