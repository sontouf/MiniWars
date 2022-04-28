using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Reflection;
using System.Linq;
/*
 * 씬을 관리하는 메서드들
 */
public class SceneManagerScript : MonoBehaviour
{
    private void Awake()
    {
/*        if (!PlayerPrefs.HasKey("StoryNumber"))
        {
            return;
        }
        DontDestroyUserData.storyNumber = PlayerPrefs.GetInt("StoryNumber");*/
    }


    // ============================ [ call-back method ] ============================
    static public void MainScene()
    {
        SceneManager.LoadScene(0);

    }

    static public void ExitGame()
    {
        Application.Quit();
    }

    static public void StageSelectScene()
    {
        SceneManager.LoadScene(1);
    }

    static public void PlayerScene()
    {
        SceneManager.LoadScene(3);
    }

    static public void BattleScene()
    {
        if (UnitBox.selectedUnitNumber > 0)
        {
            SceneManager.LoadScene(4);
        }

    }
}
