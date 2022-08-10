using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HeadScript : MonoBehaviour
{
    public GameObject Tail;
    List<GameObject> Tails;

    Vector3 old_coordinate;
    GameObject old_Tail;

    float speed = 20.0f;

    public GameObject Play_Again;

    

    void Start()
    {
        Tails = new List<GameObject>();

        for (int i = 0; i < 5; i++)
        {
            GameObject new_Tail = Instantiate(Tail, transform.position, Quaternion.identity);
            Tails.Add(new_Tail);
        }

        InvokeRepeating("Move", 0.0f, 0.1f);
    }

    public void Increment_Tail()
    {
        GameObject new_Tail = Instantiate(Tail, transform.position, Quaternion.identity);
        Tails.Add(new_Tail);
    }

    void Move()
    {
        old_coordinate = transform.position;

        transform.Translate(0, 0, speed * Time.deltaTime);

        Tail_Follow();
    }
    
    void Tail_Follow()
    {
        Tails[0].transform.position = old_coordinate;
        old_Tail = Tails[0];
        Tails.RemoveAt(0);
        Tails.Add(old_Tail);
    }

    public void rotate(float angle)
    {
        transform.Rotate(0, angle, 0);

    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Play_Again.SetActive(true);
            Time.timeScale = 0.0f;
       }

        if (other.gameObject.tag == "Tail")
        {
            Play_Again.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void Reload()
    {
        Time.timeScale = 1.0f;

        SceneManager.LoadScene("Snake/Scene/Snake");
    }
    

}
  
