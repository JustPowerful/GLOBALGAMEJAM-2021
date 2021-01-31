using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class countCollectsWin : MonoBehaviour
{
    int count = 0;
    public GameObject finalObject;
    public int wantedResults;
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "collectible")
        {
            Destroy(coll.collider.gameObject);
            count++;
        }

        if (count >= wantedResults)
        {
            finalObject.active = true;
        }
    }
}
