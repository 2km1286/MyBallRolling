using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Manager : MonoBehaviour
{
    public int totalItemCount;
    public int stage;
    public int itemCount = 0;
    
    public Text OriginalText;
    public Text NowText;
    private void Awake()
    {
        OriginalText.text = "/ " + totalItemCount;
    }
    public void GetItem(int count)
    {
        NowText.text = count.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
            SceneManager.LoadScene(stage);
    }
}