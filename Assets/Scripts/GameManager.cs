using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int count = 0;
    public bool sulfurState;
    public bool circleStatus;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {


    }



}
