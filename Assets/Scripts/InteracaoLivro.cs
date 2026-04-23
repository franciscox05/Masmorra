using UnityEngine;
using TMPro; 

public class InteracaoLivro : MonoBehaviour
{
    [Header("Configurações de UI")]
    public GameObject painelDoLivro; // Arrastas o Panel aqui no Inspector

    private bool estaPerto = false;
    private bool livroAberto = false; // Controla se o UI está visível

    void Update()
    {
        // Se o jogador estiver perto e carregar na tecla E
        if (estaPerto && Input.GetKeyDown(KeyCode.E))
        {
            if (!livroAberto)
            {
                AbrirLivro();
            }
            else
            {
                FecharLivro();
            }
        }
    }

    public void AbrirLivro()
    {
        livroAberto = true;
        painelDoLivro.SetActive(true);

        // Liberta o rato para o jogador
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // NOTA: Se o movimento do personagem ainda estiver ativo, 
        // podes precisar de o desativar aqui (ex: playerMovement.enabled = false).
    }

    public void FecharLivro()
    {
        livroAberto = false;
        painelDoLivro.SetActive(false);

        // Prende o rato de novo para o jogador continuar a jogar
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Deteta quando o jogador se aproxima do livro
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            estaPerto = true;
            Debug.Log("Perto do livro. Carrega em E para abrir/fechar.");
        }
    }

    // Deteta quando o jogador se afasta
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            estaPerto = false;
            // Se o jogador se afastar com o livro aberto, ele fecha automaticamente
            if (livroAberto)
            {
                FecharLivro();
            }
        }
    }
}