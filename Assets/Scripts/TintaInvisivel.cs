using UnityEngine;
using TMPro;

public class TintaInvisivel : MonoBehaviour
{
    public Transform lanternaJogador; // O objeto da lanterna para saber a direção
    public Light luzLanterna;         // A luz para saber se está ligada
    private TextMeshPro texto;

    void Start()
    {
        texto = GetComponent<TextMeshPro>();
        // Começa totalmente transparente (invisível)
        texto.color = new Color(texto.color.r, texto.color.g, texto.color.b, 0);
    }

    void Update()
    {
        // Verifica se a lanterna existe e se a luz está ligada no momento
        if (luzLanterna != null && luzLanterna.enabled && luzLanterna.gameObject.activeInHierarchy)
        {
            float distancia = Vector3.Distance(lanternaJogador.position, transform.position);
            Vector3 direcaoParaTexto = (transform.position - lanternaJogador.position).normalized;
            float angulo = Vector3.Angle(lanternaJogador.forward, direcaoParaTexto);

            // Se estiver perto (menos de 7 metros) e dentro do cone de luz (ângulo)
            if (distancia < 7f && angulo < (luzLanterna.spotAngle / 2))
            {
                texto.color = new Color(texto.color.r, texto.color.g, texto.color.b, 1); // Fica visível
            }
            else
            {
                texto.color = new Color(texto.color.r, texto.color.g, texto.color.b, 0); // Fica invisível
            }
        }
        else
        {
            texto.color = new Color(texto.color.r, texto.color.g, texto.color.b, 0);
        }
    }
}