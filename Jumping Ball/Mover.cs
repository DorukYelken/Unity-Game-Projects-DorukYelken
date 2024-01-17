using UnityEngine;
using UnityEngine.UI;
public class Mover : MonoBehaviour
{
    public float moveSpeed = 5f; // Hızı kontrol etmek için bir değişken
    
    public float moveForce = 1.4f;
    public float moveForceLimit = 3f ;
      // Zıplama kuvveti
    public int jumpLimit = 0;
     public int jumpLimitGui = 8;
    private bool canInstantiate = true;
     public GameObject powerCube;
    private Rigidbody rb;
    public Material newMaterial;
    public Material jumpMaterial;

    
    public Text textPoint; 
    public Text textJumpLimit;
    void Start()
    {
       
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
       
        // İleri yönde hareket vektörünü oluştur
        Vector3 forwardMovement = transform.forward * moveSpeed * moveForce * Time.deltaTime ;

        // Rigidbody'nin pozisyonunu güncelle
        rb.MovePosition(rb.position + forwardMovement);

        // Karakterin rotasyonunu sıfır olarak sabitle
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        // Ekran tıklandığında zıplama
        if (Input.GetMouseButtonDown(0) && jumpLimit < 8) // 0 sol tık, 1 sağ tık, 2 orta tık
        {
            Renderer renderer = GetComponent<Renderer>();
            renderer.material = jumpMaterial;
            jumpLimit++;
            Jump();
            jumpLimitGui--;
        }
        textPoint.text = jumpLimitGui.ToString();
        string tamSayi = Mathf.FloorToInt(transform.position.z).ToString();
        textJumpLimit.text   =  tamSayi ;
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        if(moveForce <= moveForceLimit){
            moveForce = moveForce + 0.2f;
        }else{
            moveForce = moveForceLimit;
        }
        if (canInstantiate)
        {
            GameObject newPowerCube = Instantiate(powerCube, new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), Quaternion.identity);
            canInstantiate = false; // Bir kere Instantiate edildikten sonra tetikleyiciyi kapat
            Destroy(newPowerCube, 1.5f);
        }
        canInstantiate = true;
    }

    void OnCollisionEnter(Collision colObject)
    {
       
        if(moveForce < moveForceLimit){
             moveForce += 0.2f;
        }
            
        
        jumpLimit = 0;
        jumpLimitGui = 8;
        Renderer renderer = GetComponent<Renderer>();
        renderer.material = newMaterial;
    }

    
   
}

