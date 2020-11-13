using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Magazines
{
    class StackMagazine : IMagazine
    {
        private Stack<Color> mag;
        private HUD hud;

        public StackMagazine()
        {
            mag = new Stack<Color>();
            hud = GameObject.FindGameObjectWithTag("Player").GetComponent<HUD>();
        }

        public Queue<Color> empty()
        {
            Queue<Color> clip = new Queue<Color>();
            for (int i = 0; i < mag.Count; i++)
            {
                clip.Enqueue(mag.Pop());
            }
            return clip;
        }

        public void load(Queue<Color> clip)
        {
            for (int i = 0; i < clip.Count; i++)
            {
                mag.Push(clip.Dequeue());
            }
        }

        public bool reload(Color ammo)
        {
            mag.Push(ammo);
            return true;
        }

        public Color shoot()
        {
            if (mag.Count != 0)
                return mag.Pop();
            return Color.clear;

        }
    }
}
