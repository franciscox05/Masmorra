using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float rayDistance = 3f; // Distância que o teu "braço" alcança

    void Update()
    {
        // Se o jogador carregar na tecla 'E' (botão de interação padrão)
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Cria o raio (laser) a partir do centro da câmara, a apontar em frente
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit; // Isto vai guardar a informação do objeto em que acertámos

            // Dispara o laser! Se bater em algo a menos de 3 metros...
            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                // ...verifica se esse objeto tem a etiqueta (Tag) "Interativo"
                if (hit.collider.CompareTag("Interativo"))
                {
                    // Confirma na consola e apaga o objeto do mundo (apanhou a chave!)
                    Debug.Log("Apanhei a chave!");
                    Destroy(hit.collider.gameObject); 
                }
            }
        }
    }
}