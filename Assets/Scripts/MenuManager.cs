using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void OnStartClick()
    {
        Debug.Log("START CLICK");
        SceneManager.LoadScene("SampleScene");
    }
}
