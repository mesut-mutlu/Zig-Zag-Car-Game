using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject platformBlast;
    public GameObject diamond, star;
    // Start is called before the first frame update
    void Start()
    {
        int randNumber = Random.Range(1, 51);
        Vector3 tempPos = transform.position;
        tempPos.y += 1.2f;
        if(randNumber<4)
        {
            Instantiate(star, tempPos, star.transform.rotation);
        }

        if(randNumber == 7)
        {
            Instantiate(diamond, tempPos, diamond.transform.rotation);
        }

    }//Start

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("FallDown", 0.2f);   //0.2 saniye gecikme ile düþecekler
            //FallDown();
        }
    }//OnCollisionExit

    void FallDown()
    {
        Instantiate(platformBlast, transform.position, Quaternion.identity);    //düþen kutulara efekt ayarladýk
        GetComponent<Rigidbody>().isKinematic = false;  //yerçekimini devredýþý býrakacak
        Destroy(gameObject, 0.5f);   // 0.5 saniye sonra arkandaki platform düþecek
    }


}
