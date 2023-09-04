using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject LastGround;

    private void Start()
    {
        for (int i = 0; i < 25; i++)
        {
            GroundSpawn();
            i++;
        }

    }

    public void GroundSpawn()
    {
        Vector3 Direction;
        if (Random.Range(0,2) == 0)
        {
            Direction = Vector3.left;
        }
        else
        {
            Direction = Vector3.forward;
        }
        LastGround = Instantiate(LastGround, LastGround.transform.position + Direction, LastGround.transform.rotation);
    }
}

