using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public float rayDistance = 3f;
    public string chaveNoBolso = "Nenhuma";
    public bool temLanternaNoInventario = false; 

    public TextMeshProUGUI textoNoEcra;

    public AudioSource altifalante;
    public AudioClip somChave;
    public AudioClip somPorta;
    
    // --- A NOVA VARIÁVEL: O som exclusivo da lanterna ---
    public AudioClip somLanterna; 

    public Light luzDaLanterna;
    public GameObject painelTecladoUI;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        if (luzDaLanterna != null)
        {
            luzDaLanterna.enabled = false;
        }
    }

    void Update()
    {
        // SISTEMA DA LANTERNA (TECLA F)
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (temLanternaNoInventario == true && luzDaLanterna != null)
            {
                luzDaLanterna.enabled = !luzDaLanterna.enabled;
                
                // Toca o som da lanterna!
                if (somLanterna != null) altifalante.PlayOneShot(somLanterna); 
            }
            else if (temLanternaNoInventario == false)
            {
                MostrarMensagem("Ainda não tens uma lanterna!");
            }
        }

        // Se o teclado estiver aberto, não fazemos Raycast
        if (painelTecladoUI != null && painelTecladoUI.activeSelf)
        {
            return; 
        }

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.CompareTag("Interativo"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // 1. TECLADO
                    if (hit.collider.gameObject.name == "PainelParede")
                    {
                        painelTecladoUI.SetActive(true);
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
                    }
                    // 2. APANHAR LANTERNA
                    else if (hit.collider.gameObject.name == "LanternaFisica")
                    {
                        temLanternaNoInventario = true;
                        MostrarMensagem("Apanhaste a Lanterna! Prime [F] para usar.");
                        
                        // Toca o som da lanterna ao apanhar!
                        if (somLanterna != null) altifalante.PlayOneShot(somLanterna); 
                        
                        Destroy(hit.collider.gameObject); 
                    }
                    // 3. APANHAR CHAVES
                    else
                    {
                        chaveNoBolso = hit.collider.gameObject.name;
                        MostrarMensagem("Apanhaste a " + chaveNoBolso + "!");
                        if (somChave != null) altifalante.PlayOneShot(somChave);
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
            else if (hit.collider.CompareTag("Porta"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    string nomeDaPorta = hit.collider.gameObject.name;

                    if (nomeDaPorta == "PortaVermelha")
                    {
                        if (chaveNoBolso == "ChaveVermelha") AbrirPorta(hit.collider.gameObject);
                        else MostrarMensagem("Precisas da ChaveVermelha! Tu tens: " + chaveNoBolso);
                    }
                    else if (nomeDaPorta == "PortaAzul")
                    {
                        if (chaveNoBolso == "ChaveAzul") AbrirPorta(hit.collider.gameObject);
                        else MostrarMensagem("Precisas da ChaveAzul! Tu tens: " + chaveNoBolso);
                    }
                }
            }
        }
    }

    void AbrirPorta(GameObject portaAberta)
    {
        MostrarMensagem("A porta destrancou!");
        if (somPorta != null) altifalante.PlayOneShot(somPorta);
        portaAberta.transform.Translate(Vector3.up * 5f);
        portaAberta.GetComponent<Collider>().enabled = false;
        chaveNoBolso = "Nenhuma";
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