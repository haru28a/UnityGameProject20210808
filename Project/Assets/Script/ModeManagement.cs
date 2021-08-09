using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeManagement : MonoBehaviour
{

    public GameObject FullScreen;

    // Start is called before the first frame update
    void Start()
    {
        //Public関数使うために受け側のオブジェクト情報を取得
        FullScreen = GameObject.Find("FullScreen");
    }

    // Update is called once per frame
    void Update()
    {
        //右クリックでモード選択画面へ遷移
        FullScreen.GetComponent<LeftClickMoveMainScene>().MoveSceneMain();
        
        //各難易度の判定ロジックを考える
        //難易度毎にシーンを分けるのか、ステータスを持たせて一つのシーンで切り替えるのか
    }
}
