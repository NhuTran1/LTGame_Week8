using UnityEngine;
using TMPro; // Bắt buộc để dùng TextMeshPro
using UnityEngine.SceneManagement; // Bắt buộc để chuyển Scene

public class PopupManager : MonoBehaviour
{
    [Header("UI References")]
    public GameObject popupPanel; // Kéo PopupMenu vào đây
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI messageText;
    public TextMeshProUGUI restartButtonText;
    public TextMeshProUGUI enterButtonText;

    public AirplaneController airplane; // Kéo object Airplane vào đây trong Inspector
    // private bool hasTakenOff = false;

    void Start()
    {
        // Yêu cầu: Load nội dung text từ code
        titleText.text = "Welcome to Unity!";
        messageText.text = "Do you want continue?";
        restartButtonText.text = "Restart";
        enterButtonText.text = "Enter";
        
        // Đảm bảo popup ẩn lúc đầu
        popupPanel.SetActive(false);
    }

    // void Update()
    // {
    //     // Giả sử logic "cất cánh" là khi máy bay đạt độ cao Y > 5 (bạn có thể thay bằng logic riêng của bạn)
    //     if (transform.position.y > 5f) 
    //     {
    //         hasTakenOff = true;
    //     }
    // }

    // Yêu cầu: Chỉ hiện Popup khi máy bay đã cất cánh và va chạm với Enter Wall
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Đã va chạm với: " + other.name); // Xem máy bay đâm vào cái gì

        if (other.CompareTag("EnterWall")) 
        {
            Debug.Log("Đã nhận diện đúng tường EnterWall!");
            
            if (airplane == null) 
            {
                Debug.LogError("LỖI: Ô Airplane trong Inspector đang bị trống!");
            }
            else if (!airplane.HasTakenOff()) 
            {
                Debug.Log("Máy bay chưa cất cánh nên không hiện Menu.");
            }
            else 
            {
                Debug.Log("Đã cất cánh! Đang hiện Menu...");
                popupPanel.SetActive(true);
                airplane.enabled = false; 
                airplane.GetComponent<Rigidbody>().isKinematic = true; 
            }
        }
    }

}