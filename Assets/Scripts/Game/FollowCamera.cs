using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform LocationBall;
    Vector3 Gap;

    private void Start()
    {
        Gap = transform.position - LocationBall.position;
    }

    private void Update()
    {
        
        if (BallController.isDown == false)
        {
            transform.position = LocationBall.position + Gap;
        }

        
    }
}
