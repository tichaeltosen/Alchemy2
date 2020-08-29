using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextHover : MonoBehaviour
{
    public Text startButton;

    Color normal;

    private void Start()
    {
        normal = startButton.color;
    }


    public void ChangeTextColor()
    {
        startButton.color = Color.red;
    }

    public void NormalTextColor()
    {
        startButton.color = normal;
    }
}
