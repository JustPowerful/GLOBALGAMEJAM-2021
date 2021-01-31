using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFaceShoot : MonoBehaviour
{
    public GameObject Player;
    public Transform shootingPos;
    private Vector2 direction;
    // Update is called once per frame
    void Update()
    {
        direction = Player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


    }
}
