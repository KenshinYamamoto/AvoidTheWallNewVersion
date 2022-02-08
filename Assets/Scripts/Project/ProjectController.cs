using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// �v���W�F�N�g�S�̂��Ǘ�����

public class ProjectController : MonoBehaviour
{
    public static ProjectController projectController;
    private void Awake()
    {
        if(projectController == null)
        {
            projectController = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SoundManager.soundManager.SearchObject();
    }
}
