using UnityEngine;
using TMPro; 

public class PlayerInteraction : MonoBehaviour
{
    public float rayDistance = 3f; 
    public bool temChave = false; 
    public TextMeshProUGUI textoNoEcra; 

    public AudioSource altifalante; 
    public AudioClip somChave;      
    public AudioClip somPorta;      

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;                   
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit; 

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            // 1. CHAVE
            if (hit.collider.CompareTag("Interativo"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    MostrarMensagem("Apanhaste a chave!"); 
                    temChave = true; 
                    
                    if(somChave != null) altifalante.PlayOneShot(somChave);

                    Destroy(hit.collider.gameObject); // A chave continua a desaparecer do chão
                }
            }
            // 2. PORTA
            else if (hit.collider.CompareTag("Porta"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (temChave == true)
                    {
                        MostrarMensagem("Usaste a chave e a porta abriu!");
                        
                        if(somPorta != null) altifalante.PlayOneShot(somPorta);

                        // --- A MÁGICA DA OPÇÃO A ---
                        // Em vez de Destroy, a porta sobe 5 metros (Vector3.up * 5f)
                        hit.collider.transform.Translate(Vector3.up * 5f);
                        
                        // Também podíamos desligar o colisor para garantir que não bates lá:
                        // hit.collider.enabled = false;
                    }
                    else
                    {
                        MostrarMensagem("A porta está trancada! Vai procurar a chave.");
                    }
                }
            }
        }
    }

    void MostrarMensagem(string mensagem)
    {
        textoNoEcra.text = mensagem; 
        CancelInvoke("ApagarMensagem"); 
        Invoke("ApagarMensagem", 3f); 
    }

    void ApagarMensagem()
    {
        textoNoEcra.text = ""; 
    }
}