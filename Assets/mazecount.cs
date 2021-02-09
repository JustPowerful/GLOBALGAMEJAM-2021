using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mazecount : MonoBehaviour
{
    public int toCount;
    public int count = 0;

    public void increaseCount()
    {
        count++;
    }
    // Update is called once per frame
    void Update()
    {
        if (count >= toCount)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
