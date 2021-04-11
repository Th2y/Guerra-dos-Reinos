using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarregarFases : MonoBehaviour
{
    [SerializeField]
    private GameObject comprarVidas;

    [SerializeField]
    private Button[] faseAtual;
    private int numFaseAtual = 0;
    private string nomeDaFase;

    private void Start()
    {
        nomeDaFase = SceneManager.GetActiveScene().name;
        if(nomeDaFase == "Fases")
            Fase();
    }

    //Faz com que o jogo detecte a última fase que o jogador ganhou e deixe o botão da próxima maior
    private void Fase()
    {
        if (PlayerPrefs.HasKey("ProxFase"))
            numFaseAtual = PlayerPrefs.GetInt("ProxFase");
        else
            PlayerPrefs.SetInt("ProxFase", numFaseAtual);

        if (faseAtual[numFaseAtual] != null)
            faseAtual[numFaseAtual].transform.localScale = new Vector3(1.2f, 1.2f, 1);
    }

    public void EscolherFase(int fase)
    {
        if (PlayerPrefs.GetInt("Vidas") > 0)
            SceneManager.LoadScene("Fase" + fase);
        else
            comprarVidas.SetActive(true);
    }

    public void VoltarASelecao()
    {
        SceneManager.LoadScene("Fases");
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene(nomeDaFase);
    }
}
