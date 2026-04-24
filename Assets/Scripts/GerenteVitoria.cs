using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Essencial para reiniciar cenas

public class GerenteVitoria : MonoBehaviour
{
    [Header("Referências UI")]
    public GameObject painelVitoria;
    public TextMeshProUGUI textoScore;

    [Header("Referências do Jogo")]
    public LogicaTimer scriptDoTimer;

    public void FinalizarJogo()
    {
        // 1. Ativar o painel
        painelVitoria.SetActive(true);

        // 2. Parar o mundo (congelar tempo)
        Time.timeScale = 0f;

        // 3. Libertar o rato para o jogador poder clicar
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // 4. Calcular Score (Tempo restante x 100)
        if (scriptDoTimer != null)
        {
            float pontos = Mathf.Round(scriptDoTimer.tempoRestante) * 100f;
            textoScore.text = "SCORE FINAL: " + Mathf.RoundToInt(pontos).ToString();
        }
    }

    public void Reiniciar()
    {
        // Descongelar o tempo antes de mudar de cena!
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}