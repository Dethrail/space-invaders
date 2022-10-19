using UnityEngine;

namespace SpaceInvaders.UI
{
    public class HUDScreen : MonoBehaviour
    {
        [SerializeField] private GameObject _context = null;
        [SerializeField] private MainScreen _mainScreen;

        // hide all screens except of main
        public void Awake()
        {
            _context.SetActive(false);
        }

        public void Show()
        {
            _context.SetActive(true);
        }

        public void Hide()
        {
            _context.SetActive(false);
        }

        // Called from ui button
        public void OnAbortGame()
        {
            _mainScreen.Show();
            Hide();
            
            // Create abort signal (restart)
        }
    }
}