using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class MainManagement : MonoBehaviour {

    GameObject MainInitialGUI;
    GameObject QuestionGUI;
    GameObject AppManagement;
    GameObject AnswerGUI;
    GameObject EnterGUI;
    AppManagement AppManagementScript;
    private int MainQuestionStart = 0;
    private bool MainDelayFlg = false;
    public InputField inputField;
    //　読み込んだテキストを出力するUIテキスト
	[SerializeField]
	private Text dataText;
	//　読む込むテキストが書き込まれている.txtファイル
	[SerializeField]
	private TextAsset textAsset1;
    [SerializeField]
    private TextAsset textAsset2;
    [SerializeField]
    private TextAsset textAsset3;
    [SerializeField]
    private TextAsset textAsset4;
    [SerializeField]
    private TextAsset textAsset5;
    [SerializeField]
    private TextAsset textAsset6;
    [SerializeField]
    private TextAsset textAsset7;
    [SerializeField]
    private TextAsset textAsset8;
    [SerializeField]
    private TextAsset textAsset9;
    [SerializeField]
    private TextAsset textAsset10;
	//　テキストファイルから読み込んだデータ
	private string loadText1;
    private string loadText2;
    private string loadText3;
    private string loadText4;
    private string loadText5;
    private string loadText6;
    private string loadText7;
    private string loadText8;
    private string loadText9;
    private string loadText10;

    // Start is called before the first frame update
    void Start() {
        //読み込んだテキストを格納する
        loadText1 = textAsset1.text;
        loadText2 = textAsset2.text;
        loadText3 = textAsset3.text;
        loadText4 = textAsset4.text;
        loadText5 = textAsset5.text;
        loadText6 = textAsset6.text;
        loadText7 = textAsset7.text;
        loadText8 = textAsset8.text;
        loadText9 = textAsset9.text;
        loadText10 = textAsset10.text;

        //Public関数、変数を使うために受け側のオブジェクト情報を取得
        AppManagement = GameObject.Find("AppManagement");
        MainInitialGUI = GameObject.Find("MainInitialGUI");
        QuestionGUI = GameObject.Find("QuestionGUI");
        AnswerGUI = GameObject.Find("AnswerGUI");
        EnterGUI = GameObject.Find("EnterGUI");
        
        //受け側のオブジェクトにアタッチされたScript情報を取得
        AppManagementScript = AppManagement.GetComponent<AppManagement>();

        //Mainシーン読み込み初回タイミングで注意書きを表示する
        MainInitialGUI.SetActive (true);

        //それ以外は非表示にする
        QuestionGUI.SetActive (false);
        AnswerGUI.SetActive (false);
        EnterGUI.SetActive (false);
        MainQuestionStart = 0;

        inputField = inputField.GetComponent<InputField> ();

        //次LoadSceneされたときのシーン遷移先情報を格納
        AppManagementScript.NextScene = "Clear";
    }

    // Update is called once per frame
    void Update() {
        //スペースキー入力
        if (Input.GetKeyDown(KeyCode.Space)){
            //注意書き非表示
            MainInitialGUI.SetActive (false);
            //問題表示
            QuestionGUI.SetActive (true);
            AnswerGUI.SetActive (true);
            EnterGUI.SetActive (true);
            MainQuestionStart = 1;
        }
        //テスト用 問題 国語 難易度 簡単 ※下記ロジックをベースに他問題ジャンル用も作成 積み残し
        if (AppManagementScript.ModeSelectNum == 3 && AppManagementScript.LevelSelectNum == 1){
            //Debug.Log(MainQuestionStart);
            //while (MainQuestionStart < 10){ //旧ロジック
                if (MainQuestionStart == 1){
                    dataText.text = loadText1;
                    if (Input.GetKeyDown(KeyCode.Return)){
                            FileStream f = new FileStream("Assets/text/Answer1.txt", FileMode.Create, FileAccess.Write);
                            BinaryWriter writer = new BinaryWriter(f);
                            writer.Write(inputField.text);
                            writer.Close();
                            inputField.text = "";
                            MainDelayFlg = true;
                            if (MainDelayFlg == true){
                                //遅延ロジック
                                //連続入力を受け付けないように一定時間処理を止める
                                Invoke("MainDelay", 0.1f);
                        }
                    }
                }
                if (MainQuestionStart == 2){
                    dataText.text = loadText2;
                    if (Input.GetKeyDown(KeyCode.Return)){
                            FileStream f = new FileStream("Assets/text/Answer2.txt", FileMode.Create, FileAccess.Write);
                            BinaryWriter writer = new BinaryWriter(f);
                            writer.Write(inputField.text);
                            writer.Close();
                            inputField.text = "";
                            MainDelayFlg = true;
                            if (MainDelayFlg == true){
                                //遅延ロジック
                                //連続入力を受け付けないように一定時間処理を止める
                                Invoke("MainDelay", 0.1f);
                        }
                    }
                }
                if (MainQuestionStart == 3){
                    dataText.text = loadText3;
                    if (Input.GetKeyDown(KeyCode.Return)){
                            FileStream f = new FileStream("Assets/text/Answer3.txt", FileMode.Create, FileAccess.Write);
                            BinaryWriter writer = new BinaryWriter(f);
                            writer.Write(inputField.text);
                            writer.Close();
                            inputField.text = "";
                            MainDelayFlg = true;
                            if (MainDelayFlg == true){
                                //遅延ロジック
                                //連続入力を受け付けないように一定時間処理を止める
                                Invoke("MainDelay", 0.1f);
                        }
                    }
                }
                if (MainQuestionStart == 4){
                    dataText.text = loadText4;
                    if (Input.GetKeyDown(KeyCode.Return)){
                            FileStream f = new FileStream("Assets/text/Answer4.txt", FileMode.Create, FileAccess.Write);
                            BinaryWriter writer = new BinaryWriter(f);
                            writer.Write(inputField.text);
                            writer.Close();
                            inputField.text = "";
                            MainDelayFlg = true;
                            if (MainDelayFlg == true){
                                //遅延ロジック
                                //連続入力を受け付けないように一定時間処理を止める
                                Invoke("MainDelay", 0.1f);
                        }
                    }
                }
                if (MainQuestionStart == 5){
                    dataText.text = loadText5;
                    if (Input.GetKeyDown(KeyCode.Return)){
                            FileStream f = new FileStream("Assets/text/Answer5.txt", FileMode.Create, FileAccess.Write);
                            BinaryWriter writer = new BinaryWriter(f);
                            writer.Write(inputField.text);
                            writer.Close();
                            inputField.text = "";
                            MainDelayFlg = true;
                            if (MainDelayFlg == true){
                                //遅延ロジック
                                //連続入力を受け付けないように一定時間処理を止める
                                Invoke("MainDelay", 0.1f);
                        }
                    }
                }
                if (MainQuestionStart == 6){
                    dataText.text = loadText6;
                    if (Input.GetKeyDown(KeyCode.Return)){
                            FileStream f = new FileStream("Assets/text/Answer6.txt", FileMode.Create, FileAccess.Write);
                            BinaryWriter writer = new BinaryWriter(f);
                            writer.Write(inputField.text);
                            writer.Close();
                            inputField.text = "";
                            MainDelayFlg = true;
                            if (MainDelayFlg == true){
                                //遅延ロジック
                                //連続入力を受け付けないように一定時間処理を止める
                                Invoke("MainDelay", 0.1f);
                        }
                    }
                }
                if (MainQuestionStart == 7){
                    dataText.text = loadText7;
                    if (Input.GetKeyDown(KeyCode.Return)){
                            FileStream f = new FileStream("Assets/text/Answer7.txt", FileMode.Create, FileAccess.Write);
                            BinaryWriter writer = new BinaryWriter(f);
                            writer.Write(inputField.text);
                            writer.Close();
                            inputField.text = "";
                            MainDelayFlg = true;
                            if (MainDelayFlg == true){
                                //遅延ロジック
                                //連続入力を受け付けないように一定時間処理を止める
                                Invoke("MainDelay", 0.1f);
                        }
                    }
                }
                if (MainQuestionStart == 8){
                    dataText.text = loadText8;
                    if (Input.GetKeyDown(KeyCode.Return)){
                            FileStream f = new FileStream("Assets/text/Answer8.txt", FileMode.Create, FileAccess.Write);
                            BinaryWriter writer = new BinaryWriter(f);
                            writer.Write(inputField.text);
                            writer.Close();
                            inputField.text = "";
                            MainDelayFlg = true;
                            if (MainDelayFlg == true){
                                //遅延ロジック
                                //連続入力を受け付けないように一定時間処理を止める
                                Invoke("MainDelay", 0.1f);
                        }
                    }
                }
                if (MainQuestionStart == 9){
                    dataText.text = loadText9;
                    if (Input.GetKeyDown(KeyCode.Return)){
                            FileStream f = new FileStream("Assets/text/Answer9.txt", FileMode.Create, FileAccess.Write);
                            BinaryWriter writer = new BinaryWriter(f);
                            writer.Write(inputField.text);
                            writer.Close();
                            inputField.text = "";
                            MainDelayFlg = true;
                            if (MainDelayFlg == true){
                                //遅延ロジック
                                //連続入力を受け付けないように一定時間処理を止める
                                Invoke("MainDelay", 0.1f);
                        }
                    }
                }
                if (MainQuestionStart == 10){
                    dataText.text = loadText10;
                    if (Input.GetKeyDown(KeyCode.Return)){
                            FileStream f = new FileStream("Assets/text/Answer10.txt", FileMode.Create, FileAccess.Write);
                            BinaryWriter writer = new BinaryWriter(f);
                            writer.Write(inputField.text);
                            writer.Close();
                            inputField.text = "";
                            MainDelayFlg = true;
                            if (MainDelayFlg == true){
                                //遅延ロジック
                                //連続入力を受け付けないように一定時間処理を止める
                                Invoke("MainDelay", 0.1f);
                        }
                    }
                }
                if (MainQuestionStart == 11){
                    SceneManager.LoadScene(AppManagementScript.NextScene);
                } 
            //}
        }    
    }

    void MainDelay(){
        MainQuestionStart++;
        MainDelayFlg = false;
    }
}
