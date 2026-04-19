using UnityEngine;

public class DadosBau : MonoBehaviour
{
    public string senhaCorreta;
    public GameObject tampaBau;

    public void Abrir()
    {
        if (tampaBau != null)
        {
            tampaBau.transform.Rotate(-80f, 0f, 0f);
        }
    }
}
