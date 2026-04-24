using UnityEngine;

public class GatilhoLivro : MonoBehaviour
{
    public LogicaPuzzleVital scriptDoPuzzle;
    public Transform player; 
    public float distanciaParaAbrir = 3f; // Distância máxima para interagir

    void Update()
    {
        // Verifica se carregaste no E
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Calcula a distância entre o Livro e o Jogador
            float distancia = Vector3.Distance(transform.position, player.position);

            if (distancia <= distanciaParaAbrir)
            {
                scriptDoPuzzle.AbrirPuzzle();
            }
        }
    }
}