using System;

namespace unit04_greed.Game.Casting
{
    /// <summary>
    /// <para>An item of cultural or historical interest.</para>
    /// <para>
    /// The responsibility of an Artifact is to provide a message about itself.
    /// </para>
    /// </summary>
    public class Artifact : Actor
    {

        private string artifactType = "";

        /// <summary>
        /// Constructs a new instance of an Artifact.
        /// </summary>
        public Artifact()
        {
            Random random = new Random();
            int x = random.Next(0, 2);
            if(x == 0) {
                artifactType = "gem";
                this.SetText("*");
            } else {
                artifactType = "rock";
                this.SetText("o");
            }
        }


        /// <summary>
        /// Gets the artifact's type.
        /// </summary>
        /// <returns>The type.</returns>
        public string GetArtifactType() {
            return artifactType;
        }


       
    }
}