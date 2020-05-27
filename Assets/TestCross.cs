using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEditor;

[ExecuteInEditMode]
public class TestCross : MonoBehaviour
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

        sb.AppendFormat("corss ab {0},corss ba {1}",
            Vector3.Cross(aTran.position, bTran.position), Vector3.Cross(bTran.position, aTran.position));

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
        Handles.Label(a.transform.position, "A",gUIStyle);
        Handles.DrawLine(Vector3.zero, b.transform.position);
        Handles.Label(b.transform.position, "B", gUIStyle);

        Vector3 aVec =a.transform.position;
        Vector3 bVec = b.transform.position;
        Vector3 ab = Vector3.Cross(aVec, bVec);
        Vector3 ba = Vector3.Cross(bVec, aVec);

        Handles.Label(ab, "AxB", gUIStyle);
        Handles.Label(ba, "BxA", gUIStyle);

        Handles.color = Color.red;
        Handles.DrawLine(Vector3.zero, ab);
        Handles.color = Color.yellow;
        Handles.DrawLine(Vector3.zero, ba);
    }
}
