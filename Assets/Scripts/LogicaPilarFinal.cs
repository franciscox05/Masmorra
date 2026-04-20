using UnityEngine;

public class LogicaPilarFinal : MonoBehaviour
{
    [Header("Sequência")]
    private int[] sequenciaCorreta = { 0, 1, 2, 3 }; 
    private int passoAtual = 0;

    [Header("Recompensa")]
    public GameObject objetoParaAtivar;

    [Header("Ficheiros de Som (.mp3 / .wav)")]
    public AudioClip somClique;   // Aqui vão aparecer os buraquinhos novos!
    public AudioClip somSucesso;
    public AudioClip somErro;

    [Header("O Leitor")]
    public AudioSource fonteAudio; // O componente AudioSource do Pilar

    public void SimboloClicado(int id)
    {
        if (id == sequenciaCorreta[passoAtual])
        {
            passoAtual++;
            // Usamos PlayOneShot para tocar o ficheiro diretamente
            if (fonteAudio != null && somClique != null) 
                fonteAudio.PlayOneShot(somClique);

            if (passoAtual >= sequenciaCorreta.Length)
            {
                Ganhou();
            }
        }
        else
        {
            if (fonteAudio != null && somErro != null) 
                fonteAudio.PlayOneShot(somErro);
            passoAtual = 0;
        }
    }

    void Ganhou()
    {
        if (fonteAudio != null && somSucesso != null) 
            fonteAudio.PlayOneShot(somSucesso);
            
        if (objetoParaAtivar != null) objetoParaAtivar.SetActive(true);
    }
}