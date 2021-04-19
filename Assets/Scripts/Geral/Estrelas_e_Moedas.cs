using UnityEngine;
using TMPro;

public class Estrelas_e_Moedas : MonoBehaviour
{
    //Variaveis
    private int numMoedas;

    //Moedas
    [SerializeField]
    private TextMeshProUGUI textMoedas;
    //Estrelas de fases normais
    [SerializeField]
    private GameObject[] umaEstrela;
    [SerializeField]
    private GameObject[] duasEstrelas;
    [SerializeField]
    private GameObject[] tresEstrelas;
    //Estrelas de fases 5x5
    [SerializeField]
    private GameObject[] umaEstrela5x5;
    [SerializeField]
    private GameObject[] duasEstrelas5x5;
    [SerializeField]
    private GameObject[] tresEstrelas5x5;
    //Estrelas de fases 8x8
    [SerializeField]
    private GameObject[] umaEstrela8x8;
    [SerializeField]
    private GameObject[] duasEstrelas8x8;
    [SerializeField]
    private GameObject[] tresEstrelas8x8;

    private void Start()
    {
        NumEstrelas();
        NumEstrelas5x5();
        NumEstrelas8x8();

        NumMoedas();
    }

    private void NumEstrelas()
    {
        for (int i = 0; i < umaEstrela.Length; i++)
        {
            if (PlayerPrefs.HasKey("EstrelasFase" + i))
            {
                if (PlayerPrefs.GetInt("EstrelasFase" + i) == 1)
                    umaEstrela[i].SetActive(true);
                else if (PlayerPrefs.GetInt("EstrelasFase" + i) == 2)
                {
                    umaEstrela[i].SetActive(true);
                    duasEstrelas[i].SetActive(true);
                }
                else if (PlayerPrefs.GetInt("EstrelasFase" + i) == 3)
                {
                    umaEstrela[i].SetActive(true);
                    duasEstrelas[i].SetActive(true);
                    tresEstrelas[i].SetActive(true);
                }
                else if (PlayerPrefs.GetInt("EstrelasFase" + i) > 3)
                    PlayerPrefs.SetInt("EstrelasFase" + i, 3);
            }
            else
                PlayerPrefs.SetInt("EstrelasFase" + i, 0);
        }
    }

    private void NumEstrelas5x5()
    {
        for (int i = 0; i < umaEstrela5x5.Length; i++)
        {
            if (PlayerPrefs.HasKey("Estrelas5x5Fase" + i))
            {
                if (PlayerPrefs.GetInt("Estrelas5x5Fase" + i) == 1)
                    umaEstrela5x5[i].SetActive(true);
                else if (PlayerPrefs.GetInt("Estrelas5x5Fase" + i) == 2)
                {
                    umaEstrela5x5[i].SetActive(true);
                    duasEstrelas5x5[i].SetActive(true);
                }
                else if (PlayerPrefs.GetInt("Estrelas5x5Fase" + i) == 3)
                {
                    umaEstrela5x5[i].SetActive(true);
                    duasEstrelas5x5[i].SetActive(true);
                    tresEstrelas5x5[i].SetActive(true);
                }
                else if (PlayerPrefs.GetInt("Estrelas5x5Fase" + i) > 3)
                    PlayerPrefs.SetInt("Estrelas5x5Fase" + i, 3);
            }
            else
                PlayerPrefs.SetInt("Estrelas5x5Fase" + i, 0);
        }
    }

    private void NumEstrelas8x8()
    {
        for (int i = 0; i < umaEstrela8x8.Length; i++)
        {
            if (PlayerPrefs.HasKey("Estrelas8x8Fase" + i))
            {
                if (PlayerPrefs.GetInt("Estrelas8x8Fase" + i) == 1)
                    umaEstrela8x8[i].SetActive(true);
                else if (PlayerPrefs.GetInt("Estrelas8x8Fase" + i) == 2)
                {
                    umaEstrela8x8[i].SetActive(true);
                    duasEstrelas8x8[i].SetActive(true);
                }
                else if (PlayerPrefs.GetInt("Estrelas8x8Fase" + i) == 3)
                {
                    umaEstrela8x8[i].SetActive(true);
                    duasEstrelas8x8[i].SetActive(true);
                    tresEstrelas8x8[i].SetActive(true);
                }
                else if (PlayerPrefs.GetInt("Estrelas8x8Fase" + i) > 3)
                    PlayerPrefs.SetInt("Estrelas8x8Fase" + i, 3);
            }
            else
                PlayerPrefs.SetInt("Estrelas8x8Fase" + i, 0);
        }
    }

    private void NumMoedas()
    {
        if (PlayerPrefs.HasKey("Moedas"))
        {
            numMoedas = PlayerPrefs.GetInt("Moedas");
            if (numMoedas < 0)
            {
                numMoedas = 0;
                PlayerPrefs.SetInt("Moedas", numMoedas);
            }
            else if (numMoedas > 1000)
            {
                numMoedas = 1000;
                PlayerPrefs.SetInt("Moedas", numMoedas);
            }

            textMoedas.text = numMoedas.ToString();
        }
        else
        {
            numMoedas = 0;
            PlayerPrefs.SetInt("Moedas", numMoedas);
            textMoedas.text = numMoedas.ToString();
        }
    }
}
