using UnityEngine;
using TMPro; // Se usares TextMeshPro

public class InteracaoLivro : MonoBehaviour
{
    public GameObject painelDoLivro; // Arrastas o Panel aqui
    private bool estaPerto = false;

    void Update()
    {
        // Se o jogador estiver perto e carregar na tecla E (ou outra que escolhas)
        if (estaPerto && Input.GetKeyDown(KeyCode.E))
        {
            AbrirLivro();
        }
    }

    public void AbrirLivro()
    {
        painelDoLivro.SetActive(true);
        // Liberta o rato para o jogador poder fechar o livro se quiseres
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void FecharLivro()
    {
        painelDoLivro.SetActive(false);
        // Prende o rato de novo para o jogador continuar a andar
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Deteta quando o jogador se aproxima do livro
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            estaPerto = true;
            Debug.Log("Carrega em E para ler o livro");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            estaPerto = false;
            FecharLivro(); // Fecha automaticamente se o jogador se afastar
        }
    }
}