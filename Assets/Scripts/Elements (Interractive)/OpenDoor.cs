using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Animator doorAnim;
    // Update is called once per frame
    void Run()
    {
        doorAnim.SetBool("open", true);
    }
}
