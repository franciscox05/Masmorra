using UnityEngine;
using TMPro;

public class TintaInvisivel : MonoBehaviour
{
    private TextMeshPro texto;
    private Light luzLanterna;
    private Transform camTransform;

    public float distanciaRevelar = 8f;
    public float anguloFoco = 35f;
    public float velocidadeFade = 10f;

    void Start()
    {
        texto = GetComponent<TextMeshPro>();
        camTransform = Camera.main.transform;

        // Procura a luz que está dentro do Player
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            // Procura o componente Light nos filhos do Player
            luzLanterna = player.GetComponentInChildren<Light>();
        }

        // Começa invisível
        if (texto != null) {
            Color c = texto.color;
            c.a = 0f;
            texto.color = c;
        }
    }

    void Update()
{
    if (texto == null || luzLanterna == null || camTransform == null) return;

    float alvoAlpha = 0f;

    if (luzLanterna.enabled && luzLanterna.gameObject.activeInHierarchy)
    {
        float dist = Vector3.Distance(transform.position, camTransform.position);
        Vector3 direcao = (transform.position - camTransform.position).normalized;
        float angulo = Vector3.Angle(camTransform.forward, direcao);

        // Adicionámos uma pequena margem para evitar o piscar nas bordas
        if (dist < distanciaRevelar + 1f && angulo < anguloFoco + 5f)
        {
            alvoAlpha = 1f;
        }
    }

    // Se o alvo for 1, ele sobe. Se for 0, ele desce.
    float novoAlpha = Mathf.MoveTowards(texto.color.a, alvoAlpha, velocidadeFade * Time.deltaTime);
    texto.color = new Color(texto.color.r, texto.color.g, texto.color.b, novoAlpha);
}
}