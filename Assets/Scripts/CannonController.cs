using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public Camera gameCamera;
    public GameObject cannonBase;
    public GameObject bulletPrefab;
    public float bulletForce;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        Vector2 mousePostion = Input.mousePosition;
        Vector3 worldPosition = gameCamera.ScreenToWorldPoint(new Vector3(mousePostion.x,mousePostion.y,transform.position.z - gameCamera.transform.position.z));

        if(worldPosition.x > cannonBase.transform.position.x + 1){
            cannonBase.transform.localEulerAngles = new Vector3(
                cannonBase.transform.localEulerAngles.x,
                cannonBase.transform.localEulerAngles.y,
                Mathf.Atan2((worldPosition.y - cannonBase.transform.position.y),(worldPosition.x - cannonBase.transform.position.x)) * Mathf.Rad2Deg
            );
        }

        if(Input.GetMouseButtonDown(0)){
            GameObject bulletObject = Instantiate(bulletPrefab);
            bulletObject.transform.position = cannonBase.transform.position + cannonBase.transform.right * 1.5f;
            bulletObject.GetComponent<Rigidbody>().AddForce(cannonBase.transform.right * bulletForce);
        }

    }
}
