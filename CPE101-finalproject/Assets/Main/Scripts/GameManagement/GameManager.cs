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

    private void Start()
    {
        
    }

    public void GameStart()
    {
        AudioManager.instance.PlayBgm(true);
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Select);
    }

    public void GameOver()
    {
        //player.gameObject.SetActive(true);
        StartCoroutine(GameOverRoutine());
    }

    IEnumerator GameOverRoutine()
    {
        //isLive = false;
        player.enabled = false;

        yield return new WaitForSeconds(0.2f);

        uiResult.SetActive(true);
        Time.timeScale = 0;

        AudioManager.instance.PlayBgm(false);
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Lose);
    }

    public void Restart()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Select);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
