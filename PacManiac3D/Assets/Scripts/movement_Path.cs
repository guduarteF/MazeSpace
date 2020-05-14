using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_Path : MonoBehaviour
{
    //public PathTypes PathType;
    public int movement_Direction = 1;
   // public int movingTo = 0;
    public Transform[] PathSequence;
    public static movement_Path movp;
    


    // Start is called before the first frame update
    void Start()
    {
        movp = this;  
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void OnDrawGizmos()
    {
        if(PathSequence == null || PathSequence.Length < 2)
        {
            return;
        }
        
        for(var i=1; i < PathSequence.Length; i++)
        {
            Gizmos.DrawLine(PathSequence[i - 1].position, PathSequence[i].position);
        }
        //if(PathType == PathTypes.loop)
        //{
        //    Gizmos.DrawLine(PathSequence[0].position, PathSequence[PathSequence.Length - 1].position);
        //}
    }

    
    //public enum PathTypes
    //{
    //    loop,
    //    linear
    //}

    public IEnumerator<Transform> GetNextPathPoint()
    {
        if(PathSequence == null || PathSequence.Length < 1)
        {
            yield break;
        }
        while(true)
        {
           // yield return PathSequence[movingTo];

            if(PathSequence.Length == 1)
            {
                continue;
            }

            //if(PathType == PathTypes.linear)
            //{
            //    if(movingTo <= 0)
            //    {
            //        movement_Direction = 1;
            //    }
            //    else if (movingTo >= PathSequence.Length -1)
            //    {
            //        movement_Direction = -1;
            //    }

            //}
            //movingTo = movingTo + movement_Direction;
            //if(PathType == PathTypes.loop)
            //{
            //    if(movingTo >= PathSequence.Length)
            //    {
            //        movingTo = 0;
            //    }
            //    if(movingTo < 0)
            //    {
            //        movingTo = PathSequence.Length - 1;
            //    }
               
            //}
        }
    }
}
