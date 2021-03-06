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

    public void DisplayItem(OnRequiredItemChangeArgs args)
    {
        _image.sprite = _itemSprites.ToList().FirstOrDefault(x => x.name == (args).type.ToString());
    }
}
