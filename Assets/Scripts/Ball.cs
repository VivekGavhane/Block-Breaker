using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    // config param
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush=2f;
    [SerializeField] float yPush=15f;
    [SerializeField] AudioClip[] ballsounds;
    [SerializeField] float randomFactor = 0.2f;

    // state
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    //cached component reference
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;

    // Use this for initialization
    void Start () {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchBallOnMouseClick();
        }
        
    }

    private void LaunchBallOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidBody2D.velocity = new Vector2(xPush, yPush); 
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(UnityEngine.Random.Range(0f, randomFactor), UnityEngine.Random.Range(0f, randomFactor));
        if (hasStarted)
        {
            AudioClip clip = ballsounds[UnityEngine.Random.Range(0, ballsounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        }
        
    }
}
