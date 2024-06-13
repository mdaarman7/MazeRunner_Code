using UnityEngine;
public class BackGroundColorChange : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    private PlayerMovementScript player;
    private Color newColor = new Color(1f, 1f, 1f, 1f);
    void Start()
    {
        player = FindObjectOfType<PlayerMovementScript>();
    }
    void Update()
    {
        if (player != null && player.playerPos == player.nextlevel)
            ChangeColor();
    }
    public void ChangeColor()
    {
        newColor = HexToColor("CE43D2");
        spriteRenderer.color = newColor;
    }
    Color HexToColor(string hex)
    {
        // Remove any "#" prefix and convert hexadecimal string to Color
        Color color = new Color();
        if (ColorUtility.TryParseHtmlString("#" + hex, out color))
        {
            return color;
        }
        else
        {
            return Color.white; // Default color if parsing fails
        }
    }
}