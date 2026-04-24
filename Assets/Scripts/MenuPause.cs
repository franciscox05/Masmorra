using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorPause : MonoBehaviour
{
    public GameObject painelPause; // Arrastas o Painel aqui no Inspector
    private bool jogoPausado = false;

    void Update()
    {
        // Verifica se o jogador carregou no ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (jogoPausado)
            {
                Retomar();
            }
            else
            {
                Pausar();
            }
        }
    }

    public void Pausar()
    {
        jogoPausado = true;
        painelPause.SetActive(true); // Mostra o menu
        
        Time.timeScale = 0f; // Para o tempo do jogo (física, animações, etc.)
        
        // Liberta o rato para o utilizador clicar nos botões
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Retomar()
    {
        jogoPausado = false;
        painelPause.SetActive(false); // Esconde o menu
        
        Time.timeScale = 1f; // O tempo volta ao normal
        
        // Prende o rato de volta ao centro do ecrã
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void IrParaMenu()
    {
        Time.timeScale = 1f; // Garante que o tempo volta ao normal ao sair
        SceneManager.LoadScene("MenuPrincipal"); // Ajusta para o nome da tua cena de menu
    }
}