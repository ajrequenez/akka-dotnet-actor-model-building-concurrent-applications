using Akka.Actor;
using MovieStreaming.Messages;

namespace MovieStreaming.Actors
{
    internal class PlaybackActor : ReceiveActor
    {
        public PlaybackActor()
        {
            ColorConsole.WriteLineGreen("Playback Actor Created");

            Context.ActorOf(PlaybackStatisticsActor.Props(), "PlaybackStatistics");
            Context.ActorOf(UserCoordinatorActor.Props(), "UserCoordinator");
            //Receive<PlayMovieMessage>(HandlePlayMovieMessage);
        }

        private void HandlePlayMovieMessage(PlayMovieMessage message)
        {
            ColorConsole.WriteLineYellow(
                string.Format("Playing movie '{0}' for user: {1}", message.MovieTitle, message.UserId));
        }

        #region Lifecycle Hooks
        protected override void PreStart()
        {
            ColorConsole.WriteLineGreen("Playback Actor Prestart");
        }

        protected override void PostStop()
        {
            ColorConsole.WriteLineGreen("Playback Actor PostStop");
        }

        protected override void PreRestart(Exception reason, object message)
        {
            ColorConsole.WriteLineGreen(
                string.Format("Playback Actor PreRestart because: {0}", reason));
            base.PreRestart(reason, message);
        }
        protected override void PostRestart(Exception reason)
        {
            ColorConsole.WriteLineGreen(
                string.Format("Playback Actor PostRestart because: {0}", reason));
            base.PostRestart(reason);
        }
        #endregion
        public static Props Props() => Akka.Actor.Props.Create(() => new PlaybackActor());
    }
}
