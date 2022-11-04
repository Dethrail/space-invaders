using UnityEngine;

namespace SpaceInvaders.UI
{
    public class HUDScreen : MonoBehaviour
    {
        [SerializeField] private GameObject Context = null;
        [SerializeField] private MainScreen MainScreen;

        // hide all screens except of main
        public void Awake()
        {
            Context.SetActive(false);
        }

        public void Show()
        {
            Context.SetActive(true);
        }

        public void Hide()
        {
            Context.SetActive(false);
        }

        // Called from ui button
        public void OnAbortGame()
        {
            MainScreen.Show();
            Hide();

            Contexts.sharedInstance.game.isGameAbortSignal = true;
            // Create abort signal (restart)
        }
    }
}