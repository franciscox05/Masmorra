using UnityEngine;

public class Bau : MonoBehaviour
{
    public string senha = "123"; 
    public TecladoUI teclado; 
    private Animator animatorDoBau; // Nova variável para a animação

    void Start()
    {
        // Encontra o Animator assim que o jogo começa
        animatorDoBau = GetComponent<Animator>();
    }

    void OnMouseDown()
    {
        if (teclado != null)
        {
            teclado.AbrirTeclado(this); 
        }
    }

    public void AbrirCadeado()
    {
        if (animatorDoBau != null)
        {
            animatorDoBau.SetTrigger("Abrir");
        }
        else
        {
            Debug.LogWarning("O Baú não tem componente Animator!");
        }
    }
}