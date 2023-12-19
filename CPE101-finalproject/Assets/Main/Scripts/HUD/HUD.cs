using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType { Coin, Health, Kill, Wave }
    public InfoType type;

    public WaveSpawner waveSpawner;
    //public Text currWave;
    int _currWave;
    public float kill;

    PlayerHP playerHP;

    Text myText;
    Slider mySlider;

    private void Awake()
    {
        myText = GetComponent<Text>();
        mySlider = GetComponent<Slider>();
        kill = 0;
    }

    private void Update()
    {
        waveSpawner = GameObject.FindGameObjectWithTag("WaveSpawner").GetComponent<WaveSpawner>();
        playerHP = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHP>();
        _currWave = waveSpawner.currWave;
        //currWave.text = _currWave.ToString();
    }

    void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Coin:

                break;
            case InfoType.Health:
                float curHealth = playerHP.currentHP;
                float maxHealth = playerHP.maxHP;
                mySlider.value = curHealth / maxHealth;
                break;
            case InfoType.Kill:
                myText.text = string.Format("{0:F0}", kill.ToString());
                break;
            case InfoType.Wave:
                myText.text = string.Format("Wave:{0:F0}", _currWave.ToString());
                break;
        }
    }

    public void addKill()
    {
        kill += 1;
    }
}