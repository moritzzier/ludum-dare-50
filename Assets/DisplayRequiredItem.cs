using Assets.Scripts.Utilities;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DisplayRequiredItem : MonoBehaviour
{
    Image _image;
    [SerializeField] Sprite[] _itemSprites;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void DisplayItem(GameEventArgs args)
    {
        if (!_image.IsActive()) _image.gameObject.SetActive(true);
        _image.sprite = _itemSprites.ToList().FirstOrDefault(x => x.name == ((OnRequiredItemChangedArgs)args).type.ToString());
    }
}
