using SpaceInvaders.Game;
using UnityEngine;

namespace SpaceInvaders.UI
{
    // TODO: switch UI to nice and tidy screen/window system with animations and magic :)
    public class MainScreen : MonoBehaviour
    {
        [SerializeField] private GameObject _context = null;
        [SerializeField] private HUDScreen _hudScreen = null;

        // show main screen
        public void Awake()
        {
            _context.SetActive(true);
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
        public void OnPlay()
        {
            var e = Contexts.sharedInstance.game.CreateEntity();
            var lc = new LevelComponent
            {
                Id = "first level"
            };

            e.ReplaceRestartLevel(lc, false);
            e.isDestroyed = true;

            _hudScreen.Show();
            Hide();
        }
    }
}