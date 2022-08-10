using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AppleScript : MonoBehaviour
{
   
    
    
    public TMPro.TextMeshProUGUI Score_txt;
    int Score = 0;

    HeadScript Create_Tail;

    

    private void Start()
    {
        Create_Tail = GameObject.Find("Head").GetComponent<HeadScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Head")
        {
            Score += 10;
            Score_txt.text = "SCORE " + Score;

            change_coordinate();

            Create_Tail.Increment_Tail();
        }

        if (other.gameObject.tag == "Tail")
        {
            change_coordinate();
        }
       
    }

    void change_coordinate()
    {
        float x_value = Random.Range(1.75f, -4.1f);
        float z_value = Random.Range(18.99f, 24.784f);
        

        transform.position = new Vector3(x_value, 2.18f, z_value);
    }

   
}
