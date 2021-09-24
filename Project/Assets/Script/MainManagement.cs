using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MainManagement : MonoBehaviour {

    GameObject MainInitialGUI;
    GameObject QuestionGUI;
    GameObject AppManagement;
    GameObject AnswerGUI;
    GameObject EnterGUI;
    AppManagement AppManagementScript;
    private int MainQuestionStart = 0;
    public InputField inputField;
    //　読み込んだテキストを出力するUIテキスト
	[SerializeField]
	private Text dataText;
	//　読む込むテキストが書き込まれている.txtファイル
	[SerializeField]
	private TextAsset textAsset1;
    [SerializeField]
    private TextAsset textAsset2;
	//　テキストファイルから読み込んだデータ
	private string loadText1;
    private string loadText2;

    // Start is called before the first frame update
    void Start() {
        //読み込んだテキストを格納する
        loadText1 = textAsset1.text;
        loadText2 = textAsset2.text;

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
    }

    // Update is called once per frame
    void Update() {
        Debug.Log(inputField.text);
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
        if (MainQuestionStart == 1/* && AppManagementScript.ModeSelectNum == 2 && AppManagementScript.LevelSelectNum == 1*/){
            dataText.text = loadText1;
            if (Input.GetKeyDown(KeyCode.Return)){
                FileStream f = new FileStream("Assets/text/Answer1.txt", FileMode.Create, FileAccess.Write);
                BinaryWriter writer = new BinaryWriter(f);
                writer.Write(inputField.text);
                writer.Close();
                inputField.text = "";
                MainQuestionStart++;
            }
        }
        //仮 2問目以降のロジック未実装 現状は表示のみ切り替え ※積み残し
        if (MainQuestionStart == 2){
            dataText.text = loadText2;
        }
    }
}
