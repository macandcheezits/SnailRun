using UnityEngine;

// Reference: This class is modelled after the Ground class from a tutorial 
// youtube url: https://www.youtube.com/watch?v=UPvW8kYqxZk&t=5215s
// author: zigurous 
// accessed: Aug 11 2024
public class GroundScript : MonoBehaviour
{
    // Start is called before the first frame update
    private MeshRenderer meshRenderer;

    private void Awake(){
        //Debug.Log("Awake was called in GroundScript");
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {   
        Debug.Log("Update was called in GroundScript");
        Debug.Log($"GameManager.Instance.gameSpeed: {GameManager.Instance.gameSpeed}" );
        float speed = GameManager.Instance.gameSpeed / transform.localScale.x;
        Debug.Log($"Speed is {speed}");
        Debug.Log($"prev offset = {meshRenderer.material.mainTextureOffset}");
        meshRenderer.material.mainTextureOffset += speed * Time.deltaTime * Vector2.right;
        Debug.Log($"after offset = {meshRenderer.material.mainTextureOffset}");
    }
}
