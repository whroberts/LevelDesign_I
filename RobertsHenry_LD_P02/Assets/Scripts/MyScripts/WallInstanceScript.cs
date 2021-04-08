using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class WallInstanceScript : MonoBehaviour
    {
        [SerializeField] float _speed = 0.01f;

        Vector2 _start;
        Vector2 _finish;

        float _startTime;
        float _length;

        private void Start()
        {
            _start = new Vector2(this.gameObject.transform.position.x, 4.1f);
            _finish = new Vector2(this.gameObject.transform.position.x, -3f);

            _startTime = Time.time;
            _length = Vector2.Distance(_start, _finish);
        }

        public void MoveWall()
        {
            print("MOVING");
            float distCovered = (Time.time - _startTime) * _speed;
            float fractionOfJourney = distCovered / _length;
            this.gameObject.transform.position = Vector2.Lerp(_start, _finish, fractionOfJourney);
        }
    }
}
