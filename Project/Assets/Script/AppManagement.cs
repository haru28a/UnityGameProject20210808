using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class AppManagement : MonoBehaviour {

	public int ModeSelectNum = 3; //キーの押下のみで判断しており汎用性が高いとは言えないロジックとなっているため改修したほうが良いかも ※問題ジャンルや難易度追加に対応できない。
	public int LevelSelectNum = 2;
	public string NextScene = "Title";
	public bool QuestionSelectSW = false;
	public bool LevelSelectSW = false;

	// Use this for initialization
	void Start () {
		//遷移したシーンの情報を格納
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void Awake () {
		//AppManagementオブジェクト保持用
		DontDestroyOnLoad(this);
	}

    void OnSceneLoaded( Scene scene, LoadSceneMode mode ) {
		//シーン遷移時に実行
		if(scene.name == "Title"){
			//AppManagementは維持されるので初期化処理が必要な変数は初期化しておく
			QuestionSelectSW = false;
			LevelSelectSW = false;
		}
    }

	
	// Update is called once per frame
	void Update () {
		//タイトル画面に戻る デバッグ用ロジック
		//if (Input.GetKey(KeyCode.H)) {
			//SceneManager.LoadScene ("Title");
		//}
	}
}
