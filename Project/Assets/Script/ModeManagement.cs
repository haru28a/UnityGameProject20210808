using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeManagement : MonoBehaviour {

    GameObject Easy;
    GameObject Normal;
    GameObject Hard;
    GameObject Japanese;
    GameObject Society;
    GameObject Science;
    GameObject English;
    GameObject Mix;
    Renderer RenderObjEasy;
    Renderer RenderObjNormal;
    Renderer RenderObjHard;
    Renderer RenderObjJapanese;
    Renderer RenderObjSociety;
    Renderer RenderObjScience;
    Renderer RenderObjEnglish;
    Renderer RenderObjMix;
    GameObject AppManagement;
    AppManagement AppManagementScript;

    // Start is called before the first frame update
    void Start()
    {
        //Public関数、変数を使うために受け側のオブジェクト情報を取得
        AppManagement = GameObject.Find("AppManagement");
        Easy = GameObject.Find("Easy");
        Normal = GameObject.Find("Normal");
        Hard = GameObject.Find("Hard");
        Japanese = GameObject.Find("Japanese");
        Society = GameObject.Find("Society");
        Science = GameObject.Find("Science");
        English = GameObject.Find("English");
        Mix = GameObject.Find("Mix");

        //受け側のオブジェクトにアタッチされたScript情報を取得
        AppManagementScript = AppManagement.GetComponent<AppManagement>();

        //オブジェクトの表示、非表示を切り替えるため受け側のオブジェクトにアタッチされたRenderer情報を取得
        RenderObjEasy = Easy.GetComponent<Renderer>();
        RenderObjNormal = Normal.GetComponent<Renderer>();
        RenderObjHard = Hard.GetComponent<Renderer>();
        RenderObjJapanese = Japanese.GetComponent<Renderer>();
        RenderObjSociety = Society.GetComponent<Renderer>();
        RenderObjScience = Science.GetComponent<Renderer>();
        RenderObjEnglish = English.GetComponent<Renderer>();
        RenderObjMix = Mix.GetComponent<Renderer>();

        //次LoadSceneされたときのシーン遷移先情報を格納
        AppManagementScript.NextScene = "Main";

        //Modeシーン読み込み初回タイミングでは問題ジャンル選択は表示しておく
        RenderObjJapanese.enabled = true;
        RenderObjSociety.enabled = true;
        RenderObjScience.enabled = true;
        RenderObjEnglish.enabled = true;
        RenderObjMix.enabled = true;

        //問題ジャンル選択ロジックはModeシーン読み込み初回タイミングで有効にしておく
        AppManagementScript.QuestionSelectSW = true;

        //Modeシーン読み込み初回タイミングでは難易度選択は非表示にする
        RenderObjEasy.enabled = false;
        RenderObjNormal.enabled = false;
        RenderObjHard.enabled = false;

        //Rendererだけ非表示にしてもロジックは生きてるので難易度選択ロジックも無効にしておく
        AppManagementScript.LevelSelectSW = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(AppManagementScript.QuestionSelectSW == true){
            //マウス想定の操作になってるのでキーボード操作想定のロジックに作り直し※積み残し
            Japanese.GetComponent<LeftClickMoveScene>().LevelSelect();
            Society.GetComponent<LeftClickMoveScene>().LevelSelect();
            Science.GetComponent<LeftClickMoveScene>().LevelSelect();
            English.GetComponent<LeftClickMoveScene>().LevelSelect();
            Mix.GetComponent<LeftClickMoveScene>().LevelSelect();
            //各問題ジャンル判定ロジックを考える※積み残し
        }

        if(AppManagementScript.LevelSelectSW == true){
            //問題が選択されたら問題ジャンル選択は非表示にしておく
            RenderObjJapanese.enabled = false;
            RenderObjSociety.enabled = false;
            RenderObjScience.enabled = false;
            RenderObjEnglish.enabled = false;
            RenderObjMix.enabled = false;
            //難易度選択を表示にする
            RenderObjEasy.enabled = true;
            RenderObjNormal.enabled = true;
            RenderObjHard.enabled = true;
            //左クリックでメイン画面へ遷移
            //マウス想定の操作になってるのでキーボード操作想定のロジックに作り直し※積み残し
            Easy.GetComponent<LeftClickMoveScene>().MoveScene();
            Normal.GetComponent<LeftClickMoveScene>().MoveScene();
            Hard.GetComponent<LeftClickMoveScene>().MoveScene();
        }
        //各難易度の判定ロジックを考える※積み残し
        //難易度毎にシーンを分けるのか、ステータスを持たせて一つのシーンで切り替えるのか
    }
}
