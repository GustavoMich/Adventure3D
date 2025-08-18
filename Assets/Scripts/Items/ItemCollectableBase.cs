using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Itens
{
    public class ItemCollectableBase : MonoBehaviour
    {
        public SFXType sfxType;
        public ItemType itemType;


        public string compareTag = "Player";
        public ParticleSystem myparticleSystem;
        public float timeToHide = 1;
        public GameObject graphicItem;

        public Collider mycollider;

        [Header("Sounds")]
        public AudioSource audioSource;


        private void Awake()
        {
            // if (myparticleSystem != null) myparticleSystem.transform.SetParent(null);
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.transform.CompareTag(compareTag))
            {
                Collect();
            }
        }

        private void PlaySFX()
        {
            SFXPool.Instance.Play(sfxType);
        }

        protected virtual void Collect()
        {
            PlaySFX();
            if (mycollider != null) mycollider.enabled = false;
            if (graphicItem != null) graphicItem.SetActive(false);
            Invoke("HideObject", timeToHide);
            OnCollect();
        }

        private void HideObject()
        {
            gameObject.SetActive(false);

        }


        protected virtual void OnCollect()
        {
            if (myparticleSystem != null) myparticleSystem.Play();
            if (audioSource != null) audioSource.Play();
            ItemManager.Instance.AddByType(itemType);
        }



    }
}
