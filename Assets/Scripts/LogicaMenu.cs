using UnityEngine;
using UnityEngine.SceneManagement; // Obrigatório para o Unity saber trocar de cenas!

public class LogicaMenu : MonoBehaviour
{
    // A função para o botão "Jogar"
    public void ComecarJogo()
    {
        // ATENÇÃO: Substitui "Masmorra_Final" pelo nome exato da tua cena do jogo, se for diferente!
        SceneManager.LoadScene("Masmorra_Final"); 
    }

    // A função para o botão "Sair"
    public void FecharJogo()
    {
        Debug.Log("O jogo vai fechar!"); // Mensagem para tu saberes que o botão funciona no editor
        Application.Quit(); // O comando real que fecha a janela (só funciona depois do jogo ser exportado)
    }
}