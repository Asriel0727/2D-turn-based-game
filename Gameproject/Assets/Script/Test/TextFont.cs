using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFont : MonoBehaviour
{
    public Font newFont;

    void Start()
    {
        Text[] texts = FindObjectsOfType<Text>();

        foreach (Text text in texts)
        {
            text.font = newFont;
        }
    }
}
