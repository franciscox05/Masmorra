using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float rayDistance = 3f; 
    
    // O NOSSO INVENTÁRIO: Começa em 'false' porque nasces sem a chave
    public bool temChave = false; 

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit; 

        // Desenha o laser vermelho na janela Scene para ajudar a ver
        Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.red);

        // Dispara o laser. Se bater em algo a menos de 3 metros...
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            // 1. O laser bateu numa CHAVE?
            if (hit.collider.CompareTag("Interativo"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Apanhaste a chave!");
                    temChave = true; // A MÁGICA: O jogo agora sabe que tens a chave no bolso!
                    Destroy(hit.collider.gameObject); // A chave desaparece do chão
                }
            }
            
            // 2. O laser bateu numa PORTA?
            else if (hit.collider.CompareTag("Porta"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // O jogo pergunta: "Ele tem a chave no bolso?"
                    if (temChave == true)
                    {
                        Debug.Log("Usaste a chave e a porta abriu!");
                        Destroy(hit.collider.gameObject); // A porta desaparece (abriu)
                    }
                    else
                    {
                        Debug.Log("A porta está trancada! Vai procurar a chave.");
                    }
                }
            }
        }
    }
}