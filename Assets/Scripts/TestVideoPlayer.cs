using UnityEngine;
using UnityEngine.Video; 
using UnityEngine.SceneManagement;

public class TestVideoPlayer : MonoBehaviour
{   
    [SerializeField]
    public VideoPlayer myVideoPlayer;
    private double currentFrame;
    private double totalFrames;
    // Start is called before the first frame update

    private bool skipButtonClicked = false;
    void Start()
    {      
        //  totalFrames = myVideoPlayer.frameCount;
        //  Debug.Log($"totalFrames:{totalFrames}");
    }

    void OnEnable(){
        totalFrames = myVideoPlayer.frameCount - 1;
        Debug.Log($"totalFrames:{totalFrames}");
    }

    // Update is called once per frame
    void Update()
    {   
        currentFrame = myVideoPlayer.frame;
        //Debug.Log($"currentFrame:{currentFrame}");
        if(currentFrame == totalFrames || skipButtonClicked){
            DoSomethingWhenVideoFinish(this.myVideoPlayer);
        }
    }

    public void SkipVideo(){
        skipButtonClicked = true;
    }

    private void DoSomethingWhenVideoFinish(VideoPlayer vp){
        Debug.Log("video finished");
        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
    }
}
