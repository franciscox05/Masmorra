using UnityEngine;
using UnityEngine.SceneManagement; // Obrigatório para o Unity saber trocar de cenas!

public class LogicaMenu : MonoBehaviour
{
    // A função para o botão "Jogar"
    public void ComecarJogo()
    {
        SceneManager.LoadScene("Masmorra_Final"); 
    }

    // A função para o botão "Sair"
    public void FecharJogo()
    {
        Debug.Log("O jogo vai fechar!"); 
        Application.Quit(); 
    }
}