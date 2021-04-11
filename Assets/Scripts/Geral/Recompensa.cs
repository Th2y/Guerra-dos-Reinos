using UnityEngine;
using System;

public class Recompensa : MonoBehaviour
{
    public static Recompensa instancia;

    public int intervaloMinutos = 30;
    public int intervaloSegundos = 0;

    private const string recompensaPP = "Proximo_Tempo_Recompensa";

    private void Awake()
    {
        if (instancia == null)
            instancia = this;
        else
            Destroy(this.gameObject);
    }

    public void ResetTempoRecompensa()
    {
        //O DateTime.Now retorna o horário atual do dispositivo
        //O TimeSpan faz com que a hora atual seja adicionada do tempo que for definido
        DateTime tempo = DateTime.Now.Add(new TimeSpan(0, intervaloMinutos, intervaloSegundos));
        TempoRecompensaLoja(tempo);
    }

    //Faz com que o horário alvo seja salvo
    private void TempoRecompensaLoja(DateTime tempo)
    {
        PlayerPrefs.SetString(recompensaPP, tempo.ToBinary().ToString());
        PlayerPrefs.Save();
    }

    DateTime GetRecompensaTempo()
    {
        string tempoLoja = PlayerPrefs.GetString(recompensaPP, "");

        //Pode pegar a recompensa
        if (tempoLoja.Equals(""))
            return DateTime.Now;
        else
            return DateTime.FromBinary(Convert.ToInt64(tempoLoja));
    }

    public TimeSpan TempoRestanteRecompensa()
    {
        return GetRecompensaTempo().Subtract(DateTime.Now);
    }

    public bool PodePegarRecompensa()
    {
        return TempoRestanteRecompensa() <= TimeSpan.Zero;
    }
}
