using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redCubeEscape : MonoBehaviour
{
    public GameObject[] toEnable;
    public GameObject[] toDestroy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            foreach (GameObject eObject in toEnable)
            {
                eObject.SetActive(true);
            }

            foreach(GameObject dObject in toDestroy)
            {
                Destroy(dObject);
            }
        }
    }
}
