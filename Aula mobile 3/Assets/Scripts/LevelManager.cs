using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timer;
    [SerializeField] private float tempo = 30;
    private bool pararTempo = false;

    public int qntdObjetivo = 0;
    [SerializeField] public GameObject portao;

    [SerializeField] GameObject pnlGameOver;
    [SerializeField] GameObject pnlVitoria;

    [SerializeField] private SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        soundManager = GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer != null && tempo != 0 && pararTempo == false)
        {
            tempo -= Time.deltaTime;
        }
        
        timer.text = tempo.ToString("F2");

        Fase1();
    }

    private void Fase1()
    {
        if (qntdObjetivo == 5)
        {
            Vitoria();
            Debug.Log("Acabou o nivel");
        }

        else if (tempo <= 0)
        {
            tempo = 0;
            GameOver();
        }
    }

    public void Vitoria()
    {
        soundManager.PlaySound(SoundManager.SoundType.TypeVictory);
        pnlVitoria.SetActive(true);
        pararTempo = true;
    }

    public void GameOver()
    {
        soundManager.PlaySound(SoundManager.SoundType.TypeGameOver);
        pnlGameOver.SetActive(true);
        pararTempo = true;
    }
}
