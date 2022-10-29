using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runSpeed;
    public float jumpStrength;
    public Rigidbody2D rb;
    public Collider2D collider;
    public bool isGrounded;
    public LayerMask terrainMask;
    public bool isSliding;
    public Animator anim;
    public SpriteRenderer ren;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();

        //sliding control
        if (!isSliding && isGrounded && Input.GetAxis("Vertical") < -0.1f) {
            isSliding = true;
            anim.SetBool("Sliding", true);
            transform.rotation = Quaternion.Euler(0, 0, 90);
        } else if (isSliding && Input.GetAxis("Vertical") >= -0.1f && CanStand()) {
            isSliding = false;
            anim.SetBool("Sliding", false);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        //move control
        if (!isSliding) {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * runSpeed, rb.velocity.y);
            if (System.Math.Abs(rb.velocity.x) > 0.01f) {
                anim.SetBool("Running", true);
                if (rb.velocity.x > 0) {
                    ren.flipX = false;
                } else {
                    ren.flipX = true;
                }
            } else {
                anim.SetBool("Running", false);
            }
        } else {
            SlopeSlide();
            if (System.Math.Abs(rb.velocity.x) < runSpeed * 0.25f && rb.velocity.x > 0.05f) {
                rb.velocity = new Vector2(runSpeed * 0.25f, rb.velocity.y);
            } else if (System.Math.Abs(rb.velocity.x) < runSpeed * 0.25f && rb.velocity.x < -0.05f) {
                rb.velocity = new Vector2(runSpeed * -0.25f, rb.velocity.y);
            } else if (System.Math.Abs(rb.velocity.x) <= 0.05f && !CanStand()) {
                rb.velocity = new Vector2(runSpeed * 0.25f, rb.velocity.y);
            }
        }
        

        //jump control
        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) {
            rb.velocity = new Vector2(rb.velocity.x, jumpStrength + 0.5f * System.Math.Abs(rb.velocity.x));
            isSliding = false;
            anim.SetBool("Sliding", false);
            anim.SetTrigger("Jump");
            //rb.AddForce(new Vector2(0, jumpStrength));
        }

        if (IsDead()) {
            rb.velocity = new Vector2(0, 0);
            isGrounded = false;
            transform.position = Game.instance.lastCheckpoint.spawnPoint;
        }
    }

    //checks if the player is below the death (water) plane
    public bool IsDead() {
        return transform.position.y < Game.instance.waterLevel;
    }

    //checks if the player is standing on the ground, to enable jumping
    public void GroundCheck() {
        RaycastHit2D raycast = Physics2D.BoxCast(collider.bounds.center, new Vector2(collider.bounds.size.x - 0.05f, collider.bounds.size.y - 0.05f), 0f, Vector2.down, 0.3f, terrainMask);
        if (raycast.collider == null) {
            //Debug.Log("wow");
            isGrounded = false;
        } else {
            //Debug.Log("No");
            isGrounded = true;
        }
    }

    //checks if the player is on a slope while sliding and sets their velocity accordingly
    public void SlopeSlide() {
        RaycastHit2D leftcast = Physics2D.Raycast(new Vector2(collider.bounds.center.x - collider.bounds.extents.x, collider.bounds.center.y), Vector2.down, collider.bounds.extents.y + 0.1f, terrainMask);
        RaycastHit2D rightcast = Physics2D.Raycast(new Vector2(collider.bounds.center.x + collider.bounds.extents.x, collider.bounds.center.y), Vector2.down, collider.bounds.extents.y + 0.1f, terrainMask);
        RaycastHit2D deepleftcast = Physics2D.Raycast(new Vector2(collider.bounds.center.x - collider.bounds.extents.x, collider.bounds.center.y), Vector2.down, collider.bounds.extents.y + 2f, terrainMask);
        RaycastHit2D deeprightcast = Physics2D.Raycast(new Vector2(collider.bounds.center.x + collider.bounds.extents.x, collider.bounds.center.y), Vector2.down, collider.bounds.extents.y + 2f, terrainMask);


        if (leftcast.collider == null && rightcast.collider != null && deepleftcast.collider != null) {
            rb.velocity = new Vector2(runSpeed * -1.5f, runSpeed * -0.8f);
        } else if (leftcast.collider != null && rightcast.collider == null && deeprightcast.collider != null) {
            rb.velocity = new Vector2(runSpeed * 1.5f, runSpeed * -0.8f);
        }
    }

    //checks if the ceiling is too close to stop sliding
    public bool CanStand() {
        RaycastHit2D raycast = Physics2D.BoxCast(collider.bounds.center, new Vector2(collider.bounds.size.y - 0.05f, collider.bounds.size.y - 0.05f), 0f, Vector2.up, collider.bounds.extents.x - collider.bounds.extents.y + 0.1f, terrainMask);
        return raycast.collider == null;
    }

}