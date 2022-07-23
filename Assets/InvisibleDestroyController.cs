using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleDestroyController : MonoBehaviour
{
    private GameObject unityChan;
    private int objectDestroyMargin = -20;

    // Start is called before the first frame update
    void Start()
    {
        this.unityChan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("uchan-pos " + this.unityChan.transform.position.x + "  " + this.unityChan.transform.position.y + "  " + this.unityChan.transform.position.z);
        //Debug.Log("my-pos " + this.transform.position.x + "  " + this.transform.position.y + "  " + this.transform.position.z);

        //���̂̈ʒu��unity����������i�}�[�W�����݁j�ɂȂ��������
        if (this.unityChan.transform.position.z + objectDestroyMargin > this.transform.position.z)
        {
            Debug.Log("DESTROY " + this.gameObject.name);
            Destroy(this.gameObject);
        }
    }

    /* �����Lesson�͈͊O�Ȃ̂Ńi�V
    void OnBecameInvisible()
    {
        Debug.Log("BecomeInvisible " + gameObject.name);
        Destroy(this.gameObject);
    }
    */
}
