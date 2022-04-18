using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Apple : MonoBehaviour
{
    public Text write_txt;
    public Text score_txt;

    int score = 0;
    int increment_value = 100;

    void Start()
    {
        InvokeRepeating("control", 0, 5.0f);
    }
    void control()
    {
        float X = Random.Range(-2.0f, -29.0f);
        float Z = Random.Range(2.0f, 32.0f);

        int random = Random.Range(1, 5);
        if (random == 4)
        {
            write_txt.gameObject.SetActive(true);
        }
        else
        {
            write_txt.gameObject.SetActive(false);
        }
        Vector3 coordinate = new Vector3(X, 1, Z);
        transform.position = coordinate;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            CancelInvoke();
            InvokeRepeating("control", 0f, 5.0f);

            if (write_txt.gameObject.activeSelf == true)
            {
                score += (increment_value * 2);
            }
            else
            {
                score += increment_value;
            }
            score_txt.text = "score: " + score;
        }
        if (col.gameObject.tag == "Tail")
        {
            CancelInvoke();
            InvokeRepeating("control", 0f, 5.0f);
        }
    }
}
