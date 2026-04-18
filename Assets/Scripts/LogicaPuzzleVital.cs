using UnityEngine;
using TMPro;

public class LogicaPuzzleVital : MonoBehaviour
{
    [Header("Configurações da UI")]
    public TMP_InputField campoEscrita; 
    public GameObject painelDoPuzzle;
    public GameObject mira; 

    [Header("Objeto para Desbloquear")]
    public GameObject correntes; 

    [Header("Configuração de Áudio (Solução Unity 6)")]
    public AudioSource leitorDeSom; // Arraste o componente Audio Source para aqui
    public AudioClip ficheiroDeSom; // Arraste o ficheiro "somCorrentes" da pasta Audio para aqui

    [Header("Controlos do Jogador")]
    public MonoBehaviour scriptMovimento; 
    public MonoBehaviour scriptCamera;

    void Update()
    {
        // Fecha o puzzle se carregar em ESC
        if (painelDoPuzzle.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            FecharPuzzle();
        }
    }

    public void ValidarResposta()
    {
        if (campoEscrita.text.ToUpper() == "VITAL")
        {
            Sucesso();
        }
        else
        {
            campoEscrita.text = ""; 
            campoEscrita.ActivateInputField();
        }
    }

    void Sucesso()
    {
        Debug.Log("Puzzle resolvido!");

        // ESTA É A LINHA MÁGICA:
        // Ela toca o som na posição da câmara, por isso ouves sempre, 
        // mesmo que o painel do puzzle seja fechado logo a seguir!
        if (ficheiroDeSom != null)
        {
            AudioSource.PlayClipAtPoint(ficheiroDeSom, Camera.main.transform.position);
            Debug.Log("Som disparado no espaço 3D!");
        }

        if (correntes != null) 
        {
            correntes.SetActive(false); 
        }

        FecharPuzzle(); // Agora já podes fechar à vontade!
    }

    public void AbrirPuzzle()
    {
        painelDoPuzzle.SetActive(true);
        if (mira != null) mira.SetActive(false);
        if (scriptMovimento != null) scriptMovimento.enabled = false; 
        if (scriptCamera != null) scriptCamera.enabled = false; 

        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true;
        campoEscrita.ActivateInputField(); 
    }

    public void FecharPuzzle()
    {
        painelDoPuzzle.SetActive(false);
        if (mira != null) mira.SetActive(true);
        if (scriptMovimento != null) scriptMovimento.enabled = true; 
        if (scriptCamera != null) scriptCamera.enabled = true; 

        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
    }
}