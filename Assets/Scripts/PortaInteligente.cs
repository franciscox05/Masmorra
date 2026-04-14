using UnityEngine;

public class PortaInteligente : MonoBehaviour
{
    public string nomeDaChaveNecessaria; 
    private bool estaAberta = false;

    [Header("Final do Jogo")]
    public bool eA_UltimaPorta = false; // Ligar isto SÓ na porta final!
    public GerenteVitoria gerenteVitoria; // Ligar ao objeto VitoriaManager

    public void TentarAbrir(PlayerInteraction jogador)
    {
        if (estaAberta) return; 

        string corDaPorta = gameObject.name.Replace("Porta", "");

        if (jogador.chavesNoBolso.Contains(nomeDaChaveNecessaria))
        {
            jogador.MostrarMensagem("Porta " + corDaPorta + " aberta!");
            jogador.TocarSomPorta(); 
            estaAberta = true;
            
            transform.Rotate(0, 90f, 0); 
            GetComponent<Collider>().enabled = false;

            // LÓGICA DE VITÓRIA (O que faltava!)
            if (eA_UltimaPorta && gerenteVitoria != null)
            {
                gerenteVitoria.FinalizarJogo(); // Avisa o Gerente para parar o tempo e mostrar o Score!
            }
        }
        else
        {
            string nomeDaChaveBonito = nomeDaChaveNecessaria.Replace("Chave", "Chave ");
            jogador.MostrarMensagem("Precisas da " + nomeDaChaveBonito + "!");
        }
    }
}