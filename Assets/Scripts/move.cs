using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class move : MonoBehaviour {

	public float speed=10.0f;
	static public int status=0;
	public float length=10f;
	// Use this for initialization
	public StreamWriter sw;
	public FoveInterfaceBase foveInterface;
    public string name;
    public static float distance;
    public static float angle = 0f;
    public static float eyeAngle = 0f;
    public static Vector3 standardForward;
    public static Vector3 standardEyeForward;
    public static Vector3 standardPosition;
	void Start () {
		sw=File.CreateText("./data/name_"+name+" speed_"+speed.ToString()+" length_"+length.ToString()+".txt");
		status=-1;
    }
	
	// Update is called once per frame
	void Update () {
        distance = transform.parent.position.z - 0.5f;
        if (status != -1 && status!=2&& status != 3 && status != 6 && status != 7 && status != 10 && status != 11 && status != 14 && status != 15 ) {
            angle =Vector3.Angle(foveInterface.transform.forward, standardForward);
            sw.Write(angle);
            sw.Write("\t");
            eyeAngle = Vector3.Angle(foveInterface.GetLeftEyeVector(), standardEyeForward);
            sw.Write(eyeAngle);
            sw.Write("\t");
            sw.Write(angle + eyeAngle);
            sw.Write("\t");
            float l1 = (foveInterface.transform.position - standardPosition).magnitude;
            float l2 = (transform.position - standardPosition).magnitude;
            float l3 = (foveInterface.transform.position - transform.position).magnitude;
            sw.Write(Mathf.Acos((Mathf.Pow(l1, 2f) + Mathf.Pow(l3, 2f) - Mathf.Pow(l2, 2f)) / (2 * l1 * l3)) / 3.1415926 * 180);
            sw.Write("\n");
        }
        if (status == -1 && Input.GetKeyDown(KeyCode.N)) {
            standardForward = foveInterface.transform.forward;
            standardEyeForward = foveInterface.GetLeftEyeVector();
            transform.position = new Vector3(0f, 0f, distance);
            standardPosition = transform.position;
            status++;
        }
        if (status==0){
			transform.position=Vector3.MoveTowards(transform.position,new Vector3(-length,0f,distance),speed*Time.deltaTime);
            if (transform.position.x <= -length)
				status++;
		}
        if (status == 1 && Input.GetKeyDown(KeyCode.N)) {
            status++;
            sw.Write("\n");
        }
        if(status==2){
			transform.position=Vector3.MoveTowards(transform.position,new Vector3(0f,0f, distance),speed*Time.deltaTime);
            if (transform.position.x >= 0) 
                status++;
		}
        if (status == 3 && Input.GetKeyDown(KeyCode.N)) {
            standardForward = foveInterface.transform.forward;
            standardPosition = transform.position;
            standardEyeForward = foveInterface.GetLeftEyeVector();
            status++;
            sw.Write("\n");
        }
        if(status ==4){
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(length, 0f, distance), speed * Time.deltaTime);
            if (transform.position.x >= length)
                status++;
        }
        if (status == 5 && Input.GetKeyDown(KeyCode.N)) {
            status++;
            sw.Write("\n");
        }
        if (status==6){
			transform.position=Vector3.MoveTowards(transform.position,new Vector3(0f,0f, distance),speed*Time.deltaTime);
            if (transform.position.x <= 0) 
                status++;
		}
        if (status == 7 && Input.GetKeyDown(KeyCode.N)) {
            standardForward = foveInterface.transform.forward;
            standardPosition = transform.position;
            standardEyeForward = foveInterface.GetLeftEyeVector();
            status++;
            sw.Write("\n");
        }
        if(status==8){
			transform.position=Vector3.MoveTowards(transform.position,new Vector3(0f,length, distance),speed*Time.deltaTime);
			if(transform.position.y>=length)
				status++;
		}
        if (status == 9 && Input.GetKeyDown(KeyCode.N)) {
            status++;
            sw.Write("\n");
        }
		if(status==10){
			transform.position=Vector3.MoveTowards(transform.position,new Vector3(0f,0f, distance),speed*Time.deltaTime);
            if (transform.position.y <= 0) 
                status++;
		}
        if (status == 11 && Input.GetKeyDown(KeyCode.N)) {
            standardForward = foveInterface.transform.forward;
            standardPosition = transform.position;
            standardEyeForward = foveInterface.GetLeftEyeVector();
            status++;
            sw.Write("\n");
        }
        if(status==12){
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0f, -length, distance), speed * Time.deltaTime);
            if (transform.position.y <= -length)
                status++;
        }
        if (status == 13 && Input.GetKeyDown(KeyCode.N)) {
            status++;
            sw.Write("\n");
        }
        if (status == 14) {
            transform.position=Vector3.MoveTowards(transform.position,new Vector3(0f,0f, distance),speed*Time.deltaTime);
			if(transform.position.y>=0)
				status++;
		}
		if(status==15)
			sw.Dispose();
	}
}
