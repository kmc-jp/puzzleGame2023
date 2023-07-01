using System.Collections;
using System.Collections.Generic;
using UnityEditor.AssetImporters;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class UIinkMnager : MonoBehaviour
{
    //画像格納
    public Sprite ink0;
    public Sprite ink1;
    public Sprite ink2;
    public Sprite ink3;
    public Sprite ink4;
    public Sprite ink5;
    public Sprite ink6;
    public Sprite ink7;
    public Sprite ink8;
    public Sprite ink9;
    public Sprite ink10;
    public Sprite ink11;
    public Sprite ink12;
    public Sprite ink13;
    public Sprite ink14;
    public Sprite ink15;
    public Sprite ink16;
    public Sprite ink17;
    public Sprite ink18;
    public Sprite ink19;
    public Sprite ink20;

    public Sprite[] sprites = new Sprite[21];

    //imge読み込み用
    private Image image;

    //Cubeのスクリプト取得用
    private GameObject Object;
    GM script;

    //CubeのinkLeftを受け取る変数
    public double inkLeft;

    //CubeのinkAmountを受け取る変数
    public double inkAmount;
    //インク総量を20等分
    public double inkUnit;


    // Start is called before the first frame update
    void Start()
    {
        //imageを読み込み
        image = GetComponent<Image>();      

        //spritesに画像を格納
        //脳筋すぎるので誰かスマートな方法あったら教えて
        sprites[0] = ink0;
        sprites[1] = ink1;
        sprites[2] = ink2;
        sprites[3] = ink3;
        sprites[4] = ink4;
        sprites[5] = ink5;
        sprites[6] = ink6;
        sprites[7] = ink7;
        sprites[8] = ink8;
        sprites[9] = ink9;
        sprites[10] = ink10;
        sprites[11] = ink11;
        sprites[12] = ink12;
        sprites[13] = ink13;
        sprites[14] = ink14;
        sprites[15] = ink15;
        sprites[16] = ink16;
        sprites[17] = ink17;
        sprites[18] = ink18;
        sprites[19] = ink19;
        sprites[20] = ink20;
}

    // Update is called once per frame
    void Update()
    {
        //CubeのスクリプトGMからインク総量を取得
        //この方法はバグを起こしやすいので変えた方がいいかもしれない
        Object = GameObject.Find("Cube");
        script = Object.GetComponent<GM>();
        inkAmount = script.inkAmount;

        //inkUnitを初期化
        inkUnit = inkAmount / 20;

        //CubeのスクリプトGMからインク残量を取得
        //この方法はバグを起こしやすいので変えた方がいいかもしれない
        Object = GameObject.Find("Cube");
        script = Object.GetComponent<GM>();
        inkLeft = script.inkLeft;

        Debug.Log("inkUnit="+inkUnit);
        Debug.Log("inkAmount=" + inkAmount);
        for (int i = 20; i >= 0; i--)
        {
            Debug.Log(i);
            Debug.Log(inkLeft >= i * inkUnit);
            if(inkLeft >= i * inkUnit)
            {
                image.sprite = sprites[i];
                break;
            }
        }
    }
}