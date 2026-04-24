using UnityEngine;

public class InteracaoSimbolo : MonoBehaviour
{
    public int meuId; // Definir 0, 1, 2 ou 3
    public LogicaPilarFinal scriptPilar;

    // Esta função deteta o clique do rato (funciona devido ao Mesh Collider)
    void OnMouseDown()
    {
        if (scriptPilar != null)
        {
            scriptPilar.SimboloClicado(meuId);
        }
    }
}