using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public KeyCode JumpKey = KeyCode.Space;
    public float JumpSpeed;
    public Sprite FemalePlayer;
    bool isWalking;
    bool isGrounded;
    bool FacingRight;
    RaycastHit2D hit;

    void Update()
    {
        Rigidbody2D r = GetComponent<Rigidbody2D>();
        r.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, r.velocity.y);

        if (Input.GetAxis("Horizontal") > 0)
        {
            FacingRight = true;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            FacingRight = false;
        }
        if (!FacingRight)   //Flip the player to the right or left
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (r.velocity.magnitude > 0.1f)
        {
            if (!isWalking)
            {
                StartCoroutine(Walk());
            }
        }

        //Grounded Checking

        hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.down);
        Debug.Log(Vector2.Distance(new Vector2(transform.position.x, transform.position.y), hit.collider.transform.position));
        if (hit.distance < 1.9f)
        {
            isGrounded = true;
           /// Debug.Log("On Ground.");
        }
        else
        {
            isGrounded = false;
           /// Debug.Log("Off Ground.");
        }
        //Jump
        if (isGrounded)
        {
            if (Input.GetKeyDown(JumpKey))
            {
                r.velocity = new Vector2(r.velocity.x, JumpSpeed);
            }
        }

        //Digging

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            if (hit.collider.gameObject.GetComponent<TileData>() != null)
            {
                Debug.Log(hit.collider.name);
                GetComponent<Inventory>().Add(hit.collider.gameObject.GetComponent<TileData>().tileType, 1);
                Destroy(hit.collider.gameObject);
            }
            else
            {
                Debug.Log("Hit nothing");
            }
        }
    }

        //For future animation of walking

        IEnumerator Walk()
    {
        isWalking = true;
        GetComponent<SpriteRenderer>().sprite = FemalePlayer;
        yield return new WaitForSeconds(0.25f);
        GetComponent<SpriteRenderer>().sprite = FemalePlayer;
        yield return new WaitForSeconds(0.25f);
        isWalking = false;
    }
}


