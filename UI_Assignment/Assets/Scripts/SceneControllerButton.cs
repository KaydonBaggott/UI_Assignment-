using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SceneControllerButton : MonoBehaviour
{
    enum TargetScene
    {
        Shop,
        Backpack
    }

    [SerializeField] TargetScene targetScene;
    Button button;

    // Start is called before the first frame update
    void Start()
    {
     button = GetComponent<Button>();
        
        button.onClick.RemoveAllListeners();
        switch (targetScene)
        {
            case TargetScene.Shop:
                button.onClick.AddListener(() => SceneController.LoadShopScene());
                break;

            case TargetScene.Backpack:
                button.onClick.AddListener(() => SceneController.LoadNextScene());
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
