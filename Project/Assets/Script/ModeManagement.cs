using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeManagement : MonoBehaviour {

    GameObject Easy;
    GameObject Basic;
    GameObject Hard;
    GameObject AppManagement;
    AppManagement AppManagementScript;

    // Start is called before the first frame update
    void Start()
    {
        //Public関数、変数を使うために受け側のオブジェクト情報を取得
        AppManagement = GameObject.Find("AppManagement");
        Easy = GameObject.Find("Easy");
        Basic = GameObject.Find("Basic");
        Hard = GameObject.Find("Hard");
        //受け側のオブジェクトにアタッチされたScript情報を取得
        AppManagementScript = AppManagement.GetComponent<AppManagement>();
        //次LoadSceneされたときのシーン遷移先情報を格納
        AppManagementScript.NextScene = "Main";
    }

    // Update is called once per frame
    void Update()
    {
        //右クリックでモード選択画面へ遷移
        Easy.GetComponent<LeftClickMoveScene>().MoveScene();
        Basic.GetComponent<LeftClickMoveScene>().MoveScene();
        Hard.GetComponent<LeftClickMoveScene>().MoveScene();
        
        //各難易度の判定ロジックを考える
        //難易度毎にシーンを分けるのか、ステータスを持たせて一つのシーンで切り替えるのか
    }
}
