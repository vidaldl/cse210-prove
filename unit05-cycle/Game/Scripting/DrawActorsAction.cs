using System.Collections.Generic;
using unit05_cycle.Game.Casting;
using unit05_cycle.Game.Services;


namespace unit05_cycle.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawActorsAction : Action
    {
        private VideoService videoService;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public DrawActorsAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            // Snake 1
            Snake snake = (Snake)cast.GetFirstActor("snake");
            List<Actor> segments = snake.GetSegments();
            Actor score = cast.GetFirstActor("score");
            
            List<Actor> messages = cast.GetActors("messages");
            // Snake 2
            Snake snake2 = (Snake)cast.GetFirstActor("snake2");
            List<Actor> segments2 = snake2.GetSegments();
            Actor score2 = cast.GetFirstActor("score2");
            
            List<Actor> messages2 = cast.GetActors("messages2");
            
            videoService.ClearBuffer();
            // Snake 1
            videoService.DrawActors(segments);
            videoService.DrawActor(score);
            
            videoService.DrawActors(messages);
            // Snake 2
            videoService.DrawActors(segments2);
            videoService.DrawActor(score2);

            videoService.DrawActors(messages2);
            videoService.FlushBuffer();

            
        }
    }
}