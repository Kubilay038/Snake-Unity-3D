using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    public GameObject Tail;
    List<GameObject> tails;
    Vector3 old_position;
    GameObject out_tail;
    public float speed;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Apple")
        {
            GameObject new_tail = Instantiate(Tail, old_position, Quaternion.identity);
            tails.Add(new_tail);
        }
        if (col.gameObject.tag == "" || col.gameObject.tag == "Wall") //wall is not collider
        {
            SceneManager.LoadScene("Scenes/SampleScene");
        }
    }
    void Start()
    {
        tails = new List<GameObject>();

        for (int i = 0; i <= 5 ; i++)
        {
            GameObject new_tail = Instantiate(Tail, old_position, Quaternion.identity);
            tails.Add(new_tail);
        }
        InvokeRepeating("Movement", 0, 0.1f);
    }

    void Movement()
    {
        old_position = transform.position;
        transform.Translate(0, 0, speed * Time.deltaTime);

        if (tails.Count>0)
        {
            tails[0].transform.position = old_position;

            out_tail = tails[0];
            tails.RemoveAt(0);
            tails.Add(out_tail);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Rotate(0, 90, 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -90, 0);
        }
    }
}
