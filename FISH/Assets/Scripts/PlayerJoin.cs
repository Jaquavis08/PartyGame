using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerJoin : MonoBehaviour
{
    public int playerNumber;
    public GameObject image;
    public Color[] playerColors;

    private void Awake()
    {
        PlayerInput player = GetComponent<PlayerInput>();

        playerNumber = player.playerIndex + 1;

        GameObject canvasObj = GameObject.Find("Canvas");
        if (canvasObj == null)
        {
            Debug.LogWarning("Canvas not found in scene. Falling back to localPosition placement.");
            // Keep legacy behavior as a fallback
            transform.SetParent(null);
            transform.localPosition = new Vector2(UnityEngine.Random.Range(730f, 1341f), UnityEngine.Random.Range(594f, 893f));
        }
        else
        {
            // Parent to canvas without changing local transforms
            transform.SetParent(canvasObj.transform, false);

            RectTransform canvasRect = canvasObj.GetComponent<RectTransform>();
            // Prefer this GameObject's RectTransform; otherwise use the image's RectTransform
            RectTransform rt = GetComponent<RectTransform>() ?? (image != null ? image.GetComponent<RectTransform>() : null);

            Vector2 elementSize = rt != null ? rt.rect.size : Vector2.zero;
            float padding = 10f;

            float canvasWidth = canvasRect != null ? canvasRect.rect.width : Screen.width;
            float canvasHeight = canvasRect != null ? canvasRect.rect.height : Screen.height;

            float halfW = canvasWidth * 0.5f;
            float halfH = canvasHeight * 0.5f;

            float minX = -halfW + elementSize.x * 0.5f + padding;
            float maxX = halfW - elementSize.x * 0.5f - padding;
            float minY = -halfH + elementSize.y * 0.5f + padding;
            float maxY = halfH - elementSize.y * 0.5f - padding;

            // If element size is unknown, use canvas bounds with padding
            if (elementSize == Vector2.zero)
            {
                minX = -halfW + padding;
                maxX = halfW - padding;
                minY = -halfH + padding;
                maxY = halfH - padding;
            }

            // Ensure ranges are valid
            if (minX > maxX) { float mid = (minX + maxX) * 0.5f; minX = maxX = mid; }
            if (minY > maxY) { float mid = (minY + maxY) * 0.5f; minY = maxY = mid; }

            Vector2 randomAnchored = new Vector2(UnityEngine.Random.Range(minX, maxX), UnityEngine.Random.Range(minY, maxY));

            if (rt != null)
                rt.anchoredPosition = randomAnchored;
            else
                transform.localPosition = randomAnchored;
        }

        switch (playerNumber)
        {
            case 1:
                image.GetComponent<UnityEngine.UI.Image>().color = playerColors[0];
                break;
            case 2:
                image.GetComponent<UnityEngine.UI.Image>().color = playerColors[1];
                break;
            case 3:
                image.GetComponent<UnityEngine.UI.Image>().color = playerColors[2];
                break;
            case 4:
                image.GetComponent<UnityEngine.UI.Image>().color = playerColors[3];
                break;
        }

        image.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            SceneManager.LoadScene("SampleScene"); DontDestroyOnLoad(gameObject);
        }
    }
}
