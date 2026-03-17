using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 300f; 
    public Transform playerBody; // A referência ao corpo da cápsula

    private float xRotation = 0f;

    void Start()
    {
        // Esconde o rato e prende-o no centro do ecrã para jogar
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Lê os movimentos do rato
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotação vertical (Cima/Baixo) na câmara
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Impede de olhar além dos 90 graus
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotação horizontal (Esquerda/Direita) no corpo do jogador
        playerBody.Rotate(Vector3.up * mouseX);
    }
}