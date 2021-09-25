using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearManagement : MonoBehaviour{

    GameObject AppManagement;
    AppManagement AppManagementScript;

    // Start is called before the first frame update
    void Start(){
        //Public関数、変数を使うために受け側のオブジェクト情報を取得
        AppManagement = GameObject.Find("AppManagement");
        //受け側のオブジェクトにアタッチされたScript情報を取得
        AppManagementScript = AppManagement.GetComponent<AppManagement>();
        //次LoadSceneされたときのシーン遷移先情報を格納
        AppManagementScript.NextScene = "AppManagement";
    }

    // Update is called once per frame
    void Update(){
        //仮ロジック クリアシーンは大幅に改修予定
        if (Input.GetKeyDown(KeyCode.Space)){
            SceneManager.LoadScene(AppManagementScript.NextScene);
            //AppManagementシーン内で初期化するべき変数は初期化する ※積み残し
        } 
    }
}
