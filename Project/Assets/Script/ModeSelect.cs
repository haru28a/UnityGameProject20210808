using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSelect : MonoBehaviour
{

    private bool ModeSelectDelayFlg = false;
    private bool ModeSelectLeft = false;
    private bool ModeSelectRight = false;
    GameObject AppManagement;
    AppManagement AppManagementScript;

    // Start is called before the first frame update
    void Start(){
        //Public関数、変数を使うために受け側のオブジェクト情報を取得
        AppManagement = GameObject.Find("AppManagement");
        //受け側のオブジェクトにアタッチされたScript情報を取得
        AppManagementScript = AppManagement.GetComponent<AppManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(AppManagementScript.ModeSelectNum); //デバッグ用 積み残し対応終わったら消す
        if(ModeSelectDelayFlg == false){
        //左に移動
        //ガード処理を追加する ※積み残し
            if (Input.GetKey (KeyCode.LeftArrow)) {
                this.transform.Translate (-30.0f,0.0f,0.0f);
                ModeSelectDelayFlg = true;
                ModeSelectLeft = true;
            }
        //右に移動
        //ガード処理を追加する ※積み残し
            if (Input.GetKey (KeyCode.RightArrow)) {
                this.transform.Translate (30.0f,0.0f,0.0f);
                ModeSelectDelayFlg = true;
                ModeSelectRight = true;
            }
        //問題選択と難易度選択判定
        //ガード処理を追加する ※積み残し
            if (ModeSelectLeft == true){
                AppManagementScript.ModeSelectNum = AppManagementScript.ModeSelectNum - 1;
                AppManagementScript.LevelSelectNum = AppManagementScript.LevelSelectNum - 1;
                ModeSelectLeft = false;
            }

            if (ModeSelectRight == true){
                AppManagementScript.ModeSelectNum = AppManagementScript.ModeSelectNum + 1;
                AppManagementScript.LevelSelectNum = AppManagementScript.LevelSelectNum + 1;
                ModeSelectRight = false;
            }

            if (ModeSelectDelayFlg == true){
                Invoke("ModeSelectDelay", 0.3f);
            }
        }
    }

    void ModeSelectDelay(){
        ModeSelectDelayFlg = false;
    }
}