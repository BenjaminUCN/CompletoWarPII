using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersBoundaries : MonoBehaviour
{
    [SerializeField] private float width = 16f;
    [SerializeField] private float height = 10f;
    [SerializeField] private float stroke = 0.1f;
    [SerializeField] private Transform[] targets;

    [SerializeField] private string boundarieLayerName;
    
    // Start is called before the first frame update
    void Start()
    {
        CreateBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 avg = Vector3.zero;
        foreach(Transform target in targets){
            avg += target.position;
        }
        avg /= targets.Length;

        transform.position = avg;
    }

    public Vector2 GetSize(){
        return new Vector2(width,height);
    }

    void CreateBoundaries(){
        float x = width/2;
        float y = height/2;
        float w = width;
        float h = height;
        float s = stroke;
        CreateBoundary( 0, y,w,s,"a");
        CreateBoundary(-x, 0,s,h,"b");
        CreateBoundary( 0,-y,w,s,"c");
        CreateBoundary( x, 0,s,h,"d");
    }

    void CreateBoundary(float x,float y,float w,float h,string name){
        GameObject boundary = new GameObject("Boundary "+name);
        boundary.layer = LayerMask.NameToLayer(boundarieLayerName);
        boundary.transform.SetParent(transform);
        boundary.transform.localPosition = Vector3.zero;

        BoxCollider2D collider = boundary.AddComponent<BoxCollider2D>();
        collider.size = new Vector2(w,h);
        collider.offset = new Vector2(x,y);



    }

#if UNITY_EDITOR
    void OnDrawGizmos(){
        Vector3 pos = transform.position;

        Gizmos.color = Color.yellow;

        DrawCenteredRect(pos.x,pos.y,width,height);
        
        Gizmos.color = Color.green;
        DrawCenteredRect(pos.x,pos.y,width-stroke,height-stroke);
        DrawCenteredRect(pos.x,pos.y,width+stroke,height+stroke);
    }

    void DrawCenteredRect(float x,float y,float w,float h){
        w/=2; h/=2;
        Vector3 a = new Vector3( x - w, y - h, 0);
        Vector3 b = new Vector3( x - w, y + h, 0);
        Vector3 c = new Vector3( x + w, y + h, 0);
        Vector3 d = new Vector3( x + w, y - h, 0);
        Gizmos.DrawLine(a,b);
        Gizmos.DrawLine(b,c);
        Gizmos.DrawLine(c,d);
        Gizmos.DrawLine(d,a);
    }
#endif
}
