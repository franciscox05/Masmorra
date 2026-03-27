using UnityEngine;
using TMPro;

public class LogicaKeypad : MonoBehaviour
{
    public TextMeshProUGUI visor; // Onde os números vão aparecer
    public GameObject painelKeypad; // O próprio ecrã para se auto-desligar
    public GameObject portaCofre; // A porta que isto vai abrir

    string codigoIntroduzido = "";
    string codigoCerto = "123"; // O CÓDIGO PARA GANHAR!

    // Estas são as funções que os teus botões vão chamar!
    public void Clicar1() { AdicionarNumero("1"); }
    public void Clicar2() { AdicionarNumero("2"); }
    public void Clicar3() { AdicionarNumero("3"); }

    void AdicionarNumero(string num)
    {
        codigoIntroduzido = codigoIntroduzido + num; // Junta o número
        visor.text = codigoIntroduzido; // Mostra no ecrã
    }

    public void ClicarOK()
    {
        if (codigoIntroduzido == codigoCerto)
        {
            visor.text = "ABERTO!";
            
            // Abre a porta!
            if(portaCofre != null)
            {
                portaCofre.transform.Translate(Vector3.up * 5f);
            }
            
            // Chama a função de fechar o teclado passado 1.5 segundos
            Invoke("FecharTeclado", 1.5f); 
        }
        else
        {
            visor.text = "ERRO!";
            codigoIntroduzido = ""; // Limpa a memória para tentares outra vez
        }
    }

    void FecharTeclado()
    {
        painelKeypad.SetActive(false); // Esconde o teclado
        visor.text = "";
        codigoIntroduzido = "";

        // Tranca o rato outra vez para poderes voltar a jogar o teu FPS!
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}