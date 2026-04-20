using UnityEngine;

public class InteracaoSimbolo : MonoBehaviour
{
    public int meuId; // Vais definir 0, 1, 2 ou 3 no Inspector
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