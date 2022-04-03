using System;

namespace Assets.Scripts.Utilities
{
    public interface GameEventArgs
    { }

    public class OnHealthUpdateArgs : GameEventArgs
    {
        /// <summary>
        /// The Health of the patient in percent.
        /// 0.0f to 1.0f
        /// </summary>
        public float value;
    }

    public class OnGameOverArgs : GameEventArgs
    {
        /// <summary>
        /// The Final Score.
        /// The Time the player survived.
        /// The Number of correct Items.
        /// The Number of wrong Items.
        /// </summary>
        public int score;
        public TimeSpan timeSurvived;
        public int correctItems;
        public int wrongItems;
    }

    public class OnItemCollectArgs : GameEventArgs
    {
        /// <summary>
        /// The Item that was collected.
        /// </summary>
        public Item.ItemType type;
    }

    public class OnRequiredItemChangeArgs : GameEventArgs
    {
        /// <summary>
        /// The Item that is required.
        /// </summary>
        public Item.ItemType type;
    }

    public class OnSpawnRateUpdateArgs : GameEventArgs
    {
        /// <summary>
        /// The new spawn rate.
        /// </summary>
        public float newSpawnRate;
    }
}