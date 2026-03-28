using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public float rayDistance = 3f;

    public bool temChaveVermelha = false;
    public bool temChaveAzul = false;
    public bool temLanternaNoInventario = false; 

    public TextMeshProUGUI textoNoEcra;

    public AudioSource altifalante;
    public AudioClip somChave;
    public AudioClip somPorta;
    public AudioClip somLanterna; 

    public Light luzDaLanterna;
    public GameObject painelTecladoUI;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        if (luzDaLanterna != null) luzDaLanterna.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (temLanternaNoInventario && luzDaLanterna != null)
            {
                luzDaLanterna.enabled = !luzDaLanterna.enabled;
                if (somLanterna != null) altifalante.PlayOneShot(somLanterna); 
            }
            else if (!temLanternaNoInventario)
            {
                MostrarMensagem("Ainda não tens uma lanterna!");
            }
        }

        if (painelTecladoUI != null && painelTecladoUI.activeSelf) return;

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.CompareTag("Interativo"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    string nomeObjeto = hit.collider.gameObject.name;

                    if (nomeObjeto == "PainelParede")
                    {
                        painelTecladoUI.SetActive(true);
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
                    }
                    else if (nomeObjeto == "LanternaFisica")
                    {
                        temLanternaNoInventario = true;
                        MostrarMensagem("Apanhaste a Lanterna! Prime [F].");
                        if (somLanterna != null) altifalante.PlayOneShot(somLanterna); 
                        Destroy(hit.collider.gameObject); 
                    }
                    else if (nomeObjeto == "ChaveVermelha")
                    {
                        temChaveVermelha = true;
                        MostrarMensagem("Apanhaste a Chave Vermelha!");
                        if (somChave != null) altifalante.PlayOneShot(somChave);
                        Destroy(hit.collider.gameObject);
                    }
                    else if (nomeObjeto == "ChaveAzul")
                    {
                        temChaveAzul = true;
                        MostrarMensagem("Apanhaste a Chave Azul!");
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
                        if (temChaveVermelha) AbrirPorta(hit.collider.gameObject, "Vermelha");
                        else MostrarMensagem("Precisas da Chave Vermelha!");
                    }
                    else if (nomeDaPorta == "PortaAzul")
                    {
                        if (temChaveAzul) AbrirPorta(hit.collider.gameObject, "Azul");
                        else MostrarMensagem("Precisas da Chave Azul!");
                    }
                }
            }
        }
    }

    void AbrirPorta(GameObject portaObjeto, string cor)
    {
        MostrarMensagem("Porta " + cor + " aberta!");
        if (somPorta != null) altifalante.PlayOneShot(somPorta);
        
        // NOVA ANIMAÇÃO: Roda a porta 90 graus (como uma porta normal)
        portaObjeto.transform.Rotate(0, 90f, 0); 
        portaObjeto.GetComponent<Collider>().enabled = false;
    }

    void MostrarMensagem(string mensagem)
    {
        if (textoNoEcra != null)
        {
            textoNoEcra.text = mensagem;
            CancelInvoke("ApagarMensagem");
            Invoke("ApagarMensagem", 3f);
        }
    }

    void ApagarMensagem()
    {
        if (textoNoEcra != null) textoNoEcra.text = "";
    }
}