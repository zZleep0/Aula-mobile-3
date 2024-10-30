using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paredemovel : MonoBehaviour
{
    [SerializeField] private float velocidade;

    [SerializeField] private Transform atual;
    [SerializeField] private Transform down;
    public bool troca;


    // Start is called before the first frame update
    void Start()
    {
        troca = false;
    }

    // Update is called once per frame
    void Update()
    {
        MovimentoParede();
    }

    void MovimentoParede()
    {
        if (atual != null && down != null)
        {
            switch (troca)
            {
                case true:
                    transform.Translate(new Vector3(0, down.position.y, 0) * Time.deltaTime * velocidade);
                    if (transform.position.y <= down.position.y)
                    {
                        troca = false;
                    }
                    break;

                case false:
                    transform.Translate(new Vector3(0, atual.position.y, 0) * Time.deltaTime * velocidade);
                    if (transform.position.y >= atual.position.y)
                    {
                        troca = true;
                    }
                    break;
            }
        }
    }
}
