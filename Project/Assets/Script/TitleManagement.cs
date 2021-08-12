using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManagement : MonoBehaviour {

    GameObject FullScreen;
    GameObject AppManagement;
    AppManagement AppManagementScript;

    // Start is called before the first frame update
    void Start()
    {
        //Public関数、変数を使うために受け側のオブジェクト情報を取得
        FullScreen = GameObject.Find("FullScreen");
        AppManagement = GameObject.Find("AppManagement");
        //受け側のオブジェクトにアタッチされたScript情報を取得
        AppManagementScript = AppManagement.GetComponent<AppManagement>();
        //次LoadSceneされたときのシーン遷移先情報を格納
        AppManagementScript.NextScene = "Mode";
    }

    // Update is called once per frame
    void Update()
    {
        //左クリックでモード選択画面へ遷移
        //マウス想定の操作になってるのでキーボード操作想定のロジックに作り直し※積み残し
        FullScreen.GetComponent<LeftClickMoveScene>().MoveScene();
    }
}
