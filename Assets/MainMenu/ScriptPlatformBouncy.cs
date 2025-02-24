using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPlatformBouncy : MonoBehaviour

{
    public int bouncyForce = 10;
    private void OnCollisionEnter2D(Collision2D other)
    {
        // make the player bounce when it collides with the bouncy platform
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bouncyForce, ForceMode2D.Impulse);
        }
    }
}
