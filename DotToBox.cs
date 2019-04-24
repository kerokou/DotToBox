using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotToBox : MonoBehaviour {

    [SerializeField, Range(0, 1)]
    private float alphaThreshold = 0.0f;
    [SerializeField]
    private Texture2D targetTexture;

	// Use this for initialization
	void Start () {

       //get texture
        Texture2D mainTexture = targetTexture;
        
        //initial position
        Vector3 currentPosition = new Vector3(0, 0, 0);

        for (int currentHeight=0; currentHeight < mainTexture.height; currentHeight++) {
            //renew position
            currentPosition.z = currentHeight;
            for (int currentWidth = 0; currentWidth < mainTexture.width; currentWidth++) {
                //renew position
                currentPosition.x = currentWidth;

                //ignore transparent dot
                if (mainTexture.GetPixel(currentWidth, currentHeight).a > alphaThreshold) {
                    //make cube
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    //move it
                    cube.transform.Translate(currentPosition);
                    //get color from pixel and paint
                    cube.GetComponent<Renderer>().material.color = mainTexture.GetPixel(currentWidth, currentHeight);
                    //Debug.Log(mainTexture.GetPixel(currentWidth, currentHeight));
                }
                

            }

        }
        
    }

    // Update is called once per frame
    void Update () {
		
	}
}
