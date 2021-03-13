using UnityEngine;
using UnityEngine.SceneManagement;

public class CarregarFases : MonoBehaviour
{
    [SerializeField]
    private GameObject comprarVidas;

    public void EscolherFase(int fase)
    {
        if (PlayerPrefs.GetInt("vidas") > 0)
            SceneManager.LoadScene("Fase" + fase);
        else
            comprarVidas.SetActive(true);
    }
}
