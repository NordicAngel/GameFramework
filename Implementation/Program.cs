using GameFramework.Item.Items;
using GameFramework.worldEntitys;
using Implementation;
using Implementation.Creatures;
using Implementation.WorldObjects;
using GameFramework.Extra;

const string worldXMLPath = @"C:\Users\User\OneDrive\Zealand\ASWC\GameFramework\World.xml";

GameEngine.InitGameEgine(worldXMLPath, EngineHandeler.InitWorld);
GameEngine.GameTickDraw += EngineHandeler.DrawWorld;
while (true)
{
	GameEngine.TickGame();
}


