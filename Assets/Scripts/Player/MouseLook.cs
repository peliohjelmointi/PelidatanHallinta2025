using UnityEngine;

namespace KS
{
    public class MouseLook : MonoBehaviour
    {
        GameObject player;


        [SerializeField] float minClamp = -45f; //rajoitetaan p��n yl�s/alas liikkumista
        [SerializeField] float maxClamp = 45f;

        Vector2 rotation;
        Vector2 currentLookRotation;
        Vector2 rotationVelocity = new Vector2(0, 0);

        [SerializeField] float lookSensitivy = 2.0f; // k��ntymisnopeuden s��t�'
        [SerializeField] float lookSmoothDamp = 0.1f; // tasataan yl�s/alas p��nk��nt��

        private void Awake()
        {
            player = transform.parent.gameObject;
        }

        private void Update()
        {
            rotation.y += Input.GetAxis("Mouse Y") * lookSensitivy;

            //rajoitetaan p��n liikkuminen minClamp ja maxClamp-arvojen mukaan
            rotation.y = Mathf.Clamp(rotation.y, minClamp, maxClamp);

            //k��nnet��n pelihahmoa paikallaan hiiren x-arvon mukaisesti
            player.transform.RotateAround(transform.position, Vector3.up, Input.GetAxis("Mouse X") * lookSensitivy);

            //tasataan nykyinen(current) y-rotaatio yl�s/alas p��nk��nt��n
            currentLookRotation.y = Mathf.SmoothDamp(currentLookRotation.y, rotation.y, ref rotationVelocity.y, lookSmoothDamp);

            //transform = kamera, jossa skripti kiinni
            //p�ivitet��n kameran x-rotaatio vastaamaan hiirell� annettuja liikkumisarvoja
            transform.localEulerAngles = new Vector3(-currentLookRotation.y, 0, 0);
        }
    }

}