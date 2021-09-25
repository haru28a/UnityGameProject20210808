using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSelect : MonoBehaviour
{

    private bool ModeSelectDelayFlg = false;
    private bool ModeSelectLeft = false;
    private bool ModeSelectRight = false;
    private bool ModeSelectCamPosReset = true;
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
        //難易度選択ロジックに切り替える際、カメラの座標を初期値にリセットする
        if(AppManagementScript.LevelSelectSW == true){
            if(ModeSelectCamPosReset == true){
                Vector3 pos = this.gameObject.transform.position;
                this.gameObject.transform.position = new Vector3 (pos.x = 0.0f, pos.y, pos.z);
            }
        }

        //Debug.Log(AppManagementScript.ModeSelectNum); //デバッグ用 積み残し対応終わったら消す
        //Debug.Log(AppManagementScript.LevelSelectNum); //デバッグ用 積み残し対応終わったら消す
        if(ModeSelectDelayFlg == false){
        //左に移動
            if (Input.GetKey (KeyCode.LeftArrow)) {
                Vector3 pos = this.gameObject.transform.position;
                if(AppManagementScript.QuestionSelectSW == true){
                    //ガード処理
                    if(pos.x > -60.0f){
		                this.gameObject.transform.position = new Vector3 (pos.x - 30.0f, pos.y, pos.z);
                        ModeSelectLeft = true;
                    }
                }
                if(AppManagementScript.LevelSelectSW == true){
                    //ガード処理
                    if(pos.x > -30.0f){
		                this.gameObject.transform.position = new Vector3 (pos.x - 30.0f, pos.y, pos.z);
                        ModeSelectCamPosReset = false;
                        ModeSelectLeft = true;
                    }
                }
                //this.transform.Translate (-30.0f,0.0f,0.0f); 旧ロジック
                ModeSelectDelayFlg = true;
                //ModeSelectLeft = true; 旧ロジック
            }
        //右に移動
            if (Input.GetKey (KeyCode.RightArrow)) {
                Vector3 pos = this.gameObject.transform.position;
                if(AppManagementScript.QuestionSelectSW == true){
                    //ガード処理
                    if(pos.x < 60.0f){
		                this.gameObject.transform.position = new Vector3 (pos.x + 30.0f, pos.y, pos.z);
                        ModeSelectRight = true;
                    }
                }
                if(AppManagementScript.LevelSelectSW == true){
                    //ガード処理
                    if(pos.x < 30.0f){
		                this.gameObject.transform.position = new Vector3 (pos.x + 30.0f, pos.y, pos.z);
                        ModeSelectCamPosReset = false;
                        ModeSelectRight = true;
                    }
                }
                //this.transform.Translate (30.0f,0.0f,0.0f); 旧ロジック
                ModeSelectDelayFlg = true;
                //ModeSelectRight = true; 旧ロジック
            }
        //問題選択と難易度選択判定
        //ガード処理によりガードされた場合は使わない
            if (ModeSelectLeft == true){
                if(AppManagementScript.QuestionSelectSW == true){
                    AppManagementScript.ModeSelectNum = AppManagementScript.ModeSelectNum - 1;
                }
                if(AppManagementScript.LevelSelectSW == true){
                    AppManagementScript.LevelSelectNum = AppManagementScript.LevelSelectNum - 1;
                }
                ModeSelectLeft = false;
            }

            if (ModeSelectRight == true){
                if(AppManagementScript.QuestionSelectSW == true){
                    AppManagementScript.ModeSelectNum = AppManagementScript.ModeSelectNum + 1;
                }
                if(AppManagementScript.LevelSelectSW == true){
                    AppManagementScript.LevelSelectNum = AppManagementScript.LevelSelectNum + 1;
                }
                ModeSelectRight = false;
            }

            if (ModeSelectDelayFlg == true){
                //遅延ロジック
                //連続入力を受け付けないように一定時間処理を止める
                Invoke("ModeSelectDelay", 0.3f);
            }
        }
    }

    void ModeSelectDelay(){
        ModeSelectDelayFlg = false;
    }
}