using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class PlayfabManager : MonoBehaviour
{
    [Header("Windows")]
    public GameObject nameWindow;
    public GameObject leaderboardWindow;

    [Header("Display name window")]
    public GameObject nameError;
    public InputField nameInput;

    [Header("Leaderboard")]
    public GameObject rowPrefab;
    public Transform rowsParent;
    public string leaderboardName;

    public void Start()
    {
        print("juste je test la ");
        Login(Global.Username);
    }

    void Login(string customid)
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = customid,
            CreateAccount = true,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams

            {
                GetPlayerProfile = true
            }
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnError);
    }

    void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Successful login/account create!");
        //SendLeaderboard(100);
        var requestUpd = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = Global.Username,
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(requestUpd, OnDisplayNameUpdate, OnError);
       /* string name = null;
        if (result.InfoResultPayload.PlayerProfile != null)
            name = result.InfoResultPayload.PlayerProfile.DisplayName;
        print("nameuh : " + name);
        if (name == null)
            nameWindow.SetActive(true);
        else
            leaderboardWindow.SetActive(true);*/
    }

    public void SubmitNameButton()
    {
        //SendLeaderboard(100);
        //Login(nameInput.text);
       /* var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = nameInput.text,
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnError);*/
    }

    void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("Updated display name!");
        leaderboardWindow.SetActive(true);
    }

    void OnSuccess(LoginResult result)
    {
        Debug.Log("Successful login/account create ! ");
    }

    void OnError(PlayFabError error)
    {
        Debug.Log("Error while logging in/creating account ! ");
        Debug.Log(error.GenerateErrorReport());
    }

    public void SendLeaderboard(int score)
    {
        print("sendeuh");
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = leaderboardName,
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    public void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Successful leadearboard sent ! ");
    }

    public void GetleaderBoard()
    {
        print("je guette la ");
        var request = new GetLeaderboardRequest
        {
            StatisticName = leaderboardName,
            StartPosition = 0,
            MaxResultsCount = 6
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }

    void OnLeaderboardGet(GetLeaderboardResult result)
    {
        print("je me fais gueetz la xD");
        foreach (Transform item in rowsParent)
            Destroy(item.gameObject);

        foreach (var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = item.Position.ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();


            //Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
        }
    }
}
