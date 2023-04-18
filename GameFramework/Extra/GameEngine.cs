using GameFramework.Exceptions;
using GameFramework.worldEntitys;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace GameFramework.Extra
{
    /// <summary>
    /// The engien used to run the game
    /// </summary>
    public static class GameEngine
    {
        private static World? _world;

        /// <summary>
        /// The world of the game
        /// </summary>
        public static World World
        {
            get
            {
                if (_world == null)
                    throw new SingeltonNotInitilised("The World has not been Initilised");
                return _world;
            }
        }


        private static TraceSource? _traceSource;
        /// <summary>
        /// Trace source of the game engien used for tracing
        /// </summary>
        public static TraceSource TraceSource
        {
            get
            {
                if (_traceSource == null)
                    throw new SingeltonNotInitilised("The TraceSource has not been initilised");
                return _traceSource;
            }
        }
        private static int _nextTraceId = 1;
        /// <summary>
        /// Used to get the id of the next trace event
        /// </summary>
        public static int NextTraceId
        {
            get
            {
                return _nextTraceId++;
            }
        }

        /// <summary>
        /// This delegate is called for every game tick. 
        /// </summary>
        public static GameTickDelegate? GameTickAct { get; set; }

        /// <summary>
        /// This delegate is called after <c>GameTickAct</c> to apply damage to creatures
        /// </summary>
        public static GameTickDelegate? GameTickTakeDamage { get; set; }
        /// <summary>
        /// This delegate is called after <c>GameTickAct</c> and damage is removed and is for drawing the world
        /// </summary>
        public static GameTickDelegate? GameTickDraw { get; set; }
        public delegate void GameTickDelegate();

        /// <summary>
        /// Runs the next game tick
        /// </summary>
        public static void TickGame()
        {
            GameTickAct.Invoke();
            GameTickTakeDamage.Invoke();
            GameTickDraw.Invoke();
            Thread.Sleep(100);
            World.WorldEntities.RemoveAll(e => e is DamgeArea);
            GameTickDraw.Invoke();
        }

        /// <summary>
        /// Initilises the GameEgiene
        /// </summary>
        /// <param name="path">The path to a json file to initilise the world size</param>
        /// <param name="initWorld">A func to populate the world</param>
        public static void InitGameEgine(string path, Action initWorld)
        {
            _traceSource = new TraceSource("GameEngien");
            _traceSource.Switch = new SourceSwitch("GameEngien", SourceLevels.All.ToString());
            Trace.AutoFlush = true;

            XmlDocument doc = new();
            doc.Load(path);
            XmlNode node = doc.DocumentElement;
            int maxX = int.Parse(node.SelectSingleNode("maxx").InnerText);
            int maxY = int.Parse(node.SelectSingleNode("maxy").InnerText);
            _world = new World(maxX, maxY);

            initWorld();
        }

    }
}
