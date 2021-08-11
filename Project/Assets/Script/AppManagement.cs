using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class AppManagement : MonoBehaviour {

	public bool Testmonitor = false; //Testmonitorはデバッグ用 ロジックごと削除予定

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
        Debug.Log ( scene.name + " scene loaded"); //デバッグ用ロジック
		if(scene.name == "Title"){
			//AppManagementは維持されるので初期化処理が必要な変数は初期化しておく
			Testmonitor = false; //デバッグ用ロジック
			Debug.Log (Testmonitor); //デバッグ用ロジック
		}
		else{
			Testmonitor = true; //デバッグ用ロジック
			Debug.Log (Testmonitor); //デバッグ用ロジック
		}
    }

	
	// Update is called once per frame
	void Update () {
		//タイトル画面に戻る
		if (Input.GetKey(KeyCode.H)) { //デバッグ用ロジック
			SceneManager.LoadScene ("Title"); //デバッグ用ロジック
		} //デバッグ用ロジック
	}
}
