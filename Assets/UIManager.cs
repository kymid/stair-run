using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject WinMenu, LoseMenu;
    [SerializeField] TextMeshProUGUI LoseText;
    [SerializeField] Image bar;

    public void Win()
    {
        WinMenu.SetActive(true); 
    }

    public void Lose()
    {
        LoseMenu.SetActive(true);
        LoseText.text = (int)(bar.fillAmount * 100) + "% Complete";
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
