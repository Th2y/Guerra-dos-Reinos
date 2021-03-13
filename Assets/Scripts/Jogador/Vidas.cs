using UnityEngine;
using TMPro;

public class Vidas : MonoBehaviour
{
    public int vidas = 3;

    [SerializeField]
    private TextMeshProUGUI quantVidas;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("vidas"))
            PlayerPrefs.SetInt("vidas", vidas);
        else
            vidas = PlayerPrefs.GetInt("vidas");

        quantVidas.text = vidas.ToString();
    }

    public void PerderVida()
    {
        vidas--;
        PlayerPrefs.SetInt("vidas", vidas);
        quantVidas.text = vidas.ToString();
    }

    public void GanharVida()
    {
        vidas++;
        PlayerPrefs.SetInt("vidas", vidas);
        quantVidas.text = vidas.ToString();
    }
}
