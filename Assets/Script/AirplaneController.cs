using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    [Header("Thông số bay")]
    public float forwardSpeed = 20f; // Tốc độ bay tới (luôn cố định)
    public float verticalSpeed = 10f; // Tốc độ bay lên/xuống
    public float pitchAmount = 25f;   // Góc chúc mũi máy bay (chỉ để tạo hình ảnh)

    private bool isTakeOff = false;
    private float startY;

    void Start()
    {
        // Lưu lại độ cao ban đầu
        startY = transform.position.y;

        // Cấu hình Rigidbody để không bị trọng lực kéo rớt
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
            rb.isKinematic = true; // Tắt vật lý, dùng Transform để di chuyển
        }
    }

    void Update()
    {
        // 1. Luôn bay về phía trước theo trục Z của thế giới (Space.World)
        // Dù mũi máy bay có chúc lên hay xuống, nó vẫn bay thẳng tới trước
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime, Space.World);

        // 2. Điều khiển lên/xuống bằng phím W/S hoặc Mũi tên
        float moveVertical = Input.GetAxis("Vertical");

        if (moveVertical != 0)
        {
            // Di chuyển máy bay lên/xuống theo trục Y của thế giới
            transform.Translate(Vector3.up * moveVertical * verticalSpeed * Time.deltaTime, Space.World);

            // Xoay mũi máy bay để tạo cảm giác đang bay lên/xuống (chỉ là hình ảnh)
            // Nếu bấm W (đi lên), mũi chúc lên (góc X âm). Nếu bấm S, mũi chúc xuống (góc X dương).
            float targetPitch = -moveVertical * pitchAmount;
            transform.rotation = Quaternion.Euler(targetPitch, 0, 0);
        }
        else
        {
            // Trở về trạng thái cân bằng khi không bấm gì
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        // 3. Kiểm tra xem máy bay đã cất cánh chưa (Dựa vào độ cao Y so với lúc đầu)
        if (transform.position.y > startY + 1.0f)
        {
            isTakeOff = true;
        }
    }

    // Hàm này để PopupManager gọi kiểm tra
    public bool HasTakenOff()
    {
        return isTakeOff;
    }
}