using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UserAccess : MonoBehaviour
{
    // public GameObject Pannel;
    // public void EnterPassWord(int UserName)
    // {
    //     Pannel.SetActive(true);
    // }
    public void ChangeScene()
    {
        SceneManager.LoadScene("Supermarket");
    }
}
