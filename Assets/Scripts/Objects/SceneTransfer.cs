using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransfer : MonoBehaviour
{
    public Vector2 Position;
    public VectorValue playerPosition;
    public string sceneToLoad;
    public GameObject fadeOut;
    public float fadeTime;

    /*private void Awake()
    {
        GameObject panel = Instantiate(fadeIn, Vector2.zero, Quaternion.identity);
        Destroy(panel, 1f);
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"&&!collision.isTrigger)
        {
            playerPosition.initialValue = Position;
            //SceneManager.LoadScene(sceneToLoad);
            StartCoroutine(FadeCo());
        }
    }

    IEnumerator FadeCo()
    {
        Instantiate(fadeOut, Vector2.zero, Quaternion.identity);
        yield return new WaitForSeconds(fadeTime);
        AsyncOperation fadeOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        if(!fadeOperation.isDone)
        {
            yield return null;
        }
    }

}
