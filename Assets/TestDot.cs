using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEditor;

[ExecuteInEditMode]
public class TestDot : MonoBehaviour
{
    public TestElement a;
    public TestElement b;

    void Start()
    {
        
    }
    void OnGUI()
    {
   
    }
        
        void Update()
    {
        if (a == null || b == null)
        {
            return;
        }
        Transform aTran = a.transform;
        Transform bTran = b.transform;

        StringBuilder sb = new StringBuilder();

        Vector3 getANor = aTran.position.normalized;
        Vector3 getBNor = bTran.position.normalized;

        aTran.position = getANor * a.distance;
        bTran.position = getBNor * b.distance;

        float rad = Mathf.Acos(Vector3.Dot(aTran.position.normalized , bTran.position.normalized));
        float angle = Mathf.Rad2Deg * rad;

        sb.AppendFormat("arc a*b {0},angel {1} ,a*b {2}", rad, angle,
            Vector3.Dot(aTran.position, bTran.position));

        Debug.Log(sb);
    }


    void OnDrawGizmos()
    {
        if (a == null || b == null)
        {
            return;
        }
        Handles.color = Color.blue;
        Handles.DrawLine(Vector3.zero, a.transform.position);
        GUIStyle gUIStyle = new GUIStyle();
        Handles.Label(a.transform.position, "A", gUIStyle);
        Handles.DrawLine(Vector3.zero, b.transform.position);
        Handles.Label(b.transform.position, "B", gUIStyle);
        float projectLength = Vector3.Dot(a.transform.position, b.transform.position);

       Vector3 aProject = a.transform.position.normalized *
           projectLength;
        Vector3 bProject = b.transform.position.normalized *
            projectLength;
        Handles.Label(aProject, "A·B", gUIStyle);
        Handles.Label(bProject, "B·A", gUIStyle);

        Handles.color = Color.red;
        Handles.DrawLine(Vector3.zero, aProject);
        Handles.color = Color.yellow;
        Handles.DrawLine(Vector3.zero, bProject);
    }
}
