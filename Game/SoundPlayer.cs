using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Game
{
    public class SoundPlayer
    {
        /// <summary>
        ///  Menu
        /// </summary>

        public void PlayMenuMusic()
        {
            MediaPlayer playMedia = new MediaPlayer();
            var uri = new Uri("pack://siteoforigin:,,,/Sound/awesomeness.wav");
            playMedia.Open(uri);
            playMedia.Play();
        }

        public void MenuButtonClick()
        {
            MediaPlayer playMedia = new MediaPlayer();
            var uri = new Uri("pack://siteoforigin:,,,/Sound/awesomeness.wav");
            playMedia.Open(uri);
            playMedia.Play();
        }


        /// <summary>
        /// Player
        /// </summary>

        public void PlayWalkingSound()
        {
            MediaPlayer playMedia = new MediaPlayer();
            var uri = new Uri("pack://siteoforigin:,,,/Sound/awesomeness.wav");
            playMedia.Open(uri);
            playMedia.Play();
        }

        public void PlayerHurt()
        {
            MediaPlayer playMedia = new MediaPlayer();
            var uri = new Uri("pack://siteoforigin:,,,/Sound/awesomeness.wav");
            playMedia.Open(uri);
            playMedia.Play();
        }

        public void OpenChest()
        {
            MediaPlayer playMedia = new MediaPlayer();
            var uri = new Uri("pack://siteoforigin:,,,/Sound/awesomeness.wav");
            playMedia.Open(uri);
            playMedia.Play();
        }

        public void PickedUpItem()
        {
            MediaPlayer playMedia = new MediaPlayer();
            var uri = new Uri("pack://siteoforigin:,,,/Sound/awesomeness.wav");
            playMedia.Open(uri);
            playMedia.Play();
        }

        public void PlayerNormalAttackSound()
        {
            MediaPlayer playMedia = new MediaPlayer();
            var uri = new Uri("pack://siteoforigin:,,,/Sound/awesomeness.wav");
            playMedia.Open(uri);
            playMedia.Play();
        }

        public void PlayerStrongAttackSound()
        {
            MediaPlayer playMedia = new MediaPlayer();
            var uri = new Uri("pack://siteoforigin:,,,/Sound/awesomeness.wav");
            playMedia.Open(uri);
            playMedia.Play();
        }

        public void ShootBullets()
        {
            MediaPlayer playMedia = new MediaPlayer();
            var uri = new Uri("pack://siteoforigin:,,,/Sound/awesomeness.wav");
            playMedia.Open(uri);
            playMedia.Play();
        }

        public void PlayerDeath()
        {
            MediaPlayer playMedia = new MediaPlayer();
            var uri = new Uri("pack://siteoforigin:,,,/Sound/awesomeness.wav");
            playMedia.Open(uri);
            playMedia.Play();
        }



        public void EnemyHurt()
        {
            MediaPlayer playMedia = new MediaPlayer();
            var uri = new Uri("pack://siteoforigin:,,,/Sound/awesomeness.wav");
            playMedia.Open(uri);
            playMedia.Play();
        }

        public void EnemyAttack()
        {
            MediaPlayer playMedia = new MediaPlayer();
            var uri = new Uri("pack://siteoforigin:,,,/Sound/awesomeness.wav");
            playMedia.Open(uri);
            playMedia.Play();
        }
    }
}
