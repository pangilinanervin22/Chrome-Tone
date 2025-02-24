using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptWhiteMove : MonoBehaviour
{
    public Rigidbody2D character;
    // public Animator animator;
    public float speed = 10;
    public float jumpForce = 20;
    private bool isJumping = false;
    SpriteRenderer spriteRenderer;
    public AudioClip jumpSound;

    void Awake()
    {
        character = GetComponent<Rigidbody2D>();
        spriteRenderer = character.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float horizontalInput = 0;
        if (Input.GetKey(KeyCode.J))
            horizontalInput = -1;
        else if (Input.GetKey(KeyCode.L))
            horizontalInput = 1;


        Vector2 movement = new Vector2(horizontalInput, 0).normalized;
        // transform.position += new Vector3(movement.x * speed * Time.deltaTime, 0, 0);
        character.velocity = new Vector2(movement.x * speed, character.velocity.y);

        if (movement.magnitude > 0.01f)
            if (movement.x < 0)
                spriteRenderer.flipX = true;
            else
                spriteRenderer.flipX = false;


        if (Input.GetKeyDown(KeyCode.I) && !isJumping)
        {
            character.AddRelativeForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
            ScriptSoundManager.instance.PlaySound(jumpSound);
            transform.SetParent(null);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BlackPlatform"))
            Physics2D.IgnoreCollision(collision.collider, character.GetComponent<Collider2D>());


        bool acceptedPlatformCheck = collision.gameObject.CompareTag("WhitePlatform") ||
                                        collision.gameObject.CompareTag("Platform") ||
                                        collision.gameObject.CompareTag("BlackCharacter");
        if (acceptedPlatformCheck)
        {
            // Check if the character is above the platform
            if (transform.position.y <= collision.relativeVelocity.y)
            {
                isJumping = false;
                if (!collision.gameObject.CompareTag("BlackCharacter"))
                    transform.SetParent(collision.transform);
            }
        }
        else if (collision.gameObject.CompareTag("DeadPlatform"))
        {
            ScriptSoundManager.instance.PlayDeathSound();
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }

    }

}

