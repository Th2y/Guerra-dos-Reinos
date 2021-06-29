using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Estrelas_e_Moedas : MonoBehaviour
{
    //Variaveis
    [Header("Variaveis")]
    private int numMoedas;
    private string nomeDaCena;
    private string[] nomeDaCenaSplit;
    private int numFaseAtual;
    public EnumDificuldade dificuldade = EnumDificuldade.facil;

    //Moedas
    [Header ("Moedas")]
    [SerializeField]
    private TextMeshProUGUI textMoedas;

    //Estrelas de fases normais
    [Header("Estrelas de fases normais")]
    [SerializeField]
    private GameObject[] umaEstrela;
    [SerializeField]
    private GameObject[] duasEstrelas;
    [SerializeField]
    private GameObject[] tresEstrelas;

    //Estrelas de fases 5x5
    [Header("Estrelas de fases 5x5")]
    [SerializeField]
    private GameObject[] umaEstrela5x5;
    [SerializeField]
    private GameObject[] duasEstrelas5x5;
    [SerializeField]
    private GameObject[] tresEstrelas5x5;

    //Estrelas de fases 8x8
    [Header("Estrelas de fases 8x8")]
    [SerializeField]
    private GameObject[] umaEstrela8x8;
    [SerializeField]
    private GameObject[] duasEstrelas8x8;
    [SerializeField]
    private GameObject[] tresEstrelas8x8;

    //Estrelas em cada fase
    [Header("Estrelas em cada fase")]
    [SerializeField]
    private GameObject[] estrelasFase;    

    private void Start()
    {
        nomeDaCena = SceneManager.GetActiveScene().name;

        if (nomeDaCena == "Fases")
            ChamarNumMenu();
        else
        {
            nomeDaCenaSplit = nomeDaCena.Split('e');
            numFaseAtual = int.Parse(nomeDaCenaSplit[1]);
        }
    }

    private void ChamarNumMenu()
    {
        NumEstrelas();
        NumEstrelas5x5();
        NumEstrelas8x8();

        NumMoedas();
    }

    private void NumEstrelas()
    {
        for (int i = 1; i < umaEstrela.Length + 1; i++)
        {
            int j = i - 1;
            if (PlayerPrefs.HasKey("EstrelasFase" + i))
            {
                if (PlayerPrefs.GetInt("EstrelasFase" + i) == 1)
                    umaEstrela[j].SetActive(true);
                else if (PlayerPrefs.GetInt("EstrelasFase" + i) == 2)
                {
                    umaEstrela[j].SetActive(true);
                    duasEstrelas[j].SetActive(true);
                }
                else if (PlayerPrefs.GetInt("EstrelasFase" + i) == 3)
                {
                    umaEstrela[j].SetActive(true);
                    duasEstrelas[j].SetActive(true);
                    tresEstrelas[j].SetActive(true);
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

    public void DefinirEstrelasEMoedas(int num, bool venceu)
    {
        DefinirEstrelas(num);
        DefinirMoedas(num);
        DefinirProxFase(venceu);
    }

    private void DefinirProxFase(bool venceu)
    {
        int proxFase = PlayerPrefs.GetInt("ProxFase");
        if (venceu && numFaseAtual > proxFase)
        {
            PlayerPrefs.SetInt("ProxFase", numFaseAtual);
            Debug.Log("Salvei a prox fase");
        }
    }

    private void DefinirEstrelas(int num)
    {
        for (int i = 0; i < num; i++)
        {
            estrelasFase[i].gameObject.SetActive(true);
        }        
    }

    private void DefinirMoedas(int num)
    {
        numMoedas = PlayerPrefs.GetInt("Moedas");
        if (num == 3)
        {
            if (dificuldade == EnumDificuldade.facil)
                numMoedas += Random.Range(11, 15);
            else if (dificuldade == EnumDificuldade.media)
                numMoedas += Random.Range(13, 18);
            else if (dificuldade == EnumDificuldade.dificil)
                numMoedas += Random.Range(15, 20);
            else
                numMoedas += Random.Range(17, 22);
        }
        else if (num == 2)
        {
            if (dificuldade == EnumDificuldade.facil)
                numMoedas += Random.Range(6, 10);
            else if (dificuldade == EnumDificuldade.media)
                numMoedas += Random.Range(7, 12);
            else if (dificuldade == EnumDificuldade.dificil)
                numMoedas += Random.Range(8, 14);
            else
                numMoedas += Random.Range(9, 16);
        }
        else if (num == 1)
        {
            if (dificuldade == EnumDificuldade.facil)
                numMoedas += Random.Range(2, 5);
            else if (dificuldade == EnumDificuldade.media)
                numMoedas += Random.Range(3, 6);
            else if (dificuldade == EnumDificuldade.dificil)
                numMoedas += Random.Range(4, 7);
            else
                numMoedas += Random.Range(5, 8);
        }

        textMoedas.text = numMoedas.ToString();
        PlayerPrefs.SetInt("Moedas", numMoedas);
    }

    public void MoedaAoPerder()
    {
        numMoedas = PlayerPrefs.GetInt("Moedas");
        PlayerPrefs.SetInt("Moedas", numMoedas++);
    }
}
