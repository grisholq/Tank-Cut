using UnityEngine;

public static class LevelPassData 
{
    private const string LevelIndexKey = "Current Level";
    private const string LevelsLoopKey = "Levels Loop";

    private const int FirstLevelIndex = 1;
    private const bool LevelsLoop = false;
    private const int LevelsCount = 10;

    private static int _currentLevelIndex;
    private static bool _levelsLoop;

    static LevelPassData()
    {
        InizializeLevelIndex();
        InizializeLevelIndex();
        InizializeLevelsLoop();
    }

    public static void Reset()
    {
        _currentLevelIndex = FirstLevelIndex;
        PlayerPrefs.SetInt(LevelIndexKey, FirstLevelIndex);

        _levelsLoop = LevelsLoop;
        PlayerPrefs.SetInt(LevelsLoopKey, LevelsLoop == true ? 1 : 0);
    }

    private static void InizializeLevelIndex()
    {
        if (PlayerPrefs.HasKey(LevelIndexKey))
        {
            _currentLevelIndex = PlayerPrefs.GetInt(LevelIndexKey);
        }
        else
        {
            _currentLevelIndex = FirstLevelIndex;
            PlayerPrefs.SetInt(LevelIndexKey, FirstLevelIndex);
        }
    }
    
    private static void InizializeLevelsLoop()
    {
        if (PlayerPrefs.HasKey(LevelsLoopKey))
        {
             _levelsLoop = PlayerPrefs.GetInt(LevelsLoopKey) == 1 ? true : false;
        }
        else
        {
            _levelsLoop = LevelsLoop;
            PlayerPrefs.SetInt(LevelsLoopKey, LevelsLoop == true ? 1 : 0);
        }
    }

    public static int GetCurrentLevelIndex()
    {
        return PlayerPrefs.GetInt(LevelIndexKey);
    }

    public static bool GetLevelsLoop()
    {
        return PlayerPrefs.GetInt(LevelsLoopKey) == 1 ? true : false;
    }

    public static void NextLevel()
    {
        if(_levelsLoop)
        {
            SetCurrentLevel(Random.Range(FirstLevelIndex, LevelsCount + 1));
            return;
        }

        if((_currentLevelIndex + 1) > LevelsCount)
        {
            SetLevelsLoop(true);
            SetCurrentLevel(FirstLevelIndex);
        }
        else
        {
            _currentLevelIndex++;
            SetCurrentLevel(_currentLevelIndex);
        }
    }

    private static void SetCurrentLevel(int level)
    {
        _currentLevelIndex = level;
        PlayerPrefs.SetInt(LevelIndexKey, _currentLevelIndex);
        PlayerPrefs.Save();
    }
    
    private static void SetLevelsLoop(bool loop)
    {
        _levelsLoop = loop;
        PlayerPrefs.SetInt(LevelsLoopKey, _levelsLoop == true ? 1 : 0);
        PlayerPrefs.Save();
    }
}