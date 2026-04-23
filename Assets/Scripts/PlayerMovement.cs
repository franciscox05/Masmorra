using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;
    private Vector2 moveInput;

    void Start()
    {
        // Vai buscar o Rigidbody que adicionaste há pouco na cápsula
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Cursor.lockState == CursorLockMode.None) return;
        // O teclado (teclas WASD ou Setas) lê-se no Update para ser responsivo
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveZ).normalized;
    }

    void FixedUpdate()
    {
        // A deslocação física faz-se obrigatoriamente no FixedUpdate
        Vector3 moveDirection = transform.right * moveInput.x + transform.forward * moveInput.y;
        Vector3 targetPosition = rb.position + moveDirection * speed * Time.fixedDeltaTime;
        rb.MovePosition(targetPosition);
    }
}