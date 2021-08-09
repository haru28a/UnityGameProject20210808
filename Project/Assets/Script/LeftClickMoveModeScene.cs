using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeftClickMoveModeScene : MonoBehaviour
{
    public void MoveSceneMode()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //モード選択画面へ遷移
            SceneManager.LoadScene("Mode");
        }
    }
}