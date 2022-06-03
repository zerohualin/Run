using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDemos: MonoBehaviour
{
    public int instances;
    public Mesh mesh;
    public Material[] mats;
    private List<List<Matrix4x4>> batches = new List<List<Matrix4x4>>();

    public GameObject Obj;

    // Start is called before the first frame update
    void Start()
    {
        // int addedMatricies = 0;
        // for (int i = 0; i < instances; i++)
        // {
        //     if (addedMatricies < 1000 && this.batches.Count != 0)
        //     {
        //         var randomPos = new Vector3(Random.Range(-10.0f, 10.0f), 0.0f, Random.Range(-10.0f, 10.0f));
        //         this.batches[this.batches.Count - 1].Add(Matrix4x4.TRS(randomPos, Quaternion.Euler(Vector3.zero), Vector3.one));
        //         addedMatricies += 1;
        //     }
        //     else
        //     {
        //         this.batches.Add(new List<Matrix4x4>());
        //         addedMatricies = 0;
        //     }
        // }


        for (int i = 0; i < instances; i++)
        {
            var obj = GameObject.Instantiate(Obj);
            obj.transform.localScale = Vector3.one * Random.Range(0.6f, 1);
            obj.transform.localPosition = new Vector3(Random.Range(-10.0f, 10), 0, Random.Range(-10.0f, 10));
        }
        
    }

    private void RenderBatches()
    {
        foreach (var batch in batches)
        {
            for (int i = 0; i < mesh.subMeshCount; i++)
            {
                Graphics.DrawMeshInstanced(mesh, i, this.mats[i], batch);
            }
        }
    }

    private void Update()
    {
        // RenderBatches();
    }
}