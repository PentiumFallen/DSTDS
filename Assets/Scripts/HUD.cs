using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    class HUD : MonoBehaviour
    {
        public Image QAmag;
        public Image[] QAshot;
        public Image Stackmag;
        public Image[] Stackshot;
        private int mode = 1;

        private void Start()
        {
            QAmag.GetComponent<Image>().color = Color.white;
            for (int i = 0; i < QAshot.Length; i++)
            {
                QAshot[i].GetComponent<Image>().color = Color.clear;
            }
            Stackmag.GetComponent<Image>().color = Color.clear;
            for (int i = 0; i < Stackshot.Length; i++)
            {
                Stackshot[i].GetComponent<Image>().color = Color.clear;
            }
        }

        private void Update()
        {
            
        }

        public void Qreload(Color color)
        {
            if (QAshot[0].GetComponent<Image>().color.Equals(Color.clear))
            {
                for (int i = 1; i < QAshot.Length; i++)
                {
                    if (!QAshot[i].GetComponent<Image>().color.Equals(Color.clear))
                    {
                        QAshot[i - 1].GetComponent<Image>().color = color;
                        return;
                    }
                }
                QAshot[4].GetComponent<Image>().color = color;
            }
            Update();
        }

        public void QShoot()
        {
            // Queue
            if (mode == 1)
            {
                Color next = QAshot[0].GetComponent<Image>().color;
                QAshot[0].GetComponent<Image>().color = Color.clear;
                for (int i = 1; i < QAshot.Length; i++)
                {
                    Color temp = QAshot[i].GetComponent<Image>().color;
                    QAshot[i].GetComponent<Image>().color = next;
                    next = temp;
                }
            }
            else if (mode == 2)
            {

            }
        }
    }
}
