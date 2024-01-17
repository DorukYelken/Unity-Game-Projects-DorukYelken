using System.Xml.Xsl;
using UnityEngine;
using UnityEngine.UIElements;
using static Unity.Burst.Intrinsics.Arm;

public class Mover : MonoBehaviour
{
    public float jumpForce = 5f;
    public float moveSpeed = 5f; // Hareket hızı
    public bool shiftKeyClick = false;
    public bool shiftCheck = true;
    public float rotationSpeed = 2f;
    private bool isGrounded = true;
    public GameObject canvasPrefab;
    public GameObject gun;
    public GameObject rightHand;
    public int x = 0;
    private Animator animator;
   
    void Start()
    {
        gun.SetActive(false);
        // Animator bileşenini alınır
        animator = GetComponent<Animator>();
    }

    void Update()
    {
       
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);



        if (Input.GetKeyDown(KeyCode.Space) )
        {
            
            Jump();
            
        }
       
        if (Input.GetKeyDown(KeyCode.LeftShift) && shiftCheck == true)
        {
            shiftKeyClick = true;
            shiftCheck = false;
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && shiftCheck == false)
        {
            shiftKeyClick = false;
            shiftCheck = true;
        }




       
        // Kamera yönlendirmesini al
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0f; // Y ekseni üzerindeki hareketi engelle
        cameraForward.Normalize(); // Vektörü normalize et (uzunluğunu 1 yap)

        // Kamera yönlendirmesini sadece x ve z düzlemlerinde kullan
        Vector3 cameraDirection = new Vector3(cameraForward.x, 0f, cameraForward.z).normalized;

        // Input.GetAxis ile WASD tuşlarına göre hareket vektörü alınır
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Hareket vektörü oluşturulur
        Vector3 moveDirection = cameraDirection * vertical + Camera.main.transform.right * horizontal;

        if (moveDirection.magnitude > 0.01f)
        {
            
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

     /*   if (moveDirection.magnitude == 0f)
        {
            Vector3 newPosition = new Vector3(-1.149999f, -0.2999894f, 0f);
            gun.transform.position = newPosition;
            Vector3 newRotation = new Vector3(130.632f, 76.778f, 79.89f);
            gun.transform.rotation = Quaternion.Euler(newRotation);


        }*/

        Rigidbody rb = GetComponent<Rigidbody>();


        if (Input.GetMouseButton(1))
        {
            Vector3 cameraForward1 = Camera.main.transform.forward;
            cameraForward1.y = 0f;
            cameraForward1.Normalize();
            
            transform.forward = cameraForward1;

            animator.SetBool("GunHold", true);
            gun.SetActive(true);
            canvasPrefab.gameObject.SetActive(true);
            shiftKeyClick = false;
            shiftCheck = true;
            



            if (Input.GetMouseButton(0))
            {
                animator.SetBool("GunFire", true);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("NO FIRE");
                animator.SetBool("GunFire", false);
            }
        }
        else
        {
            gun.SetActive(false);
            x = 0;
            canvasPrefab.gameObject.SetActive(false);
            animator.SetBool("GunHold", false);
        }


        /*  if (Input.GetKey(KeyCode.S))
          {
              animator.SetBool("Back", true);
          }
          else
          {
              animator.SetBool("Back", false);
          }*/







        if (shiftKeyClick == true)
        {
            rb.MovePosition(transform.position + moveDirection * moveSpeed * 15f * Time.deltaTime);
            animator.SetFloat("Walk", moveDirection.magnitude);

            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
            {
                animator.SetBool("right", true);
            }
            else
            {
                animator.SetBool("right", false);
            }

            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
            {
                animator.SetBool("left", true);
            }
            else
            {
                animator.SetBool("left", false);
            }
        }
        else if (shiftKeyClick != true)
        {
            rb.MovePosition(transform.position + moveDirection * moveSpeed * 5f * Time.deltaTime);
            animator.SetFloat("Walk", moveDirection.magnitude);
            if (moveDirection.magnitude >= 0.4f)
            {
                animator.SetFloat("Walk", 0.4f);
            }

            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
            {
                animator.SetBool("right", true);
            }
            else
            {
                animator.SetBool("right", false);
            }

            if (Input.GetKey(KeyCode.D))
            {
                animator.SetBool("onlyRight", true);
            }
            else
            {
                animator.SetBool("onlyRight", false);
            }

            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
            {
                animator.SetBool("left", true);
            }
            else
            {
                animator.SetBool("left", false);
            }

            if (Input.GetKey(KeyCode.A))
            {
                animator.SetBool("onlyLeft", true);
            }
            else
            {
                animator.SetBool("onlyLeft", false);
            }
        }
        
    }
    void OnCollisionEnter(Collision collision)
    {
        // Check if the player is grounded when colliding with a surface
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("Jump", false);

        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Update grounded state when leaving a surface
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            animator.SetBool("Jump", true);

        }
    }

    void Jump()
    {
        // Check if the player is on the ground before allowing a jump
        if (isGrounded)
        {
            animator.SetBool("Jump", true);
            Rigidbody rb = GetComponent<Rigidbody>();
            // Add force in the upward direction to simulate jumping
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            // Set the animator parameter for jumping if you have one
            
        }
        
    }


}