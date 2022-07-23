using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;
    //スタート地点
    private int startPos = 80;
    //ゴール地点
    private int goalPos = 360;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    private GameObject unityChan; //unityちゃん
    public int itemGenerationDistanceMaximum = 20; // アイテムを生成する距離最大（unityちゃんから）
    public int itemGenerationDistanceInterval = 15; // アイテムを生成する間隔
    public int lastGeneratePosition = 40;　// 最後にアイテムを生成した位置。スタート直後の空白を兼ねる

    // Use this for initialization
    void Start()
    {
        unityChan = GameObject.Find("unitychan");
       // lastGeneratePosition = 50;
    }

    // Update is called once per frame
    void Update()
    {
        //最後に生成したアイテムとunityちゃんまでの距離に応じて新規アイテムを生成する。ゴールより向こうにはおかない
        if ((unityChan.transform.position.z + itemGenerationDistanceMaximum > lastGeneratePosition) & (unityChan.transform.position.z + itemGenerationDistanceMaximum + +itemGenerationDistanceInterval < goalPos))
        {
        
            int i = lastGeneratePosition + itemGenerationDistanceInterval;  //元プログラムの変数iを流用したい
            lastGeneratePosition += itemGenerationDistanceInterval;　//最後アイテムの位置を更新する

            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                }
            }
            else
            {

                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置:30%車配置:10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                    }
                }
            }
        }
    }
}