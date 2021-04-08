using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class BackWall : MonoBehaviour
    {
        Vector2 _start;
        Vector2 _finish;

        float _speed = 1f;
        float _raiseSpeed = 1.5f;
        float _length;

        private void Start()
        {
            _start = new Vector2(this.gameObject.transform.position.x, 0f);
            _finish = new Vector2(this.gameObject.transform.position.x, -3f);

            _length = Vector2.Distance(_start, _finish);
        }

        public void LowerBackWall(float startTime)
        {
            float distCovered = (Time.time - startTime) * _speed;
            float fractionOfJourney = distCovered / _length;
            this.gameObject.transform.position = Vector2.Lerp(_start, _finish, fractionOfJourney);
        }

        public void RaiseBackWall(float startTime)
        {
            float distCovered = (Time.time - startTime) * _raiseSpeed;
            float fractionOfJourney = distCovered / _length;
            this.gameObject.transform.position = Vector2.Lerp(_finish, _start, fractionOfJourney);
        }
    }
}
