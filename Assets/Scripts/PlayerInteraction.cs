using UnityEngine;
using TMPro; // MÁGICA: Esta linha é obrigatória para o Unity usar o teu texto!

public class PlayerInteraction : MonoBehaviour
{
    public float rayDistance = 3f; 
    public bool temChave = false; 
    
    // A variável que vai guardar a tua caixa de texto do Canvas
    public TextMeshProUGUI textoNoEcra; 

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit; 

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            // 1. O laser bateu numa CHAVE?
            if (hit.collider.CompareTag("Interativo"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    MostrarMensagem("Apanhaste a chave!"); 
                    temChave = true; 
                    Destroy(hit.collider.gameObject); 
                }
            }
            // 2. O laser bateu numa PORTA?
            else if (hit.collider.CompareTag("Porta"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (temChave == true)
                    {
                        MostrarMensagem("Usaste a chave e a porta abriu!");
                        Destroy(hit.collider.gameObject); 
                    }
                    else
                    {
                        MostrarMensagem("A porta está trancada! Vai procurar a chave.");
                    }
                }
            }
        }
    }

    // --- FUNÇÕES QUE CONTROLAM O TEXTO NO ECRÃ ---
    void MostrarMensagem(string mensagem)
    {
        textoNoEcra.text = mensagem; // Escreve o texto
        CancelInvoke("ApagarMensagem"); // Cancela temporizadores antigos
        Invoke("ApagarMensagem", 3f); // Manda apagar o texto passado 3 segundos!
    }

    void ApagarMensagem()
    {
        textoNoEcra.text = ""; // Limpa o ecrã
    }
}