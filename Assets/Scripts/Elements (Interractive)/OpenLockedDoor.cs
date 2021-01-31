using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class OpenLockedDoor : MonoBehaviour
{
    public Animator doorAnim;
    private bool alreadyshaked = false;
    // Update is called once per frame

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "key")
        {
            doorAnim.SetBool("open", true);
            if (!alreadyshaked)
            {
                CameraShaker.Instance.ShakeOnce(2, 1, 0.5f, 2f);
                alreadyshaked = true;
            }
        }
    }
}
