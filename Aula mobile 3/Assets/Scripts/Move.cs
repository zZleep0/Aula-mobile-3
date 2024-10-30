using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    private float speed = 10;

    [SerializeField] private LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(Input.acceleration.x, 0, Input.acceleration.y) * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Objetivo"))
        {
            levelManager.qntdObjetivo++;
            Destroy(collision.gameObject);
        }
        if (collision.collider.CompareTag("Botao") && levelManager.portao != null)
        {
            Destroy(levelManager.portao);
        }
        if (collision.collider.CompareTag("Chao perigoso"))
        {
            levelManager.GameOver();
        }
    }
}
