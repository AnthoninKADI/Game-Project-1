using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    public GameObject credits;
    public GameObject missionBrief;
    public void GoLevel2()
    {
        SceneManager.LoadScene("LevelTwo");
    }
    public void Generic()
    {
        credits.SetActive(true);
        missionBrief.SetActive(false);
    }
}
