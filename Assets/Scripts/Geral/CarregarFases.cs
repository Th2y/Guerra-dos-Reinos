using UnityEngine;
using UnityEngine.SceneManagement;

public class CarregarFases : MonoBehaviour
{
    public void EscolherFase(int fase)
    {
        if (PlayerPrefs.GetInt("vidas") > 0)
            SceneManager.LoadScene("Fase" + fase);
        else
            Debug.Log("O jogador não possui vidas suficientes");
    }
}
