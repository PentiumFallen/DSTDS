using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Magazines
{
    class QueueMagazine : IMagazine
    {
        private Queue<Color> mag;
        private HUD hud;

        public QueueMagazine()
        {
            mag = new Queue<Color>(5);
            hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        }

        public Queue<Color> empty()
        {
            return mag;
        }

        public void load(Queue<Color> clip)
        {
            while(clip.Count != 0)
            {
                mag.Enqueue(clip.Dequeue());
            }
        }

        public bool reload(Color ammo)
        {
            if (mag.Count < 5)
            {
                hud.Qreload(ammo);
                mag.Enqueue(ammo);
                return true;
            }
            return false;
        }

        public Color shoot()
        {
            if (mag.Count > 0)
            { 
                hud.QShoot();
                return mag.Dequeue();
            }
            else 
            {
                return Color.clear;
            }
        }
    }
}
