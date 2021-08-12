using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugScript_AppSceneJump : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Init処理を走らせる デバッグ用ロジック
        //正式版ビルド前にはロジックごと削除かロジックをコメントアウト
		if (Input.GetKey(KeyCode.F3)) {
			SceneManager.LoadScene ("AppManagement");
		}
    }
}
