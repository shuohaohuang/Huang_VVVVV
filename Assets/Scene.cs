using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("cfcc");
        SceneManager.LoadScene("w");

        if (collision == MainCharacter.instance)
        if (collision == MainCharacter.instance)
        {
            Debug.Log("cfcc");

        }
    }
}
