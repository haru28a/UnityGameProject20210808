using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeftClickMoveScene : MonoBehaviour {

    GameObject AppManagement;
    AppManagement AppManagementScript;

    // Start is called before the first frame update
    void Start(){
        //Public関数、変数を使うために受け側のオブジェクト情報を取得
        AppManagement = GameObject.Find("AppManagement");
        //受け側のオブジェクトにアタッチされたScript情報を取得
        AppManagementScript = AppManagement.GetComponent<AppManagement>();
    }

    public void LevelSelect(){
        //マウス想定の操作になってるのでキーボード操作想定のロジックに作り直し※積み残し
        if (Input.GetMouseButtonDown(0)){
            if(AppManagementScript.QuestionSelectSW == true){
                //問題ジャンル選択ロジック 問題選択の際はシーン遷移ロジックは無効にし、選択された問題情報を格納する※積み残し
                //オブジェクト名をAppManagementの変数に格納するロジックを作れば解決？

                //AppManagementの難易度選択判定を有効に切り替える
                AppManagementScript.LevelSelectSW = true;

                //遷移ロジックを有効切り替えをゲーム進行に影響でない程度に遅延させる 遅延させないとバグる
                Invoke("MoveSceneDelay", 0.01f);
            }
        }
    }

    void MoveSceneDelay(){
        //AppManagementの問題ジャンル選択判定を無効に切り替える
        AppManagementScript.QuestionSelectSW = false;
    }

    public void MoveScene(){   
        //マウス想定の操作になってるのでキーボード操作想定のロジックに作り直し※積み残し
            if (Input.GetMouseButtonDown(0)){
                if(AppManagementScript.QuestionSelectSW == false){
                    //シーン遷移
                    SceneManager.LoadScene(AppManagementScript.NextScene);
            }
        }
    }
}