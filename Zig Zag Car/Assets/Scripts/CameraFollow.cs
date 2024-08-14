using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    Vector3 distance;
    public float followSpeed;

    [SerializeField] [Range(0f, 1f)] float lerpTime;    //oyunda ilerledikçe arka plan rengi deðiþmesi için
    [SerializeField] Color[] myColors;
    int colorIndex = 0;
    float change = 0f;
    int len;

    // Start is called before the first frame update
    void Start()
    {
        distance = target.position - transform.position;
        len = myColors.Length;
    }//Start

    // Update is called once per frame
    void Update()
    {
        if(target.position.y >= 0)  // araba düþtüðünde kamera takibi býraksýn
        {
            Follow();
        }
        //oyunda ilerledikçe arka plan rengi deðiþecek
        Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, myColors[colorIndex], lerpTime * Time.deltaTime);
        change = Mathf.Lerp(change, 1f, lerpTime * Time.deltaTime);
        if (change > 0.9f)
        {
            change = 0f;
            colorIndex++; //seçmiþ olduðumuz renkler arasý geçiþ yapacak
            colorIndex = (colorIndex >= len) ? 0 : colorIndex;
        }

    }//Update

    void Follow()
    {
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = target.position - distance;

        transform.position = Vector3.Lerp(currentPosition, targetPosition, followSpeed * Time.deltaTime);   //Kamera hedefi takip edecek
    }
}
