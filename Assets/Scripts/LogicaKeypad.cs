using UnityEngine;
using TMPro;

public class LogicaKeypad : MonoBehaviour
{
    [Header("Configurações do Cofre")]
    public string codigoCorreto = "4791"; // Mudei para o teu código da sala escura!
    private string inputAtual = "";
    private int limiteDigitos = 10; // NOVO: Limite de 10 dígitos
    
    [Header("Referências da UI")]
    public TextMeshProUGUI textoDisplay; 
    public GameObject painelTeclado; 
    
    [Header("Referências do Mundo 3D")]
    public GameObject tampaDoBau; 
    public GameObject chaveK4; // NOVO: A chave que vai aparecer
    public PlayerInteraction jogador; // NOVO: Para podermos enviar o aviso para o ecrã

    void Start()
    {
        // Garante que a chave começa escondida
        if (chaveK4 != null) chaveK4.SetActive(false);
    }

    public void AdicionarNumero(string numeroClicado)
    {
        // NOVO: Verifica se ainda não passou dos 10 dígitos
        if (inputAtual.Length < limiteDigitos)
        {
            inputAtual += numeroClicado;
            AtualizarDisplay();
        }
    }

    public void ConfirmarCodigo()
    {
        if (inputAtual == codigoCorreto)
        {
            if (textoDisplay != null) textoDisplay.text = "Aberto";
            
            // NOVO: Usa o script do jogador para avisar no ecrã principal
            if (jogador != null) jogador.MostrarMensagem("Código Correto! O baú abriu.");
            
            // Abre a tampa do baú (Tua animação original!)
            if (tampaDoBau != null)
            {
                tampaDoBau.transform.Rotate(-80f, 0f, 0f);
                Collider col = tampaDoBau.GetComponent<Collider>();
                if (col != null) col.enabled = false;
            }

            // NOVO: Faz a Chave K4 aparecer
            if (chaveK4 != null) chaveK4.SetActive(true);

            // Esconde o teclado e tranca o rato
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            if (painelTeclado != null) painelTeclado.SetActive(false); 
        }
        else
        {
            if (textoDisplay != null) textoDisplay.text = "Erro";
            if (jogador != null) jogador.MostrarMensagem("Código Errado!");
            Invoke("LimparInput", 1f); // Espera 1 segundo e limpa o ecrã
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