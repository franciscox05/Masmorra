using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LogicaTimer : MonoBehaviour
{
    [Header("Configurações de Tempo")]
    public float tempoInicialEmSegundos = 600f; // 10 minutos por defeito
    private float tempoRestante;
    private bool cronometroAtivo = false;

    [Header("Referências da UI")]
    public TextMeshProUGUI textoTimer;

    void Start()
    {
        tempoRestante = tempoInicialEmSegundos;
        cronometroAtivo = true;
    }

    void Update()
    {
        if (cronometroAtivo)
        {
            if (tempoRestante > 0)
            {
                // Subtrai o tempo real que passou desde o último frame
                tempoRestante -= Time.deltaTime;
                AtualizarDisplay(tempoRestante);
            }
            else
            {
                Debug.Log("O tempo acabou!");
                tempoRestante = 0;
                cronometroAtivo = false;
                GameOver();
            }
        }
    }

    void AtualizarDisplay(float tempoParaMostrar)
    {
        // Garante que o tempo não mostra valores negativos
        if (tempoParaMostrar < 0) tempoParaMostrar = 0;

        // Cálculos matemáticos para converter segundos em Minutos:Segundos
        float minutos = Mathf.FloorToInt(tempoParaMostrar / 60);
        float segundos = Mathf.FloorToInt(tempoParaMostrar % 60);

        // Formata a string para ter sempre dois dígitos (ex: 09:05 em vez de 9:5)
        textoTimer.text = string.Format("{0:00}:{1:00}", minutos, segundos);
        
        // DICA: Se faltar menos de 30 segundos, podemos pôr o texto a vermelho
        if (tempoParaMostrar < 30f) textoTimer.color = Color.red;
    }

    void GameOver()
    {
        // Certifica-te que crias uma cena chamada "Cena_Derrota" nas Build Settings
        SceneManager.LoadScene("Cena_Derrota");
    }
}