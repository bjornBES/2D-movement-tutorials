using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace BEs.Tutorials.Movement._2D
{
    [System.Serializable]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] float movementSpeed = 15f;
        [SerializeField] Vector2 TopDownMovenetSpeed = new Vector2(15,15);
        [SerializeField] float MaxSpeed = 35f;
        [SerializeField] float jumpForce = 15f;
        [SerializeField] bool wallJumps;
        [SerializeField] public Rigidbody2D PlayerRig;
        [SerializeField] public Collider2D PlayerColl;
        [SerializeField] public int NumberOfJumps = 1;
        public int PreNumberOfJumps;
        Vector2 MoveMovement;
        [SerializeField] SpriteRenderer PlayerRenderer;
        [Header("layers")]
        [SerializeField] LayerMask grounde;
        [SerializeField] LayerMask wall;
        [Header("bools")]
        bool iswalking = true;
        bool isSneak = false;
        [SerializeField] public bool grounded;
        [SerializeField] public bool jumpGrounded;
        [SerializeField] bool rayA;
        [SerializeField] bool rayB;

        void Awake()
        {
            PlayerRenderer.flipX = true;

            PreNumberOfJumps = NumberOfJumps;
        }
        public void TopDownMovement()
        {
            TopDownWalk();
        }
        public void movement()
        {
            BEsUpdate();
            sticking();
            addRig();
        }
        public void addRig()
        {
            if (gameObject.GetComponent<Rigidbody2D>() == false)
            {
                PlayerRig = gameObject.AddComponent<Rigidbody2D>();
                PlayerRig.freezeRotation = true;

            }
            else
            {
                PlayerRig = gameObject.GetComponent<Rigidbody2D>();
            }
        }
        void BEsUpdate()
        {

            MoveMovement.x = Input.GetAxis("Horizontal");
            MoveMovement.y = Input.GetAxis("Vertical");

            PlayerColl = gameObject.GetComponent<Collider2D>();


            wallJumps = Physics2D.IsTouchingLayers(PlayerColl, wall);

            grounded = Physics2D.IsTouchingLayers(PlayerColl, grounde);

            if (jumpGrounded == true)
            {
                NumberOfJumps = PreNumberOfJumps;
            }
            walk();
            if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
            {

                PlayerRig.velocity = new Vector2(MoveMovement.x * 5f, jumpForce);
                grounded = false;

            }
            if (Input.GetKeyDown(KeyCode.Space) && NumberOfJumps >= 1)
            {

                PlayerRig.velocity = new Vector2(MoveMovement.x * 5f, jumpForce);
                NumberOfJumps--;

            }
        }
        void walk()
        {
            StartCoroutine(speed());
            if (Input.GetAxis("Horizontal") > 0.1f || Input.GetAxis("Horizontal") < -0.1)
            {
                transform.Translate(new Vector2(Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime, 0));
            }
        }
        void TopDownWalk()
        {
            StartCoroutine(TopDownSpeed());
            if (Input.GetAxis("Horizontal") > 0.1f || Input.GetAxis("Horizontal") < -0.1)
            {
                transform.Translate(new Vector2(Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime, 0));
            }
            if (Input.GetAxis("Vertical") > 0.1f || Input.GetAxis("Vertical") < -0.1)
            {
                transform.Translate(new Vector2(0,Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime));
            }
        }
        IEnumerator speed()
        {
            if (!(Input.anyKeyDown))
            {
                if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
                {
                    PlayerRenderer.flipX = false;
                    yield return new WaitForSeconds((float)0.1);
                    if (!(movementSpeed >= MaxSpeed))
                    {
                        movementSpeed += (float)0.5;
                    }
                }
                else if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
                {
                    yield return new WaitForSeconds((float)0.1);
                    if (movementSpeed >= 15f)
                    {
                        movementSpeed -= (float)0.5;
                    }
                }
                if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                {
                    PlayerRenderer.flipX = true;
                    yield return new WaitForSeconds((float)0.1);
                    if (!(movementSpeed >= MaxSpeed))
                    {
                        movementSpeed += (float)0.5;
                    }
                }
                else if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                {
                    yield return new WaitForSeconds((float)0.1);
                    if (movementSpeed >= 15f)
                    {
                        movementSpeed -= (float)0.5;
                    }
                }
            }
        }
        IEnumerator TopDownSpeed()
        {
            if (!(Input.anyKeyDown))
            {
                if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
                {
                    PlayerRenderer.flipX = false;
                    yield return new WaitForSeconds((float)0.1);
                    if (!(TopDownMovenetSpeed.x >= MaxSpeed))
                    {
                        TopDownMovenetSpeed.x += (float)0.5;
                    }
                }
                else if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
                {
                    yield return new WaitForSeconds((float)0.1);
                    if (TopDownMovenetSpeed.x >= 15f)
                    {
                        TopDownMovenetSpeed.x -= (float)0.5;
                    }
                }
                if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                {
                    PlayerRenderer.flipX = true;
                    yield return new WaitForSeconds((float)0.1);
                    if (!(TopDownMovenetSpeed.x >= MaxSpeed))
                    {
                        TopDownMovenetSpeed.x += (float)0.5;
                    }
                }
                else if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                {
                    yield return new WaitForSeconds((float)0.1);
                    if (TopDownMovenetSpeed.x >= 15f)
                    {
                        TopDownMovenetSpeed.x -= (float)0.5;
                    }
                }

                if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
                {
                    PlayerRenderer.flipX = false;
                    yield return new WaitForSeconds((float)0.1);
                    if (!(TopDownMovenetSpeed.y >= MaxSpeed))
                    {
                        TopDownMovenetSpeed.y += (float)0.5;
                    }
                }
                else if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
                {
                    yield return new WaitForSeconds((float)0.1);
                    if (TopDownMovenetSpeed.y >= 15f)
                    {
                        TopDownMovenetSpeed.y -= (float)0.5;
                    }
                }
                if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
                {
                    yield return new WaitForSeconds((float)0.1);
                    if (!(TopDownMovenetSpeed.y >= MaxSpeed))
                    {
                        TopDownMovenetSpeed.y += (float)0.5;
                    }
                }
                else if (!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
                {
                    yield return new WaitForSeconds((float)0.1);
                    if (TopDownMovenetSpeed.y >= 15f)
                    {
                        TopDownMovenetSpeed.y -= (float)0.5;
                    }
                }
            }
        }
        void sticking()
        {
            Vector2 Scale = new Vector2(1, 0.5f);
            if (Input.GetKeyDown(KeyCode.RightShift) && isSneak == false && iswalking == true)
            {
                transform.localScale = Scale;
                isSneak = true;
                iswalking = false;
            }
            if (Input.GetKeyUp(KeyCode.RightShift) && isSneak == true && iswalking == false)
            {
                transform.localScale = new Vector2(1, 1);
                isSneak = false;
                iswalking = true;
            }
        }
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "GroundReset")
            {
                jumpGrounded = true;
            }
        }
        void OnTriggerStay2D(Collider2D other)
        {
            if(other.gameObject.tag == "GrounReset")
            {
                PreNumberOfJumps = NumberOfJumps;
            }
        }
        void OnTriggerExit2D(Collider2D collision)
        {
            jumpGrounded = false;
        }
        public void WallJump()
        {
            jumpOnWall();
            castRay();
        }

        
        void jumpOnWall()
        {
            if(wallJumps == true)
            {
                PlayerRig.velocity = new Vector2(0f, 0f);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (rayA == true)
                    {
                        PlayerRig.velocity = new Vector2(15, jumpForce);
                    }
                    if (rayB == true)
                    {
                        PlayerRig.velocity = new Vector2(-15, jumpForce);
                    }
                }
            }
        }
        void castRay()
        {
            rayA = Physics2D.Raycast(transform.position, new Vector2(1.1f, 0), 1.1f, wall);
            rayB = Physics2D.Raycast(transform.position, new Vector2(-1.1f, 0), -1.1f, wall);
            Debug.DrawRay(transform.position, new Vector3(1.1f, 0f, 0f), Color.green, 1.1f);
            Debug.DrawRay(transform.position, new Vector3(-1.1f, 0f, 0f), Color.green, -1.1f);
        }
    }
}
