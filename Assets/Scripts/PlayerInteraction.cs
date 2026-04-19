using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float rayDistance = 3f;

    [Header("Inventario (O Bolso)")]
    public List<string> chavesNoBolso = new List<string>();
    public bool temLanternaNoInventario = false;

    [Header("UI - Teclados")]
    public GameObject painelTecladoUI;
    public GameObject painelTecladoUI2;
    public ControladorTeclado controladorTeclado;

    [Header("UI - Geral")]
    public TextMeshProUGUI textoNoEcra;

    [Header("Audio e Luz")]
    public AudioSource altifalante;
    public AudioClip somChave;
    public AudioClip somPorta;
    public AudioClip somLanterna;
    public Light luzDaLanterna;

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
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (temLanternaNoInventario && luzDaLanterna != null)
            {
                luzDaLanterna.enabled = !luzDaLanterna.enabled;

                if (somLanterna != null)
                {
                    altifalante.PlayOneShot(somLanterna);
                }
            }
            else if (!temLanternaNoInventario)
            {
                MostrarMensagem("Ainda nao tens uma lanterna!");
            }
        }

        bool teclado1Ativo = painelTecladoUI != null && painelTecladoUI.activeSelf;
        bool teclado2Ativo = painelTecladoUI2 != null && painelTecladoUI2.activeSelf;
        bool tecladoBauAtivo = controladorTeclado != null &&
                               controladorTeclado.painelUI != null &&
                               controladorTeclado.painelUI.activeSelf;

        if (teclado1Ativo || teclado2Ativo || tecladoBauAtivo)
        {
            return;
        }

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance) && Input.GetKeyDown(KeyCode.E))
        {
            DadosBau dadosBau = hit.collider.GetComponent<DadosBau>();

            if (dadosBau == null)
            {
                dadosBau = hit.collider.GetComponentInParent<DadosBau>();
            }

            if (dadosBau != null)
            {
                InteragirComBau(dadosBau);
                return;
            }

            string nomeObjeto = hit.collider.gameObject.name;

            if (nomeObjeto == "PainelParede")
            {
                AtivarTeclado(painelTecladoUI);
            }
            else if (nomeObjeto == "Bau_2")
            {
                AtivarTeclado(painelTecladoUI2);
            }
            else if (nomeObjeto == "LanternaFisica")
            {
                temLanternaNoInventario = true;
                MostrarMensagem("Apanhaste a Lanterna! Prime [F].");

                if (somLanterna != null)
                {
                    altifalante.PlayOneShot(somLanterna);
                }

                Destroy(hit.collider.gameObject);
            }
            else if (hit.collider.CompareTag("Chave"))
            {
                chavesNoBolso.Add(nomeObjeto);
                MostrarMensagem("Apanhaste uma chave!");

                if (somChave != null)
                {
                    altifalante.PlayOneShot(somChave);
                }

                Destroy(hit.collider.gameObject);
            }
            else if (hit.collider.CompareTag("Porta"))
            {
                PortaInteligente porta = hit.collider.GetComponent<PortaInteligente>();

                if (porta != null)
                {
                    porta.TentarAbrir(this);
                }
            }
        }
    }

    void InteragirComBau(DadosBau bau)
    {
        if (bau == null || controladorTeclado == null)
        {
            return;
        }

        controladorTeclado.PrepararTeclado(bau);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void AtivarTeclado(GameObject teclado)
    {
        if (teclado != null)
        {
            teclado.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
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
        if (textoNoEcra != null)
        {
            textoNoEcra.text = "";
        }
    }

    public void TocarSomPorta()
    {
        if (somPorta != null)
        {
            altifalante.PlayOneShot(somPorta);
        }
    }
}
