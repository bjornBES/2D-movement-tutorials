using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BEs.Tutorials.Movement.ToD
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] float movementSpeed;
        [SerializeField] float MaxSpeed;
        [SerializeField] float jumpForce;
        [SerializeField] bool grounded;
        [SerializeField] Rigidbody2D PlayerRig;

        [SerializeField] LayerMask grounde;

        public void movement()
        {
            FixedUpdate();
        }
        public void addRig()
        {
            PlayerRig = gameObject.AddComponent<Rigidbody2D>();

            Rig();
        }
        void Rig()
        {
            PlayerRig.freezeRotation = true;
        }
        void FixedUpdate()
        {
            grounded = Physics2D.IsTouchingLayers(gameObject.GetComponent<Collider2D>(), grounde);

            walk();
            if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
            {
                PlayerRig.velocity = new Vector2(PlayerRig.velocity.x, jumpForce);
                grounded = false;
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
        IEnumerator speed()
        {
            if (!(Input.anyKeyDown))
            {
                if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
                {
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
    }
}
