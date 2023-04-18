using GameFramework.worldEntitys;

namespace GameFramework.Extra
{
    /// <summary>
    /// The world of the game
    /// </summary>
    public class World
    {
        /// <summary>
        /// The world of the game
        /// </summary>
        /// <param name="maxX">The max x cordinate</param>
        /// <param name="maxY">The max y cordinate</param>
        public World(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
            WorldEntities = new List<IWorldEntity>();
        }

        /// <summary>
        /// The max x cordinate
        /// </summary>
        public int MaxX { get; set; }

        /// <summary>
        /// The max y cordinate
        /// </summary>
        public int MaxY { get; set; }

        /// <summary>
        /// A list of all creatures and world objects
        /// </summary>
        public List<IWorldEntity> WorldEntities { get; set; }


    }
}