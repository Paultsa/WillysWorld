using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    public CharacterController controller;

    private Vector3 moveDirection;
    public float gravityScale;

    public Animator anim;
    public Transform pivot;
    public float rotateSpeed;

    public GameObject playerModel;

    public float knockbackForce;
    public float knockbackTime;
    private float knockbackCounter;
    private float jumpCounter;
    public float jumpTime;
    public float jumpingForce;

    private bool isGrounded; // is on a slope or not
    public float slideFriction = 0.3f; // ajusting the friction of the slope
    private Vector3 hitNormal; //orientation of the slope.
    public float slopeLimit;


    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        if (knockbackCounter <= 0)
        {



            float yStore = moveDirection.y;

            moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + transform.right * Input.GetAxisRaw("Horizontal");
            moveDirection = moveDirection.normalized * moveSpeed;
            moveDirection.y = yStore;

            if (controller.isGrounded)
            {
                moveDirection.y = 0f;
                if (Input.GetButton("Jump") && isGrounded)
                {
                    moveDirection.y = jumpForce;
                }
            }
        }
        else
        {
            knockbackCounter -= Time.deltaTime;
        }


        if (jumpCounter <= 0)
        {



            float yStore = moveDirection.y;

            moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + transform.right * Input.GetAxisRaw("Horizontal");
            moveDirection = moveDirection.normalized * moveSpeed;
            moveDirection.y = yStore;


        }
        else
        {
            knockbackCounter -= Time.deltaTime;
        }

        isGrounded = (Vector3.Angle(Vector3.up, hitNormal) <= slopeLimit);

        if (!isGrounded && Vector3.Angle(Vector3.up, hitNormal) < 85)
        {
            moveDirection.x += (1f - hitNormal.y) * hitNormal.x * (12f - slideFriction);
            moveDirection.z += (1f - hitNormal.y) * hitNormal.z * (12f - slideFriction);
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }

        anim.SetBool("isGrounded", controller.isGrounded);
        anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxisRaw("Vertical")) + Mathf.Abs(Input.GetAxisRaw("Horizontal"))));
    }


    public void Knockback(Vector3 direction)
    {
        knockbackCounter = knockbackTime;


        moveDirection = direction * knockbackForce;
        moveDirection.y = knockbackForce;

    }
    public void Jump(Vector3 direction, JumpPad go)
    {
        jumpCounter = jumpTime;


        moveDirection = direction * go.jumpingForce;
        moveDirection.y = go.jumpingForce;

    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        hitNormal = hit.normal;
    }
}