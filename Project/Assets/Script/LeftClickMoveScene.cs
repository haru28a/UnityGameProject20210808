using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeftClickMoveScene : MonoBehaviour {
    //Script名のLeftClickを消す ※積み残し

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
        //スペースキーで問題ジャンル決定
        if (Input.GetKeyDown(KeyCode.Space)){
            if(AppManagementScript.QuestionSelectSW == true){
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
        //スペースキーでシーン遷移 ※スペースキー以外での遷移を想定した作りにできていないため積み残し
            if (Input.GetKeyDown(KeyCode.Space)){
                if(AppManagementScript.QuestionSelectSW == false){
                    //シーン遷移
                    SceneManager.LoadScene(AppManagementScript.NextScene);
            }
        }
    }
}