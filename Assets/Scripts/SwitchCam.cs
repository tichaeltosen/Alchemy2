using UnityEngine;

public class SwitchCam : MonoBehaviour {

public GameObject player, freecam, reticle, text, testElements;
public bool reticleActive = true;
public bool testElementsActive = false;
// private int cameraNumber = 0;

void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            SwitchPlayer();
        }
        if (Input.GetKeyDown("2"))
        {
            SwitchFreeCam();
        }
        if (Input.GetKeyDown("r"))
        {
            ToggleReticle();
        }
        if (Input.GetKeyDown("t"))
        {
            ToggleTestElements();
        }


    }
        
    
    // Call this function to switch to the next camera controller,
    // and enable overhead camera.
    public void SwitchPlayer() {
        player.SetActive(true);
        freecam.SetActive(false);

    }
        public void SwitchFreeCam() {
        player.SetActive(false);
        freecam.SetActive(true);

    }
        public void ToggleReticle() {
            
            if (reticleActive == true) {
                Debug.Log("reticle off");
                reticle.SetActive(false);
                text.SetActive(false);
                reticleActive = false;
            }
            else {
                Debug.Log("reticle on");
                reticle.SetActive(true);                
                text.SetActive(true);
                reticleActive = true;
            }

        }

        public void ToggleTestElements() {
            
            if (testElementsActive == true) {
                Debug.Log("test Elements Off");
                testElements.SetActive(false);
                testElementsActive = false;
            }
            else {
                Debug.Log("test Elements On");
                testElements.SetActive(true);
                testElementsActive = true;
            }

        }


}