using UnityEngine;

namespace Ursaanimation.CubicFarmAnimals
{
    public class AnimationController : MonoBehaviour
    {
        public Animator animator;
        
        public string walkForwardAnimation = "walk_forward";
        public string walkBackwardAnimation = "walk_backwards";
        public string runForwardAnimation = "run_forward";
        public string turn90LAnimation = "turn_90_L";
        public string turn90RAnimation = "turn_90_R";
        public string trotAnimation = "trot_forward";
        public string sittostandAnimation = "sit_to_stand";
        public string standtositAnimation = "stand_to_sit";
        private float speed;
        private int shouldAnimalMove;

        void Start()
        {
            shouldAnimalMove = 0;
            animator = GetComponent<Animator>();
            speed = NextFloat(1f, 12f);
            animator.Play("stand_to_sit");
        }

        void Update()
        {
        
            if (shouldAnimalMove == 1) 
            {
                animator.Play(walkForwardAnimation);
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
            }
            
        }
        void OnTriggerEnter(Collider col)
        {
            if (col.tag == "Player")
            {
                shouldAnimalMove = 1;
                animator.Play("sit_to_stand");
            }

        }

        static float NextFloat(float min, float max)
        {
            System.Random random = new System.Random();
            double val = (random.NextDouble() * (max - min) + min);
            return (float)val;
        }
    }
}
