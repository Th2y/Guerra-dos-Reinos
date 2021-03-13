using UnityEngine;
using TMPro;

public class Vidas : MonoBehaviour
{
    public int vidas = 3;

    [SerializeField]
    private TextMeshProUGUI quantVidas;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Vidas"))
            PlayerPrefs.SetInt("Vidas", vidas);
        else
            vidas = PlayerPrefs.GetInt("Vidas");

        quantVidas.text = vidas.ToString();
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