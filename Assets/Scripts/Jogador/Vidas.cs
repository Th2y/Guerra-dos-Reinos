using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Vidas : MonoBehaviour
{
    public int vidas = 3;
    private string nomeDaCena;

    [SerializeField]
    private TextMeshProUGUI quantVidas;
    [SerializeField]
    private TextMeshProUGUI tempoProxVida;

    private void Start()
    {
        nomeDaCena = SceneManager.GetActiveScene().name;

        if (!PlayerPrefs.HasKey("Vidas"))
            PlayerPrefs.SetInt("Vidas", vidas);
        else
            vidas = PlayerPrefs.GetInt("Vidas");

        quantVidas.text = vidas.ToString();
    }

    private void Update()
    {
        if (Recompensa.instancia.PodePegarRecompensa())
        {
            GanharVida();
            if (nomeDaCena == "Fases")
                tempoProxVida.gameObject.SetActive(false);
            Recompensa.instancia.ResetTempoRecompensa();
        }
        else
        {
            if(vidas < 5)
            {
                TimeSpan tempoRecompensa = Recompensa.instancia.TempoRestanteRecompensa();
                if(nomeDaCena == "Fases")
                {
                    tempoProxVida.gameObject.SetActive(true);
                    tempoProxVida.text = string.Format("{00:00}:{01:00}", tempoRecompensa.Minutes, tempoRecompensa.Seconds);
                }
            }else if (nomeDaCena == "Fases")
                tempoProxVida.gameObject.SetActive(false);
        }
    }

    public void PerderVida()
    {
        if(vidas > 0)
        {
            vidas--;
            PlayerPrefs.SetInt("Vidas", vidas);
            quantVidas.text = vidas.ToString();
        }
    }

    public void GanharVida()
    {
        if(vidas < 5)
        {
            vidas++;
            PlayerPrefs.SetInt("Vidas", vidas);
            quantVidas.text = vidas.ToString();
        }
    }

    public void ComprarVida(int quant)
    {
        vidas++;
        PlayerPrefs.SetInt("Vidas", vidas);
        quantVidas.text = vidas.ToString();
    }
}