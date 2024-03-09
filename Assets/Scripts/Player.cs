using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private float speed;
    public PlayerNum playerNum;

    private void Update()
    {
        if (playerNum == PlayerNum.PLAYERONE)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                MoveRight();
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                MoveLeft();
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                MoveRight();
            }

            if (Input.GetKey(KeyCode.A))
            {
                MoveLeft();
            }
        }
    }

    private void MoveRight()
    {
        characterController.Move(Vector3.right * speed * Time.deltaTime);
    }

    private void MoveLeft()
    {
        characterController.Move(Vector3.left * speed * Time.deltaTime);
    }
}

public enum PlayerNum
{
    PLAYERONE,
    PLAYERTWO,
}