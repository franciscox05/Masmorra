using TMPro;
using UnityEngine;

public class ControladorTeclado : MonoBehaviour
{
    private DadosBau bauAtual;
    private string inputAtual = string.Empty;
    private bool inputBloqueado;

    public string textoPlaceholder = "----";
    public TextMeshProUGUI visor;
    public GameObject painelUI;

    public void PrepararTeclado(DadosBau novoBau)
    {
        CancelInvoke(nameof(FinalizarCodigoCorreto));
        CancelInvoke(nameof(ReporPlaceholderDepoisDeErro));
        bauAtual = novoBau;
        inputBloqueado = false;
        LimparInput();

        if (painelUI != null)
        {
            painelUI.SetActive(true);
        }
    }

    public void PremirBotao(string numero)
    {
        if (inputBloqueado || string.IsNullOrEmpty(numero))
        {
            return;
        }

        if (string.IsNullOrEmpty(inputAtual))
        {
            inputAtual = numero;
        }
        else
        {
            inputAtual += numero;
        }

        AtualizarVisor();
    }

    public void Confirmar()
    {
        if (inputBloqueado || bauAtual == null)
        {
            return;
        }

        inputBloqueado = true;

        if (inputAtual == bauAtual.senhaCorreta)
        {
            if (visor != null)
            {
                visor.text = "CORRETO";
            }

            Invoke(nameof(FinalizarCodigoCorreto), 0.8f);
        }
        else
        {
            if (visor != null)
            {
                visor.text = "ERRO";
            }

            Invoke(nameof(ReporPlaceholderDepoisDeErro), 1f);
        }
    }

    public void Sair()
    {
        if (inputBloqueado)
        {
            return;
        }

        CancelInvoke(nameof(FinalizarCodigoCorreto));
        CancelInvoke(nameof(ReporPlaceholderDepoisDeErro));
        LimparInput();
        FecharPainelETrancarRato();
    }

    private void FecharPainelETrancarRato()
    {
        if (painelUI != null)
        {
            painelUI.SetActive(false);
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void AtualizarVisor()
    {
        if (visor != null)
        {
            visor.text = string.IsNullOrEmpty(inputAtual) ? textoPlaceholder : inputAtual;
        }
    }

    private void LimparInput()
    {
        inputAtual = string.Empty;
        AtualizarVisor();
    }

    private void FinalizarCodigoCorreto()
    {
        inputBloqueado = false;
        bauAtual.Abrir();
        LimparInput();
        FecharPainelETrancarRato();
    }

    private void ReporPlaceholderDepoisDeErro()
    {
        inputBloqueado = false;
        LimparInput();
    }
}
