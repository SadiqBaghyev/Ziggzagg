using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    Vector3 Direction;
    public float speed;
    public GroundSpawner GroundScript;
    public static bool isDown;
    public float addSpeed;
    private void Start()
    {
        Direction = Vector3.forward;
        isDown = false;
    }

    private void Update()
    {
        if (transform.position.y <= 0f)
        {
            isDown = true; 
        }

        if (isDown == true)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Direction.x == 0)
            {
                Direction = Vector3.left;
            }
            else
            {
                Direction = Vector3.forward;
            }

            speed += addSpeed * Time.deltaTime; 
        }

    }

    private void FixedUpdate()
    {
        Vector3 move = Direction * Time.deltaTime * speed;
        transform.position += move;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            
            collision.gameObject.AddComponent<Rigidbody>();
            GroundScript.GroundSpawn();
            StartCoroutine(DeleteGrounds(collision.gameObject));
            Score.score++;
        } 
    }

    IEnumerator DeleteGrounds(GameObject deleted)
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(deleted);
    }
}
