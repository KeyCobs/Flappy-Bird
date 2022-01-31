using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManager : MonoBehaviour
{
    //GameObject
    public GameObject g_PipeBottom;
    public GameObject g_PipeUpper;

    //static image for pipes

    // Start is called before the first frame update
    void Start()
    {
        
    }

    [SerializeField]
    float g_Speed = 20.0f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
        print("Test");
            SpawPipe();
        }
    }

    #region Deleting Pipes
    private void DeletingPipes()
    {
        
    }
    #endregion
    #region PipeSpawning
    [SerializeField]
    float g_FlySpace = 2.0f;
    [SerializeField]
    float g_minimumPipeHeight = 1.0f;
    [SerializeField]
    float g_PipeSize = 0.5f;
    void SpawPipe()
    {
        SpawnBottomPipes();
        SpawnUpperPipes();
        

        //Destroy(bob)
    }
    private void SpawnUpperPipes()
    {
        //variables
        //CameraSizes
        float cameraHeight = Camera.main.orthographicSize * 2;
        
        //BottomPipe info
        float bottomPipeHeight = g_PipeBottom.transform.localScale.y;

        //Set height
        float pipeUpperHeight = cameraHeight - g_FlySpace - bottomPipeHeight;
        Vector3 pipeHeightVec = new Vector3(g_PipeSize, pipeUpperHeight, 0.0f);
        g_PipeUpper.transform.localScale = pipeHeightVec;

        //upper pipe location
        Point2f upperPipeLocation = new Point2f();
        upperPipeLocation.x = g_PipeBottom.transform.position.x;
        upperPipeLocation.y = (cameraHeight/2) - (pipeUpperHeight / 2);

        //Set location
        Vector3 pipeSpawnLocationVec = new Vector3(upperPipeLocation.x, upperPipeLocation.y, 0.0f);
        g_PipeUpper.transform.position = pipeSpawnLocationVec;

        //SpawnPipe
        Instantiate(g_PipeUpper,pipeSpawnLocationVec,Quaternion.identity);
    }
    private void SpawnBottomPipes()
    {
        //Variables
        //Camera size info
        float cameraHeight = Camera.main.orthographicSize * 2;
        float cameraWidth = cameraHeight * Camera.main.aspect;

        //Camera Random Calculate
        float randomHeight = Random.Range(0.0f, cameraHeight - g_FlySpace - g_minimumPipeHeight);

        //Positioning pipes
        Point2f pipePos = new Point2f();
        pipePos.x = cameraWidth / 2 + g_PipeSize;
        pipePos.y = 0 - (cameraHeight / 2) + (randomHeight / 2);

        //Set location
        Vector3 pipeSpawnPosition = new Vector3(pipePos.x, pipePos.y, 0.0f);
        g_PipeBottom.transform.position = pipeSpawnPosition;

        //Set random height
        Vector3 pipeHeightV = new Vector3(g_PipeSize, randomHeight, 0.0f);
        g_PipeBottom.transform.localScale = pipeHeightV;

        //Testing
        //print("Pipe size: " + g_PipeBottom.transform.localScale.y + ".  CameraWidthPxl: " + cameraWidth + ". flyspace: " + g_FlySpace + ".");

        //Spawning Pipe
        Instantiate(g_PipeBottom, pipeSpawnPosition, Quaternion.identity);
    }
    #endregion

}
    struct Point2f
    {
       public float x,y;
    }

