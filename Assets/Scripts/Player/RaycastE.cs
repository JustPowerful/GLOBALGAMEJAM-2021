using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RaycastE : MonoBehaviour
{
    public Camera playerCam;
    public float distanceLimit;

    [Header("Crosshair Options :")]
    public LayerMask interractLayer;
    public Sprite normalCrosshair;
    public Sprite interractCrosshair;

    public Image displayedCrosshair;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKey("e"))
        {
            FindAndRun();
        }


        // Crosshair script
        RaycastHit crosshit;
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out crosshit, Mathf.Infinity, interractLayer))
        {
            displayedCrosshair.sprite = interractCrosshair;
        } 
        else
        {
            displayedCrosshair.sprite = normalCrosshair;
        }
    }

    void FindAndRun()
    {
        RaycastHit hit;

        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, distanceLimit))
        {
            OpenDoor doorScript = hit.transform.GetComponent<OpenDoor>(); // Gets the door script if available
            CradleRemember cradleRemember = hit.transform.GetComponent<CradleRemember>(); // Gets the cradle remember scene
            mazepick mp = hit.transform.GetComponent<mazepick>();
            // In case of opening the door script 
            if (doorScript != null)
            {
                doorScript.SendMessage("Run");
            }

            if (cradleRemember != null)
            {
                cradleRemember.SendMessage("Run");
            }
        }
    }
}
