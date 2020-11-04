﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    //Movement
    Vector3 MoveDirection;
    private float Movementx;
    private float Movementy;
    private float Mousex;
    private float Mousey;
    public float SpeedReduction;
    public float MaxSpeed;
    public float ActualSpeed;
    public bool CanMove = true;

    //Physics
    private Rigidbody PlayerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        //Recupere les Input
        Movementx = Input.GetAxisRaw("Horizontal") * SpeedReduction;
        Movementy = Input.GetAxisRaw("Vertical");

        //Avance Diagonale
        if (Movementx != 0 && Movementy > 0)
        {
            ActualSpeed = MaxSpeed * (Mathf.Sqrt(2) / 2);
        }
        //Recule Diagonale
        else if (Movementx != 0 && Movementy < 0)
        {
            ActualSpeed = MaxSpeed * (Mathf.Sqrt(2) / 2) * SpeedReduction;
        }
        //Avance ou Pas de cote
        else if (Movementx != 0 || Movementy > 0)
        {
            ActualSpeed = MaxSpeed;
        }
        //Recule
        else if (Movementy < 0)
        {
            ActualSpeed = MaxSpeed * SpeedReduction;
        }
        //Ne Bouge Pas
        else
        {
            ActualSpeed = 0;
        }

        MoveDirection = new Vector3(Movementx, 0, Movementy) * ActualSpeed;   

        //Deplace Le Joueur
        Vector3 newVel = MoveDirection;
        PlayerRigidbody.velocity = newVel;
    }
}
