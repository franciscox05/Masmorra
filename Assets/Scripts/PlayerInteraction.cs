using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public float rayDistance = 3f;

    [Header("Inventário (O Bolso)")]
    public List<string> chavesNoBolso = new List<string>();
    public bool temLanternaNoInventario = false; 

    [Header("UI")]
    public TextMeshProUGUI textoNoEcra;
    public GameObject painelTecladoUI;

    [Header("Áudio e Luz")]
    public AudioSource altifalante;
    public AudioClip somChave;
    public AudioClip somPorta;
    public AudioClip somLanterna; 
    public Light luzDaLanterna;

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
                else if (hit.collider.CompareTag("Chave"))
                {
                    chavesNoBolso.Add(nomeObjeto);
                    // MENSAGENS PERSONALIZADAS PARA AS CHAVES
                    string nomeBonito = nomeObjeto.Replace("Chave", "Chave ");
                    MostrarMensagem("Apanhaste a " + nomeBonito + "!");
                    
                    if (somChave != null) altifalante.PlayOneShot(somChave);
                    Destroy(hit.collider.gameObject);
                }
                else if (hit.collider.CompareTag("Porta"))
                {
                    PortaInteligente porta = hit.collider.GetComponent<PortaInteligente>();
                    if (porta != null) porta.TentarAbrir(this);
                }
            }
        }
    }

    public void MostrarMensagem(string mensagem)
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

    public void TocarSomPorta()
    {
        if (somPorta != null) altifalante.PlayOneShot(somPorta);
    }
}