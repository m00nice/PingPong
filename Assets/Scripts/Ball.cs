using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private Vector3 spawnPosition;


    private void Start()
    {
        int rInt = Random.Range(-1, 1);
        if (rInt == 0)
        {
            rb.velocity = Vector3.forward;
        }
        else
        {
            rb.velocity = Vector3.back;
        }
    }

    private void Update()
    {
        MoveBall();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Paddle"))
        {
            if (other.transform.parent.GetComponent<Player>().playerNum == PlayerNum.PLAYERONE)
            {
                rb.velocity = (transform.position - other.transform.position).normalized;
            }
            else
            {
                rb.velocity = (transform.position - other.transform.position).normalized;
            }
        }
        else if (other.gameObject.CompareTag("Goal"))
        {
        }
        else if (other.gameObject.CompareTag("Side"))
        {
            Vector3 normal = (other.transform.position - transform.position).normalized;
            Vector3 reflection = Vector3.Reflect(rb.velocity, normal);
            rb.velocity = new Vector3(-reflection.x, reflection.y, -reflection.z);
        }
    }

    private void MoveBall()
    {
        rb.velocity = rb.velocity.normalized * (speed * Time.deltaTime);
    }
}