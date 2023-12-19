using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isLive;
    public static GameManager instance;
    public PLayerMovement player;
    public GameObject uiResult;

    private void Awake()
    {
        instance = this;
    }

    public void GameOver()
    {
        StartCoroutine(GameOverRoutine());
    }

    IEnumerator GameOverRoutine()
    {
        //isLive = false;
        player.enabled = false;

        yield return new WaitForSeconds(0.5f);

        uiResult.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
