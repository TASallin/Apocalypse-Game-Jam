using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runSpeed;
    public float jumpStrength;
    public Rigidbody2D rb;
    public BoxCollider2D collider;
    public bool isGrounded;
    public LayerMask terrainMask;
    public bool isSliding;
    public Animator anim;
    public SpriteRenderer ren;
    public bool disableControls;
    public LevelReset reset;
    public GameObject credits;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0f) {
            return;
        }


        GroundCheck();

        if (rb.gravityScale > 0.1f && IsDead()) {
            disableControls = true;
            rb.velocity = new Vector2(0, 0);
            rb.gravityScale = 0.1f;
            anim.SetTrigger("Die");
            return;
        }

        if (disableControls) {
            return;
        }

        //sliding control
        if (!isSliding && isGrounded && Input.GetAxis("Vertical") < -0.1f) {
            isSliding = true;
            anim.SetBool("Sliding", true);
            collider.size = new Vector2(collider.size.y, collider.size.x);
            //transform.rotation = Quaternion.Euler(0, 0, 90);
        } else if (isSliding && Input.GetAxis("Vertical") >= -0.1f && CanStand()) {
            isSliding = false;
            anim.SetBool("Sliding", false);
            collider.size = new Vector2(collider.size.y, collider.size.x);
            //transform.rotation = Quaternion.Euler(0, 0, 0);
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
            rb.velocity = new Vector2(rb.velocity.x, jumpStrength + 0.25f * System.Math.Abs(rb.velocity.x));
            if (isSliding) {
                collider.size = new Vector2(collider.size.y, collider.size.x);
            }
            isSliding = false;
            anim.SetBool("Sliding", false);
            anim.SetTrigger("Jump");
            anim.SetBool("Landing", false);
            //rb.AddForce(new Vector2(0, jumpStrength));
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
            if (isGrounded == true) {
                anim.SetBool("Landing", false);
            }
            isGrounded = false;
        } else {
            if (isGrounded == false) {
                anim.SetBool("Landing", true);
            }
            isGrounded = true;
            
        }
    }

    public void Respawn() {
        if (Game.instance.creditsFlag) {
            credits.SetActive(true);
        } else {
            disableControls = false;
            rb.gravityScale = 2f;
            isGrounded = false;
            transform.position = Game.instance.lastCheckpoint.spawnPoint;
            if (reset != null) {
                reset.Reset();
            }
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
