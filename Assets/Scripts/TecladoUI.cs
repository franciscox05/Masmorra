using UnityEngine;
using TMPro;

public class TecladoUI : MonoBehaviour
{
    public TextMeshProUGUI visor; 
    
    private string entradaAtual = ""; 
    private Bau bauQueEstamosATentarAbrir; 

    public void AbrirTeclado(Bau bauClicado)
    {
        bauQueEstamosATentarAbrir = bauClicado;
        entradaAtual = "";
        if (visor != null) visor.text = "";
        gameObject.SetActive(true); 
    }

    public void AdicionarNumero(string numero)
    {
        entradaAtual += numero;
        if (visor != null) visor.text = entradaAtual; 
    }

    public void ValidarSenha()
    {
        if (entradaAtual == bauQueEstamosATentarAbrir.senha)
        {
            bauQueEstamosATentarAbrir.AbrirCadeado();
            FecharTeclado(); 
        }
        else
        {
            if (visor != null) visor.text = "ERRO";
            entradaAtual = ""; 
        }
    }

    public void FecharTeclado()
    {
        gameObject.SetActive(false); // Esconde o UI
        
        // Tranca o rato outra vez para voltares a jogar em 1ª pessoa
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}