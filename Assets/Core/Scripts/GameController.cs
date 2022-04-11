using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public ResultPanel resultPanel;
    public GamePanel gamePanel;

    private float _startTime;
    private bool _isGameStarted;
    public bool IsGameStarted => _isGameStarted;

    private void Awake()
    {
        Instance = this;

        resultPanel.gameObject.SetActive(true);
    }

    private void Start()
    {
        gamePanel.levelText.text = "Level " + (Account.Level + 1);

        gamePanel.ShowTutorial();
    }

    private void Update()
    {
        if (!_isGameStarted && Input.GetMouseButtonDown(0)/* && RaycastMouse().Count <= 1*/)
            StartGame();
    }

    public void StartGame()
    {
        _isGameStarted = true;

        HandleStartEvents();
    }

    public void OnLevelCompleted(bool isWin = true, float delay = 0.5f)
    {
        HandleCompleteEvents(isWin);

        if (isWin)
        {

        }

        resultPanel.Show(isWin, delay);
    }

    private void HandleStartEvents()
    {
        /*
        string levelNumber = Utility.IntToString(Account.Level + 1, 5);
        _startTime = Time.time;

        //GameAnalyticsSDK.GameAnalytics.SetCustomDimension01(Account.AB_TEST_GROUP_ID == 0 ? "releaseToKill" : "autoKill");
        TinySauce.OnGameStarted(levelNumber);*/
    }

    private void HandleCompleteEvents(bool isWin)
    {
        /*
        string levelNumber = Utility.IntToString(Account.Level + 1, 5);
        string sceneName = SceneManager.GetActiveScene().name;// Account.SceneName;

        int levelDuration = Mathf.RoundToInt(Time.time - _startTime);

        TinySauce.OnGameFinished(isWin, levelDuration, levelNumber);

        if (!Account.IsShuffled)
        {
            if (isWin)
                TinySauce.TrackCustomEvent(levelNumber + "_win");
            else
                TinySauce.TrackCustomEvent(levelNumber + "_fail");
        }

        if (isWin)
            TinySauce.TrackCustomEvent(sceneName + "_win");
        else
            TinySauce.TrackCustomEvent(sceneName + "_fail");
        */
    }

    public List<RaycastResult> RaycastMouse()
    {

        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            pointerId = -1,
        };

        pointerData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        return results;
    }

}
