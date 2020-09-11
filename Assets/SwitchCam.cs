using UnityEngine;

public class SwitchCam : MonoBehaviour {

public GameObject player, freecam;
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

}