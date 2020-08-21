using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_KeyHolder : MonoBehaviour
{
    [SerializeField] private KeyHolder keyHolder;

    public Transform container;
    private Transform keyTemplate;

    private void Awake()
    {
        keyTemplate = container.Find("KeyFrame");
        keyTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        keyHolder.OnKeysChanged += KeyHolder_OnKeysChanged;
    }

    private void KeyHolder_OnKeysChanged(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        //Clean up old keys
        foreach (Transform child in container)
        {
            if (child == keyTemplate) continue;
            {
                Destroy(child.gameObject);
            }
        }

        //Instantiate current key list
        List<KeyScript.KeyType> keyList = keyHolder.GetKeyList();
        for (int i = 0; i < keyList.Count; i++)
        {
            KeyScript.KeyType keyType = keyList[i];
            Transform keyTransform = Instantiate(keyTemplate, container);
            keyTemplate.gameObject.SetActive(true);
            keyTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(50 * 1, 0);
            Image keyImage = keyTransform.Find("Image").GetComponent<Image>();
            switch (keyType)
            {
                default:
                case KeyScript.KeyType.Red: keyImage.color = Color.red; break;
                case KeyScript.KeyType.Green: keyImage.color = Color.red; break;
                case KeyScript.KeyType.Blue: keyImage.color = Color.red; break;
                
            }
        }
    } 
}
