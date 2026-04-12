using UnityEngine;
using TMPro;

public class LogicaKeypad : MonoBehaviour
{
    [Header("Configurações do Cofre")]
    public string codigoCorreto = "123"; 
    private string inputAtual = "";
    
    [Header("Referências da UI")]
    public TextMeshProUGUI textoDisplay; 
    public GameObject painelTeclado; // NOVO: Para a mira não desaparecer!
    
    [Header("Referências do Mundo 3D")]
    public GameObject tampaDoBau; 

    public void AdicionarNumero(string numeroClicado)
    {
        if (inputAtual.Length < codigoCorreto.Length)
        {
            inputAtual += numeroClicado;
            AtualizarDisplay();
        }
    }

    public void ConfirmarCodigo()
    {
        if (inputAtual == codigoCorreto)
        {
            Debug.Log("Código Correto! O baú abriu!");
            if (textoDisplay != null) textoDisplay.text = "Aberto";
            
            // Abre a tampa do baú
            if (tampaDoBau != null)
            {
                tampaDoBau.transform.Rotate(-80f, 0f, 0f);
                Collider col = tampaDoBau.GetComponent<Collider>();
                if (col != null) col.enabled = false;
            }

            // Esconde SÓ o teclado (a mira fica viva) e tranca o rato
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            if (painelTeclado != null) painelTeclado.SetActive(false); 
        }
        else
        {
            Debug.Log("Código Errado!");
            if (textoDisplay != null) textoDisplay.text = "Erro";
            Invoke("LimparInput", 1f);
        }
    }

    public void LimparInput()
    {
        inputAtual = "";
        AtualizarDisplay();
    }

    private void AtualizarDisplay()
    {
        if (textoDisplay != null) textoDisplay.text = inputAtual;
    }
    
    public void FecharTeclado()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (painelTeclado != null) painelTeclado.SetActive(false);
    }




}