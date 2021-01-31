using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;




public class storyTelling : MonoBehaviour
{
    public string[] arguments;
    public Text dialogueText;
    int currentArg = 0;
    // Update is called once per frame
    public bool end = false;


    private void Update()
    {

        // Clamping the argument array
        if (currentArg < arguments.Length)
        {
            dialogueText.text = arguments[currentArg];
        }
    }

    public void onButtonNext()
    {
        currentArg++;
        if (currentArg >= arguments.Length)
        {
            if (!end)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
