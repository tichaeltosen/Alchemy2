using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private IPersistable [] elements = new IPersistable[3];

    public int count = 0;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        
    }

    // void OnDisable()
    //{
    //    foreach (IPersistable persistable in elements)
    //    {
    //        persistable.Save();
    //    }
        
    //}


}
