using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    // Hàm cho nút Restart
    public void RestartGame()
    {
        // Load lại Scene hiện tại
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f; // Reset thời gian nếu đã dừng ở bước trước
    }

    // Hàm cho nút Enter/Continue
    public void GoToNextScene()
    {
        // Chuyển sang Scene tiếp theo
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}