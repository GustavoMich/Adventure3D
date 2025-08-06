using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ebac.Core.Singleton;

public class CheckpointManager : Singleton<CheckpointManager>
{
    public int lastCheckPointKey = 0;

    public List<CheckpointBase> checkpoints;

    [Header("UI Checkpoint")]
    public Text checkpointText;

    public float textDuration = 3f; 

    private Coroutine textCoroutine;

    private void Start()
    {
        if (checkpointText != null)
            checkpointText.gameObject.SetActive(false);
    }



    public bool HasCheckpoint()
    {
        return lastCheckPointKey > 0;
    }


    public void SaveCheckPoint(int i)
    {
        if(i > lastCheckPointKey)
        {
            lastCheckPointKey = i;
            ShowCheckpointText();
        }
    }

    public Vector3 GetPositionLastCheck()
    {
       var checkpoint = checkpoints.Find(i => i.key == lastCheckPointKey);
        return checkpoint.transform.position;
    }


    private void ShowCheckpointText()
    {
        if (checkpointText == null) return;

        
        if (textCoroutine != null)
            StopCoroutine(textCoroutine);

        checkpointText.gameObject.SetActive(true);

        textCoroutine = StartCoroutine(HideCheckpointText());
    }

    private IEnumerator HideCheckpointText()
    {
        yield return new WaitForSeconds(textDuration);
        checkpointText.gameObject.SetActive(false);
    }
}
