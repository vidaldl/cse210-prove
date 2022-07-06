using System;
using System.Collections.Generic;
using unit04_greed.Game.Casting;
using unit04_greed.Game.Services;


namespace unit04_greed.Game.Directing
{
    /// <summary>
    /// <para>A person who directs the game.</para>
    /// <para>
    /// The responsibility of a Director is to control the sequence of play.
    /// </para>
    /// </summary>
    public class Director
    {
        private KeyboardService keyboardService = null;
        private VideoService videoService = null;

        private int moveYCount = 0;

        private int score = 0;

        /// <summary>
        /// Constructs a new instance of Director using the given KeyboardService and VideoService.
        /// </summary>
        /// <param name="keyboardService">The given KeyboardService.</param>
        /// <param name="videoService">The given VideoService.</param>
        public Director(KeyboardService keyboardService, VideoService videoService)
        {
            this.keyboardService = keyboardService;
            this.videoService = videoService;
        }

         /// <summary>
        /// Generates new artifacts and adds them as actors to the cast
        /// </summary>
        /// <param name="cast">The given cast.</param>

         public Cast GenArtifacts(Cast cast) {
            Random random = new Random();
            for (int i = 0; i < 20; i++)
            {


                int x = random.Next(1, 60);
                int y = random.Next(1, 14);

                
                // Sets position outside the viewport.
                Point position = new Point(x, y);              
                position = position.Scale(15);
                Point newPosition = new Point(position.GetX(), position.GetY() * -1);

                int r = random.Next(0, 256);
                int g = random.Next(0, 256);
                int b = random.Next(0, 256);
                Color color = new Color(r, g, b);

                Artifact artifact = new Artifact();
                // artifact.SetText(text);
                artifact.SetFontSize(20);
                artifact.SetColor(color);
                artifact.SetPosition(newPosition);
                cast.AddActor("artifacts", artifact);
            }
            
            return cast;

        }

        /// <summary>
        /// Starts the game by running the main game loop for the given cast.
        /// </summary>
        /// <param name="cast">The given cast.</param>

        
        public void StartGame(Cast cast)
        {   
           
            videoService.OpenWindow();
            while (videoService.IsWindowOpen())
            {
                    // banner.SetText(moveYCount.ToString());
                
                if(moveYCount == 5) {
                    cast = GenArtifacts(cast);
                }
                GetInputs(cast);
                DoUpdates(cast);
                DoOutputs(cast);
                if(moveYCount == 200) {
                    moveYCount = 0;

                }
            }
            videoService.CloseWindow();
        }

        /// <summary>
        /// Gets directional input from the keyboard and applies it to the robot.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void GetInputs(Cast cast)
        {
            Actor robot = cast.GetFirstActor("robot");
            Point velocity = keyboardService.GetDirection();
            robot.SetVelocity(velocity);     
        }

        /// <summary>
        /// Updates the robot's position and resolves any collisions with artifacts.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void DoUpdates(Cast cast)
        {
            Actor banner = cast.GetFirstActor("banner");
            Actor robot = cast.GetFirstActor("robot");
            List<Actor> artifacts = cast.GetActors("artifacts");
            banner.SetText("Score: " + score);

            
            int maxX = videoService.GetWidth();
            int maxY = videoService.GetHeight();
            robot.MoveNext(maxX, maxY);

            

            foreach (Actor actor in artifacts)
            {
                // Moves the artifacts down 1px per frame.
                Point currPosition = actor.GetPosition();
                Point newPoint = new Point(currPosition.GetX(), currPosition.GetY() + 1);
                actor.SetPosition(newPoint);
                

                if (robot.GetPosition().Equals(actor.GetPosition()))
                {
                    // Updates the score
                    banner.SetText("Score: " + score);
                    Artifact artifact = (Artifact) actor;

                    // gets the type of artifact and programs a response once the player gets near it.
                    string artType = artifact.GetArtifactType();
                    if(artType == "gem") {
                        score += 10;
                        cast.RemoveActor("artifacts", actor);
                    }
                    else if(artType == "rock") {
                        score -= 10;
                        cast.RemoveActor("artifacts", actor);

                    }
                    
                }

            } 
            moveYCount++;
        }

        /// <summary>
        /// Draws the actors on the screen.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void DoOutputs(Cast cast)
        {
            List<Actor> actors = cast.GetAllActors();
            videoService.ClearBuffer();
            videoService.DrawActors(actors);
            videoService.FlushBuffer();
        }

    }
}