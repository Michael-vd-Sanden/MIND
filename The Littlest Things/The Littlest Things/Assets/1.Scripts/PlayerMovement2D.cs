using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    Rigidbody2D rb2D;
    Vector2 playerMovement;
    [SerializeField] private float speed = 5.0f;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        playerMovement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        moveCharacter(playerMovement);
    }

    public void moveCharacter(Vector2 direction) 
    {
        rb2D.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }
}
