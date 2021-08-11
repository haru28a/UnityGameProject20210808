using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class AppInitial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //イニシャル処理なのでゲーム起動初回時のみの実行
        
        //イニシャル処理実行後タイトルへ遷移
        SceneManager.LoadScene("Title");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
