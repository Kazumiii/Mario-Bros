using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    //Cammera will be followed for this 
    public Transform cameraTarget;

    public float cameraSpeed;


    //how far  in direction camera can be
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;

    //method owing to camre will follow
    private void FixedUpdate()
    {
        if(cameraTarget!=null)
        {

            //Lerp allows  move from starting position to terminal position
            var newPos = Vector2.Lerp(transform.position, cameraTarget.position,Time.deltaTime*cameraSpeed);

            //defines camera new position
            var vect3 = new Vector3(newPos.x, newPos.y,-10f);


            //clampX gets cmaera ex position, allows moveing to right 
            var clampX = Mathf.Clamp(vect3.x, minX, maxX);
            //clampY allows camera follow our player  when  he will jump
            var clampY = Mathf.Clamp(vect3.y, minY, maxY);

            transform.position = new Vector3(clampX, clampY, -10f);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
