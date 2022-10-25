
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool domovement = true;
    public float panspeed = 30f;

    public float panBorderThickness = 10f;
    // Update is called once per frame
    void Update()
    
    {
        if (Input.GetKeyDown(KeyCode.Escape))//escye basınca camera duruyor.
        {
            domovement = !domovement;
        }
        if (!domovement)
        {return;
            
        }
        if (Input.GetKey("w")|| Input.mousePosition.y >=Screen.height -panBorderThickness)//between ten and zero but from top
        {
           transform.Translate(Vector3.forward*panspeed*Time.deltaTime,Space.World); 
        }

        if (Input.GetKey("s")|| Input.mousePosition.y <=Screen.height -panBorderThickness)//between zero and ten but from bottom
        {
            transform.Translate(Vector3.back*panspeed*Time.deltaTime,Space.World); 
        }
        if (Input.GetKey("d")|| Input.mousePosition.x >=Screen.width -panBorderThickness)
        {
            transform.Translate(Vector3.right*panspeed*Time.deltaTime,Space.World); 
        }
        if (Input.GetKey("a")|| Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left*panspeed*Time.deltaTime,Space.World);
            
        }
        
        
    }
}
