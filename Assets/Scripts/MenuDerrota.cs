using UnityEngine;
using UnityEngine.SceneManagement; // Necessário para mudar de cena

public class MenuDerrota : MonoBehaviour
{
    void Start()
    {
        // 1. Liberta e mostra o rato assim que o ecrã aparece
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        // 2. Garante que o tempo do jogo corre (caso o Chico o tenha pausado)
        Time.timeScale = 1f;
    }

    public void ReiniciarJogo()
    {
        // Carrega a cena da Masmorra (ajusta o nome se for diferente)
        SceneManager.LoadScene("Masmorra_Final");
    }

    public void VoltarAoMenu()
    {
        // Carrega o menu principal
        SceneManager.LoadScene("MenuPrincipal");
    }
}