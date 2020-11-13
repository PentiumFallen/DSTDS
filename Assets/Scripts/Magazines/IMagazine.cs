using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Magazines
{
    interface IMagazine
    {
        void load(Queue<Color> clip);
        bool reload(Color ammo);
        Color shoot();
        Queue<Color> empty();
    }
}
