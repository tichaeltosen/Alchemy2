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
    public bool textState;

    GameObject killNotes;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        StartCoroutine(EnableClick());
        
    }

    public void EndGame()
    {
        SceneManager.LoadScene("GameOver");
       
    }

    private IEnumerator EnableClick()
    {
        if (textState)
        {

            PlayerMovement.instance.playerLocked = true;
            MouseLook.instance.mouseLocked = true;
            yield return new WaitForSeconds(0.05f);
         
            if (Input.GetMouseButtonDown(0))
            {
                killNotes = GameObject.FindGameObjectWithTag("Notes");
                if(killNotes != null)
                {
                    killNotes.SetActive(false);

                }

                textState = false;
                PlayerMovement.instance.playerLocked = false;
                MouseLook.instance.mouseLocked = false;
                
            }
        }
        
    }


}
