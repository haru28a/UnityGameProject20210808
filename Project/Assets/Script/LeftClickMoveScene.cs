using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeftClickMoveScene : MonoBehaviour {

    GameObject AppManagement;
    AppManagement AppManagementScript;

    // Start is called before the first frame update
    void Start()
    {
        //Public関数、変数を使うために受け側のオブジェクト情報を取得
        AppManagement = GameObject.Find("AppManagement");
        //受け側のオブジェクトにアタッチされたScript情報を取得
        AppManagementScript = AppManagement.GetComponent<AppManagement>();
    }

    public void MoveScene()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //シーン遷移
            SceneManager.LoadScene(AppManagementScript.NextScene);
        }
    }
}