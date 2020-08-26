using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int count = 0;
    public bool sulfurState;
    public bool circleStatus;
    public bool gameOver;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {


    }

    public void EndGame()
    {
        SceneManager.LoadScene("GameOver");
    }


}
