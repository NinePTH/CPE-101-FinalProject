using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType { Coin, Health, Kill, Wave }
    public InfoType type;

    Text myText;
    Slider mySlider;

    private void Awake()
    {
        myText = GetComponent<Text>();
        mySlider = GetComponent<Slider>();
    }

    void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Coin:

                break;
            case InfoType.Health:

                break;
            case InfoType.Kill:

                break;
            case InfoType.Wave:

                break;
        }
    }
}