using System;
using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float velocityX = 3f;
    [SerializeField] float velocityY = 15f;
    //[SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;

    // state
    Vector2 paddleToBallVector;
    bool hasLaunched = false;

    // Cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();  // GetComponent searches only in the the current GameObject local
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasLaunched)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
        else
        {
            ResetBallStuck();
        }
    }

    private void ResetBallStuck()
    {
        if (Input.GetKeyDown("r"))
        {
            LockBallToPaddle();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasLaunched = true;
            myRigidBody2D.velocity = new Vector2(velocityX, velocityY);
        }
    }

    public void LockBallToPaddle()
    {
        hasLaunched = false;
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Vector2 velocityTweak = new Vector2(UnityEngine.Random.Range(0f, randomFactor), UnityEngine.Random.Range(0f, randomFactor));
        if (hasLaunched)
        {
            myAudioSource.Play();
            //myRigidBody2D.velocity += velocityTweak;

            //AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            //GetComponent<AudioSource>().PlayOneShot(clip);
        }
    }
}
