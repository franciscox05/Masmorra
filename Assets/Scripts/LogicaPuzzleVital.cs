using UnityEngine;
using TMPro;

public class LogicaPuzzleVital : MonoBehaviour
{
    public TMP_InputField campoEscrita; 
    public GameObject painelDoPuzzle;
    public GameObject correntes; 

    [Header("Controlos do Jogador")]
    public MonoBehaviour scriptMovimento; 
    public MonoBehaviour scriptCamera; // Aqui é onde está a tua Main Camera

    void Update()
    {
        // Se carregar em ESC enquanto o puzzle está aberto, ele fecha
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
        }
    }

    void Sucesso()
    {
        correntes.SetActive(false); 
        FecharPuzzle();
    }

    public void AbrirPuzzle()
    {
        painelDoPuzzle.SetActive(true);
        if (scriptMovimento != null) scriptMovimento.enabled = false; 
        if (scriptCamera != null) scriptCamera.enabled = false; 

        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true;
        campoEscrita.ActivateInputField(); 
    }

    public void FecharPuzzle()
    {
        painelDoPuzzle.SetActive(false);
        if (scriptMovimento != null) scriptMovimento.enabled = true; 
        if (scriptCamera != null) scriptCamera.enabled = true; 

        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
    }
}